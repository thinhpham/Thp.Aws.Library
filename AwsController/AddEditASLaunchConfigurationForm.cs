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
    public partial class AddEditASLaunchConfigurationForm : Form {
        public Amazon.RegionEndpoint SelectedRegion { get; set; }

        public AddEditASLaunchConfigurationForm() {
            InitializeComponent();
        }

        private void AddEditASLaunchConfiguration_Load(object sender, EventArgs e) {
            LoadControls();
        }

        private void LoadControls() {
            var thread = new Thread(new ThreadStart(() => {
                var imageIdList = AmazonEC2Utility.DescribeImages(SelectedRegion, null).DescribeImagesResult.Image.OrderBy(s => s.Name).ToList();
                var instanceTypeList = AmazonEC2Utility.EC2_INSTANCE_TYPES;
                var keyNameList = AmazonEC2Utility.DescribeKeyPairs(SelectedRegion).DescribeKeyPairsResult.KeyPair.OrderBy(s => s.KeyName).ToList();
                var securityGroupList = AmazonEC2Utility.DescribeSecurityGroups(SelectedRegion).DescribeSecurityGroupsResult.SecurityGroup.OrderBy(s => s.GroupName).ToList();

                Invoke(new MethodInvoker(() => {
                    m_guiImageId.DisplayMember = "Name";
                    m_guiImageId.ValueMember = "Name";
                    m_guiImageId.DataSource = imageIdList;

                    m_guiInstanceType.DataSource = AmazonEC2Utility.EC2_INSTANCE_TYPES;

                    m_guiKeyName.DisplayMember = "KeyName";
                    m_guiKeyName.ValueMember = "KeyName";
                    m_guiKeyName.DataSource = keyNameList;

                    m_guiSecurityGroup.DisplayMember = "GroupName";
                    m_guiSecurityGroup.ValueMember = "GroupId";
                    m_guiSecurityGroup.DataSource = securityGroupList;

                    m_guiEnabledDetailMonitoring.Checked = true;
                    m_guiEbsOptimized.Checked = true;
                }));
            }));
            thread.Start();
        }

        private void m_guiOK_Click(object sender, EventArgs e) {
            if (m_guiName.Text.Length > 0) {
                var name = m_guiName.Text;
                var imageId = ((Amazon.EC2.Model.Image)m_guiImageId.SelectedItem).ImageId;
                var instanceType = m_guiInstanceType.Text;
                var keyName = ((Amazon.EC2.Model.KeyPair)m_guiKeyName.SelectedItem).KeyName;
                var enableMonitoring = m_guiEnabledDetailMonitoring.Checked;
                var ebsOptimized = m_guiEbsOptimized.Checked;

                var securityGroup = new List<string>();
                securityGroup.Add(((Amazon.EC2.Model.SecurityGroup)m_guiSecurityGroup.SelectedItem).GroupId);

                AmazonAutoScalingUtility.CreateLaunchConfiguration(SelectedRegion, name, imageId, instanceType, keyName, securityGroup, enableMonitoring, ebsOptimized, null, null, null, null, null);

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
