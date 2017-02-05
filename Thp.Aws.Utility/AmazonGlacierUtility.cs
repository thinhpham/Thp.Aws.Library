using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.Glacier;
using Amazon.Glacier.Model;

namespace Thp.Har.Utility {
    public class AmazonGlacierUtility {
        private const string CONST_DEFAULT_JOB_FORMAT = "JSON";

        public static AmazonGlacierClient GetClient(RegionEndpoint region) {
            var config = new AmazonGlacierConfig() { RegionEndpoint = region };
            return new AmazonGlacierClient(CacheObject.Settings.AWSAccessKey, CacheObject.Settings.AWSSecretKey, config);
        }


        public static Amazon.Glacier.Transfer.UploadResult UploadArchive(RegionEndpoint region, string vaultName, string archiveDescription, string filePath) {
            using (var client = GetClient(region)) {
                using (var transferManager = new Amazon.Glacier.Transfer.ArchiveTransferManager(client)) {
                    return transferManager.Upload(vaultName, archiveDescription, filePath);                    
                }
            }
        }

        public static void DownloadArchive(RegionEndpoint region, string vaultName, string archiveId, string filePath) {
            using (var client = GetClient(region)) {
                using (var transferManager = new Amazon.Glacier.Transfer.ArchiveTransferManager(client)) {
                    transferManager.Download(vaultName, archiveId, filePath);
                }
            }
        }

        public static void DownloadJob(RegionEndpoint region, string vaultName, string jobId, string filePath) {
            using (var client = GetClient(region)) {
                using (var transferManager = new Amazon.Glacier.Transfer.ArchiveTransferManager(client)) {
                    transferManager.DownloadJob(vaultName, jobId, filePath);
                }
            }
        }


        public static DeleteArchiveResponse DeleteArchive(RegionEndpoint region, string vaultName, string archiveId) {
            using (var client = GetClient(region)) {
                var request = new DeleteArchiveRequest();
                request.VaultName = vaultName;
                request.ArchiveId = archiveId;
                return client.DeleteArchive(request);
            }
        }


        public static ListVaultsResponse ListVaults(RegionEndpoint region) {
            using (var client = GetClient(region)) {
                return client.ListVaults();
            }
        }

        public static DescribeVaultResponse DescribeVault(RegionEndpoint region, string vaultName) {
            using (var client = GetClient(region)) {
                var request = new DescribeVaultRequest();
                request.VaultName = vaultName;
                return client.DescribeVault(request);
            }
        }

        public static CreateVaultResponse CreateVault(RegionEndpoint region, string vaultName) {
            using (var client = GetClient(region)) {
                var request = new CreateVaultRequest();
                request.VaultName = vaultName;
                return client.CreateVault(request);
            }
        }

        public static DeleteVaultResponse DeleteVault(RegionEndpoint region, string vaultName) {
            using (var client = GetClient(region)) {
                var request = new DeleteVaultRequest();
                request.VaultName = vaultName;
                return client.DeleteVault(request);
            }
        }


        public static InitiateJobResponse InitiateArchiveRetrievalJob(RegionEndpoint region, string vaultName, string description, string retrievalByteRange, string snsTopic) {
            return InitiateJob(region, vaultName, "archive-retrieval", description, CONST_DEFAULT_JOB_FORMAT, retrievalByteRange, snsTopic);
        }

        public static InitiateJobResponse InitiateInventoryRetrievalJob(RegionEndpoint region, string vaultName, string description, string retrievalByteRange, string snsTopic) {
            return InitiateJob(region, vaultName, "inventory-retrieval", description, CONST_DEFAULT_JOB_FORMAT, retrievalByteRange, snsTopic);
        }

        public static InitiateJobResponse InitiateJob(RegionEndpoint region, string vaultName, string type, string description, string format, string retrievalByteRange, string snsTopic) {
            using (var client = GetClient(region)) {
                var request = new InitiateJobRequest();
                request.VaultName = vaultName;

                var parameters = new JobParameters();
                parameters.Type = type;
                if (!string.IsNullOrEmpty(description)) parameters.Description = description;
                if (!string.IsNullOrEmpty(format)) parameters.Format = format; else parameters.Format = CONST_DEFAULT_JOB_FORMAT;
                if (!string.IsNullOrEmpty(retrievalByteRange)) parameters.RetrievalByteRange = retrievalByteRange;
                if (!string.IsNullOrEmpty(snsTopic)) parameters.SNSTopic = snsTopic;
                request.JobParameters = parameters;

                return client.InitiateJob(request);
            }
        }

        public static ListJobsResponse ListJobs(RegionEndpoint region, string vaultName, int limit) {
            using (var client = GetClient(region)) {
                var request = new ListJobsRequest();
                request.VaultName = vaultName;
                if (limit > 0) request.Limit = limit;
                return client.ListJobs(request);
            }
        }

        public static DescribeJobResponse DescribeJob(RegionEndpoint region, string vaultName, string jobId) {
            using (var client = GetClient(region)) {
                var request = new DescribeJobRequest();
                request.VaultName = vaultName;
                request.JobId = jobId;
                return client.DescribeJob(request);
            }
        }

        public static GetJobOutputResponse GetJobOutput(RegionEndpoint region, string vaultName, string jobId, string range) {
            using (var client = GetClient(region)) {
                var request = new GetJobOutputRequest();
                request.VaultName = vaultName;
                request.JobId = jobId;
                if (!string.IsNullOrEmpty(range)) request.Range = range;
                return client.GetJobOutput(request);
            }
        }
    }
}
