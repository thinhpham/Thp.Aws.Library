using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Thp.Har.Utility;
using Amazon;
using Amazon.S3.Transfer;
using Amazon.S3.Model;

namespace AwsController {
    public enum TaskLocationType {
        LocalSystem,
        S3
    }

    public enum TaskObjectType {
        Bucket,
        Drive,
        File,
        Folder
    }

    public enum TaskAction {
        Copy,
        Delete,
        Move
    }

    public enum TaskStatus {
        Queued,
        Running,
        Done,
        Cancelling,
        Cancelled
    }

    public class TaskObject {
        public string Server { get; set; }
        public RegionEndpoint Region { get; set; }
        public S3StorageClass StorageClass { get; set; }
        public string Path { get; set; }
        public TaskLocationType LocationType { get; set; }
        public TaskObjectType ObjectType { get; set; }
        public object Tag { get; set; }
    }

    public delegate void QueueTaskStarted(QueueTask item);
    public delegate void QueueTaskCompleted(QueueTask item, bool isSuccess);

    public class QueueTask {
        private const int S3_TRANSFER_TIMEOUT = 1000000;

        public event QueueTaskStarted TaskStarted;
        public event QueueTaskCompleted TaskCompleted;
        public bool IsStarted { get; private set; }

        public RegionEndpoint SelectedRegion { get; set; }
        public string Id { get; set; }
        public TaskObject Source { get; set; }
        public TaskObject Destination { get; set; }
        public TaskAction Action { get; set; }
        public TaskStatus Status { get; set; }
        public string Progress { get; set; }

        public void Execute() {
            var result = true;
            IsStarted = true;

            if (TaskStarted != null) {
                TaskStarted(this);
            }

            ExecuteS3CopyMoveDelete();

            if (TaskCompleted != null) {
                TaskCompleted(this, result);
            }
        }

        private void ExecuteS3CopyMoveDelete() {
            Status = TaskStatus.Running;
            object request = null;
            
            if (Action == TaskAction.Copy) {
                // First setup the download/upload request
                if (Source.LocationType == TaskLocationType.LocalSystem) {
                    if (Destination.ObjectType == TaskObjectType.Bucket) {
                        Destination.Path = Destination.Path.TrimEnd(AmazonS3Utility.BUCKET_SUFFIX_CHAR) + AmazonS3Utility.BUCKET_SUFFIX_STRING;
                    }

                    var bucketName = GetBucketName(Destination.Path);

                    // 1. If the object is right under the bucket, keyPrefix should be the object name
                    // 2. Else it should be the name of the folder
                    var keyPrefix = GetKeyPrefix(Destination.Path);
                    if (string.IsNullOrEmpty(keyPrefix)) {
                        keyPrefix = new DirectoryInfo(Source.Path).Name;
                    }

                    if (Source.ObjectType == TaskObjectType.Folder || Source.ObjectType == TaskObjectType.Drive) {
                        request = new TransferUtilityUploadDirectoryRequest()
                            .WithTimeout(S3_TRANSFER_TIMEOUT)
                            .WithBucketName(bucketName)
                            .WithKeyPrefix(keyPrefix)
                            .WithStorageClass(Destination.StorageClass)
                            .WithDirectory(Source.Path)
                            .WithSearchOption(SearchOption.AllDirectories)
                            .WithSubscriber((s, e) => {
                                Progress = string.Format("Copying {0} of {1} file(s)", e.NumberOfFilesUploaded, e.TotalNumberOfFiles);
                            });
                    } else if (Source.ObjectType == TaskObjectType.File) {
                        keyPrefix += ((FileInfo)Source.Tag).Name;
                        request = new TransferUtilityUploadRequest()
                            .WithTimeout(S3_TRANSFER_TIMEOUT)
                            .WithBucketName(bucketName)
                            .WithKey(keyPrefix)
                            .WithStorageClass(Destination.StorageClass)
                            .WithFilePath(Source.Path)
                            .WithSubscriber((s, e) => {
                                Progress = string.Format("{0}% done", e.PercentDone);
                            });
                    }
                } else if (Source.LocationType == TaskLocationType.S3) {
                    if (Source.ObjectType == TaskObjectType.Bucket) {
                        Source.Path = Source.Path.TrimEnd(AmazonS3Utility.BUCKET_SUFFIX_CHAR) + AmazonS3Utility.BUCKET_SUFFIX_STRING;
                    }
                    var bucketName = GetBucketName(Source.Path);
                    var keyPrefix = GetKeyPrefix(Source.Path);

                    if (Source.ObjectType == TaskObjectType.Bucket || Source.ObjectType == TaskObjectType.Folder) {
                        request = new TransferUtilityDownloadDirectoryRequest()
                            .WithTimeout(S3_TRANSFER_TIMEOUT)
                            .WithBucketName(GetBucketName(Source.Path))
                            .WithS3Directory(GetKeyPrefix(Source.Path))
                            .WithLocalDirectory(Destination.Path)
                            .WithSubscriber((s, e) => {
                                Progress = e.CurrentFile;
                            });
                    } else if (Source.ObjectType == TaskObjectType.File) {
                        request = new TransferUtilityDownloadRequest()
                            .WithTimeout(S3_TRANSFER_TIMEOUT)
                            .WithBucketName(GetBucketName(Source.Path))
                            .WithKey(GetKeyPrefix(Source.Path))
                            .WithFilePath(Destination.Path)
                            .WithSubscriber((s, e) => {
                                Progress = e.PercentDone.ToString();
                            });
                    }
                }


                // Then create the transfer utility to do the actual transfer
                using (var client = AmazonS3Utility.GetClient(SelectedRegion)) {
                    using (var transferUtility = new Amazon.S3.Transfer.TransferUtility(client)) {
                        if (Source.LocationType == TaskLocationType.LocalSystem) {
                            if (Source.ObjectType == TaskObjectType.Folder || Source.ObjectType == TaskObjectType.Drive) {
                                transferUtility.UploadDirectory((TransferUtilityUploadDirectoryRequest)request);
                            } else if (Source.ObjectType == TaskObjectType.File) {
                                transferUtility.Upload((TransferUtilityUploadRequest)request);
                            }
                        } else if (Source.LocationType == TaskLocationType.S3) {
                            if (Source.ObjectType == TaskObjectType.Bucket || Source.ObjectType == TaskObjectType.Folder) {
                                transferUtility.DownloadDirectory((TransferUtilityDownloadDirectoryRequest)request);
                            } else if (Source.ObjectType == TaskObjectType.Folder) {
                                transferUtility.Download((TransferUtilityDownloadRequest)request);
                            }
                        }
                    }
                }
            } else if (Action == TaskAction.Delete) {
                var client = AmazonS3Utility.GetClient(SelectedRegion);
                request = new DeleteObjectsRequest()
                    .WithBucketName("")
                    .WithKeys(new KeyVersion(""))
                    .WithQuiet(true);
                client.DeleteObjects((DeleteObjectsRequest)request);
            }

            Status = TaskStatus.Done;
        }

        private string GetBucketName(string value) {
            if (value.IndexOf(AmazonS3Utility.BUCKET_SUFFIX_STRING) > -1) {
                return value.Substring(0, value.IndexOf(AmazonS3Utility.BUCKET_SUFFIX_STRING));
            } else {
                return string.Empty;
            }
        }

        private string GetKeyPrefix(string value) {
            if (value.IndexOf(AmazonS3Utility.BUCKET_SUFFIX_STRING) > -1) {
                return value.Substring(value.IndexOf(AmazonS3Utility.BUCKET_SUFFIX_STRING) + 1);
            } else {
                return value;
            }
        }
    }
}
