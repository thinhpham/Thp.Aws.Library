using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Amazon.EC2.Model;
using System.Net;
using Amazon;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Thp.Har.Utility {
    public class ApiUtility : IHttpHandler {
        public bool IsReusable {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context) {
            var localPath = context.Request.Url.PathAndQuery;

            if (localPath.StartsWith("/e1", StringComparison.OrdinalIgnoreCase)) {
                ProcessE1(context);
            } else if (localPath.StartsWith("/api/github/callback", StringComparison.OrdinalIgnoreCase)) {
                GitHubCallback(context);
            } else if (localPath.StartsWith("/api/github/update", StringComparison.OrdinalIgnoreCase)) {
                GitHubUpdate(context);
            } else {
                context.Response.AddHeader("Content-Type", "application/json");
                context.Response.Write("{\"success\": false, \"msg\": \"Nothing to do\"}");
            }
        }

        private void ProcessE1(HttpContext context) {
            var localPath = context.Request.Url.PathAndQuery;
            context.Response.ClearHeaders();

            try {
                var url = localPath.Substring(3);
                var newPath = "http://harpictures.marketlinx.com" + url;
                var wc = new WebClient();
                var data = wc.DownloadData(newPath);

                if (data != null && data.LongLength > 0) {
                    foreach (var key in wc.ResponseHeaders.AllKeys) {
                        context.Response.AddHeader(key, wc.ResponseHeaders[key]);
                    }
                    context.Response.BinaryWrite(data);
                }

                LoggingUtility.Debug(url);
            } catch (System.Net.WebException ex) {
                HttpStatusCode statusCode = ((System.Net.HttpWebResponse)ex.Response).StatusCode;
                context.Response.StatusCode = (int)statusCode;
                LoggingUtility.Debug(ex);
            } catch (Exception ex) {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.StatusDescription = ex.Message;
                LoggingUtility.Warning(ex);
            }
        }

        private void GitHubCallback(HttpContext context) {
            LoggingUtility.Info("Running Github callback API");

            var updateNeeded = false;
            var updateCount = 0;
            var updateList = new List<string>();

            var target = context.Request["target"];
            var list = context.Request["list"];
            string[] instanceList = null;
            if (!string.IsNullOrEmpty(list)) {
                instanceList = list.Split(',');
            }

            try {
                LoggingUtility.Info("Calling AmazonEC2Utility.DescribeInstances() to download a list of reservations");
                var reservations = AmazonEC2Utility.DescribeInstances().DescribeInstancesResult.Reservation;

                if (reservations.Count > 0) {
                    foreach (Reservation reservation in reservations) {
                        var instance = reservation.RunningInstance.FirstOrDefault();
                        updateNeeded = false;

                        try {
                            var tag = AmazonEC2Utility.GetTagByName(instance, "Type", "aws:autoscaling:groupName");

                            if (!string.IsNullOrEmpty(tag)) {
                                if ((target == CommonUtility.UPDATE_SOFTWARE_ALL || target == CommonUtility.UPDATE_SOFTWARE_MEMBERS) && CommonUtility.UPDATE_SOFTWARE_TAGS_MEMBERS.Contains(tag)) {
                                    updateNeeded = true;
                                } else if ((target == CommonUtility.UPDATE_SOFTWARE_ALL || target == CommonUtility.UPDATE_SOFTWARE_SEARCH) && CommonUtility.UPDATE_SOFTWARE_TAGS_SEARCH.Contains(tag)) {
                                    updateNeeded = true;
                                } else if ((target == CommonUtility.UPDATE_SOFTWARE_ALL || target == CommonUtility.UPDATE_SOFTWARE_WWW) && CommonUtility.UPDATE_SOFTWARE_TAGS_WWW.Contains(tag)) {
                                    updateNeeded = true;
                                } else if (target == CommonUtility.UPDATE_SOFTWARE_INSTANCE) {
                                    if (instanceList.Contains(instance.InstanceId)) {
                                        updateNeeded = true;
                                    }
                                }
                            }

                            if (updateNeeded) {
                                updateCount++;
                                updateList.Add(instance.InstanceId);
                                LoggingUtility.Info(string.Format("Calling instanceId {0}'s Github update API", instance.InstanceId));

                                var url = string.Format("http://{0}:8080/api/github/update", instance.PrivateIpAddress);
                                var wc = new WebClient();
                                wc.DownloadStringAsync(new Uri(url));
                            }
                        } catch (Exception ex) {
                            LoggingUtility.Warning(string.Format("Failed calling instanceId {0}'s Github update API. Error: {1}", instance.InstanceId, ex));
                        }
                    }
                } else {
                    LoggingUtility.Info("No reservation found when calling AmazonEC2Utility.DescribeInstances()");
                }

                context.Response.AddHeader("Content-Type", "application/json");
                context.Response.Write("{\"success\": true, \"count\": " + updateCount.ToString() + ", \"list\": \"" + string.Join(",", updateList.ToArray()) + "\"}");
            } catch (Exception ex) {
                LoggingUtility.Warning(ex);
                context.Response.AddHeader("Content-Type", "application/json");
                context.Response.Write("{\"success\": false, \"msg\": \"" + ex.Message + "\"}");
            }
        }

        private void GitHubUpdate(HttpContext context) {
            LoggingUtility.Info("Running Github update API");

            try {
                var github = new GitHubUtility();
                github.Execute();

                context.Response.AddHeader("Content-Type", "application/json");
                context.Response.Write("{\"success\": true}");
            } catch (Exception ex) {
                LoggingUtility.Warning(ex);
                context.Response.AddHeader("Content-Type", "application/json");
                context.Response.Write("{\"success\": false, \"msg\": " + ex.Message + "}");
            }
        }

        public static void DisplayHelp(HttpContext context) {
            var url = context.Request.Url;

            context.Response.Write("Options:<br />");
            context.Response.Write("<ul>");

            context.Response.Write(string.Format("<li><a href='{0}?q=ip' target='_'>{0}?q=ip</a></li>", context.Request.Url));
            context.Response.Write(string.Format("<li><a href='{0}?q=info' target='_'>{0}?q=info</a></li>", context.Request.Url));
            context.Response.Write(string.Format("<li><a href='{0}?q=instances' target='_'>{0}?q=instances</a></li>", context.Request.Url));
            context.Response.Write(string.Format("<li><a href='{0}?q=regions' target='_'>{0}?q=regions</a></li>", context.Request.Url));
            context.Response.Write(string.Format("<li><a href='{0}?q=path' target='_'>{0}?q=path</a></li>", context.Request.Url));

            context.Response.Write("</ul>");
        }

        public static void DisplayIp(HttpContext context) {
            var ipList = NetworkUtility.GetCurrentIp();
            for (var i = 0; i < ipList.Count; i++) {
                context.Response.Write(string.Format("ip address #{0}: {1}<br />", i, ipList[i]));
            }
        }

        public static void DisplayInfo(HttpContext context) {
            //var instanceId = "i-810448f0";

            var instanceId = context.Request["instanceId"];
            if (string.IsNullOrEmpty(instanceId)) {
                instanceId = AmazonEC2Utility.GetCurrentInstanceId();
            }

            var regionId = context.Request["regionId"];

            if (!string.IsNullOrEmpty(instanceId)) {
                var me = AmazonEC2Utility.GetInstance(instanceId);

                if (me != null) {
                    context.Response.Write("Instance information:<br />");
                    context.Response.Write("<ul>");
                    context.Response.Write(string.Format("<li>MachineName: {0}</li>", Environment.MachineName));
                    context.Response.Write(string.Format("<li>OSVersion: {0}</li>", Environment.OSVersion));
                    context.Response.Write(string.Format("<li>Version: {0}</li>", Environment.Version));
                    context.Response.Write(string.Format("<li>Is64BitOperatingSystem: {0}</li>", Environment.Is64BitOperatingSystem));
                    context.Response.Write(string.Format("<li>Is64BitProcess: {0}</li>", Environment.Is64BitProcess));
                    context.Response.Write(string.Format("<li>ProcessorCount: {0}</li>", Environment.ProcessorCount));
                    context.Response.Write(string.Format("<li>UserDomainName: {0}</li>", Environment.UserDomainName));

                    var computer = new Microsoft.VisualBasic.Devices.ComputerInfo();
                    ulong bytesPerMebibyte = (1 << 20);
                    context.Response.Write(string.Format("<li>TotalPhysicalMemory: {0}</li>", (computer.TotalPhysicalMemory / bytesPerMebibyte) + " MB"));

                    context.Response.Write(string.Format("<li>UserName: {0}</li>", Environment.UserName));
                    context.Response.Write(string.Format("<li>InstanceId: {0}</li>", me.InstanceId));
                    context.Response.Write(string.Format("<li>InstanceState: {0}</li>", me.InstanceState.Name));
                    context.Response.Write(string.Format("<li>PublicIpAddress: {0}</li>", me.IpAddress));
                    context.Response.Write(string.Format("<li>PrivateIpAddress: {0}</li>", me.PrivateIpAddress));
                    context.Response.Write(string.Format("<li>PublicDnsName: {0}</li>", me.PublicDnsName));
                    context.Response.Write(string.Format("<li>PrivateDnsName: {0}</li>", me.PrivateDnsName));
                    context.Response.Write(string.Format("<li>Architecture: {0}</li>", me.Architecture));
                    context.Response.Write(string.Format("<li>EbsOptimized: {0}</li>", me.EbsOptimized));
                    context.Response.Write(string.Format("<li>ImageId: {0}</li>", me.ImageId));
                    context.Response.Write(string.Format("<li>LaunchTime: {0}</li>", me.LaunchTime));
                    context.Response.Write(string.Format("<li>RootDeviceName: {0}</li>", me.RootDeviceName));
                    context.Response.Write(string.Format("<li>RootDeviceType: {0}</li>", me.RootDeviceType));
                    context.Response.Write(string.Format("<li>SubnetId: {0}</li>", me.SubnetId));
                    context.Response.Write(string.Format("<li>VirtualizationType: {0}</li>", me.VirtualizationType));
                    context.Response.Write(string.Format("<li>VpcId: {0}</li>", me.VpcId));
                    context.Response.Write(string.Format("<li>AvailabilityZone: {0}</li>", me.Placement.AvailabilityZone));
                    context.Response.Write(string.Format("<li>Tenancy: {0}</li>", me.Placement.Tenancy));

                    if (me.Tag.Count > 0) {
                        string tag = string.Empty;
                        for (int i = 0; i < me.Tag.Count; i++) {
                            if (i > 0) {
                                tag += "; ";
                            }

                            tag += me.Tag[i].Key + ": " + me.Tag[i].Value;
                        }

                        context.Response.Write(string.Format("<li>Tag: {0}</li>", tag));
                    }

                    context.Response.Write("</ul>");
                }
            } else {
                context.Response.Write("No instanceId to report");
            }
        }

        public static void DisplayPath(HttpContext context) {
            var req = context.Request;

            context.Response.Write("<ul>");
            context.Response.Write(string.Format("<li>ApplicationPath: {0}</li>", req.ApplicationPath));
            context.Response.Write(string.Format("<li>AppRelativeCurrentExecutionFilePath: {0}</li>", req.AppRelativeCurrentExecutionFilePath));
            context.Response.Write(string.Format("<li>CurrentExecutionFilePath: {0}</li>", req.CurrentExecutionFilePath));
            context.Response.Write(string.Format("<li>CurrentExecutionFilePathExtension: {0}</li>", req.CurrentExecutionFilePathExtension));
            context.Response.Write(string.Format("<li>FilePath: {0}</li>", req.FilePath));
            context.Response.Write(string.Format("<li>Path: {0}</li>", req.Path));
            context.Response.Write(string.Format("<li>PhysicalApplicationPath: {0}</li>", req.PhysicalApplicationPath));
            context.Response.Write(string.Format("<li>PhysicalPath: {0}</li>", req.PhysicalPath));
            context.Response.Write(string.Format("<li>RawUrl: {0}</li>", req.RawUrl));
            context.Response.Write(string.Format("<li>Url: {0}</li>", req.Url));
            context.Response.Write("</ul>");
        }

        public static void TestUrl(HttpContext context) {
            var count = 1;
            var count_q = context.Request["count"];
            if (!string.IsNullOrEmpty(count_q)) {
                count = int.Parse(count_q);
            }

            var url = context.Request["testUrl"];

            if (!string.IsNullOrEmpty(url)) {
                var client = new WebClient();

                context.Response.Write("Testing url. Valid options: testUrl=URL_VALUE, count=COUNT_VALUE<br />");
                context.Response.Write("<ul>");
                for (int i = 0; i < count; i++) {
                    var content = client.DownloadString(url);

                    if (!string.IsNullOrEmpty(content)) {
                        context.Response.Write(string.Format("<li>{0}</li>", context.Server.HtmlEncode(content)));
                    }
                }
                context.Response.Write("</ul>");
            } else {
                context.Response.Write("No url to test");
            }
        }

        public static void DescribeInstances(HttpContext context) {
            List<Reservation> instances = AmazonEC2Utility.DescribeInstances().DescribeInstancesResult.Reservation;
            context.Response.Write("Reservation list:<br />");
            context.Response.Write("<ul>");

            foreach (var instance in instances) {
                context.Response.Write("<li>");
                context.Response.Write(string.Format("ReservationId: {0}, OwnerId: {1}, Running instances:<br />", instance.ReservationId, instance.OwnerId));

                var runningInstances = instance.RunningInstance;
                context.Response.Write("<ol>");
                foreach (var me in runningInstances) {
                    context.Response.Write("<li>");
                    context.Response.Write("<ul>");
                    context.Response.Write(string.Format("<li>InstanceId: {0}</li>", me.InstanceId));
                    context.Response.Write(string.Format("<li>InstanceState: {0}</li>", me.InstanceState.Name));
                    context.Response.Write(string.Format("<li>PublicIpAddress: {0}</li>", me.IpAddress));
                    context.Response.Write(string.Format("<li>PrivateIpAddress: {0}</li>", me.PrivateIpAddress));
                    context.Response.Write(string.Format("<li>PublicDnsName: {0}</li>", me.PublicDnsName));
                    context.Response.Write(string.Format("<li>PrivateDnsName: {0}</li>", me.PrivateDnsName));
                    context.Response.Write(string.Format("<li>Architecture: {0}</li>", me.Architecture));
                    context.Response.Write(string.Format("<li>EbsOptimized: {0}</li>", me.EbsOptimized));
                    context.Response.Write(string.Format("<li>ImageId: {0}</li>", me.ImageId));
                    context.Response.Write(string.Format("<li>LaunchTime: {0}</li>", me.LaunchTime));
                    context.Response.Write(string.Format("<li>RootDeviceName: {0}</li>", me.RootDeviceName));
                    context.Response.Write(string.Format("<li>RootDeviceType: {0}</li>", me.RootDeviceType));
                    context.Response.Write(string.Format("<li>SubnetId: {0}</li>", me.SubnetId));
                    context.Response.Write(string.Format("<li>VirtualizationType: {0}</li>", me.VirtualizationType));
                    context.Response.Write(string.Format("<li>VpcId: {0}</li>", me.VpcId));
                    context.Response.Write(string.Format("<li>AvailabilityZone: {0}</li>", me.Placement.AvailabilityZone));
                    context.Response.Write(string.Format("<li>Tenancy: {0}</li>", me.Placement.Tenancy));

                    if (me.Tag.Count > 0) {
                        string tag = string.Empty;
                        for (int i = 0; i < me.Tag.Count; i++) {
                            if (i > 0) {
                                tag += "; ";
                            }

                            tag += me.Tag[i].Key + ": " + me.Tag[i].Value;
                        }

                        context.Response.Write(string.Format("<li>Tag: {0}</li>", tag));
                    }

                    context.Response.Write("</ul>");
                    context.Response.Write("</li>");
                }
                context.Response.Write("</ol>");
                context.Response.Write("</li>");
            }

            context.Response.Write("</ul>");
        }

        public static void DescribeRegions(HttpContext context) {
            context.Response.Write("Region list:<br />");
            context.Response.Write("<ul>");
            foreach (var region in RegionEndpoint.EnumerableAllRegions) {
                context.Response.Write(string.Format("<li>DisplayName: {0}<br />SystemName: {1}</li>", region.DisplayName, region.SystemName));
            }
            context.Response.Write("</ul>");
        }
    }
}
