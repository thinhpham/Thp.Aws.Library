using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Thp.Har.Utility;

namespace AwsController {
    public partial class AddEditASAlarmForm : Form {
        public Amazon.RegionEndpoint SelectedRegion { get; set; }
        public Amazon.CloudWatch.Model.MetricAlarm ItemToEdit { get; set; }

        public AddEditASAlarmForm() {
            InitializeComponent();

            m_guiNamespace.SelectedIndexChanged += new EventHandler(m_guiNamespace_SelectedIndexChanged);
        }

        void m_guiNamespace_SelectedIndexChanged(object sender, EventArgs e) {
            if (m_guiNamespace.SelectedValue.ToString() == AmazonAutoScalingUtility.AS_ALARM_NAMESPACE_EC2) {
                m_guiMetric.DataSource = AmazonAutoScalingUtility.AS_ALARM_METRIC_EC2;
            } else if (m_guiNamespace.SelectedValue.ToString() == AmazonAutoScalingUtility.AS_ALARM_NAMESPACE_ELB) {
                m_guiMetric.DataSource = AmazonAutoScalingUtility.AS_ALARM_METRIC_ELB;
            }

            if (ItemToEdit != null) {
                if (m_guiNamespace.SelectedValue.ToString() == AmazonAutoScalingUtility.AS_ALARM_NAMESPACE_EC2) {
                    for (int i = 0; i < AmazonAutoScalingUtility.AS_ALARM_METRIC_EC2.Length; i++) {
                        if (ItemToEdit.MetricName == AmazonAutoScalingUtility.AS_ALARM_METRIC_EC2[i]) {
                            m_guiMetric.SelectedIndex = i;
                            break;
                        }
                    }
                } else if (m_guiNamespace.SelectedValue.ToString() == AmazonAutoScalingUtility.AS_ALARM_NAMESPACE_ELB) {
                    for (int i = 0; i < AmazonAutoScalingUtility.AS_ALARM_METRIC_ELB.Length; i++) {
                        if (ItemToEdit.MetricName == AmazonAutoScalingUtility.AS_ALARM_METRIC_ELB[i]) {
                            m_guiMetric.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void AddEditASAlarm_Load(object sender, EventArgs e) {
            LoadControls();
        }

        private void LoadControls() {
            m_guiDimension.DisplayMember = "Value";
            m_guiDimension.ValueMember = "Value";

            if (ItemToEdit == null) {
                LoadControlsForAdd();
            } else {
                LoadControlsForEdit();
            }
        }

        private void LoadControlsForAdd() {
            Cursor = Cursors.WaitCursor;

            m_guiActionsEnabled.Checked = true;
            m_guiNamespace.DataSource = AmazonAutoScalingUtility.AS_ALARM_NAMESPACES;
            m_guiStatistic.DataSource = AmazonAutoScalingUtility.AS_ALARM_STATISTIC_TYPES;
            m_guiComparision.DataSource = AmazonAutoScalingUtility.AS_ALARM_COMPARISON_OPERATORS;

            var thread = new Thread(new ThreadStart(() => {
                var alarmAction = AmazonAutoScalingUtility.DescribeScalingPolicies(SelectedRegion, null, null).DescribePoliciesResult.ScalingPolicies;

                Invoke(new MethodInvoker(() => {
                    m_guiAlarmAction.DisplayMember = "PolicyName";
                    m_guiAlarmAction.ValueMember = "PolicyARN";
                    m_guiAlarmAction.DataSource = alarmAction;

                    Cursor = Cursors.Default;
                }));
            }));
            thread.Start();
        }

        private void LoadControlsForEdit() {
            Cursor = Cursors.WaitCursor;

            m_guiActionsEnabled.Checked = ItemToEdit.ActionsEnabled;
            m_guiName.Text = ItemToEdit.AlarmName;
            m_guiThreshold.Text = ItemToEdit.Threshold.ToString();
            m_guiPeriod.Text = ItemToEdit.Period.ToString();
            m_guiEvaluationPeriod.Text = ItemToEdit.EvaluationPeriods.ToString();

            m_guiNamespace.DataSource = AmazonAutoScalingUtility.AS_ALARM_NAMESPACES;
            for (int i = 0; i < AmazonAutoScalingUtility.AS_ALARM_NAMESPACES.Length; i++) {
                if (ItemToEdit.Namespace == AmazonAutoScalingUtility.AS_ALARM_NAMESPACES[i]) {
                    m_guiNamespace.SelectedIndex = i;
                    break;
                }
            }

            m_guiStatistic.DataSource = AmazonAutoScalingUtility.AS_ALARM_STATISTIC_TYPES;
            for (int i = 0; i < AmazonAutoScalingUtility.AS_ALARM_STATISTIC_TYPES.Length; i++) {
                if (ItemToEdit.Statistic == AmazonAutoScalingUtility.AS_ALARM_STATISTIC_TYPES[i]) {
                    m_guiStatistic.SelectedIndex = i;
                    break;
                }
            }

            m_guiComparision.DataSource = AmazonAutoScalingUtility.AS_ALARM_COMPARISON_OPERATORS;
            for (int i = 0; i < AmazonAutoScalingUtility.AS_ALARM_COMPARISON_OPERATORS.Length; i++) {
                if (ItemToEdit.ComparisonOperator == AmazonAutoScalingUtility.AS_ALARM_COMPARISON_OPERATORS[i]) {
                    m_guiComparision.SelectedIndex = i;
                    break;
                }
            }

            foreach (var dimention in ItemToEdit.Dimensions) {
                m_guiDimension.Items.Add(dimention);
            }

            var thread = new Thread(new ThreadStart(() => {
                var scalingPolicies = AmazonAutoScalingUtility.DescribeScalingPolicies(SelectedRegion, null, null).DescribePoliciesResult.ScalingPolicies;
                scalingPolicies.Insert(0, new Amazon.AutoScaling.Model.ScalingPolicy());

                Invoke(new MethodInvoker(() => {
                    if (ItemToEdit.AlarmActions != null && ItemToEdit.AlarmActions.Count > 0) {
                        m_guiAlarmAction.DisplayMember = "PolicyName";
                        m_guiAlarmAction.ValueMember = "PolicyARN";
                        m_guiAlarmAction.DataSource = scalingPolicies;
                        m_guiAlarmAction.SelectedIndex = -1;

                        for (int i = 0; i < scalingPolicies.Count; i++) {
                            if (scalingPolicies[i].PolicyARN == ItemToEdit.AlarmActions[0]) {
                                m_guiAlarmAction.SelectedIndex = i;
                                break;
                            }
                        }
                    }

                    Cursor = Cursors.Default;
                }));
            }));
            thread.Start();
        }

        private void m_guiAddDimension_Click(object sender, EventArgs e) {
            var form = new AddEditASAlarmDimensionForm();
            form.SelectedRegion = SelectedRegion;
            form.ShowDialog(this);

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                m_guiDimension.Items.Add(form.ItemToEdit);
            }
        }

        private void m_guiEditDimension_Click(object sender, EventArgs e) {
            if (m_guiDimension.SelectedItem != null) {
                var form = new AddEditASAlarmDimensionForm();
                form.SelectedRegion = SelectedRegion;
                form.ItemToEdit = m_guiDimension.SelectedItem as Amazon.CloudWatch.Model.Dimension;
                form.ShowDialog(this);

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                    var idx = -1;
                    for (int i = 0; i < m_guiDimension.Items.Count; i++) {
                        var item = m_guiDimension.Items[i] as Amazon.CloudWatch.Model.Dimension;
                        if (item.Name == form.ItemToEdit.Name) {
                            idx = i;
                        }
                    }

                    if (idx > -1) {
                        m_guiDimension.Items.RemoveAt(idx);
                        m_guiDimension.Items.Add(form.ItemToEdit);
                    }
                }
            } else {
                MessageBox.Show("Nothing was selected to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_guiDeleteDimension_Click(object sender, EventArgs e) {
            var selectedRow = m_guiDimension.SelectedItem;

            if (selectedRow != null) {
                if (MessageBox.Show("Are you sure you want to delete the selected item(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    m_guiDimension.Items.Remove(selectedRow);
                    MessageBox.Show("Item was deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                MessageBox.Show("Nothing was selected for deletion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_guiOK_Click(object sender, EventArgs e) {
            if (m_guiName.Text.Length > 0) {
                var actionsEnabled = m_guiActionsEnabled.Checked;
                var name = m_guiName.Text;
                var alarmNamespace = m_guiNamespace.SelectedValue.ToString();
                var metricName = m_guiMetric.SelectedValue.ToString();
                var statistic = m_guiStatistic.SelectedValue.ToString();
                var comparisionOperator = m_guiComparision.SelectedValue.ToString();
                var threshold = int.Parse(m_guiThreshold.Text);
                var period = int.Parse(m_guiPeriod.Text);
                var evaluationPeriods = int.Parse(m_guiEvaluationPeriod.Text);

                var alarmActions = new List<string>();
                alarmActions.Add(m_guiAlarmAction.SelectedValue.ToString());

                var alarmDimension = new List<Amazon.CloudWatch.Model.Dimension>();
                foreach (Amazon.CloudWatch.Model.Dimension dimension in m_guiDimension.Items) {
                    alarmDimension.Add(dimension);
                }

                AmazonCloudWatchUtility.PutMetricAlarm(SelectedRegion, actionsEnabled, name, null,
                    alarmActions, null, null, alarmDimension, comparisionOperator, evaluationPeriods,
                    metricName, alarmNamespace, period, statistic, threshold, null);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            } else {
                MessageBox.Show("Name is required");
            }
        }

        private void m_guiCancel_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
