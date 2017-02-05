using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Thp.Har.Utility;
using Amazon.EC2.Model;
using System.Threading;
using Amazon;
using System.IO;

namespace AwsController {
    public partial class MainForm : Form {
        private const int TIMER_INTERVAL = 30000;
        private const int DELAY_WAIT_TIME = 1000;

        private RegionEndpoint m_SelectedRegion = null;

        private TabPage m_SelectedMainTab = null;
        private TabPage m_SelectedEC2Tab = null;
        private TabPage m_SelectedS3Tab = null;
        private TabPage m_SelectedVPCTab = null;
        private TabPage m_SelectedASTab = null;
        private TabPage m_SelectedGlacierTab = null;

        private System.Windows.Forms.Timer m_Timer = new System.Windows.Forms.Timer();

        private AwsControllerQueueForm m_AwsControllerQueueForm = new AwsControllerQueueForm();


        public MainForm() {
            InitializeComponent();

            this.Load += new EventHandler(MainForm_Load);
            this.Resize += new EventHandler(MainForm_Resize);

            m_guiTab.SelectedIndexChanged += new EventHandler(m_guiTab_SelectedIndexChanged);
            m_guiRegionEndpoints.SelectedIndexChanged += new EventHandler(m_guiRegionEndpoints_SelectedIndexChanged);

            MainFormASTab_Constructor();
            MainFormEC2Tab_Constructor();
            MainFormS3Tab_Constructor();
            MainFormVPCTab_Constructor();
            MainFormGlacierTab_Constructor();

            // Set default tab on first load otherwise nothing get shown
            m_SelectedMainTab = m_guiTabEC2;
            m_SelectedEC2Tab = m_guiTabEC2Instance;
            m_SelectedASTab = m_guiTabASLaunchConfiguration;
            m_SelectedGlacierTab = m_guiTabGlacierVault;

            m_Timer.Interval = TIMER_INTERVAL;
            m_Timer.Tick += new EventHandler(m_Timer_Tick);
            m_Timer.Start();
        }


        private void MainForm_Load(object sender, EventArgs e) {
            DoLayout();
            LoadRegionEndpoints();
        }

        private void MainForm_Resize(object sender, EventArgs e) {
            DoLayout();
        }

        private void m_Timer_Tick(object sender, EventArgs e) {
            LoadMainTabControls(true);
        }

        private void m_guiRegionEndpoints_SelectedIndexChanged(object sender, EventArgs e) {
            m_SelectedRegion = m_guiRegionEndpoints.SelectedItem as RegionEndpoint;
            LoadMainTabControls(false);
        }

        private void m_guiTab_SelectedIndexChanged(object sender, EventArgs e) {
            m_SelectedMainTab = m_guiTab.SelectedTab;
            LoadMainTabControls(false);
        }

        private void DoLayout() {
            m_guiTab.Left = 6;
            m_guiTab.Top = 25;
            m_guiTab.Width = this.Width - 20;
            m_guiTab.Height = this.Height - 56;

            m_guiS3TabLeftListView.Height = splitContainer1.Panel1.Height - m_guiS3TabLeftStatusStrip.Height - 24;
            m_guiS3TabRightListView.Height = splitContainer1.Panel2.Height - m_guiS3TabRightStatusStrip.Height - 24;
        }

        private void LoadRegionEndpoints() {
            m_guiRegionEndpoints.ComboBox.DisplayMember = "DisplayName";
            m_guiRegionEndpoints.ComboBox.ValueMember = "SystemName";

            foreach (var endpoint in Amazon.RegionEndpoint.EnumerableAllRegions) {
                m_guiRegionEndpoints.ComboBox.Items.Add(endpoint);
            }

            m_guiRegionEndpoints.ComboBox.SelectedIndex = 0;
        }

        private void LoadMainTabControls(bool isFromTimer) {
            if (m_SelectedMainTab == m_guiTab.TabPages[TAB_EC2]) {
                LoadEC2TabControls(isFromTimer);
            } else if (m_SelectedMainTab == m_guiTab.TabPages[TAB_VPC]) {
                LoadVpcTabControls(isFromTimer);
            } else if (m_SelectedMainTab == m_guiTab.TabPages[TAB_S3]) {
                LoadS3TabControls(isFromTimer);
            } else if (m_SelectedMainTab == m_guiTab.TabPages[TAB_AS]) {
                LoadASTabControls(isFromTimer);
            } else if (m_SelectedMainTab == m_guiTab.TabPages[TAB_GLACIER]) {
                LoadGlacierTabControls(isFromTimer);
            }
        }

        private void SetControlsState(string name) {
            switch (name) {
                case GUI_EC2_INSTANCE_GRID:
                    SetEC2ControlState();
                    break;
            }
        }
    }
}
