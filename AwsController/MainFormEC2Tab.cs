using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Amazon;
using Amazon.EC2.Model;
using Thp.Har.Utility;
using System.Net;

namespace AwsController {
    public partial class MainForm {
        private const string TAB_EC2 = "m_guiTabEC2";
        private const string TAB_EC2_INSTANCE = "m_guiTabEC2Instance";
        private const string TAB_EC2_AMI = "m_guiTabEC2Ami";
        private const string TAB_EC2_VOLUME = "m_guiTabEC2Volumn";
        private const string TAB_EC2_SNAPSHOT = "m_guiTabEC2Snapshot";
        private const string TAB_EC2_LOAD_BALANCER = "m_guiTabEC2LoadBalancer";

        private const string GUI_EC2_INSTANCE_GRID = "m_guiEC2InstanceGrid";
        private const string GUI_EC2_LOAD_BALANCER_GRID = "m_guiLoadBalancerGrid";

        private const string INSTANCE_STATE_RUNNING = "running";
        private const string INSTANCE_STATE_STOPPED = "stopped";
        private const string INSTANCE_STATE_STOPPING = "stopping";
        private const string INSTANCE_STATE_REBOOT = "reboot";
        private const string INSTANCE_STATE_PENDING = "pending";
        private const string INSTANCE_STATE_SHUTTING_DOWN = "shutting-down";
        private const string INSTANCE_STATE_TERMINATED = "terminated";

        private List<InstanceStatus> m_EC2InstancesStatus = null;
        private DataGridViewImageAnimator m_guiEC2DataGridImageAnimator = null;

        // MAIN
        private void MainFormEC2Tab_Constructor() {
            m_guiTabEC2Main.SelectedIndexChanged += new EventHandler(m_guiTabEC2Main_SelectedIndexChanged);

            m_guiEC2InstanceCreateImage.Click += new EventHandler(m_guiEC2InstanceCreateImage_Click);

            m_guiEC2InstanceGrid.AutoGenerateColumns = false;
            m_guiEC2InstanceGrid.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(m_guiEC2InstanceGrid_DataBindingComplete);
            m_guiEC2InstanceGrid.SelectionChanged += new EventHandler(m_guiEC2InstanceGrid_SelectionChanged);
            m_guiEC2DataGridImageAnimator = new DataGridViewImageAnimator(m_guiEC2InstanceGrid);

            m_guiEC2LoadBalancerGrid.AutoGenerateColumns = false;
            m_guiEC2LoadBalancerGrid.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(m_guiLoadBalancerGrid_DataBindingComplete);
            m_guiEC2LoadBalancerGrid.SelectionChanged += new EventHandler(m_guiLoadBalancerGrid_SelectionChanged);

            m_guiEC2UpdateSoftwareAllInstances.Click += new EventHandler(m_guiEC2UpdateSoftwareAllInstances_Click);
            m_guiEC2UpdateSoftwareMembersInstances.Click += new EventHandler(m_guiEC2UpdateSoftwareMembersInstances_Click);
            m_guiEC2UpdateSoftwareSearchInstances.Click += new EventHandler(m_guiEC2UpdateSoftwareSearchInstances_Click);
            m_guiEC2UpdateSoftwareWwwInstances.Click += new EventHandler(m_guiEC2UpdateSoftwareWwwInstances_Click);
            m_guiEC2UpdateSoftwareSelectedInstances.Click += new EventHandler(m_guiEC2UpdateSoftwareSelectedInstances_Click);

            m_guiEC2ScheduledOnOffTask.Click += new EventHandler(m_guiEC2ScheduledOnOffTask_Click);
        }

