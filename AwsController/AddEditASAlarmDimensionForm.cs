using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Thp.Har.Utility;

namespace AwsController {
    public partial class AddEditASAlarmDimensionForm : Form {
        private const string AS_ALARM_DIMENSION_AUTO_SCALING_GROUP_NAME = "AutoScalingGroupName";
        private const string AS_ALARM_DIMENSION_AVAILABILITY_ZONE = "AvailabilityZone";
        private const string AS_ALARM_DIMENSION_LOAD_BALANCER_NAME = "LoadBalancerName";
        private const string AS_ALARM_DIMENSION_IMAGEID = "ImageId";
        private const string AS_ALARM_DIMENSION_INSTANCEID = "InstanceId";
        private const string AS_ALARM_DIMENSION_INSTANCETYPE = "InstanceType";

        public Amazon.RegionEndpoint SelectedRegion { get; set; }
        public Amazon.CloudWatch.Model.Dimension ItemToEdit { get; set; }

        public AddEditASAlarmDimensionForm() {
            InitializeComponent();

            m_guiName.SelectedIndexChanged += new EventHandler(m_guiName_SelectedIndexChanged);
        }

        void m_guiName_SelectedIndexChanged(object sender, EventArgs e) {
            var selected = m_guiName.SelectedItem as string;

            if (!string.IsNullOrEmpty(selected)) {
                m_guiValue.DataSource = null;

                switch (selected) {
                    case AS_ALARM_DIMENSION_AUTO_SCALING_GROUP_NAME:
                        m_guiValue.DisplayMember = "AutoScalingGroupName";
                        m_guiValue.ValueMember = "AutoScalingGroupARN";
                        m_guiValue.DataSource = AmazonAutoScalingUtility.DescribeAutoScalingGroups(SelectedRegion, null).DescribeAutoScalingGroupsResult.AutoScalingGroups;
                        break;
                    case AS_ALARM_DIMENSION_IMAGEID:
                        m_guiValue.DisplayMember = "ImageId";
                        m_guiValue.ValueMember = "ImageId";
                        m_guiValue.DataSource = AmazonEC2Utility.DescribeImages(SelectedRegion, null).DescribeImagesResult.Image;
                        break;
                    case AS_ALARM_DIMENSION_INSTANCEID:
                        m_guiValue.DisplayMember = "InstanceId";
                        m_guiValue.ValueMember = "InstanceId";
                        m_guiValue.DataSource = AmazonEC2Utility.DescribeInstances(SelectedRegion).DescribeInstancesResult.Reservation[0].RunningInstance;
                        break;
                    case AS_ALARM_DIMENSION_INSTANCETYPE:
                        m_guiValue.DataSource = AmazonEC2Utility.EC2_INSTANCE_TYPES;
                        break;
                    case AS_ALARM_DIMENSION_AVAILABILITY_ZONE:
                        m_guiValue.DisplayMember = "ZoneName";
                        m_guiValue.ValueMember = "ZoneName";
                        m_guiValue.DataSource = AmazonEC2Utility.DescribeAvailabilityZones(SelectedRegion).DescribeAvailabilityZonesResult.AvailabilityZone;
                        break;
                    case AS_ALARM_DIMENSION_LOAD_BALANCER_NAME:
                        m_guiValue.DisplayMember = "LoadBalancerName";
                        m_guiValue.ValueMember = "LoadBalancerName";
                        m_guiValue.DataSource = AmazonElasticLoadBalancingUtility.DescribeLoadBalancers(SelectedRegion).DescribeLoadBalancersResult.LoadBalancerDescriptions;
                        break;
                }

                if (m_guiValue.DataSource != null && ItemToEdit != null) {
                    for (var i = 0; i < m_guiValue.Items.Count; i++) {
                        if (GetValueFromName(selected, m_guiValue.Items[i]) == ItemToEdit.Value) {
                            m_guiValue.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void AddEditASAlarmDimensionForm_Load(object sender, EventArgs e) {
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
            m_guiName.DataSource = AmazonAutoScalingUtility.AS_ALARM_DIMENSION_TYPES;
        }

        private void LoadControlsForEdit() {
            m_guiName.DataSource = AmazonAutoScalingUtility.AS_ALARM_DIMENSION_TYPES;
            m_guiName.Enabled = false;

            for (int i = 0; i < m_guiName.Items.Count; i++) {
                if ((string)m_guiName.Items[i] == ItemToEdit.Name) {
                    m_guiName.SelectedIndex = i;
                    break;
                }
            }
        }

        private string GetValueFromName(string name, object item) {
            var result = string.Empty;

            switch (name) {
                case AS_ALARM_DIMENSION_AUTO_SCALING_GROUP_NAME:
                    result = (item as Amazon.AutoScaling.Model.AutoScalingGroup).AutoScalingGroupName;
                    break;
                case AS_ALARM_DIMENSION_IMAGEID:
                    result = (item as Amazon.EC2.Model.Image).ImageId;
                    break;
                case AS_ALARM_DIMENSION_INSTANCEID:
                    result = (item as Amazon.EC2.Model.RunningInstance).InstanceId;
                    break;
                case AS_ALARM_DIMENSION_INSTANCETYPE:
                    result = item as string;
                    break;
                case AS_ALARM_DIMENSION_AVAILABILITY_ZONE:
                    result = (item as Amazon.EC2.Model.AvailabilityZone).ZoneName;
                    break;
                case AS_ALARM_DIMENSION_LOAD_BALANCER_NAME:
                    result = (item as Amazon.ElasticLoadBalancing.Model.LoadBalancerDescription).LoadBalancerName;
                    break;
            }

            return result;
        }

        private void m_guiOK_Click(object sender, EventArgs e) {
            var name = m_guiName.SelectedItem as string;
            var value = GetValueFromName(name, m_guiValue.SelectedItem);

            if (ItemToEdit == null) {
                ItemToEdit = new Amazon.CloudWatch.Model.Dimension() { Name = name, Value = value };
            } else {
                ItemToEdit.Value = value;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void m_guiCancel_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
