using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Amazon;
using Amazon.EC2.Model;
using Thp.Har.Utility;

namespace AwsController {
    public partial class MainForm {
        private const string TAB_AS = "m_guiTabAS";
        private const string TAB_AS_LAUNCH_CONFIGURATION = "m_guiTabASLaunchConfiguration";
        private const string TAB_AS_GROUP = "m_guiTabASGroup";
        private const string TAB_AS_POLICY = "m_guiTabASPolicy";
        private const string TAB_AS_ALARM = "m_guiTabASAlarm";
        private const string TAB_AS_SCHEDULE = "m_guiTabASSchedule";
        private const string TAB_AS_INSTANCE = "m_guiTabASInstance";
        private const string TAB_AS_ACTIVITY = "m_guiTabASActivity";



        private void MainFormASTab_Constructor() {
            m_guiTabASMain.SelectedIndexChanged += new EventHandler(m_guiTabASMain_SelectedIndexChanged);

            m_guiASRefreshLaunchConfiguration.Click += new EventHandler(m_guiASRefreshLaunchConfiguration_Click);
            m_guiASAddLaunchConfiguration.Click += new EventHandler(m_guiASAddLaunchConfiguration_Click);
            m_guiASDeleteLaunchConfiguration.Click += new EventHandler(m_guiASDeleteLaunchConfiguration_Click);
            m_guiASLaunchConfigurationGrid.AutoGenerateColumns = false;
            m_guiASLaunchConfigurationGrid.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(m_guiASLaunchConfigurationGrid_DataBindingComplete);

            m_guiASRefreshGroup.Click += new EventHandler(m_guiASRefreshGroup_Click);
            m_guiASAddGroup.Click += new EventHandler(m_guiASAddGroup_Click);
            m_guiASEditGroup.Click += new EventHandler(m_guiASEditGroup_Click);
            m_guiASDeleteGroup.Click += new EventHandler(m_guiASDeleteGroup_Click);
            m_guiASSuspendGroup.Click += new EventHandler(m_guiASSuspendGroup_Click);
            m_guiASResumeGroup.Click += new EventHandler(m_guiASResumeGroup_Click);
            m_guiASGroupGrid.AutoGenerateColumns = false;
            m_guiASGroupGrid.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(m_guiASGroupGrid_DataBindingComplete);

            m_guiASRefreshPolicy.Click += new EventHandler(m_guiASRefreshPolicy_Click);
            m_guiASAddPolicy.Click += new EventHandler(m_guiASAddPolicy_Click);
            m_guiASEditPolicy.Click += new EventHandler(m_guiASEditPolicy_Click);
            m_guiASDeletePolicy.Click += new EventHandler(m_guiASDeletePolicy_Click);
            m_guiASPolicyGrid.AutoGenerateColumns = false;
            m_guiASPolicyGrid.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(m_guiASPolicyGrid_DataBindingComplete);

            m_guiASRefreshAlarm.Click += new EventHandler(m_guiASRefreshAlarm_Click);
            m_guiASAddAlarm.Click += new EventHandler(m_guiASAddAlarm_Click);
            m_guiASEditAlarm.Click += new EventHandler(m_guiASEditAlarm_Click);
            m_guiASDeleteAlarm.Click += new EventHandler(m_guiASDeleteAlarm_Click);
            m_guiASViewAlarmHistories.Click += new EventHandler(m_guiASViewAlarmHistories_Click);
            m_guiASAlarmGrid.AutoGenerateColumns = false;
            m_guiASAlarmGrid.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(m_guiASAlarmGrid_DataBindingComplete);

            m_guiASRefreshSchedule.Click += new EventHandler(m_guiASRefreshSchedule_Click);
            m_guiASAddSchedule.Click += new EventHandler(m_guiASAddSchedule_Click);
            m_guiASEditSchedule.Click += new EventHandler(m_guiASEditSchedule_Click);
            m_guiASDeleteSchedule.Click += new EventHandler(m_guiASDeleteSchedule_Click);
            m_guiASScheduleGrid.AutoGenerateColumns = false;

            m_guiASTerminateInstance.Click += new EventHandler(m_guiASTerminateInstance_Click);
            m_guiASRefreshInstance.Click += new EventHandler(m_guiASRefreshInstance_Click);

            m_guiASRefreshActivity.Click += new EventHandler(m_guiASRefreshActivity_Click);
            m_guiASActivityGrid.AutoGenerateColumns = false;
        }

