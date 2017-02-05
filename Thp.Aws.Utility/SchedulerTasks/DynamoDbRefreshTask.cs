using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedulerEngine;
using Amazon;
using Amazon.DynamoDB.Model;

namespace Thp.Har.Utility.SchedulerTasks {
    public class AwsControllerScheduledOnOff {
        public const string TABLE_NAME = "AwsControllerData";

        public const string RECORD_DOMAIN = "EC2";
        public const string RECORD_TYPE = "OnOff";
        public const string RECORD_ID = "1";
        public const string FREQUENCY = "Daily";

        public string InstanceIdList { get; set; }
        public bool Enabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime StopOn { get; set; }
        public string DaysOfWeek { get; set; }

        public static AwsControllerScheduledOnOff GetRecord(RegionEndpoint selectedRegion) {
            var request = new Amazon.DynamoDB.Model.GetItemRequest() {
                TableName = AwsControllerScheduledOnOff.TABLE_NAME,
                Key = new Key() { HashKeyElement = new AttributeValue() { S = AwsControllerScheduledOnOff.RECORD_ID } }
            };

            var response = AmazonDynamoDbUtility.GetItem(selectedRegion, request);

            if (response != null && response.GetItemResult != null && response.GetItemResult.Item != null) {
                return ParseRecord(response.GetItemResult.Item);
            }

            return null;
        }

        public static bool SaveRecord(RegionEndpoint selectedRegion, AwsControllerScheduledOnOff record) {
            var item = new Dictionary<string, AttributeValue>();

            item.Add("RecordId", new AttributeValue { S = AwsControllerScheduledOnOff.RECORD_ID });
            item.Add("RecordDomain", new AttributeValue { S = AwsControllerScheduledOnOff.RECORD_DOMAIN });
            item.Add("RecordType", new AttributeValue { S = AwsControllerScheduledOnOff.RECORD_TYPE });
            item.Add("Frequency", new AttributeValue { S = AwsControllerScheduledOnOff.FREQUENCY });
            item.Add("Enabled", new AttributeValue { S = record.Enabled == true ? "True" : "False" });
            item.Add("RecordData", new AttributeValue { S = record.InstanceIdList });
            item.Add("CreatedBy", new AttributeValue { S = record.CreatedBy });
            item.Add("CreatedOn", new AttributeValue { N = record.CreatedOn.ToUniversalTime().Ticks.ToString() });
            item.Add("StartOn", new AttributeValue { N = record.StartOn.ToUniversalTime().Ticks.ToString() });
            item.Add("StopOn", new AttributeValue { N = record.StopOn.ToUniversalTime().Ticks.ToString() });
            item.Add("DaysOfWeek", new AttributeValue { S = record.DaysOfWeek });

            var request = new Amazon.DynamoDB.Model.PutItemRequest() {
                TableName = AwsControllerScheduledOnOff.TABLE_NAME,
                Item = item
            };

            return AmazonDynamoDbUtility.PutItem(selectedRegion, request).PutItemResult != null;
        }

