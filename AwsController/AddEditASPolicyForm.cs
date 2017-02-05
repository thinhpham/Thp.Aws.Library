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
    public partial class AddEditASPolicyForm : Form {
        public Amazon.RegionEndpoint SelectedRegion { get; set; }

        public Amazon.AutoScaling.Model.ScalingPolicy ItemToEdit { get; set; }

        public AddEditASPolicyForm() {
            InitializeComponent();
        }

        private void AddEditASPolicy_Load(object sender, EventArgs e) {
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
                var adjustmentType = AmazonAutoScalingUtility.AS_POLICY_ADJUSTMENT_TYPE;
                var autoScalingGroup = AmazonAutoScalingUtility.DescribeAutoScalingGroups(SelectedRegion, null).DescribeAutoScalingGroupsResult.AutoScalingGroups;

                Invoke(new MethodInvoker(() => {
                    m_guiScalingAdjustment.Text = AmazonAutoScalingUtility.DEFAULT_AS_ADJUSTMENT_INCREMENT.ToString();
                    m_guiCooldown.Text = AmazonAutoScalingUtility.DEFAULT_AS_COOLDOWN.ToString();
                    m_guiAdjustmentType.DataSource = adjustmentType;

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

            m_guiName.Text = ItemToEdit.PolicyName;
            m_guiScalingAdjustment.Text = ItemToEdit.ScalingAdjustment.ToString();
            m_guiCooldown.Text = ItemToEdit.Cooldown.ToString();

            var adjustmentType = AmazonAutoScalingUtility.AS_POLICY_ADJUSTMENT_TYPE;
            m_guiAdjustmentType.DataSource = adjustmentType;
            for (int i = 0; i < adjustmentType.Length; i++) {
                if (adjustmentType[i].Equals(ItemToEdit.AdjustmentType)) {
                    m_guiAdjustmentType.SelectedIndex = i;
                    break;
                }
            }

            var thread = new Thread(new ThreadStart(() => {
                var autoScalingGroup = AmazonAutoScalingUtility.DescribeAutoScalingGroups(SelectedRegion, null).DescribeAutoScalingGroupsResult.AutoScalingGroups;

                Invoke(new MethodInvoker(() => {
                    m_guiAutoScalingGroup.DisplayMember = "AutoScalingGroupName";
                    m_guiAutoScalingGroup.ValueMember = "AutoScalingGroupARN";
                    m_guiAutoScalingGroup.DataSource = autoScalingGroup;
                    m_guiAutoScalingGroup.SelectedIndex = -1;
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

        private void m_guiOK_Click(object sender, EventArgs e) {
            if (m_guiName.Text.Length > 0) {
                var name = m_guiName.Text;
                var autoScalingGroupName = m_guiAutoScalingGroup.Text;
                var adjustmentType = m_guiAdjustmentType.SelectedValue.ToString();
                var scalingAdjustment = int.Parse(m_guiScalingAdjustment.Text);
                var cooldown = int.Parse(m_guiCooldown.Text);

                AmazonAutoScalingUtility.PutScalingPolicy(SelectedRegion, name, autoScalingGroupName, adjustmentType, scalingAdjustment, cooldown);

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
