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
    public partial class AddEditASGroupForm : Form {
        public Amazon.RegionEndpoint SelectedRegion { get; set; }

        public Amazon.AutoScaling.Model.AutoScalingGroup ItemToEdit { get; set; }

        public AddEditASGroupForm() {
            InitializeComponent();
        }

        private void AddEditASGroup_Load(object sender, EventArgs e) {
            LoadControls();
        }

        private void LoadControls() {
            m_guiHealthCheckType.DataSource = AmazonAutoScalingUtility.AS_GROUP_HEALTH_CHECK_TYPES;

            if (ItemToEdit == null) {
                LoadControlsForAdd();
            } else {
                LoadControlsForEdit();
            }
        }

        private void LoadControlsForAdd() {
            Cursor = Cursors.WaitCursor;
            m_guiName.Focus();

            m_guiMinSize.Text = AmazonAutoScalingUtility.DEFAULT_AS_MIN_SIZE.ToString();
            m_guiMaxSize.Text = AmazonAutoScalingUtility.DEFAULT_AS_MAX_SIZE.ToString();
            m_guiDesiredCapacity.Text = AmazonAutoScalingUtility.DEFAULT_AS_DESIRED_SIZE.ToString();
            m_guiDefaultCooldown.Text = AmazonAutoScalingUtility.DEFAULT_AS_COOLDOWN.ToString();
            m_guiHealthCheckGracePeriod.Text = AmazonAutoScalingUtility.DEFAULT_AS_HEALTH_CHECK_GRACE_PERIOD.ToString();
            m_guiHealthCheckType.SelectedItem = "ELB";

            var thread = new Thread(new ThreadStart(() => {
                var launchConfigurationList = AmazonAutoScalingUtility.DescribeLaunchConfigurations(SelectedRegion, null).DescribeLaunchConfigurationsResult.LaunchConfigurations;
                var availabilityZoneList = AmazonEC2Utility.DescribeAvailabilityZones(SelectedRegion).DescribeAvailabilityZonesResult.AvailabilityZone;
                var loadBalancerList = AmazonElasticLoadBalancingUtility.DescribeLoadBalancers(SelectedRegion).DescribeLoadBalancersResult.LoadBalancerDescriptions;
                var vpcZoneIdentifierList = AmazonEC2Utility.DescribeSubnets(SelectedRegion).DescribeSubnetsResult.Subnet;

                Invoke(new MethodInvoker(() => {
                    m_guiLaunchConfiguration.DisplayMember = "LaunchConfigurationName";
                    m_guiLaunchConfiguration.ValueMember = "LaunchConfigurationName";
                    m_guiLaunchConfiguration.DataSource = launchConfigurationList;

                    m_guiAvailabilityZones.DisplayMember = "ZoneName";
                    m_guiAvailabilityZones.ValueMember = "ZoneName";
                    m_guiAvailabilityZones.DataSource = availabilityZoneList;

                    m_guiLoadBalancerNames.DisplayMember = "LoadBalancerName";
                    m_guiLoadBalancerNames.ValueMember = "LoadBalancerName";
                    m_guiLoadBalancerNames.DataSource = loadBalancerList;

                    m_guiVPCZoneIdentifier.DisplayMember = "CidrBlock";
                    m_guiVPCZoneIdentifier.ValueMember = "SubnetId";
                    m_guiVPCZoneIdentifier.DataSource = vpcZoneIdentifierList;

                    //m_guiVPCZoneIdentifier.DisplayMember = "CidrBlock";
                    //m_guiVPCZoneIdentifier.ValueMember = "SubnetId";
                    //foreach (var subnet in vpcZoneIdentifierList) {
                    //    m_guiVPCZoneIdentifier.Items.Add(subnet);
                    //}

                    Cursor = Cursors.Default;
                }));
            }));
            thread.Start();
        }

        private void LoadControlsForEdit() {
            Cursor = Cursors.WaitCursor;
            m_guiName.ReadOnly = true;

            m_guiName.Text = ItemToEdit.AutoScalingGroupName;
            m_guiMinSize.Text = ItemToEdit.MinSize.ToString();
            m_guiMaxSize.Text = ItemToEdit.MaxSize.ToString();
            m_guiDesiredCapacity.Text = ItemToEdit.DesiredCapacity.ToString();
            m_guiDefaultCooldown.Text = ItemToEdit.DefaultCooldown.ToString();
            m_guiHealthCheckGracePeriod.Text = ItemToEdit.HealthCheckGracePeriod.ToString();
            m_guiHealthCheckType.SelectedItem = ItemToEdit.HealthCheckType;

            var thread = new Thread(new ThreadStart(() => {
                var launchConfigurationList = AmazonAutoScalingUtility.DescribeLaunchConfigurations(SelectedRegion, null).DescribeLaunchConfigurationsResult.LaunchConfigurations;
                var availabilityZoneList = AmazonEC2Utility.DescribeAvailabilityZones(SelectedRegion).DescribeAvailabilityZonesResult.AvailabilityZone;
                var loadBalancerList = AmazonElasticLoadBalancingUtility.DescribeLoadBalancers(SelectedRegion).DescribeLoadBalancersResult.LoadBalancerDescriptions;
                var vpcZoneIdentifierList = AmazonEC2Utility.DescribeSubnets(SelectedRegion).DescribeSubnetsResult.Subnet;

                Invoke(new MethodInvoker(() => {
                    m_guiLaunchConfiguration.DisplayMember = "LaunchConfigurationName";
                    m_guiLaunchConfiguration.ValueMember = "LaunchConfigurationName";
                    m_guiLaunchConfiguration.DataSource = launchConfigurationList;
                    m_guiLaunchConfiguration.SelectedIndex = -1;
                    for (int i = 0; i < launchConfigurationList.Count; i++) {
                        if (launchConfigurationList[i].LaunchConfigurationName.Equals(ItemToEdit.LaunchConfigurationName)) {
                            m_guiLaunchConfiguration.SelectedIndex = i;
                            break;
                        }
                    }

                    m_guiAvailabilityZones.DisplayMember = "ZoneName";
                    m_guiAvailabilityZones.ValueMember = "ZoneName";
                    m_guiAvailabilityZones.DataSource = availabilityZoneList;
                    m_guiAvailabilityZones.SelectedIndex = -1;
                    for (int i = 0; i < availabilityZoneList.Count; i++) {
                        if (availabilityZoneList[i].ZoneName.Equals(ItemToEdit.AvailabilityZones[0])) {
                            m_guiAvailabilityZones.SetSelected(i, true);
                        }
                    }

                    m_guiLoadBalancerNames.Enabled = false; // Cannot change load balancer once the group is created
                    m_guiLoadBalancerNames.DisplayMember = "LoadBalancerName";
                    m_guiLoadBalancerNames.ValueMember = "LoadBalancerName";
                    m_guiLoadBalancerNames.DataSource = loadBalancerList;
                    m_guiLoadBalancerNames.SelectedIndex = -1;
                    for (int i = 0; i < loadBalancerList.Count; i++) {
                        if (loadBalancerList[i].LoadBalancerName.Equals(ItemToEdit.LoadBalancerNames[0])) {
                            m_guiLoadBalancerNames.SetSelected(i, true);
                        }
                    }

                    m_guiVPCZoneIdentifier.DisplayMember = "CidrBlock";
                    m_guiVPCZoneIdentifier.ValueMember = "SubnetId";
                    m_guiVPCZoneIdentifier.DataSource = vpcZoneIdentifierList;
                    m_guiVPCZoneIdentifier.SelectedIndex = -1;
                    if (!string.IsNullOrEmpty(ItemToEdit.VPCZoneIdentifier)) {
                        var subnets = ItemToEdit.VPCZoneIdentifier.Split(',');
                        foreach (var subnet in subnets) {
                            for (var i = 0; i < m_guiVPCZoneIdentifier.Items.Count; i++) {
                                if (((Amazon.EC2.Model.Subnet)m_guiVPCZoneIdentifier.Items[i]).SubnetId == subnet.Trim()) {
                                    m_guiVPCZoneIdentifier.SetSelected(i, true);
                                }
                            }
                        }
                    }

                    //foreach (var subnet in vpcZoneIdentifierList) {
                    //    m_guiVPCZoneIdentifier.Items.Add(subnet);
                    //}
                    //if (!string.IsNullOrEmpty(ItemToEdit.VPCZoneIdentifier)) {
                    //    var subnets = ItemToEdit.VPCZoneIdentifier.Split(',');
                    //    if (subnets.Length > 0) {
                    //        foreach (var subnet in subnets) {
                    //            for (var i = 0; i < m_guiVPCZoneIdentifier.Items.Count; i++) {
                    //                if (((Amazon.EC2.Model.Subnet)m_guiVPCZoneIdentifier.Items[i]).SubnetId == subnet.Trim()) {
                    //                    m_guiVPCZoneIdentifier.SetItemChecked(i, true);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    Cursor = Cursors.Default;
                }));
            }));
            thread.Start();
        }

        private void m_guiOK_Click(object sender, EventArgs e) {
            if (m_guiName.Text.Length > 0) {
                var name = m_guiName.Text;
                var launchConfiguration = m_guiLaunchConfiguration.SelectedValue.ToString();
                var minSize = int.Parse(m_guiMinSize.Text);
                var maxSize = int.Parse(m_guiMaxSize.Text);
                var desiredCapacity = int.Parse(m_guiDesiredCapacity.Text);
                var defaultCooldown = int.Parse(m_guiDefaultCooldown.Text);
                var healthCheckGracePeriod = int.Parse(m_guiHealthCheckGracePeriod.Text);
                var healthCheckType = m_guiHealthCheckType.SelectedItem.ToString();

                var availabilityZones = new List<string>();
                for (int i = 0; i < m_guiAvailabilityZones.SelectedItems.Count; i++) {
                    availabilityZones.Add(((Amazon.EC2.Model.AvailabilityZone)m_guiAvailabilityZones.SelectedItems[i]).ZoneName);
                }

                var loadBalancers = new List<string>();
                for (int i = 0; i < m_guiLoadBalancerNames.SelectedItems.Count; i++) {
                    loadBalancers.Add(((Amazon.ElasticLoadBalancing.Model.LoadBalancerDescription)m_guiLoadBalancerNames.SelectedItems[i]).LoadBalancerName);
                }

                var vpcZoneIdentifier = string.Empty;
                for (var i = 0; i < m_guiVPCZoneIdentifier.SelectedItems.Count; i++) {
                    if (i > 0) {
                        vpcZoneIdentifier += ", ";
                    }
                    vpcZoneIdentifier += ((Amazon.EC2.Model.Subnet)m_guiVPCZoneIdentifier.SelectedItems[i]).SubnetId;
                }
                
                if (ItemToEdit == null) {
                    AmazonAutoScalingUtility.CreateAutoScalingGroup(SelectedRegion, name, defaultCooldown, launchConfiguration,
                        minSize, maxSize, desiredCapacity, healthCheckGracePeriod,
                        healthCheckType, loadBalancers, availabilityZones, vpcZoneIdentifier);
                } else {
                    AmazonAutoScalingUtility.UpdateAutoScalingGroup(SelectedRegion, name, defaultCooldown, launchConfiguration,
                        minSize, maxSize, desiredCapacity, healthCheckGracePeriod,
                        healthCheckType, loadBalancers, availabilityZones, vpcZoneIdentifier);
                }

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