        public static AwsControllerScheduledOnOff ParseRecord(Dictionary<string, AttributeValue> input) {
            AwsControllerScheduledOnOff result = null;

            if (input != null) {
                result = new AwsControllerScheduledOnOff();

                string instanceIdList = null;
                string enabled = null;
                string daysOfWeek = null;
                string createdBy = null;
                DateTime createdOn = DateTime.MinValue;
                DateTime startOn = DateTime.MinValue;
                DateTime stopOn = DateTime.MinValue;

                if (input.ContainsKey("RecordData")) instanceIdList = input["RecordData"].S;
                if (input.ContainsKey("Enabled")) enabled = input["Enabled"].S;
                if (input.ContainsKey("DaysOfWeek")) daysOfWeek = input["DaysOfWeek"].S;
                if (input.ContainsKey("CreatedBy")) createdBy = input["CreatedBy"].S;
                if (input.ContainsKey("CreatedOn")) createdOn = new DateTime(long.Parse(input["CreatedOn"].N), DateTimeKind.Utc).ToLocalTime();
                if (input.ContainsKey("StartOn")) startOn = new DateTime(long.Parse(input["StartOn"].N), DateTimeKind.Utc).ToLocalTime();
                if (input.ContainsKey("StopOn")) stopOn = new DateTime(long.Parse(input["StopOn"].N), DateTimeKind.Utc).ToLocalTime();

                if (!string.IsNullOrEmpty(instanceIdList)) result.InstanceIdList = instanceIdList;
                if (!string.IsNullOrEmpty(enabled)) result.Enabled = enabled == "True" ? true : false;
                if (!string.IsNullOrEmpty(daysOfWeek)) result.DaysOfWeek = daysOfWeek;
                if (!string.IsNullOrEmpty(createdBy)) result.CreatedBy = createdBy;
                if (createdOn > DateTime.MinValue) result.CreatedOn = createdOn;
                if (startOn > DateTime.MinValue) result.StartOn = startOn;
                if (stopOn > DateTime.MinValue) result.StopOn = stopOn;
            }

            return result;
        }

        public static string GetCrontabDaysOfWeekString(string input) {
            if (!string.IsNullOrEmpty(input)) {
                string result = string.Empty;
                var tmp = input.Split(',');

                for (var i = 0; i < tmp.Length; i++) {
                    if (tmp[i].Equals("yes")) {
                        result += i.ToString();
                        result += ",";
                    }
                }

                if (result.Length == 0) {
                    result = "*";
                }

                return result.Trim(',');
            } else {
                return "*";
            }
        }
    }

    public class AwsControllerScheduledOnTask : ITask {
        public const string Name = "AwsControllerScheduledOnTask";
        private object Parameters = null;

        public void HandleConditionsMetEvent(object sender, ConditionsMetEventArgs e) {
            if (Parameters != null) {
                var tmp = Parameters as string;
                if (tmp != null) {
                    var csv = tmp.Split(',');
                    var list = new List<string>();
                    foreach (var item in csv) {
                        list.Add(item.Trim());
                    }

                    try {
                        AmazonEC2Utility.StartInstances(Thp.Har.Utility.CacheObject.Settings.DefaultRegionEndpoint, list);
                    } catch (Exception ex) {
                        LoggingUtility.Warning(ex);
                    }
                }
            }
        }

        public void Initialize(ScheduleDefinition schedule, object parameters) {
            Parameters = parameters;
        }

        public static void CreateSchedule(AwsControllerScheduledOnOff record) {
            var startOnCrontab = new CrontabParser();
            startOnCrontab.CrontabEntry = string.Format("{0} {1} * * {2}", record.StartOn.Minute, record.StartOn.Hour, AwsControllerScheduledOnOff.GetCrontabDaysOfWeekString(record.DaysOfWeek));
            var startOnSchedule = new TaskSchedulerEngine.Fluent.Schedule()
                .AtSeconds(record.StartOn.Second)
                .AtMinutes(startOnCrontab.Minutes.ToArray())
                .AtHours(startOnCrontab.Hours.ToArray())
                .AtDaysOfMonth(startOnCrontab.DaysOfMonth.ToArray())
                .AtDaysOfWeek(startOnCrontab.DaysOfWeek.ToArray())
                .WithLocalTime()
                .WithName(AwsControllerScheduledOnTask.Name)
                .Execute<AwsControllerScheduledOnTask>(record.InstanceIdList);
            SchedulerRuntime.AddSchedule(startOnSchedule);
        }
    }

    public class AwsControllerScheduledOffTask : ITask {
        public const string Name = "AwsControllerScheduledOffTask";
        private object Parameters = null;