        private void m_guiTabASMain_SelectedIndexChanged(object sender, EventArgs e) {
            m_SelectedASTab = m_guiTabASMain.SelectedTab;
            LoadASTabControls(false);
        }



        private void LoadASTabControls(bool isFromTimer) {
            if (m_SelectedASTab == m_guiTabASMain.TabPages[TAB_AS_LAUNCH_CONFIGURATION]) {
                LoadASLoadConfigurations(m_SelectedRegion);
            } else if (m_SelectedASTab == m_guiTabASMain.TabPages[TAB_AS_GROUP]) {
                LoadASGroups(m_SelectedRegion);
            } else if (m_SelectedASTab == m_guiTabASMain.TabPages[TAB_AS_POLICY]) {
                LoadASPolicies(m_SelectedRegion);
            } else if (m_SelectedASTab == m_guiTabASMain.TabPages[TAB_AS_ALARM]) {
                LoadASAlarms(m_SelectedRegion);
            } else if (m_SelectedASTab == m_guiTabASMain.TabPages[TAB_AS_SCHEDULE]) {
                LoadASSchedules(m_SelectedRegion);
            } else if (m_SelectedASTab == m_guiTabASMain.TabPages[TAB_AS_INSTANCE]) {
                LoadASInstances(m_SelectedRegion);
            } else if (m_SelectedASTab == m_guiTabASMain.TabPages[TAB_AS_ACTIVITY]) {
                LoadASActivities(m_SelectedRegion);
            }
        }

        private void LoadASLoadConfigurations(RegionEndpoint region) {
            if (!string.IsNullOrEmpty(CacheObject.Settings.AWSAccessKey) && !string.IsNullOrEmpty(CacheObject.Settings.AWSSecretKey))
            {
                var thread = new Thread(new ThreadStart(() => {
                    var result = AmazonAutoScalingUtility.DescribeLaunchConfigurations(region, null);
                    var list = result.DescribeLaunchConfigurationsResult.LaunchConfigurations.OrderBy(x => x.LaunchConfigurationName).ToList();

                    Invoke(new MethodInvoker(() => {
                        m_guiASLaunchConfigurationGrid.DataSource = list;
                    }));
                }));
                thread.Start();
            }
            else
            {
                MessageBox.Show("Please provide AWSAccessKey and AWSSecretKey in app.config file");
            }
        }

        private void LoadASGroups(RegionEndpoint region) {
            var thread = new Thread(new ThreadStart(() => {
                var result = AmazonAutoScalingUtility.DescribeAutoScalingGroups(region, null);
                var list = result.DescribeAutoScalingGroupsResult.AutoScalingGroups.OrderBy(x => x.AutoScalingGroupName).ToList();

                Invoke(new MethodInvoker(() => {
                    m_guiASGroupGrid.DataSource = list;
                }));
            }));
            thread.Start();
        }

        private void LoadASPolicies(RegionEndpoint region) {
            var thread = new Thread(new ThreadStart(() => {
                var result = AmazonAutoScalingUtility.DescribeScalingPolicies(region, null, null);
                var list = result.DescribePoliciesResult.ScalingPolicies.OrderBy(x => x.PolicyName).ToList();

                Invoke(new MethodInvoker(() => {
                    m_guiASPolicyGrid.DataSource = list;
                }));
            }));
            thread.Start();
        }

