using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Thp.Har.Utility {
    public class AmazonSQSUtility {
        public static AmazonSQSClient GetClient(RegionEndpoint region) {
            var config = new AmazonSQSConfig();
            return new AmazonSQSClient(CacheObject.Settings.AWSAccessKey, CacheObject.Settings.AWSSecretKey, region);
        }

        public static SendMessageResponse CreateMessage(RegionEndpoint region, string queueUrl, string messageBody, int delaySeconds = 0) {
            using (var client = GetClient(region)) {
                var request = new SendMessageRequest();
                request.QueueUrl = queueUrl;
                request.MessageBody = messageBody;
                request.DelaySeconds = delaySeconds;
                return client.SendMessage(request);
            }
        }

        public static ReceiveMessageResponse ReceiveMessage(RegionEndpoint region, string queueUrl, List<string> attributeNameList = null, int waitTimeSeconds = 20, int maxNumberOfMessages = 1, decimal visibilityTimeout = 0) {
            using (var client = GetClient(region)) {
                var request = new ReceiveMessageRequest();
                request.QueueUrl = queueUrl;
                if (attributeNameList != null) request.AttributeName = attributeNameList;
                request.WaitTimeSeconds = waitTimeSeconds;
                request.MaxNumberOfMessages = maxNumberOfMessages;
                request.VisibilityTimeout = visibilityTimeout;
                return client.ReceiveMessage(request);
            }
        }

        public static DeleteMessageResponse DeleteMessage(RegionEndpoint region, string queueUrl, List<Amazon.SQS.Model.Attribute> attributeList, string receiptHandle) {
            using (var client = GetClient(region)) {
                var request = new DeleteMessageRequest();
                request.QueueUrl = queueUrl;
                if (attributeList != null) request.Attribute = attributeList;
                if (!string.IsNullOrEmpty(receiptHandle)) request.ReceiptHandle = receiptHandle;
                return client.DeleteMessage(request);
            }
        }
    }
}
