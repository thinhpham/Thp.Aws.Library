using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using System.IO;

namespace Thp.Har.Utility
{
    public class AmazonEC2Utility
    {
        public const string EC2_INSTANCE_ID_URL = "http://169.254.169.254/latest/meta-data/instance-id";
        public const string EC2_INSTANCE_AMI_ID_URL = "http://169.254.169.254/latest/meta-data/ami-id";
        public const string EC2_INSTANCE_TYPE_URL = "http://169.254.169.254/latest/meta-data/instance-type";
        public const string EC2_INSTANCE_LOCAL_HOSTNAME_URL = "http://169.254.169.254/latest/meta-data/local-hostname";
        public const string EC2_INSTANCE_LOCAL_IPV4_URL = "http://169.254.169.254/latest/meta-data/local-ipv4";

        public const string EC2_INSTANCE_USER_DATA_URL = "http://169.254.169.254/latest/user-data";

        public const string EC2_INSTANCE_IDENTITY_URL = "http://169.254.169.254/latest/dynamic/instance-identity/document";

        public static string[] EC2_INSTANCE_TYPES = new string[] {
            "c1.medium", "c1.xlarge",
            "c3.large", "c3.xlarge", "c3.2xlarge", "c3.4xlarge", "c3.8xlarge",
            "cc1.4xlarge",
            "cc2.8xlarge",
            "cg1.4xlarge",
            "cr1.8xlarge",
            "g2.2xlarge",
            "hi1.4xlarge",
            "hs1.8xlarge",
            "i2.xlarge", "i2.2xlarge", "i2.4xlarge", "i2.8xlarge",
            "m1.small", "m1.medium", "m1.large", "m1.xlarge",
            "m2.xlarge", "m2.2xlarge", "m2.4xlarge",
            "m3.medium", "m3.large", "m3.xlarge", "m3.2xlarge",
            "r3.large", "r3.xlarge", "r3.2xlarge", "r3.4xlarge", "r3.8xlarge",
            "t1.micro",
        };

        static AmazonEC2Utility()
        {
            //Array.Sort<string>(EC2_INSTANCE_TYPES);
        }

        public static AmazonEC2 GetClient(RegionEndpoint region)
        {
            if (!string.IsNullOrEmpty(CacheObject.Settings.AWSAccessKey) && !string.IsNullOrEmpty(CacheObject.Settings.AWSSecretKey))
            {
                var config = new AmazonEC2Config() { RegionEndpoint = region };
                return AWSClientFactory.CreateAmazonEC2Client(CacheObject.Settings.AWSAccessKey, CacheObject.Settings.AWSSecretKey, config);
            }

            return null;
        }

        public static string GetInstanceName(RunningInstance instance)
        {
            var name = GetNameFromTag(instance.Tag);

            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }
            else
            {
                return instance.InstanceId;
            }
        }

        public static List<Tag> CreateTag(string key, string value)
        {
            var list = new List<Tag>();
            Tag tag = new Tag().WithKey(key).WithValue(value);
            list.Add(tag);
            return list;
        }

        public static string GetNameFromTag(List<Tag> tag)
        {
            if (tag != null)
            {
                foreach (var item in tag)
                {
                    if (item.Key.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                        return item.Value;
                    }
                }
            }

            return null;
        }

        public static string CreateTagRequest(RegionEndpoint region, List<string> resourceId, List<Tag> tag)
        {
            using (var client = GetClient(region))
            {
                var request = new CreateTagsRequest();
                request.ResourceId = resourceId;
                request.Tag = tag;

                var response = client.CreateTags(request);
                return response.ResponseMetadata.RequestId;
            }
        }