        public void HandleConditionsMetEvent(object sender, ConditionsMetEventArgs e) {
            if (Parameters != null) {
                var tmp = Parameters as string;
                if (tmp != null) {
                    var csv = tmp.Split(',');
                    var list = new List<string>();
                    foreach (var item in csv) {
                        list.Add(item.Trim());
                    }

                    try {
                        AmazonEC2Utility.StopInstances(Thp.Har.Utility.CacheObject.Settings.DefaultRegionEndpoint, list);
                    } catch (Exception ex) {
                        LoggingUtility.Warning(ex);
                    }
                }
            }
        }

        public void Initialize(ScheduleDefinition schedule, object parameters) {
            Parameters = parameters;
        }

        public static void CreateSchedule(AwsControllerScheduledOnOff record) {
            var stopOnCrontab = new CrontabParser();
            stopOnCrontab.CrontabEntry = string.Format("{0} {1} * * {2}", record.StopOn.Minute, record.StopOn.Hour, AwsControllerScheduledOnOff.GetCrontabDaysOfWeekString(record.DaysOfWeek));
            var stopOnSchedule = new TaskSchedulerEngine.Fluent.Schedule()
                .AtSeconds(record.StopOn.Second)
                .AtMinutes(stopOnCrontab.Minutes.ToArray())
                .AtHours(stopOnCrontab.Hours.ToArray())
                .AtDaysOfMonth(stopOnCrontab.DaysOfMonth.ToArray())
                .AtDaysOfWeek(stopOnCrontab.DaysOfWeek.ToArray())
                .WithLocalTime()
                .WithName(AwsControllerScheduledOffTask.Name)
                .Execute<AwsControllerScheduledOffTask>(record.InstanceIdList);
            SchedulerRuntime.AddSchedule(stopOnSchedule);
        }
    }

    public class DynamoDbRefreshTask : ITask {
        public const string Name = "DynamoDbRefreshTask";
        private Dictionary<string, object> m_Parameters = null;
        private RegionEndpoint m_SelectedRegion = null;

        public void HandleConditionsMetEvent(object sender, ConditionsMetEventArgs e) {
            var newRecord = AwsControllerScheduledOnOff.GetRecord(m_SelectedRegion);

            if (newRecord != null) {
                AwsControllerScheduledOnOff originalRecord = null;

                if (m_Parameters != null) {
                    LoggingUtility.Debug(string.Format("DynamoDbRefreshTask has {0} parameters", m_Parameters.Count));
                    originalRecord = (AwsControllerScheduledOnOff)m_Parameters[AwsControllerScheduledOnOff.RECORD_ID];
                } else {
                    LoggingUtility.Debug(string.Format("DynamoDbRefreshTask does not have any parameter"));
                    originalRecord = new AwsControllerScheduledOnOff();
                }

                if (newRecord.CreatedOn > originalRecord.CreatedOn) {
                    var scheduleNameList = SchedulerRuntime.ListScheduleName();

                    foreach (var item in scheduleNameList) {
                        if (item.Equals(AwsControllerScheduledOnTask.Name)) {
                            SchedulerRuntime.DeleteSchedule(AwsControllerScheduledOnTask.Name);
                        } else if (item.Equals(AwsControllerScheduledOffTask.Name)) {
                            SchedulerRuntime.DeleteSchedule(AwsControllerScheduledOffTask.Name);
                        }
                    }

                    if (newRecord.Enabled) {
                        AwsControllerScheduledOnTask.CreateSchedule(newRecord);
                        AwsControllerScheduledOffTask.CreateSchedule(newRecord);
                    }

                    m_Parameters[AwsControllerScheduledOnOff.RECORD_ID] = newRecord;
                }
            }
        }

        public void Initialize(ScheduleDefinition schedule, object parameters) {
            if (parameters != null) {
                m_Parameters = parameters as Dictionary<string, object>;

                if (m_Parameters != null) {
                    if (m_Parameters.ContainsKey("SelectedRegion")) {
                        m_SelectedRegion = (RegionEndpoint)m_Parameters["SelectedRegion"];
                    } else {
                        m_SelectedRegion = Thp.Har.Utility.CacheObject.Settings.DefaultRegionEndpoint;
                    }
                }
            }
        }
    }
}