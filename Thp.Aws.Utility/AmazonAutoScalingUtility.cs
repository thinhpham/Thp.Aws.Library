using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Thp.Har.Utility {
    public class AmazonAutoScalingUtility {
        public const string CRON_HELP_URL = "http://en.wikipedia.org/wiki/Cron";
        public const string AS_SCHEDULE_TIME_FORMAT = "YYYY-MM-DDThh:mm:ssZ";

        public static string[] AS_NAMESPACE = new string[] { 
            "AWS/AutoScaling", 
            "AWS/Billing", 
            "AWS/DynamoDB", 
            "AWS/EBS", 
            "AWS/EC2", 
            "AWS/ElastiCache", 
            "AWS/ElasticMapReduce", 
            "AWS/ELB",
            "AWS/RDS", 
            "AWS/SNS", 
            "AWS/SQS", 
            "AWS/StorageGateway"
        };
        public static string[] AS_GROUP_HEALTH_CHECK_TYPES = new string[] { "EC2", "ELB" };
        public static List<string> AS_GROUP_TERMINATION_POLICY = new List<string> { "OldestLaunchConfiguration", "ClosestToNextInstanceHour", "OldestInstance" };
        public static string[] AS_POLICY_ADJUSTMENT_TYPE = new string[] { "ChangeInCapacity", "ExactCapacity", "PercentChangeInCapacity" };

        public const string AS_ALARM_NAMESPACE_EC2 = "AWS/EC2";
        public const string AS_ALARM_NAMESPACE_ELB = "AWS/ELB";
        public static string[] AS_ALARM_NAMESPACES = new string[] { AS_ALARM_NAMESPACE_EC2, AS_ALARM_NAMESPACE_ELB };
        
        public static string[] AS_ALARM_METRIC_EC2 = new string[] { 
            "CPUUtilization", 
            "DiskReadOps", 
            "DiskWriteOps", 
            "DiskReadBytes", 
            "DiskWriteBytes", 
            "NetworkIn", 
            "NetworkOut", 
            "StatusCheckFailed", 
            "StatusCheckFailed_Instance", 
            "StatusCheckFailed_System",
        };
        public static string[] AS_ALARM_METRIC_ELB = new string[] { 
            "Latency",
            "RequestCount",
            "HealthyHostCount",
            "UnHealthyHostCount",
            "HTTPCode_ELB_4XX",
            "HTTPCode_ELB_5XX",
            "HTTPCode_Backend_2XX",
            "HTTPCode_Backend_3XX",
            "HTTPCode_Backend_4XX",
            "HTTPCode_Backend_5XX"
        };

        public static string[] AS_ALARM_COMPARISON_OPERATORS = new string[] { "GreaterThanOrEqualToThreshold", "GreaterThanThreshold", "LessThanThreshold", "LessThanOrEqualToThreshold" };
        public static string[] AS_ALARM_STATISTIC_TYPES = new string[] { "Average", "Maximum", "Minimum", "SampleCount", "Sum" };
        public static string[] AS_ALARM_DIMENSION_TYPES = new string[] { "AutoScalingGroupName", "AvailabilityZone", "ImageId", "InstanceId", "InstanceType", "LoadBalancerName" };
        
        public static string[] AS_ALARM_UNIT_TYPES = new string[] { 
             "Seconds", "Microseconds", "Milliseconds", "Bytes", "Kilobytes",
             "Megabytes", "Gigabytes", "Terabytes", "Bits", "Kilobits", "Megabits", "Gigabits", "Terabits",
             "Percent", "Count", "Bytes/Second", "Kilobytes/Second", "Megabytes/Second", "Gigabytes/Second",
             "Terabytes/Second", "Bits/Second", "Kilobits/Second", "Megabits/Second", "Gigabits/Second",
             "Terabits/Second", "Count/Second", "None"
        };

        public const string DEFAULT_AS_ADJUSTMENT_TYPE = "ChangeInCapacity";
        public const int DEFAULT_AS_ADJUSTMENT_INCREMENT = 1;
        public const int DEFAULT_AS_COOLDOWN = 180;
        public const int DEFAULT_AS_HEALTH_CHECK_GRACE_PERIOD = 600;
        public const int DEFAULT_AS_MIN_SIZE = 1;
        public const int DEFAULT_AS_MAX_SIZE = 1;
        public const int DEFAULT_AS_DESIRED_SIZE = 1;

        public const string DEFAULT_AS_ALARM_UP_METRIC = "CPUUtilization";
        public const string DEFAULT_AS_ALARM_UP_STATISTIC = "Average";
        public const string DEFAULT_AS_ALARM_UP_COMPARISON = "GreaterThanOrEqualToThreshold";
        public const int DEFAULT_AS_ALARM_UP_THRESHOLD = 70;
        public const int DEFAULT_AS_ALARM_UP_PERIOD = 120;
        public const int DEFAULT_AS_ALARM_UP_EVAL_PERIOD = 2;

        public const string DEFAULT_AS_ALARM_DOWN_METRIC = "CPUUtilization";
        public const string DEFAULT_AS_ALARM_DOWN_STATISTIC = "Average";
        public const string DEFAULT_AS_ALARM_DOWN_COMPARISON = "LessThanOrEqualToThreshold";
        public const int DEFAULT_AS_ALARM_DOWN_THRESHOLD = 30;
        public const int DEFAULT_AS_ALARM_DOWN_PERIOD = 120;
        public const int DEFAULT_AS_ALARM_DOWN_EVAL_PERIOD = 4;


        public static AmazonAutoScaling GetClient(RegionEndpoint region) {
            var config = new AmazonAutoScalingConfig();

            if (region != null) {
                config.RegionEndpoint = region;
            }

            return AWSClientFactory.CreateAmazonAutoScalingClient(CacheObject.Settings.AWSAccessKey, CacheObject.Settings.AWSSecretKey, config);
        }


        public static List<Tag> CreateTag(string key, string value) {
            var list = new List<Tag>();
            Tag tag = new Tag().WithKey(key).WithValue(value);
            list.Add(tag);
            return list;
        }


        public static SuspendProcessesResponse SuspendProcesses(RegionEndpoint regionEndPoint, string autoScalingGroupName, List<string> scalingProcesses) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new SuspendProcessesRequest();
                request.AutoScalingGroupName = autoScalingGroupName;
                if (scalingProcesses != null) request.ScalingProcesses = scalingProcesses;
                return client.SuspendProcesses(request);
            }
        }

        public static ResumeProcessesResponse ResumeProcesses(RegionEndpoint regionEndPoint, string autoScalingGroupName, List<string> scalingProcesses) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new ResumeProcessesRequest();
                request.AutoScalingGroupName = autoScalingGroupName;
                if (scalingProcesses != null) request.ScalingProcesses = scalingProcesses;
                return client.ResumeProcesses(request);
            }
        }

        
        public static TerminateInstanceInAutoScalingGroupResponse TerminateInstanceInAutoScalingGroup(RegionEndpoint regionEndPoint, string instanceId, bool shouldDecrementDesiredCapacity) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new TerminateInstanceInAutoScalingGroupRequest();
                request.InstanceId = instanceId;
                request.ShouldDecrementDesiredCapacity = shouldDecrementDesiredCapacity;
                return client.TerminateInstanceInAutoScalingGroup(request);
            }
        }


        public static DescribeLaunchConfigurationsResponse DescribeLaunchConfigurations(RegionEndpoint regionEndPoint, List<string> launchConfigurationNames) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DescribeLaunchConfigurationsRequest();
                if (launchConfigurationNames != null) request.LaunchConfigurationNames = launchConfigurationNames;
                return client.DescribeLaunchConfigurations(request);
            }
        }

        public static CreateLaunchConfigurationResponse CreateLaunchConfiguration(RegionEndpoint regionEndPoint, string launchConfigurationName, 
            string imageId, string instanceType, string keyName, 
            List<string> securityGroups, bool enableInstanceMonitoring, bool ebsOptimized,
            List<BlockDeviceMapping> blockDeviceMappings, string iamInstanceProfile, string spotPrice,
            string kernelId, string ramdiskId) {
            
            using (var client = GetClient(regionEndPoint)) {
                var request = new CreateLaunchConfigurationRequest();

                if (string.IsNullOrEmpty(launchConfigurationName)) throw new ArgumentNullException("launchConfigurationName is required");
                if (string.IsNullOrEmpty(imageId)) throw new ArgumentNullException("imageId is required");
                if (string.IsNullOrEmpty(instanceType)) throw new ArgumentNullException("instanceType is required");
                if (string.IsNullOrEmpty(keyName)) throw new ArgumentNullException("keyName is required");
                if (securityGroups == null) throw new ArgumentNullException("securityGroups is required");

                request.LaunchConfigurationName = launchConfigurationName;
                request.ImageId = imageId;
                request.InstanceType = instanceType;
                request.KeyName = keyName;
                request.SecurityGroups = securityGroups;
                request.InstanceMonitoring = new InstanceMonitoring() { Enabled = enableInstanceMonitoring };
                request.EbsOptimized = ebsOptimized;

                if (blockDeviceMappings != null) request.BlockDeviceMappings = blockDeviceMappings;
                if (!string.IsNullOrEmpty(iamInstanceProfile)) request.IamInstanceProfile = iamInstanceProfile;
                if (!string.IsNullOrEmpty(spotPrice)) request.SpotPrice = spotPrice;
                if (!string.IsNullOrEmpty(kernelId)) request.KernelId = kernelId;
                if (!string.IsNullOrEmpty(ramdiskId)) request.RamdiskId = ramdiskId;

                return client.CreateLaunchConfiguration(request);
            }
        }

        public static DeleteLaunchConfigurationResponse DeleteLaunchConfiguration(RegionEndpoint regionEndPoint, string launchConfigurationName) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DeleteLaunchConfigurationRequest();
                request.LaunchConfigurationName = launchConfigurationName;                
                return client.DeleteLaunchConfiguration(request);
            }
        }


        public static DescribeAutoScalingGroupsResponse DescribeAutoScalingGroups(RegionEndpoint regionEndPoint, List<string> autoScalingGroupNames) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DescribeAutoScalingGroupsRequest();
                if (autoScalingGroupNames != null) request.AutoScalingGroupNames = autoScalingGroupNames;
                return client.DescribeAutoScalingGroups(request);
            }
        }

        public static CreateAutoScalingGroupResponse CreateAutoScalingGroup(RegionEndpoint regionEndPoint, string autoScalingGroupName, 
            int defaultCooldown, string launchConfigurationName, 
            int minSize, int maxSize, 
            int desiredCapacity, int healthCheckGracePeriod, 
            string healthCheckType, List<string> loadBalancerNames,
            List<string> availabilityZones, string vpcZoneIdentifier) {

            using (var client = GetClient(regionEndPoint)) {
                var request = new CreateAutoScalingGroupRequest();
                request.AutoScalingGroupName = autoScalingGroupName;
                request.LaunchConfigurationName = launchConfigurationName;
                request.MaxSize = maxSize;
                request.MinSize = minSize;
                request.DesiredCapacity = desiredCapacity;
                request.DefaultCooldown = defaultCooldown;
                request.HealthCheckGracePeriod = healthCheckGracePeriod;
                request.HealthCheckType = healthCheckType;
                request.AvailabilityZones = availabilityZones;
                request.LoadBalancerNames = loadBalancerNames;
                request.TerminationPolicies = AS_GROUP_TERMINATION_POLICY;
                if (!string.IsNullOrEmpty(vpcZoneIdentifier)) request.VPCZoneIdentifier = vpcZoneIdentifier;

                return client.CreateAutoScalingGroup(request);
            }
        }

        public static UpdateAutoScalingGroupResponse UpdateAutoScalingGroup(RegionEndpoint regionEndPoint, string autoScalingGroupName, 
            int defaultCooldown, string launchConfigurationName, 
            int minSize, int maxSize, 
            int desiredCapacity, int healthCheckGracePeriod, 
            string healthCheckType, List<string> loadBalancerNames,
            List<string> availabilityZones, string vpcZoneIdentifier) {

            using (var client = GetClient(regionEndPoint)) {
                var request = new UpdateAutoScalingGroupRequest();
                request.AutoScalingGroupName = autoScalingGroupName;
                request.LaunchConfigurationName = launchConfigurationName;
                request.MaxSize = maxSize;
                request.MinSize = minSize;
                request.DesiredCapacity = desiredCapacity;
                request.DefaultCooldown = defaultCooldown;
                request.HealthCheckGracePeriod = healthCheckGracePeriod;
                request.HealthCheckType = healthCheckType;
                request.AvailabilityZones = availabilityZones;
                request.TerminationPolicies = AS_GROUP_TERMINATION_POLICY;
                if (!string.IsNullOrEmpty(vpcZoneIdentifier)) request.VPCZoneIdentifier = vpcZoneIdentifier;

                return client.UpdateAutoScalingGroup(request);
            }
        }

        public static DeleteAutoScalingGroupResponse DeleteAutoScalingGroup(RegionEndpoint regionEndPoint, string autoScalingGroupName) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DeleteAutoScalingGroupRequest();
                if (!string.IsNullOrEmpty(autoScalingGroupName)) request.AutoScalingGroupName = autoScalingGroupName;
                return client.DeleteAutoScalingGroup(request);
            }
        }


        public static DescribeAutoScalingInstancesResponse DescribeAutoScalingInstances(RegionEndpoint regionEndPoint) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DescribeAutoScalingInstancesRequest();
                return client.DescribeAutoScalingInstances(request);
            }
        }


        public static DescribePoliciesResponse DescribeScalingPolicies(RegionEndpoint regionEndPoint, string autoScalingGroupName, List<string> policyNames) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DescribePoliciesRequest();
                if (!string.IsNullOrEmpty(autoScalingGroupName)) request.AutoScalingGroupName = autoScalingGroupName;
                if (policyNames != null) request.PolicyNames = policyNames;
                return client.DescribePolicies(request);
            }
        }

        public static DescribeScalingActivitiesResponse DescribeScalingActivities(RegionEndpoint regionEndPoint, string autoScalingGroupName) {
            return DescribeScalingActivities(regionEndPoint, autoScalingGroupName, 50, null);
        }

        public static DescribeScalingActivitiesResponse DescribeScalingActivities(RegionEndpoint regionEndPoint, string autoScalingGroupName, int maxRecords, string nextToken) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DescribeScalingActivitiesRequest();
                if (!string.IsNullOrEmpty(autoScalingGroupName)) request.AutoScalingGroupName = autoScalingGroupName;

                if (maxRecords > int.MinValue) {
                    request.MaxRecords = maxRecords;
                } else {
                    request.MaxRecords = 50;
                }

                if (!string.IsNullOrEmpty(nextToken)) request.NextToken = nextToken;
                
                return client.DescribeScalingActivities(request);
            }
        }


        public static DescribeScheduledActionsResponse DescribeScheduledActions(RegionEndpoint regionEndPoint, string autoScalingGroupName, List<string> scheduledActionNames) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DescribeScheduledActionsRequest();
                if (!string.IsNullOrEmpty(autoScalingGroupName)) request.AutoScalingGroupName = autoScalingGroupName;
                if (scheduledActionNames != null) request.ScheduledActionNames = scheduledActionNames;
                return client.DescribeScheduledActions(request);
            }
        }

        public static PutScheduledUpdateGroupActionResponse PutScheduledUpdateGroupAction(RegionEndpoint regionEndPoint, string scheduledActionName, string autoScalingGroupName,
            int minSize, int maxSize, int desiredCapacity, DateTime startTime, DateTime endTime, string recurrence) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new PutScheduledUpdateGroupActionRequest();
                request.ScheduledActionName = scheduledActionName;
                if (!string.IsNullOrEmpty(autoScalingGroupName)) request.AutoScalingGroupName = autoScalingGroupName;
                if (minSize > int.MinValue) request.MinSize = minSize;
                if (maxSize > int.MinValue) request.MaxSize = maxSize;
                if (desiredCapacity > int.MinValue) request.DesiredCapacity = desiredCapacity;
                if (startTime > DateTime.MinValue) request.StartTime = startTime;
                if (endTime > DateTime.MinValue) request.EndTime = endTime;
                if (!string.IsNullOrEmpty(recurrence)) request.Recurrence = recurrence;
                return client.PutScheduledUpdateGroupAction(request);
            }
        }

        public static DeleteScheduledActionResponse DeleteScheduledAction(RegionEndpoint regionEndPoint, string scheduledActionName, string autoScalingGroupName) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DeleteScheduledActionRequest();
                request.ScheduledActionName = scheduledActionName;
                if (!string.IsNullOrEmpty(autoScalingGroupName)) request.AutoScalingGroupName = autoScalingGroupName;
                return client.DeleteScheduledAction(request);
            }
        }


        public static PutScalingPolicyResponse PutScalingPolicy(RegionEndpoint regionEndPoint, string policyName, string autoScalingGroupName, string adjustmentType, int scalingAdjustment, int cooldown) {            
            using (var client = GetClient(regionEndPoint)) {
                var request = new PutScalingPolicyRequest();
                request.PolicyName = policyName;
                request.AutoScalingGroupName = autoScalingGroupName;
                request.AdjustmentType = adjustmentType;
                request.ScalingAdjustment = scalingAdjustment;
                request.Cooldown = cooldown;
                return client.PutScalingPolicy(request);
            }
        }

        public static ExecutePolicyResponse ExecuteScalingPolicy(RegionEndpoint regionEndPoint, string policyName, string autoScalingGroupName, bool honorCooldown) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new ExecutePolicyRequest();
                request.PolicyName = policyName;
                request.AutoScalingGroupName = autoScalingGroupName;
                request.HonorCooldown = honorCooldown;
                return client.ExecutePolicy(request);
            }
        }

        public static DeletePolicyResponse DeleteScalingPolicy(RegionEndpoint regionEndPoint, string policyName, string autoScalingGroupName) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DeletePolicyRequest();
                request.PolicyName = policyName;
                request.AutoScalingGroupName = autoScalingGroupName;
                return client.DeletePolicy(request);
            }
        }
    }
}
