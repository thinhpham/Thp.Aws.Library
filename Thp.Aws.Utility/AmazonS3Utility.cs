using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.IO;

namespace Thp.Har.Utility {
    public class AmazonS3Utility {
        public const string BUCKET_SUFFIX_STRING = ":";
        public const char BUCKET_SUFFIX_CHAR = ':';
        public static char[] BUCKET_SUFFIX_ARRAY = new char[] { BUCKET_SUFFIX_CHAR };

        public const string FOLDER_SUFFIX_STRING = "/";
        public const char FOLDER_SUFFIX_CHAR = '/';
        public static char[] FOLDER_SUFFIX_ARRAY = new char[] { FOLDER_SUFFIX_CHAR };

        public const int MAX_ENUMERATION_KEYS = 1000;
        public const int MAX_ITEMS_PER_DELETION = 1000;

        public static AmazonS3 GetClient() {
            return GetClient(null, null);
        }

        public static AmazonS3 GetClient(RegionEndpoint region) {
            return GetClient(null, region);
        }

        public static AmazonS3 GetClient(string serviceUrl, RegionEndpoint region) {
            var config = new AmazonS3Config();

            if (!string.IsNullOrEmpty(serviceUrl)) {
                config.ServiceURL = serviceUrl;
            }

            if (region != null) {
                config.RegionEndpoint = region;
            }

            return AWSClientFactory.CreateAmazonS3Client(CacheObject.Settings.AWSAccessKey, CacheObject.Settings.AWSSecretKey, config);
        }

        public static List<Tag> CreateTag(string key, string value) {
            var list = new List<Tag>();
            var tag = new Tag().WithKey(key).WithValue(value);
            list.Add(tag);
            return list;
        }

        public static ListBucketsResponse ListBuckets(RegionEndpoint region) {
            using (var client = GetClient(region)) {
                using (var response = client.ListBuckets()) {
                    return response;
                }
            }
        }

        public static ListObjectsResponse ListObjects(RegionEndpoint region, string bucket, string prefix, string delimiter, int maxKeys) {
            using (var client = GetClient(region)) {
                var request = new ListObjectsRequest();
                request.BucketName = bucket;
                request.Delimiter = delimiter;
                request.Prefix = prefix;

                if (maxKeys > -1) {
                    request.MaxKeys = maxKeys;
                }
                
                return client.ListObjects(request);
            }
        }

        public static PutBucketResponse AddBucket(RegionEndpoint region, string bucket) {
            using (var client = GetClient(region)) {
                var request = new PutBucketRequest()
                    .WithBucketName(bucket)
                    .WithUseClientRegion(true);

                return client.PutBucket((PutBucketRequest)request);
            }
        }

        public static List<DeleteBucketResponse> DeleteBuckets(RegionEndpoint region, params string[] buckets) {
            using (var client = AmazonS3Utility.GetClient(region)) {
                var list = new List<DeleteBucketResponse>();

                foreach (var bucket in buckets) {
                    var request = new DeleteBucketRequest().WithBucketName(bucket);
                    var result = client.DeleteBucket((DeleteBucketRequest)request);
                    list.Add(result);
                }

                return list;
            }
        }

        public static PutObjectResponse AddFolder(RegionEndpoint region, string bucket, string key) {
            using (var client = AmazonS3Utility.GetClient(region)) {
                key = key.TrimEnd(FOLDER_SUFFIX_ARRAY) + FOLDER_SUFFIX_STRING;

                var request = new PutObjectRequest()
                    .WithBucketName(bucket)
                    .WithContentType("application/octet-stream")
                    .WithContentBody("")
                    .WithKey(key);
                return client.PutObject((PutObjectRequest)request);
            }
        }