        private void LoadASAlarms(RegionEndpoint region) {
            var thread = new Thread(new ThreadStart(() => {
                var result = AmazonCloudWatchUtility.DescribeAlarms(region, null, null, null, null);
                var list = result.DescribeAlarmsResult.MetricAlarms.OrderBy(x => x.AlarmName).ToList();

                Invoke(new MethodInvoker(() => {
                    m_guiASAlarmGrid.DataSource = list;
                }));
            }));
            thread.Start();
        }

        private void LoadASSchedules(RegionEndpoint region) {
            var thread = new Thread(new ThreadStart(() => {
                var result = AmazonAutoScalingUtility.DescribeScheduledActions(region, null, null);
                var list = result.DescribeScheduledActionsResult.ScheduledUpdateGroupActions;

                Invoke(new MethodInvoker(() => {
                    m_guiASScheduleGrid.DataSource = list;
                }));
            }));
            thread.Start();
        }

        private void LoadASInstances(RegionEndpoint region) {
            var thread = new Thread(new ThreadStart(() => {
                var result = AmazonAutoScalingUtility.DescribeAutoScalingInstances(region);
                var list = result.DescribeAutoScalingInstancesResult.AutoScalingInstances.OrderBy(x => x.AutoScalingGroupName).ToList();

                Invoke(new MethodInvoker(() => {
                    try { m_guiASInstanceGrid.DataSource = list; } catch { }
                }));
            }));
            thread.Start();
        }

        private void LoadASActivities(RegionEndpoint region) {
            var thread = new Thread(new ThreadStart(() => {
                var result = AmazonAutoScalingUtility.DescribeScalingActivities(region, null);
                var list = result.DescribeScalingActivitiesResult.Activities;

                Invoke(new MethodInvoker(() => {
                    m_guiASActivityGrid.DataSource = list;
                }));
            }));
            thread.Start();
        }



        // LaunchConfigurations
        void m_guiASRefreshLaunchConfiguration_Click(object sender, EventArgs e) {

        }

