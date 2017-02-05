using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Thp.Har.Utility {
    public class AmazonCloudWatchUtility {
        public static AmazonCloudWatch GetClient(RegionEndpoint region) {
            var config = new AmazonCloudWatchConfig();

            if (region != null) {
                config.RegionEndpoint = region;
            }

            return AWSClientFactory.CreateAmazonCloudWatchClient(CacheObject.Settings.AWSAccessKey, CacheObject.Settings.AWSSecretKey, config);
        }

        public static DescribeAlarmsResponse DescribeAlarms(RegionEndpoint regionEndPoint, List<string> alarmNames, string actionPrefix, string alarmNamePrefix, string stateValue) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DescribeAlarmsRequest();
                if (alarmNames != null) request.AlarmNames = alarmNames;
                if (!string.IsNullOrEmpty(actionPrefix)) request.ActionPrefix = actionPrefix;
                if (!string.IsNullOrEmpty(alarmNamePrefix)) request.AlarmNamePrefix = alarmNamePrefix;
                if (!string.IsNullOrEmpty(stateValue)) request.StateValue = stateValue;
                return client.DescribeAlarms(request);
            }
        }

        public static DeleteAlarmsResponse DeleteAlarms(RegionEndpoint regionEndPoint, List<string> alarmNames) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DeleteAlarmsRequest();
                request.AlarmNames = alarmNames;
                return client.DeleteAlarms(request);
            }
        }

        public static SetAlarmStateResponse SetAlarmState(RegionEndpoint regionEndPoint, string alarmName, string stateReason, string stateReasonData, string stateValue) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new SetAlarmStateRequest();
                request.AlarmName = alarmName;
                request.StateReason = stateReason;
                request.StateReasonData = stateReasonData;
                request.StateValue = stateValue;
                return client.SetAlarmState(request);
            }
        }

        public static EnableAlarmActionsResponse EnableAlarmActions(RegionEndpoint regionEndPoint, List<string> alarmNames) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new EnableAlarmActionsRequest();
                request.AlarmNames = alarmNames;
                return client.EnableAlarmActions(request);
            }
        }

        public static DisableAlarmActionsResponse DisableAlarmActions(RegionEndpoint regionEndPoint, List<string> alarmNames) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DisableAlarmActionsRequest();
                request.AlarmNames = alarmNames;
                return client.DisableAlarmActions(request);
            }
        }

        public static DescribeAlarmHistoryResponse DescribeAlarmHistory(RegionEndpoint regionEndPoint, string alarmName, DateTime startDate, DateTime endDate, string historyItemType) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new DescribeAlarmHistoryRequest();
                request.AlarmName = alarmName;
                request.StartDate = startDate;
                request.EndDate = endDate;
                if (!string.IsNullOrEmpty(historyItemType)) request.HistoryItemType = historyItemType;
                return client.DescribeAlarmHistory(request);
            }
        }

        public static PutMetricAlarmResponse PutMetricAlarm(RegionEndpoint regionEndPoint, bool actionsEnabled, string alarmName, string alarmDescription, 
            List<string> alarmActions, List<string> insufficientDataActions, List<string> OKActions, 
            List<Dimension> dimensions, string comparisonOperator, int evaluationPeriods, 
            string metricName, string alarmNamespace, int period, string statistic, double threshold, string unit) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new PutMetricAlarmRequest();
                request.ActionsEnabled = actionsEnabled;
                request.AlarmName = alarmName;
                if (!string.IsNullOrEmpty(alarmDescription)) request.AlarmDescription = alarmDescription;
                if (alarmActions != null) request.AlarmActions = alarmActions;
                if (!string.IsNullOrEmpty(comparisonOperator)) request.ComparisonOperator = comparisonOperator;
                if (dimensions != null) request.Dimensions = dimensions;
                if (evaluationPeriods > int.MinValue) request.EvaluationPeriods = evaluationPeriods;
                if (insufficientDataActions != null) request.InsufficientDataActions = insufficientDataActions;
                if (!string.IsNullOrEmpty(metricName)) request.MetricName = metricName;
                if (!string.IsNullOrEmpty(alarmNamespace)) request.Namespace = alarmNamespace;
                if (OKActions != null) request.OKActions = OKActions;
                if (period > int.MinValue) request.Period = period;
                if (!string.IsNullOrEmpty(statistic)) request.Statistic = statistic;
                if (threshold > double.MinValue) request.Threshold = threshold;
                if (!string.IsNullOrEmpty(unit)) request.Unit = unit;
                return client.PutMetricAlarm(request);
            }
        }

        public static PutMetricDataResponse PutMetricData(RegionEndpoint regionEndPoint, string alarmNamespace, List<MetricDatum> metricData) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new PutMetricDataRequest();
                request.MetricData = metricData;
                request.Namespace = alarmNamespace;
                return client.PutMetricData(request);
            }
        }

        public static ListMetricsResponse ListMetrics(RegionEndpoint regionEndPoint, string metricName, string alarmNamespace, List<DimensionFilter> dimensions) {
            using (var client = GetClient(regionEndPoint)) {
                var request = new ListMetricsRequest();
                if (!string.IsNullOrEmpty(metricName)) request.MetricName = metricName;
                if (!string.IsNullOrEmpty(alarmNamespace)) request.Namespace = alarmNamespace;
                if (dimensions != null) request.Dimensions = dimensions;
                return client.ListMetrics(request);
            }
        }
    }
}
