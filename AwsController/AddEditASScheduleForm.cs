using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Thp.Har.Utility;
using System.Threading;

namespace AwsController {
    public partial class AddEditASScheduleForm : Form {
        public Amazon.RegionEndpoint SelectedRegion { get; set; }

        public Amazon.AutoScaling.Model.ScheduledUpdateGroupAction ItemToEdit { get; set; }

        public AddEditASScheduleForm() {
            InitializeComponent();
        }

        private void AddEditASScheduleForm_Load(object sender, EventArgs e) {
            LoadControls();
        }

        private void LoadControls() {
            if (ItemToEdit == null) {
                LoadControlsForAdd();
            } else {
                LoadControlsForEdit();
            }
        }

        private void LoadControlsForAdd() {
            Cursor = Cursors.WaitCursor;

            var thread = new Thread(new ThreadStart(() => {
                var autoScalingGroup = AmazonAutoScalingUtility.DescribeAutoScalingGroups(SelectedRegion, null).DescribeAutoScalingGroupsResult.AutoScalingGroups;

                Invoke(new MethodInvoker(() => {
                    m_guiAutoScalingGroup.DisplayMember = "AutoScalingGroupName";
                    m_guiAutoScalingGroup.ValueMember = "AutoScalingGroupARN";
                    m_guiAutoScalingGroup.DataSource = autoScalingGroup;

                    Cursor = Cursors.Default;
                }));
            }));
            thread.Start();
        }

        private void LoadControlsForEdit() {
            Cursor = Cursors.WaitCursor;
            m_guiName.ReadOnly = true;
            m_guiAutoScalingGroup.Enabled = false;
            m_guiStartTime.ReadOnly = true;
            m_guiEndTime.ReadOnly = true;
            m_guiRecurrence.ReadOnly = true;

            m_guiName.Text = ItemToEdit.ScheduledActionName;
            m_guiMinSize.Text = ItemToEdit.MinSize.ToString();
            m_guiMaxSize.Text = ItemToEdit.MaxSize.ToString();
            m_guiDesiredCapacity.Text = ItemToEdit.DesiredCapacity.ToString();
            m_guiStartTime.Text = ItemToEdit.StartTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            m_guiEndTime.Text = ItemToEdit.EndTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            m_guiRecurrence.Text = ItemToEdit.Recurrence;

            var thread = new Thread(new ThreadStart(() => {
                var autoScalingGroup = AmazonAutoScalingUtility.DescribeAutoScalingGroups(SelectedRegion, null).DescribeAutoScalingGroupsResult.AutoScalingGroups;

                Invoke(new MethodInvoker(() => {
                    m_guiAutoScalingGroup.DisplayMember = "AutoScalingGroupName";
                    m_guiAutoScalingGroup.ValueMember = "AutoScalingGroupARN";
                    m_guiAutoScalingGroup.DataSource = autoScalingGroup;
                    for (int i = 0; i < autoScalingGroup.Count; i++) {
                        if (autoScalingGroup[i].AutoScalingGroupName.Equals(ItemToEdit.AutoScalingGroupName)) {
                            m_guiAutoScalingGroup.SelectedIndex = i;
                            break;
                        }
                    }

                    Cursor = Cursors.Default;
                }));
            }));
            thread.Start();
        }

        private void m_guiCronHelpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                System.Diagnostics.Process.Start("http://en.wikipedia.org/wiki/Cron");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_guiOK_Click(object sender, EventArgs e) {
            if (m_guiName.Text.Length > 0 && m_guiAutoScalingGroup.SelectedIndex >= 0) {
                var name = m_guiName.Text;
                var autoScalingGroupName = m_guiAutoScalingGroup.Text;
                var minSize = int.Parse(m_guiMinSize.Text);
                var maxSize = int.Parse(m_guiMaxSize.Text);
                var desiredCapacity = int.Parse(m_guiDesiredCapacity.Text);

                DateTime startTime = DateTime.MinValue;
                if (m_guiStartTime.Text.Length > 0) {
                    startTime = DateTime.Parse(m_guiStartTime.Text).ToUniversalTime();
                }

                DateTime endTime = DateTime.MaxValue;
                if (m_guiEndTime.Text.Length > 0) {
                    DateTime.Parse(m_guiEndTime.Text).ToUniversalTime();
                }

                var recurrence = m_guiRecurrence.Text;

                var result = AmazonAutoScalingUtility.PutScheduledUpdateGroupAction(SelectedRegion, name, autoScalingGroupName, minSize, maxSize, desiredCapacity, startTime, endTime, recurrence);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void m_guiCancel_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
