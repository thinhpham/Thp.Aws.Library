using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;

namespace Thp.Har.Utility {
    public class AmazonElasticLoadBalancingUtility {
        private static AmazonElasticLoadBalancing GetClient() {
            return GetClient(null);
        }

        private static AmazonElasticLoadBalancing GetClient(RegionEndpoint endpoint) {
            var config = new AmazonElasticLoadBalancingConfig() { RegionEndpoint = endpoint };
            return AWSClientFactory.CreateAmazonElasticLoadBalancingClient(CacheObject.Settings.AWSAccessKey, CacheObject.Settings.AWSSecretKey, config);
        }

        public static DescribeLoadBalancersResponse DescribeLoadBalancers(RegionEndpoint region) {
            using (var client = GetClient(region)) {
                var request = new DescribeLoadBalancersRequest();
                return client.DescribeLoadBalancers(request);
            }
        }

        public static List<Amazon.ElasticLoadBalancing.Model.InstanceState> DescribeInstanceHealth(RegionEndpoint regionEndPoint) {
            using (var client = GetClient()) {
                var request = new DescribeInstanceHealthRequest();
                var response = client.DescribeInstanceHealth(request);
                return response.DescribeInstanceHealthResult.InstanceStates;
            }
        }

        public static List<Amazon.ElasticLoadBalancing.Model.Instance> RegisterInstancesWithLoadBalancer(RegionEndpoint regionEndPoint, string loadBalancerName, List<Amazon.ElasticLoadBalancing.Model.Instance> instances) {
            using (var client = GetClient()) {
                var request = new RegisterInstancesWithLoadBalancerRequest();
                request.LoadBalancerName = loadBalancerName;
                request.Instances = instances;

                var response = client.RegisterInstancesWithLoadBalancer(request);
                return response.RegisterInstancesWithLoadBalancerResult.Instances;
            }
        }

        public static List<Amazon.ElasticLoadBalancing.Model.Instance> DeregisterInstancesFromLoadBalancer(RegionEndpoint regionEndPoint, string loadBalancerName, List<Amazon.ElasticLoadBalancing.Model.Instance> instances) {
            using (var client = GetClient()) {
                var request = new DeregisterInstancesFromLoadBalancerRequest();
                request.Instances = instances;
                request.LoadBalancerName = loadBalancerName;

                var response = client.DeregisterInstancesFromLoadBalancer(request);
                return response.DeregisterInstancesFromLoadBalancerResult.Instances;
            }
        }

        public static HealthCheck ConfigureHealthCheck(RegionEndpoint regionEndPoint, string loadBalancerName, HealthCheck healthCheck) {
            using (var client = GetClient()) {
                var request = new ConfigureHealthCheckRequest();
                request.LoadBalancerName = loadBalancerName;
                request.HealthCheck = healthCheck;

                var response = client.ConfigureHealthCheck(request);
                return response.ConfigureHealthCheckResult.HealthCheck;
            }
        }

        public static List<string> ApplySecurityGroupsToLoadBalancer(RegionEndpoint regionEndPoint, string loadBalancerName, List<string> securityGroups) {
            using (var client = GetClient()) {
                var request = new ApplySecurityGroupsToLoadBalancerRequest();
                request.LoadBalancerName = loadBalancerName;
                request.SecurityGroups = securityGroups;

                var response = client.ApplySecurityGroupsToLoadBalancer(request);
                return response.ApplySecurityGroupsToLoadBalancerResult.SecurityGroups;
            }
        }
    }
}
