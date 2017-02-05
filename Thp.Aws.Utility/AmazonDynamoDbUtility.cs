using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.DynamoDB;
using Amazon.DynamoDB.Model;
using Amazon.DynamoDB.DataModel;
using Amazon.DynamoDB.DocumentModel;

namespace Thp.Har.Utility {
    public class AmazonDynamoDbUtility {
        public static AmazonDynamoDB GetClient(RegionEndpoint region) {
            var config = new AmazonDynamoDBConfig() { RegionEndpoint = region };
            return AWSClientFactory.CreateAmazonDynamoDBClient(CacheObject.Settings.AWSAccessKey, CacheObject.Settings.AWSSecretKey, config);
        }

        public static DeleteItemResponse DeleteItem(RegionEndpoint region, DeleteItemRequest request) {
            using (var client = GetClient(region)) {
                return client.DeleteItem(request);
            }
        }


        public static GetItemResponse GetItem(RegionEndpoint region, GetItemRequest request) {
            using (var client = GetClient(region)) {
                return client.GetItem(request);
            }
        }

        public static PutItemResponse PutItem(RegionEndpoint region, PutItemRequest request) {
            using (var client = GetClient(region)) {
                return client.PutItem(request);
            }
        }

        public static UpdateItemResponse UpdateItem(RegionEndpoint region, UpdateItemRequest request) {
            using (var client = GetClient(region)) {
                return client.UpdateItem(request);
            }
        }

        public static QueryResponse Query(RegionEndpoint region, QueryRequest request) {
            using (var client = GetClient(region)) {
                return client.Query(request);
            }
        }

        public static ScanResponse Scan(RegionEndpoint region, ScanRequest request) {
            using (var client = GetClient(region)) {
                return client.Scan(request);
            }
        }
    }
}