        void m_guiASAddLaunchConfiguration_Click(object sender, EventArgs e) {
            try {
                var form = new AddEditASLaunchConfigurationForm();
                form.SelectedRegion = m_SelectedRegion;
                form.ShowDialog(this);

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                    LoadASLoadConfigurations(m_SelectedRegion);
                    MessageBox.Show("Launch configuration was created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASDeleteLaunchConfiguration_Click(object sender, EventArgs e) {
            var selectedRows = m_guiASLaunchConfigurationGrid.SelectedRows;

            if (selectedRows.Count > 0) {
                var selectedItems = new List<string>();
                var selectedString = Environment.NewLine;
                foreach (DataGridViewRow selectedRow in selectedRows) {
                    var name = selectedRow.Cells["m_guiASLaunchConfigurationGridLaunchConfigurationName"].Value as string;
                    selectedItems.Add(name);
                    selectedString += "    - " + name + Environment.NewLine;
                }

                if (MessageBox.Show("Are you sure you want to delete the selected item(s)?" + selectedString, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    try {
                        foreach (var name in selectedItems) {
                            AmazonAutoScalingUtility.DeleteLaunchConfiguration(m_SelectedRegion, name);
                        }

                        LoadASLoadConfigurations(m_SelectedRegion);
                        MessageBox.Show("Launch configuration was deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show("Nothing was selected for deletion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASLaunchConfigurationGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            DataGridViewRow row = null;
            Amazon.AutoScaling.Model.LaunchConfiguration item = null;

            for (var i = 0; i < m_guiASLaunchConfigurationGrid.Rows.Count; i++) {
                row = m_guiASLaunchConfigurationGrid.Rows[i];
                item = row.DataBoundItem as Amazon.AutoScaling.Model.LaunchConfiguration;

                row.Cells["m_guiASLaunchConfigurationGridInstanceMonitoring"].Value = item.InstanceMonitoring.Enabled == true ? "Yes" : "No";
                row.Cells["m_guiASLaunchConfigurationGridEbsOptimized"].Value = item.EbsOptimized == true ? "Yes" : "No";
            }
        }



        // Groups
        void m_guiASRefreshGroup_Click(object sender, EventArgs e) {
            LoadASGroups(m_SelectedRegion);
        }

        void m_guiASAddGroup_Click(object sender, EventArgs e) {
            try {
                var form = new AddEditASGroupForm();
                form.SelectedRegion = m_SelectedRegion;
                form.ShowDialog(this);

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                    LoadASGroups(m_SelectedRegion);
                    MessageBox.Show("Auto scaling group was created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASEditGroup_Click(object sender, EventArgs e) {
            try {
                var form = new AddEditASGroupForm();
                form.SelectedRegion = m_SelectedRegion;
                form.ItemToEdit = m_guiASGroupGrid.SelectedRows[0].DataBoundItem as Amazon.AutoScaling.Model.AutoScalingGroup;
                form.ShowDialog(this);

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                    LoadASGroups(m_SelectedRegion);
                    MessageBox.Show("Auto scaling group was updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASDeleteGroup_Click(object sender, EventArgs e) {
            var selectedRows = m_guiASGroupGrid.SelectedRows;

            if (selectedRows.Count > 0) {
                var selectedItems = new List<string>();
                var selectedString = Environment.NewLine;
                foreach (DataGridViewRow selectedRow in selectedRows) {
                    var name = selectedRow.Cells["m_guiASGroupGridAutoScalingGroupName"].Value as string;
                    selectedItems.Add(name);
                    selectedString += "    - " + name + Environment.NewLine;
                }

                if (MessageBox.Show("Are you sure you want to delete the selected item(s)?" + selectedString, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    try {
                        foreach (var name in selectedItems) {
                            var result = AmazonAutoScalingUtility.DeleteAutoScalingGroup(m_SelectedRegion, name);
                        }

                        LoadASGroups(m_SelectedRegion);
                        MessageBox.Show("Auto scaling group was deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show("Nothing was selected for deletion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASSuspendGroup_Click(object sender, EventArgs e) {
            var selectedRows = m_guiASGroupGrid.SelectedRows;

            if (selectedRows.Count > 0) {
                if (MessageBox.Show("Are you sure you want to suspend the selected item(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    try {
                        foreach (DataGridViewRow selectedRow in selectedRows) {
                            var name = selectedRow.Cells["m_guiASGroupGridAutoScalingGroupName"].Value as string;
                            var result = AmazonAutoScalingUtility.SuspendProcesses(m_SelectedRegion, name, null);
                        }

                        LoadASGroups(m_SelectedRegion);
                        MessageBox.Show("Auto scaling group was suspended successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show("Nothing was selected for suspension!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASResumeGroup_Click(object sender, EventArgs e) {
            var selectedRows = m_guiASGroupGrid.SelectedRows;

            if (selectedRows.Count > 0) {
                if (MessageBox.Show("Are you sure you want to resume the selected item(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    try {
                        foreach (DataGridViewRow selectedRow in selectedRows) {
                            var name = selectedRow.Cells["m_guiASGroupGridAutoScalingGroupName"].Value as string;
                            var result = AmazonAutoScalingUtility.ResumeProcesses(m_SelectedRegion, name, null);
                        }

                        LoadASGroups(m_SelectedRegion);
                        MessageBox.Show("Auto scaling group was resumed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show("Nothing was selected for resumption!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASGroupGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            DataGridViewRow row = null;
            Amazon.AutoScaling.Model.AutoScalingGroup item = null;

            for (var i = 0; i < m_guiASGroupGrid.Rows.Count; i++) {
                row = m_guiASGroupGrid.Rows[i];
                item = row.DataBoundItem as Amazon.AutoScaling.Model.AutoScalingGroup;

                if (item != null) {
                    var tmp = string.Empty;
                    for (var j = 0; j < item.LoadBalancerNames.Count; j++) {
                        if (j > 0) {
                            tmp += ", ";
                        }

                        tmp += item.LoadBalancerNames[j];
                    }
                    row.Cells["m_guiASGroupGridLoadBalancerNames"].Value = tmp;

                    tmp = string.Empty;
                    for (var j = 0; j < item.AvailabilityZones.Count; j++) {
                        if (j > 0) {
                            tmp += ", ";
                        }

                        tmp += item.AvailabilityZones[j];
                    }
                    row.Cells["m_guiASGroupGridVPCAvailabilityZones"].Value = tmp;
                }
            }
        }



        // Policies
        void m_guiASRefreshPolicy_Click(object sender, EventArgs e) {
            LoadASPolicies(m_SelectedRegion);
        }

        void m_guiASAddPolicy_Click(object sender, EventArgs e) {
            var form = new AddEditASPolicyForm();
            form.SelectedRegion = m_SelectedRegion;
            form.ShowDialog(this);

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                LoadASPolicies(m_SelectedRegion);
                MessageBox.Show("Auto scaling policy was created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void m_guiASEditPolicy_Click(object sender, EventArgs e) {
            var form = new AddEditASPolicyForm();
            form.SelectedRegion = m_SelectedRegion;
            form.ItemToEdit = m_guiASPolicyGrid.SelectedRows[0].DataBoundItem as Amazon.AutoScaling.Model.ScalingPolicy;
            form.ShowDialog(this);

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                LoadASPolicies(m_SelectedRegion);
                MessageBox.Show("Auto scaling policy was created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void m_guiASDeletePolicy_Click(object sender, EventArgs e) {
            var selectedRows = m_guiASPolicyGrid.SelectedRows;

            if (selectedRows.Count > 0) {
                var selectedItems = new Dictionary<string, string>();
                var selectedString = Environment.NewLine;
                foreach (DataGridViewRow selectedRow in selectedRows) {
                    var name = selectedRow.Cells["m_guiASPolicyGridScalingPolicyName"].Value as string;
                    var autoScalingGroupName = selectedRow.Cells["m_guiASPolicyGridScalingGroupName"].Value as string;
                    selectedItems.Add(name, autoScalingGroupName);
                    selectedString += "    - " + name + Environment.NewLine;
                }

                if (MessageBox.Show("Are you sure you want to delete the selected item(s)?" + selectedString, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    foreach (var kvp in selectedItems) {
                        AmazonAutoScalingUtility.DeleteScalingPolicy(m_SelectedRegion, kvp.Key, kvp.Value);
                    }

                    LoadASPolicies(m_SelectedRegion);
                    MessageBox.Show("Auto scaling policy was deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                MessageBox.Show("Nothing was selected for deletion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASPolicyGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {

        }



        // Alarms
        void m_guiASRefreshAlarm_Click(object sender, EventArgs e) {
            LoadASAlarms(m_SelectedRegion);
        }

        void m_guiASAddAlarm_Click(object sender, EventArgs e) {
            try {
                var form = new AddEditASAlarmForm();
                form.SelectedRegion = m_SelectedRegion;
                form.ShowDialog(this);

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                    LoadASAlarms(m_SelectedRegion);
                    MessageBox.Show("Cloudwatch alarm was created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASEditAlarm_Click(object sender, EventArgs e) {
            try {
                var form = new AddEditASAlarmForm();
                form.SelectedRegion = m_SelectedRegion;
                form.ItemToEdit = m_guiASAlarmGrid.SelectedRows[0].DataBoundItem as Amazon.CloudWatch.Model.MetricAlarm;
                form.ShowDialog(this);

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                    LoadASAlarms(m_SelectedRegion);
                    MessageBox.Show("Cloudwatch alarm was created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASDeleteAlarm_Click(object sender, EventArgs e) {
            var selectedRows = m_guiASAlarmGrid.SelectedRows;

            if (selectedRows.Count > 0) {
                var selectedItems = new List<string>();
                var selectedString = Environment.NewLine;
                foreach (DataGridViewRow selectedRow in selectedRows) {
                    var name = selectedRow.Cells["m_guiASAlarmGridAlarmName"].Value as string;
                    selectedItems.Add(name);
                    selectedString += "    - " + name + Environment.NewLine;
                }

                if (MessageBox.Show("Are you sure you want to delete the selected item(s)?" + selectedString, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    var result = AmazonCloudWatchUtility.DeleteAlarms(m_SelectedRegion, selectedItems);
                    LoadASAlarms(m_SelectedRegion);
                    MessageBox.Show("Cloudwatch alarm(s) was deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                MessageBox.Show("Nothing was selected for deletion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASViewAlarmHistories_Click(object sender, EventArgs e) {
            try {
                if (m_guiASAlarmGrid.SelectedRows.Count > 0) {
                    var alarm = m_guiASAlarmGrid.SelectedRows[0].DataBoundItem as Amazon.CloudWatch.Model.MetricAlarm;
                    if (alarm != null) {
                        var alarms = AmazonCloudWatchUtility.DescribeAlarmHistory(m_SelectedRegion, alarm.AlarmName, DateTime.MinValue, DateTime.Now, null).DescribeAlarmHistoryResult.AlarmHistoryItems;
                    }
                } else {
                    MessageBox.Show("You must select an alarm item to view its histories", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASAlarmGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {

        }



        // Schedules
        void m_guiASRefreshSchedule_Click(object sender, EventArgs e) {
            LoadASSchedules(m_SelectedRegion);
        }

        void m_guiASAddSchedule_Click(object sender, EventArgs e) {
            try {
                var form = new AddEditASScheduleForm();
                form.ShowDialog(this);

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                    LoadASSchedules(m_SelectedRegion);
                    MessageBox.Show("Schedule was created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASEditSchedule_Click(object sender, EventArgs e) {
            try {
                if (m_guiASScheduleGrid.SelectedRows.Count > 0) {
                    var form = new AddEditASScheduleForm();
                    form.ItemToEdit = m_guiASScheduleGrid.SelectedRows[0].DataBoundItem as Amazon.AutoScaling.Model.ScheduledUpdateGroupAction;
                    form.ShowDialog(this);

                    if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                        LoadASSchedules(m_SelectedRegion);
                        MessageBox.Show("Schedule was updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else {
                    MessageBox.Show("Nothing was selected to edit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_guiASDeleteSchedule_Click(object sender, EventArgs e) {
            if (m_guiASScheduleGrid.SelectedRows.Count > 0) {
                if (MessageBox.Show("Are you sure you want to delete the selected item(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    try {
                        var selectedItem = m_guiASScheduleGrid.SelectedRows[0].DataBoundItem as Amazon.AutoScaling.Model.ScheduledUpdateGroupAction;
                        AmazonAutoScalingUtility.DeleteScheduledAction(m_SelectedRegion, selectedItem.ScheduledActionName, selectedItem.AutoScalingGroupName);
                        LoadASSchedules(m_SelectedRegion);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show("Nothing was selected for deletion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Instances
        void m_guiASRefreshInstance_Click(object sender, EventArgs e) {
            LoadASInstances(m_SelectedRegion);
        }

        void m_guiASTerminateInstance_Click(object sender, EventArgs e) {
            if (m_guiASInstanceGrid.SelectedRows.Count > 0) {
                if (MessageBox.Show("Are you sure you want to terminate the selected instance(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    try {
                        var selectedRows = m_guiASInstanceGrid.SelectedRows;

                        foreach (DataGridViewRow selectedRow in selectedRows) {
                            var name = selectedRow.Cells["InstanceId"].Value as string;
                            AmazonAutoScalingUtility.TerminateInstanceInAutoScalingGroup(m_SelectedRegion, name, false);
                        }
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        // Activities
        void m_guiASRefreshActivity_Click(object sender, EventArgs e) {
            LoadASActivities(m_SelectedRegion);
        }
    }
}