        private void LoadEC2TabControls(bool isFromTimer) {
            if (m_SelectedEC2Tab == m_guiTabEC2Main.TabPages[TAB_EC2_INSTANCE]) {
                LoadEC2Instances(m_SelectedRegion);
            } else if (m_SelectedEC2Tab == m_guiTabEC2Main.TabPages[TAB_EC2_AMI]) {
                LoadEC2Amis(m_SelectedRegion);
            } else if (m_SelectedEC2Tab == m_guiTabEC2Main.TabPages[TAB_EC2_VOLUME]) {
                LoadEC2Volumes(m_SelectedRegion);
            } else if (m_SelectedEC2Tab == m_guiTabEC2Main.TabPages[TAB_EC2_SNAPSHOT]) {
                LoadEC2Snapshots(m_SelectedRegion);
            } else if (m_SelectedEC2Tab == m_guiTabEC2Main.TabPages[TAB_EC2_LOAD_BALANCER]) {
                LoadEC2ElasticLoadBalancers(m_SelectedRegion);
            }
        }

        private void m_guiTabEC2Main_SelectedIndexChanged(object sender, EventArgs e) {
            m_SelectedEC2Tab = m_guiTabEC2Main.SelectedTab;
            LoadEC2TabControls(false);
        }


        // INSTANCES
        private void m_guiEC2InstanceGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            DataGridViewRow row = null;
            RunningInstance instance = null;

            for (var i = 0; i < m_guiEC2InstanceGrid.Rows.Count; i++) {
                row = m_guiEC2InstanceGrid.Rows[i];
                instance = row.DataBoundItem as RunningInstance;

                row.Cells["m_guiEC2InstanceGridInstanceName"].Value = AmazonEC2Utility.GetNameFromTag(instance.Tag);

                if (instance.InstanceState.Name.Equals(INSTANCE_STATE_RUNNING)) {
                    row.Cells["m_guiEC2InstanceGridInstanceState"].Value = Properties.Resources.green;
                } else if (instance.InstanceState.Name.Equals(INSTANCE_STATE_STOPPED)) {
                    row.Cells["m_guiEC2InstanceGridInstanceState"].Value = Properties.Resources.red;
                } else if (instance.InstanceState.Name.Equals(INSTANCE_STATE_REBOOT)) {
                    row.Cells["m_guiEC2InstanceGridInstanceState"].Value = Properties.Resources.blue;
                } else if (instance.InstanceState.Name.Equals(INSTANCE_STATE_STOPPING) || instance.InstanceState.Name.Equals(INSTANCE_STATE_PENDING)) {
                    row.Cells["m_guiEC2InstanceGridInstanceState"].Value = Properties.Resources.spinning;
                } else if (instance.InstanceState.Name.Equals(INSTANCE_STATE_SHUTTING_DOWN)) {
                    row.Cells["m_guiEC2InstanceGridInstanceState"].Value = Properties.Resources.orange;
                } else if (instance.InstanceState.Name.Equals(INSTANCE_STATE_TERMINATED)) {
                    row.Cells["m_guiEC2InstanceGridInstanceName"].Value = instance.InstanceState.Name;
                    row.Cells["m_guiEC2InstanceGridInstanceState"].Value = Properties.Resources.gray;
                } else {
                    row.Cells["m_guiEC2InstanceGridInstanceName"].Value = instance.InstanceState.Name;
                    row.Cells["m_guiEC2InstanceGridInstanceState"].Value = Properties.Resources.orange;
                }

                foreach (var item in m_EC2InstancesStatus) {
                    if (item.InstanceId == instance.InstanceId) {
                        row.Cells["m_guiEC2InstanceGridInstanceStatus"].Value = item.InstanceStatusDetail.Status;

                        if (item.SystemStatusDetail.Status != "ok") {
                            row.Cells["m_guiEC2InstanceGridInstanceState"].Value = Properties.Resources.spinning;
                        }

                        break;
                    }
                }

                if (instance.GroupName.Count > 0) {
                    row.Cells["m_guiEC2InstanceGridSecurityGroups"].Value = instance.GroupName[0];
                } else if (instance.GroupId.Count > 0) {
                    row.Cells["m_guiEC2InstanceGridSecurityGroups"].Value = instance.GroupId[0];
                }

                if (instance.NetworkInterfaceSet.Count > 0) {
                    var publicIpAddresses = string.Empty;
                    var j = 0;
                    foreach (var netInterface in instance.NetworkInterfaceSet) {
                        if (netInterface.Association != null && !string.IsNullOrEmpty(netInterface.Association.PublicIp)) {
                            if (j > 0) {
                                publicIpAddresses += ", ";
                            }

                            publicIpAddresses += netInterface.Association.PublicIp;
                            j++;
                        }
                    }
                    if (!string.IsNullOrEmpty(publicIpAddresses)) {
                        row.Cells["m_guiEC2InstanceGridPublicIp"].Value = publicIpAddresses;
                    }
                }
            }
        }