        public static List<DeleteObjectsResponse> DeleteObjects(RegionEndpoint region, string bucket, string currentContainer, params string[] deleteItems) {
            var list = new List<KeyVersion>(deleteItems.Length);

            foreach (var deleteItem in deleteItems) {
                if (deleteItem.EndsWith(FOLDER_SUFFIX_STRING)) {
                    GetObjectsForDeletion(region, bucket, currentContainer, list, deleteItem);
                } else {
                    if (!string.IsNullOrEmpty(currentContainer)) {
                        list.Add(new KeyVersion(currentContainer + deleteItem));
                    } else {
                        list.Add(new KeyVersion(deleteItem));
                    }
                }
            }


            var responses = new List<DeleteObjectsResponse>();

            if (list.Count > MAX_ITEMS_PER_DELETION) {
                int currentRowIndex = 0;

                while (currentRowIndex < list.Count) {
                    var maxRowToDelete = list.Count - currentRowIndex;
                    if (maxRowToDelete > MAX_ITEMS_PER_DELETION) {
                        maxRowToDelete = MAX_ITEMS_PER_DELETION;
                    }
                    
                    var rowsToDelete = new KeyVersion[maxRowToDelete];
                    list.CopyTo(currentRowIndex, rowsToDelete, 0, maxRowToDelete);

                    using (var client = AmazonS3Utility.GetClient(region)) {
                        var request = new DeleteObjectsRequest()
                            .WithBucketName(bucket)
                            .WithKeys(rowsToDelete);
                        var result = client.DeleteObjects((DeleteObjectsRequest)request);
                        responses.Add(result);
                    }

                    currentRowIndex += maxRowToDelete;
                }
            } else {
                using (var client = AmazonS3Utility.GetClient(region)) {
                    var request = new DeleteObjectsRequest()
                        .WithBucketName(bucket)
                        .WithKeys(list.ToArray());
                    var result = client.DeleteObjects((DeleteObjectsRequest)request);
                    responses.Add(result);
                }
            }

            return responses;
        }

        public static void GetObjectsForDeletion(RegionEndpoint endpoint, string bucket, string currentContainer, List<KeyVersion> list, string deleteItem) {
            if (deleteItem.EndsWith(FOLDER_SUFFIX_STRING)) {
                var response = AmazonS3Utility.ListObjects(endpoint, bucket, deleteItem, FOLDER_SUFFIX_STRING, MAX_ENUMERATION_KEYS);

                if (response.CommonPrefixes.Count > 0) {
                    // Folders
                    foreach (var item in response.CommonPrefixes) {
                        string text = null;

                        if (response.Prefix != null) {
                            if (item.EndsWith(FOLDER_SUFFIX_STRING)) {
                                text = item;
                            } else {
                                text = item.Substring(response.Prefix.Length);
                            }
                        } else {
                            text = item;
                        }

                        if (text.EndsWith(FOLDER_SUFFIX_STRING)) {
                            GetObjectsForDeletion(endpoint, bucket, currentContainer, list, text);
                        }
                    }

                    // Files
                    foreach (var item in response.S3Objects) {
                        if (!item.Key.Equals(response.Prefix)) {
                            var text = item.Key;
                            if (!string.IsNullOrEmpty(currentContainer)) {
                                list.Add(new KeyVersion(currentContainer + text));
                            } else {
                                list.Add(new KeyVersion(text));
                            }
                        }
                    }
                } else if (response.S3Objects.Count > 0) {
                    foreach (var item in response.S3Objects) {
                        if (!item.Key.Equals(response.Prefix)) {
                            var text = item.Key;
                            if (!string.IsNullOrEmpty(currentContainer)) {
                                list.Add(new KeyVersion(currentContainer + text));
                            } else {
                                list.Add(new KeyVersion(text));
                            }
                        } else {
                            list.Add(new KeyVersion(item.Key));
                        }
                    }
                }
            } else {
                if (!string.IsNullOrEmpty(currentContainer)) {
                    list.Add(new KeyVersion(currentContainer + FOLDER_SUFFIX_STRING + deleteItem));
                } else {
                    list.Add(new KeyVersion(deleteItem));
                }
            }
        }

        public static string currentContainerObject { get; set; }

        public static string currentContainer { get; set; }
    }
}