        public static DescribeKeyPairsResponse DescribeKeyPairs(RegionEndpoint region)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeKeyPairsRequest();
                return client.DescribeKeyPairs(request);
            }
        }



        public static DescribeSecurityGroupsResponse DescribeSecurityGroups(RegionEndpoint region)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeSecurityGroupsRequest();
                return client.DescribeSecurityGroups(request);
            }
        }



        public static DescribeImagesResponse DescribeImages(RegionEndpoint region, string owner)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeImagesRequest();

                var ownerList = new List<string>();
                if (!string.IsNullOrEmpty(owner))
                {
                    ownerList.Add(owner);
                }
                else
                {
                    ownerList.Add("self");
                }

                request.Owner = ownerList;
                return client.DescribeImages(request);
            }
        }



        public static DescribeAvailabilityZonesResponse DescribeAvailabilityZones(RegionEndpoint region)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeAvailabilityZonesRequest();
                return client.DescribeAvailabilityZones(request);
            }
        }



        public static DescribeVpcsResponse DescribeVpcs(RegionEndpoint region)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeVpcsRequest();
                return client.DescribeVpcs(request);
            }
        }



        public static DescribeSubnetsResponse DescribeSubnets(RegionEndpoint region)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeSubnetsRequest();
                return client.DescribeSubnets(request);
            }
        }



        public static RegionEndpoint GetRegionEndpoint(string input)
        {
            RegionEndpoint result = null;

            if (result == null)
            {
                switch (input)
                {
                    case "APNortheast1":
                    case "ap-northeast-1":
                        result = RegionEndpoint.APNortheast1;
                        break;
                    case "APSoutheast1":
                    case "ap-southeast-1":
                        result = RegionEndpoint.APSoutheast1;
                        break;
                    case "APSoutheast2":
                    case "ap-southeast-2":
                        result = RegionEndpoint.APSoutheast2;
                        break;
                    case "EUWest1":
                    case "eu-west-1":
                        result = RegionEndpoint.EUWest1;
                        break;
                    case "SAEast1":
                    case "sa-east-1":
                        result = RegionEndpoint.SAEast1;
                        break;
                    case "USEast1":
                    case "us-east-1":
                        result = RegionEndpoint.USEast1;
                        break;
                    case "USWest1":
                    case "us-west-1":
                        result = RegionEndpoint.USWest1;
                        break;
                    case "USWest2":
                    case "us-west-2":
                        result = RegionEndpoint.USWest2;
                        break;
                    case "USGovCloudWest1":
                        result = RegionEndpoint.USGovCloudWest1;
                        break;
                }
            }

            return result;
        }

        public static List<Region> DescribeRegions()
        {
            using (var client = GetClient(null))
            {
                var request = new DescribeRegionsRequest();
                var response = client.DescribeRegions(request);
                return response.DescribeRegionsResult.Region;
            }
        }



        public static DescribeImagesResponse DescribeImages(RegionEndpoint region, List<string> ownerList, List<string> executableByList, List<Filter> filterList, List<string> imageIdList)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeImagesRequest();
                if (ownerList != null) request.Owner = ownerList;
                if (executableByList != null) request.ExecutableBy = executableByList;
                if (filterList != null) request.Filter = filterList;
                if (imageIdList != null) request.ImageId = imageIdList;
                return client.DescribeImages(request);
            }
        }

        public static CreateImageResponse CreateImage(RegionEndpoint region, string name, string description, string instanceId, bool noReboot, List<BlockDeviceMapping> blockDeviceMappingList)
        {
            using (var client = GetClient(region))
            {
                var request = new CreateImageRequest();
                request.Name = name;
                request.NoReboot = noReboot;
                if (!string.IsNullOrEmpty(description)) request.Description = description;
                if (!string.IsNullOrEmpty(instanceId)) request.InstanceId = instanceId;
                if (blockDeviceMappingList != null) request.BlockDeviceMapping = blockDeviceMappingList;
                return client.CreateImage(request);
            }
        }

        public static DescribeImageAttributeResponse DescribeImageAttribute(RegionEndpoint region, string imageId, string attribute)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeImageAttributeRequest();
                request.ImageId = imageId;
                request.Attribute = attribute;
                return client.DescribeImageAttribute(request);
            }
        }

        public static DeregisterImageResponse DeregisterImage(RegionEndpoint region, string imageId)
        {
            using (var client = GetClient(region))
            {
                var request = new DeregisterImageRequest();
                request.ImageId = imageId;
                return client.DeregisterImage(request);
            }
        }



        public static DescribeInstancesResponse DescribeInstances()
        {
            return DescribeInstances(CacheObject.Settings.DefaultRegionEndpoint);
        }

        public static DescribeInstancesResponse DescribeInstances(RegionEndpoint region)
        {
            using (var client = GetClient(region))
            {
                if (client != null)
                {
                    var request = new DescribeInstancesRequest();
                    return client.DescribeInstances(request);
                }
            }

            return null;
        }

        public static DescribeReservedInstancesOfferingsResponse DescribeReservedInstancesOfferings(RegionEndpoint region)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeReservedInstancesOfferingsRequest();
                return client.DescribeReservedInstancesOfferings(request);
            }
        }

        public static string GetCurrentInstanceId()
        {
            try
            {
                var request = (HttpWebRequest)HttpWebRequest.Create(AmazonEC2Utility.EC2_INSTANCE_ID_URL);
                request.Timeout = 3000;

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(responseStream))
                        {
                            return sr.ReadToEnd().Trim();
                        }
                    }
                }
            }
            catch { }

            return string.Empty;
        }

        public static RunningInstance GetCurrentInstance()
        {
            return GetInstance(GetCurrentInstanceId());
        }

        public static string GetTagByName(params string[] tags)
        {
            return GetTagByName(GetCurrentInstance(), tags);
        }

        public static string GetTagByName(RunningInstance instance, params string[] tags)
        {
            if (instance != null)
            {
                foreach (var item in instance.Tag)
                {
                    foreach (var tag in tags)
                    {
                        if (tag.Equals(item.Key, StringComparison.OrdinalIgnoreCase))
                        {
                            return item.Value;
                        }
                    }
                }
            }

            return null;
        }

        public static RunningInstance GetInstance(string instanceId)
        {
            var list = DescribeInstances().DescribeInstancesResult.Reservation;
            foreach (var item in list)
            {
                for (var i = 0; i < item.RunningInstance.Count; i++)
                {
                    if (item.RunningInstance[i].InstanceId.Equals(instanceId, StringComparison.OrdinalIgnoreCase))
                    {
                        return item.RunningInstance[i];
                    }
                }
            }
            return null;
        }

        public static List<InstanceStatus> DescribeInstanceStatus(RegionEndpoint region)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeInstanceStatusRequest();
                var response = client.DescribeInstanceStatus(request);
                return response.DescribeInstanceStatusResult.InstanceStatus;
            }
        }

        public static InstanceStatus GetInstanceStatus(RegionEndpoint region, string instanceId)
        {
            var list = DescribeInstanceStatus(region);
            foreach (var item in list)
            {
                if (item.InstanceId.Equals(instanceId, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        public static DescribeInstanceAttributeResult DescribeInstanceAttribute(RegionEndpoint region, string instanceId, string attribute)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeInstanceAttributeRequest();
                request.InstanceId = instanceId;
                request.Attribute = attribute;
                var response = client.DescribeInstanceAttribute(request);
                return response.DescribeInstanceAttributeResult;
            }
        }

        public static List<InstanceStateChange> StopInstances(RegionEndpoint region, List<string> instanceId)
        {
            return StopInstances(region, instanceId, false);
        }

        public static List<InstanceStateChange> StopInstances(RegionEndpoint region, List<string> instanceId, bool force)
        {
            using (var client = GetClient(region))
            {
                var request = new StopInstancesRequest();
                var instanceStateChangeList = new List<InstanceStateChange>();

                foreach (var item in instanceId)
                {
                    try
                    {
                        request.InstanceId = new List<string> { item };
                        request.Force = force;
                        var response = client.StopInstances(request);

                        instanceStateChangeList.AddRange(response.StopInstancesResult.StoppingInstances);
                    }
                    catch (Exception ex)
                    {
                        LoggingUtility.Warning(ex);
                    }
                }

                return instanceStateChangeList;
            }
        }

        public static List<InstanceStateChange> StartInstances(RegionEndpoint region, List<string> instanceId)
        {
            using (var client = GetClient(region))
            {
                var request = new StartInstancesRequest();
                var instanceStateChangeList = new List<InstanceStateChange>();

                foreach (var item in instanceId)
                {
                    try
                    {
                        request.InstanceId = new List<string> { item };
                        var response = client.StartInstances(request);

                        instanceStateChangeList.AddRange(response.StartInstancesResult.StartingInstances);
                    }
                    catch (Exception ex)
                    {
                        LoggingUtility.Warning(ex);
                    }
                }

                return instanceStateChangeList;
            }
        }

        public static string RebootInstances(RegionEndpoint region, List<string> instanceId)
        {
            using (var client = GetClient(region))
            {
                var request = new RebootInstancesRequest();
                request.InstanceId = instanceId;
                var response = client.RebootInstances(request);
                return response.ResponseMetadata.RequestId;
            }
        }

        public static List<InstanceStateChange> TerminateInstances(RegionEndpoint region, List<string> instanceId)
        {
            using (var client = GetClient(region))
            {
                var request = new TerminateInstancesRequest();
                request.InstanceId = instanceId;
                var response = client.TerminateInstances(request);
                return response.TerminateInstancesResult.TerminatingInstance;
            }
        }

        public static string GetOwnerId(RegionEndpoint region)
        {
            try
            {
                var instance = GetCurrentInstance();

                if (instance.GroupId != null && instance.GroupId.Count > 0)
                {
                    var group = GetSecurityGroup(region, instance.GroupId[0]);

                    if (group != null)
                    {
                        return group.OwnerId;
                    }
                }
            }
            catch { }

            return CacheObject.Settings.DefaultOwnerId;
        }



        public static SecurityGroup GetSecurityGroup(RegionEndpoint region, string groupId)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeSecurityGroupsRequest();

                var list = new List<string>();
                list.Add(groupId);
                request.GroupId = list;

                var response = client.DescribeSecurityGroups(request);
                return response.DescribeSecurityGroupsResult.SecurityGroup.FirstOrDefault();
            }
        }



        public static List<Volume> DescribeVolumes(RegionEndpoint region, List<Filter> filter, List<string> volumeId)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeVolumesRequest();
                if (filter != null) request.Filter = filter;
                if (volumeId != null) request.VolumeId = volumeId;
                var response = client.DescribeVolumes(request);
                return response.DescribeVolumesResult.Volume;
            }
        }



        public static List<Snapshot> DescribeSnapshots(RegionEndpoint region)
        {
            using (var client = GetClient(region))
            {
                var request = new DescribeSnapshotsRequest();

                var filter = new Filter() { Name = "owner-id", Value = AmazonUtility.CreateStringList(CacheObject.Settings.GetOwnerId()) };
                request.Filter.Add(filter);

                var response = client.DescribeSnapshots(request);
                return response.DescribeSnapshotsResult.Snapshot;
            }
        }

        public static List<Snapshot> DescribeSnapshotsForInstance(RegionEndpoint region, string instanceId)
        {
            var result = new List<Snapshot>();
            var list = DescribeSnapshots(region);
            var instance = GetInstance(instanceId);

            foreach (var bdm in instance.BlockDeviceMapping)
            {
                foreach (var snapshot in list)
                {
                    if (snapshot.VolumeId.Equals(bdm.Ebs.VolumeId, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(snapshot);
                    }
                }
            }

            return result;
        }

        public static List<Snapshot> DescribeSnapshotsForVolume(RegionEndpoint region, string volumeId)
        {
            var result = new List<Snapshot>();
            var list = DescribeSnapshots(region);

            foreach (var item in list)
            {
                if (item.VolumeId.Equals(volumeId, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static void CreateSnapshotForInstance(RegionEndpoint region, string instanceId)
        {
            var instance = GetInstance(instanceId);
            var instanceName = GetInstanceName(instance);
            var datetime = DateTime.Now.ToString("yyyyMMdd");

            foreach (var bdm in instance.BlockDeviceMapping)
            {
                var description = string.Format("{0}, {1}, {2}, {3}, {4}", instanceName, instance.InstanceId, instance.ImageId, bdm.Ebs.VolumeId, bdm.DeviceName);
                var snapshot = CreateSnaphotForVolume(region, bdm.Ebs.VolumeId, description);
                var resourceId = AmazonUtility.CreateStringList(snapshot.SnapshotId);

                var tagName = string.Format("{0}:{1}:{2}", datetime, instanceName, bdm.DeviceName);
                var tag = CreateTag("Name", tagName);

                CreateTagRequest(region, resourceId, tag);
            }
        }

        public static Snapshot CreateSnaphotForVolume(RegionEndpoint region, string volumnId, string description)
        {
            using (var client = GetClient(region))
            {
                var request = new CreateSnapshotRequest();
                request.Description = description;
                request.VolumeId = volumnId;

                var response = client.CreateSnapshot(request);
                return response.CreateSnapshotResult.Snapshot;
            }
        }

        public static string DeleteSnaphot(RegionEndpoint region, string snapshotId)
        {
            using (var client = GetClient(region))
            {
                var request = new DeleteSnapshotRequest();
                request.SnapshotId = snapshotId;
                var response = client.DeleteSnapshot(request);
                return response.ResponseMetadata.RequestId;
            }
        }



        public static CopyImageResponse CopyImage(RegionEndpoint destinationRegion, string imageName, string imageDescription, string sourceImageId, string sourceRegion)
        {
            using (var client = GetClient(destinationRegion))
            {
                var request = new CopyImageRequest();
                if (!string.IsNullOrEmpty(imageName)) request.Name = imageName;
                if (!string.IsNullOrEmpty(imageDescription)) request.Description = imageDescription;
                request.SourceImageId = sourceImageId;
                request.SourceRegion = sourceRegion;
                return client.CopyImage(request);
            }
        }

        public static CopySnapshotResponse CopySnapshot(RegionEndpoint destinationRegion, string snapshotDescription, string sourceSnapshotId, string sourceRegion)
        {
            using (var client = GetClient(destinationRegion))
            {
                var request = new CopySnapshotRequest();
                if (!string.IsNullOrEmpty(snapshotDescription)) request.Description = snapshotDescription;
                request.SourceSnapshotId = sourceSnapshotId;
                request.SourceRegion = sourceRegion;
                return client.CopySnapshot(request);
            }
        }
    }
}