        private void m_guiEC2InstanceGrid_SelectionChanged(object sender, EventArgs e) {
            SetControlsState(((DataGridView)sender).Name);
        }

        private void m_guiEC2InstanceGrid_DoubleClick(object sender, EventArgs e) {
        }

        private void m_guiEC2InstanceRefresh_Click(object sender, EventArgs e) {
            LoadEC2Instances(m_SelectedRegion);
        }

        private void m_guiEC2InstanceConnectUsingPrivateIP_Click(object sender, EventArgs e) {
            var rows = m_guiEC2InstanceGrid.SelectedRows;
            foreach (DataGridViewRow row in rows) {
                if (row != null) {
                    LaunchRemoteDesktop(row, false);
                }
            }
        }

        private void m_guiEC2InstanceConnectUsingPublicIP_Click(object sender, EventArgs e) {
            var rows = m_guiEC2InstanceGrid.SelectedRows;
            foreach (DataGridViewRow row in rows) {
                if (row != null) {
                    LaunchRemoteDesktop(row, true);
                }
            }
        }

        private void m_guiEC2InstanceBackup_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to backup the selected instance(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes) {
                var th = new Thread(new ThreadStart(() => {
                    var list = GetSelectedEC2InstanceIdList();
                    foreach (var item in list) {
                        AmazonEC2Utility.CreateSnapshotForInstance(m_SelectedRegion, item);
                    }
                }));
                th.Start();
                Thread.Sleep(DELAY_WAIT_TIME);
                LoadEC2Instances(m_SelectedRegion);
            }
        }

        private void m_guiEC2InstanceChangeInstanceType_Click(object sender, EventArgs e) {
        }

        private void m_guiEC2InstanceChangeShutdownBehavior_Click(object sender, EventArgs e) {

        }

        private void m_guiEC2InstanceCreateImage_Click(object sender, EventArgs e) {
            if (m_guiEC2InstanceGrid.SelectedRows.Count == 1) {
                var instance = m_guiEC2InstanceGrid.SelectedRows[0].DataBoundItem as RunningInstance;
                var form = new CreateImageForm();
                form.Instance = instance;
                form.ShowDialog(this);

            } else if (m_guiEC2InstanceGrid.SelectedRows.Count == 0) {
                MessageBox.Show("Please select an instance to create image from", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                MessageBox.Show("You can only create image from one instance at a time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_guiEC2InstanceReboot_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to reboot the selected instance(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes) {
                var th = new Thread(new ThreadStart(() => {
                    var list = GetSelectedEC2InstanceIdList();
                    AmazonEC2Utility.RebootInstances(m_SelectedRegion, list);
                }));
                th.Start();
                Thread.Sleep(DELAY_WAIT_TIME);
                LoadEC2Instances(m_SelectedRegion);
            }
        }

        private void m_guiEC2InstanceStop_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to stop the selected instance(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes) {
                var th = new Thread(new ThreadStart(() => {
                    var list = GetSelectedEC2InstanceIdList();
                    AmazonEC2Utility.StopInstances(m_SelectedRegion, list);
                }));
                th.Start();
                Thread.Sleep(DELAY_WAIT_TIME);
                LoadEC2Instances(m_SelectedRegion);
            }
        }

        private void m_guiEC2InstanceStart_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to start the selected instance(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes) {
                var th = new Thread(new ThreadStart(() => {
                    var list = GetSelectedEC2InstanceIdList();
                    AmazonEC2Utility.StartInstances(m_SelectedRegion, list);
                }));
                th.Start();
                Thread.Sleep(DELAY_WAIT_TIME);
                LoadEC2Instances(m_SelectedRegion);
            }
        }

        private void m_guiEC2InstanceTerminate_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to terminate the selected instance(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes) {
                if (MessageBox.Show("Are you really sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes) {
                    var th = new Thread(new ThreadStart(() => {
                        var list = GetSelectedEC2InstanceIdList();
                        AmazonEC2Utility.TerminateInstances(m_SelectedRegion, list);
                    }));
                    th.Start();
                    Thread.Sleep(DELAY_WAIT_TIME);
                    LoadEC2Instances(m_SelectedRegion);
                }
            }
        }


        private void m_guiEC2UpdateSoftwareSelectedInstances_Click(object sender, EventArgs e) {
            try {
                var list = GetSelectedEC2InstanceIdList();

                if (list.Count > 0) {
                    var data = "target=instance&list=" + string.Join(",", list);
                    using (var wc = new WebClient()) {
                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        var result = wc.UploadString(CacheObject.Settings.ApiUrl + "/github/callback", "POST", data);
                    }
                } else {
                    MessageBox.Show("No instance selected to update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void m_guiEC2UpdateSoftwareAllInstances_Click(object sender, EventArgs e) {
            try {
                var data = "target=all";
                using (var wc = new WebClient()) {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var result = wc.UploadString(CacheObject.Settings.ApiUrl + "/github/callback", "POST", data);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void m_guiEC2UpdateSoftwareWwwInstances_Click(object sender, EventArgs e) {
            try {
                var data = "target=www";
                using (var wc = new WebClient()) {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var result = wc.UploadString(CacheObject.Settings.ApiUrl + "/github/callback", "POST", data);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void m_guiEC2UpdateSoftwareSearchInstances_Click(object sender, EventArgs e) {
            try {
                var data = "target=search";
                using (var wc = new WebClient()) {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var result = wc.UploadString(CacheObject.Settings.ApiUrl + "/github/callback", "POST", data);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void m_guiEC2UpdateSoftwareMembersInstances_Click(object sender, EventArgs e) {
            try {
                var data = "target=members";
                using (var wc = new WebClient()) {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var result = wc.UploadString(CacheObject.Settings.ApiUrl + "/github/callback", "POST", data);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


        private void m_guiEC2ScheduledOnOffTask_Click(object sender, EventArgs e) {
            try {
                var form = new ScheduledOnOffForm();
                form.SelectedRegion = m_SelectedRegion;
                form.ShowDialog(this);

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                    MessageBox.Show("On/Off schedule was saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetEC2ControlState() {
            var selectedRows = m_guiEC2InstanceGrid.SelectedRows;

            if (selectedRows.Count > 0) {
                var instance = selectedRows[0].DataBoundItem as RunningInstance;
                string currentStateType = instance.InstanceState.Name;
                bool isOfSimilarStateType = true;

                foreach (DataGridViewRow row in selectedRows) {
                    instance = row.DataBoundItem as RunningInstance;

                    if (instance.InstanceState.Name != currentStateType) {
                        isOfSimilarStateType = false;
                        currentStateType = instance.InstanceState.Name;
                    }
                }

                if (isOfSimilarStateType) {
                    if (currentStateType == INSTANCE_STATE_RUNNING) {
                        m_guiEC2InstanceConnectUsingPrivateIP.Enabled = true;
                        m_guiEC2InstanceReboot.Enabled = true;
                        m_guiEC2InstanceStop.Enabled = true;
                        m_guiEC2InstanceStart.Enabled = false;
                        m_guiEC2InstanceTerminate.Enabled = true;
                    } else {
                        m_guiEC2InstanceConnectUsingPrivateIP.Enabled = false;
                        m_guiEC2InstanceReboot.Enabled = false;
                        m_guiEC2InstanceStop.Enabled = false;
                        m_guiEC2InstanceStart.Enabled = true;
                        m_guiEC2InstanceTerminate.Enabled = true;
                    }
                } else {
                    m_guiEC2InstanceConnectUsingPrivateIP.Enabled = false;
                    m_guiEC2InstanceReboot.Enabled = false;
                    m_guiEC2InstanceStop.Enabled = false;
                    m_guiEC2InstanceStart.Enabled = false;
                    m_guiEC2InstanceTerminate.Enabled = false;
                }
            }
        }

        private List<RunningInstance> GetSelectedEC2Instances() {
            var instances = new List<RunningInstance>();

            foreach (DataGridViewRow row in m_guiEC2InstanceGrid.SelectedRows) {
                var item = row.DataBoundItem as RunningInstance;
                if (item != null) {
                    instances.Add(item);
                }
            }

            return instances;
        }

        private List<string> GetSelectedEC2InstanceIdList() {
            var instances = GetSelectedEC2Instances();
            var list = new List<string>();

            foreach (var instance in instances) {
                list.Add(instance.InstanceId);
            }

            return list;
        }

        private void LoadEC2Instances(RegionEndpoint region) {
            if (!string.IsNullOrEmpty(CacheObject.Settings.AWSAccessKey) && !string.IsNullOrEmpty(CacheObject.Settings.AWSSecretKey))
            {
                var thread = new Thread(new ThreadStart(() => {
                    var reservations = AmazonEC2Utility.DescribeInstances(region).DescribeInstancesResult.Reservation;
                    var instances = new List<RunningInstance>();

                    foreach (var reservation in reservations)
                    {
                        foreach (var instance in reservation.RunningInstance)
                        {
                            instances.Add(instance);
                        }
                    }

                    try
                    {
                        Invoke(new MethodInvoker(() => {
                            var selectedRows = new List<int>();
                            for (int i = 0; i < m_guiEC2InstanceGrid.Rows.Count; i++)
                            {
                                if (m_guiEC2InstanceGrid.Rows[i].Selected)
                                {
                                    selectedRows.Add(i);
                                }
                            }

                            m_guiEC2InstanceGrid.SuspendLayout();

                            var focused = m_guiEC2InstanceGrid.Focused;
                            m_EC2InstancesStatus = AmazonEC2Utility.DescribeInstanceStatus(m_SelectedRegion);
                            m_guiEC2InstanceGrid.DataSource = instances;
                            if (focused) m_guiEC2InstanceGrid.Focus();

                            if (m_guiEC2InstanceGrid.Rows.Count >= selectedRows.Count)
                            {
                                m_guiEC2InstanceGrid.ClearSelection();

                                for (int i = 0; i < selectedRows.Count; i++)
                                {
                                    m_guiEC2InstanceGrid.Rows[selectedRows[i]].Selected = true;
                                }
                            }

                            m_guiEC2InstanceGrid.ResumeLayout();
                        }));
                    }
                    catch { }
                }));
                thread.Start();
            }
            else
            {
                MessageBox.Show("Please provide AWSAccessKey and AWSSecretKey in app.config file");
            }
        }

        private void LaunchRemoteDesktop(DataGridViewRow row, bool usePublicIp) {
            var instance = row.DataBoundItem as RunningInstance;

            if (instance.InstanceState.Name.Equals("running", StringComparison.OrdinalIgnoreCase)) {
                var publicIp = row.Cells["m_guiEC2InstanceGridPublicIp"].Value;
                var privateIp = row.Cells["m_guiEC2InstanceGridPrivateIpAddress"].Value;
                string command = null;
                string arguments = null;

                if (usePublicIp) {
                    if (publicIp != null) {
                        arguments = publicIp.ToString();
                    } else {
                        MessageBox.Show("This instance does not have an associated Public IP Address. Please add one before attempting to connect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    if (privateIp != null) {
                        arguments = privateIp.ToString();
                    } else {
                        MessageBox.Show("This instance does not have an associated Private IP Address. Please add one before attempting to connect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (instance.Platform.Equals("windows", StringComparison.OrdinalIgnoreCase)) {
                    command = "mstsc.exe";
                    arguments = "/v:" + arguments;
                } else {
                    command = "putty.exe";
                }

                if (arguments != null) {
                    try {
                        using (var process = new System.Diagnostics.Process()) {
                            var processInfo = new System.Diagnostics.ProcessStartInfo();
                            processInfo.ErrorDialog = false;
                            processInfo.UseShellExecute = false;
                            processInfo.CreateNoWindow = true;
                            processInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            processInfo.FileName = command;
                            processInfo.Arguments = arguments;
                            process.StartInfo = processInfo;
                            process.Start();
                        }
                    } catch (Exception ex) {
                        if (ex.Message.Equals("The system cannot find the file specified")) {
                            MessageBox.Show("Cannot find putty.exe in the path. Make sure it's located some where in your environment executable path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } else {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            } else {
                MessageBox.Show("Instance is not running. Please start it first before connecting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // AMI
        private void LoadEC2Amis(RegionEndpoint m_SelectedRegion) {
        }



        // VOLUMES
        private void LoadEC2Volumes(RegionEndpoint m_SelectedRegion) {
        }



        // SNAPSHOTS
        private void LoadEC2Snapshots(RegionEndpoint m_SelectedRegion) {
        }



        // LOAD BALANCERS
        void m_guiLoadBalancerGrid_SelectionChanged(object sender, EventArgs e) {
            SetControlsState(((DataGridView)sender).Name);
        }

        void m_guiLoadBalancerGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            DataGridViewRow row = null;
            Amazon.ElasticLoadBalancing.Model.LoadBalancerDescription elb = null;

            for (var i = 0; i < m_guiEC2LoadBalancerGrid.Rows.Count; i++) {
                row = m_guiEC2LoadBalancerGrid.Rows[i];
                elb = row.DataBoundItem as Amazon.ElasticLoadBalancing.Model.LoadBalancerDescription;

                row.Cells["m_guiLoadBalancerGridInstances"].Value = elb.Instances.Count;
                row.Cells["m_guiLoadBalancerGridSecurityGroups"].Value = elb.SecurityGroups.FirstOrDefault();
                row.Cells["m_guiLoadBalancerGridSubnets"].Value = elb.Subnets.FirstOrDefault();
            }
        }

        private void LoadEC2ElasticLoadBalancers(RegionEndpoint region) {
            var th = new Thread(new ThreadStart(() => {
                var lbs = AmazonElasticLoadBalancingUtility.DescribeLoadBalancers(region);

                try {
                    if (InvokeRequired) {
                        Invoke(new MethodInvoker(() => {
                            m_guiEC2LoadBalancerGrid.DataSource = lbs;
                        }));
                    }
                } catch { }

                //var reservations = AmazonElasticLoadBalancingUtility.DescribeLoadBalancers();
                //var instances = new List<RunningInstance>();

                //foreach (var reservation in reservations) {
                //    foreach (var instance in reservation.RunningInstance) {
                //        instances.Add(instance);
                //    }
                //}

                //try {
                //    if (InvokeRequired) {
                //        Invoke(new MethodInvoker(() => {
                //            var selectedRows = new List<int>();
                //            for (int i = 0; i < m_guiEC2InstanceGrid.Rows.Count; i++) {
                //                if (m_guiEC2InstanceGrid.Rows[i].Selected) {
                //                    selectedRows.Add(i);
                //                }
                //            }

                //            m_guiEC2InstanceGrid.SuspendLayout();
                //            var focused = m_guiEC2InstanceGrid.Focused;
                //            m_InstancesStatus = AmazonEC2Utility.DescribeInstanceStatus();
                //            m_guiEC2InstanceGrid.DataSource = instances;
                //            if (focused) m_guiEC2InstanceGrid.Focus();

                //            if (selectedRows.Count > 0) {
                //                m_guiEC2InstanceGrid.ClearSelection();

                //                for (int i = 0; i < selectedRows.Count; i++) {
                //                    m_guiEC2InstanceGrid.Rows[selectedRows[i]].Selected = true;
                //                }
                //            }

                //            m_guiEC2InstanceGrid.ResumeLayout();
                //        }));
                //    }
                //} catch { }
            }));
            th.Start();
        }
    }
}
