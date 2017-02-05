using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Thp.Har.Utility {
    public class AmazonSNSUtility {
        public static AmazonSimpleNotificationService GetClient(RegionEndpoint region) {
            var config = new AmazonSimpleNotificationServiceConfig() { RegionEndpoint = region };
            return AWSClientFactory.CreateAmazonSNSClient(CacheObject.Settings.AWSAccessKey, CacheObject.Settings.AWSSecretKey, config);
        }

        public static ListTopicsResponse ListTopics(RegionEndpoint region) {
            using (var client = GetClient(region)) {
                var request = new ListTopicsRequest();
                return client.ListTopics(request);
            }
        }

        public static CreateTopicResponse CreateTopic(RegionEndpoint region, string name) {
            using (var client = GetClient(region)) {
                var request = new CreateTopicRequest();
                request.Name = name;
                return client.CreateTopic(request);
            }
        }

        public static DeleteTopicResponse DeleteTopic(RegionEndpoint region, string topicArn) {
            using (var client = GetClient(region)) {
                var request = new DeleteTopicRequest();
                request.TopicArn = topicArn;
                return client.DeleteTopic(request);
            }
        }

        public static SetTopicAttributesResponse SetTopicAttributes(RegionEndpoint region, string topicArn, string attributeName, string attributeValue) {
            using (var client = GetClient(region)) {
                var request = new SetTopicAttributesRequest();
                request.AttributeName = attributeName;
                request.AttributeValue = attributeValue;
                request.TopicArn = topicArn;
                return client.SetTopicAttributes(request);
            }
        }

        public static PublishResponse Publish(RegionEndpoint region, string topicArn, string subject, string message) {
            using (var client = GetClient(region)) {
                var request = new PublishRequest();
                request.TopicArn = topicArn;
                request.Subject = subject;
                request.Message = message;
                return client.Publish(request);
            }
        }

        public static ListSubscriptionsResponse ListSubscriptions(RegionEndpoint region) {
            using (var client = GetClient(region)) {
                var request = new ListSubscriptionsRequest();
                return client.ListSubscriptions(request);
            }
        }

        public static SubscribeResponse Subscribe(RegionEndpoint region, string endpoint, string protocol, string topicArn) {
            using (var client = GetClient(region)) {
                var request = new SubscribeRequest();
                request.Endpoint = endpoint;
                request.Protocol = protocol;
                request.TopicArn = topicArn;
                return client.Subscribe(request);
            }
        }

        public static UnsubscribeResponse Unsubscribe(RegionEndpoint region, string subscriptionArn) {
            using (var client = GetClient(region)) {
                var request = new UnsubscribeRequest();
                request.SubscriptionArn = subscriptionArn;
                return client.Unsubscribe(request);
            }
        }

        public static SetSubscriptionAttributesResponse SetSubscriptionAttributes(RegionEndpoint region, string subscriptionArn, string attributeName, string attributeValue) {
            using (var client = GetClient(region)) {
                var request = new SetSubscriptionAttributesRequest();
                request.AttributeName = attributeName;
                request.AttributeValue = attributeValue;
                request.SubscriptionArn = subscriptionArn;
                return client.SetSubscriptionAttributes(request);
            }
        }

        public static ListSubscriptionsByTopicResponse ListSubscriptionsByTopic(RegionEndpoint region, string topicArn) {
            using (var client = GetClient(region)) {
                var request = new ListSubscriptionsByTopicRequest();
                request.TopicArn = topicArn;
                return client.ListSubscriptionsByTopic(request);
            }
        }
    }
}
