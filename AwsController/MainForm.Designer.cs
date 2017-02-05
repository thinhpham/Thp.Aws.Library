namespace AwsController {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_guiTab = new System.Windows.Forms.TabControl();
            this.m_guiTabEC2 = new System.Windows.Forms.TabPage();
            this.m_guiTabEC2Main = new System.Windows.Forms.TabControl();
            this.m_guiTabEC2Instance = new System.Windows.Forms.TabPage();
            this.m_guiEC2InstanceGrid = new System.Windows.Forms.DataGridView();
            this.m_guiEC2InstanceGridInstanceState = new System.Windows.Forms.DataGridViewImageColumn();
            this.m_guiEC2InstanceGridInstanceStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridInstanceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridInstanceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridImageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridRootDeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridInstanceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridSecurityGroups = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridKeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridPrivateIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridPrivateDnsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridPublicIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiEC2InstanceGridPublicDnsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_guiEC2InstanceRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.m_guiEC2InstanceConnectUsingPrivateIP = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceConnectUsingPublicIP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiEC2InstanceReboot = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceStart = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceStop = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceTerminate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiEC2InstanceAddEditTags = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceCreateImage = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceChangeInstanceType = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceChangeSecurityGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceChangeShutdownBehavior = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceChangeSourceDestCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2InstanceChangeTerminationProtection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.m_guiEC2UpdateSoftwareAllInstances = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2UpdateSoftwareMembersInstances = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2UpdateSoftwareSearchInstances = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2UpdateSoftwareWwwInstances = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiEC2UpdateSoftwareSelectedInstances = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.m_guiEC2ScheduledOnOffTask = new System.Windows.Forms.ToolStripMenuItem();
            this.m_guiTabEC2Ami = new System.Windows.Forms.TabPage();
            this.m_guiTabEC2Volume = new System.Windows.Forms.TabPage();
            this.m_guiTabEC2Snapshot = new System.Windows.Forms.TabPage();
            this.m_guiTabEC2LoadBalancer = new System.Windows.Forms.TabPage();
            this.m_guiEC2LoadBalancerGrid = new System.Windows.Forms.DataGridView();
            this.m_guiLoadBalancerGridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiLoadBalancerGridInstances = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiLoadBalancerGridDNSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiLoadBalancerGridScheme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiLoadBalancerGridVPCId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiLoadBalancerGridSecurityGroups = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiLoadBalancerGridSubnets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.m_guiTabVPC = new System.Windows.Forms.TabPage();
            this.m_guiTabAS = new System.Windows.Forms.TabPage();
            this.m_guiTabASMain = new System.Windows.Forms.TabControl();
            this.m_guiTabASLaunchConfiguration = new System.Windows.Forms.TabPage();
            this.m_guiASLaunchConfigurationGrid = new System.Windows.Forms.DataGridView();
            this.m_guiASLaunchConfigurationGridLaunchConfigurationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASLaunchConfigurationGridImageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASLaunchConfigurationGridKeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASLaunchConfigurationGridInstanceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASLaunchConfigurationGridCreatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASLaunchConfigurationGridInstanceMonitoring = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASLaunchConfigurationGridEbsOptimized = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.m_guiASRefreshLaunchConfiguration = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiASAddLaunchConfiguration = new System.Windows.Forms.ToolStripButton();
            this.m_guiASDeleteLaunchConfiguration = new System.Windows.Forms.ToolStripButton();
            this.m_guiTabASGroup = new System.Windows.Forms.TabPage();
            this.m_guiASGroupGrid = new System.Windows.Forms.DataGridView();
            this.m_guiASGroupGridAutoScalingGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridCreatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridLaunchConfigurationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridMinSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridMaxSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridDesiredCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridVPCAvailabilityZones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridVPCZoneIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridLoadBalancerNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridDefaultCooldown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridHealthCheckGracePeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASGroupGridHealthCheckType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip9 = new System.Windows.Forms.ToolStrip();
            this.m_guiASRefreshGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiASAddGroup = new System.Windows.Forms.ToolStripButton();
            this.m_guiASEditGroup = new System.Windows.Forms.ToolStripButton();
            this.m_guiASDeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiASSuspendGroup = new System.Windows.Forms.ToolStripButton();
            this.m_guiASResumeGroup = new System.Windows.Forms.ToolStripButton();
            this.m_guiTabASPolicy = new System.Windows.Forms.TabPage();
            this.m_guiASPolicyGrid = new System.Windows.Forms.DataGridView();
            this.m_guiASPolicyGridScalingPolicyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASPolicyGridScalingGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASPolicyGridAdjustmentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASPolicyGridScalingAdjustment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASPolicyGridCooldown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip10 = new System.Windows.Forms.ToolStrip();
            this.m_guiASRefreshPolicy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiASAddPolicy = new System.Windows.Forms.ToolStripButton();
            this.m_guiASEditPolicy = new System.Windows.Forms.ToolStripButton();
            this.m_guiASDeletePolicy = new System.Windows.Forms.ToolStripButton();
            this.m_guiTabASAlarm = new System.Windows.Forms.TabPage();
            this.m_guiASAlarmGrid = new System.Windows.Forms.DataGridView();
            this.m_guiASAlarmGridAlarmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridActionsEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_guiASAlarmGridNamespace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridMetricName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridStatistic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridEvaluationPeriods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridStateReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridStateReasonData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridStateValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASAlarmGridStateUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip11 = new System.Windows.Forms.ToolStrip();
            this.m_guiASRefreshAlarm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiASAddAlarm = new System.Windows.Forms.ToolStripButton();
            this.m_guiASEditAlarm = new System.Windows.Forms.ToolStripButton();
            this.m_guiASDeleteAlarm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiASViewAlarmHistories = new System.Windows.Forms.ToolStripButton();
            this.m_guiTabASSchedule = new System.Windows.Forms.TabPage();
            this.m_guiASScheduleGrid = new System.Windows.Forms.DataGridView();
            this.m_guiASScheduleGridScheduleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASScheduleGridGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASScheduleGridStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASScheduleGridEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASScheduleGridRecurrence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASScheduleGridMinSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASScheduleGridMaxSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASScheduleGridDesiredCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip12 = new System.Windows.Forms.ToolStrip();
            this.m_guiASRefreshSchedule = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiASAddSchedule = new System.Windows.Forms.ToolStripButton();
            this.m_guiASEditSchedule = new System.Windows.Forms.ToolStripButton();
            this.m_guiASDeleteSchedule = new System.Windows.Forms.ToolStripButton();
            this.m_guiTabASInstance = new System.Windows.Forms.TabPage();
            this.m_guiASInstanceGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.m_guiASRefreshInstance = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiASTerminateInstance = new System.Windows.Forms.ToolStripButton();
            this.m_guiTabASActivity = new System.Windows.Forms.TabPage();
            this.m_guiASActivityGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASActivityGridStatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_guiASActivityGridProgressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip13 = new System.Windows.Forms.ToolStrip();
            this.m_guiASRefreshActivity = new System.Windows.Forms.ToolStripButton();
            this.m_guiTabS3 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_guiS3TabLeftStatusStrip = new System.Windows.Forms.StatusStrip();
            this.m_guiS3TabLeftStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_guiS3TabLeftListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_guiS3TabSmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.m_guiS3TabLeftRefresh = new System.Windows.Forms.ToolStripButton();
            this.m_guiS3TabLeftCopyToRight = new System.Windows.Forms.ToolStripButton();
            this.m_guiS3TabLeftAddFolder = new System.Windows.Forms.ToolStripButton();
            this.m_guiS3TabLeftDelete = new System.Windows.Forms.ToolStripButton();
            this.m_guiS3TabRightStatusStrip = new System.Windows.Forms.StatusStrip();
            this.m_guiS3TabRightStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_guiS3TabRightListView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.m_guiS3TabRightRefresh = new System.Windows.Forms.ToolStripButton();
            this.m_guiS3TabRightCopyToLeft = new System.Windows.Forms.ToolStripButton();
            this.m_guiS3TabRightAddBucket = new System.Windows.Forms.ToolStripButton();
            this.m_guiS3TabRightAddFolder = new System.Windows.Forms.ToolStripButton();
            this.m_guiS3TabRightDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.m_guiS3TabOpenTransferQueue = new System.Windows.Forms.ToolStripButton();
            this.m_guiTabGlacier = new System.Windows.Forms.TabPage();
            this.m_guiTabGlacierMain = new System.Windows.Forms.TabControl();
            this.m_guiTabGlacierVault = new System.Windows.Forms.TabPage();
            this.m_guiGlacierVaultGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip14 = new System.Windows.Forms.ToolStrip();
            this.m_guiGlacierVaultRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.m_guiGlacierVaultAddNew = new System.Windows.Forms.ToolStripButton();
            this.m_guiGlacierVaultEdit = new System.Windows.Forms.ToolStripButton();
            this.m_guiGlacierVaultDelete = new System.Windows.Forms.ToolStripButton();
            this.m_guiTabGlacierJob = new System.Windows.Forms.TabPage();
            this.m_guiGlacierJobGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip15 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.m_guiTabGlacierInventory = new System.Windows.Forms.TabPage();
            this.m_guiGlacierInventoryGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip16 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.m_guiRegionEndpoints = new System.Windows.Forms.ToolStripComboBox();
            this.m_guiTab.SuspendLayout();
            this.m_guiTabEC2.SuspendLayout();
            this.m_guiTabEC2Main.SuspendLayout();
            this.m_guiTabEC2Instance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiEC2InstanceGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.m_guiTabEC2LoadBalancer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiEC2LoadBalancerGrid)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.m_guiTabAS.SuspendLayout();
            this.m_guiTabASMain.SuspendLayout();
            this.m_guiTabASLaunchConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASLaunchConfigurationGrid)).BeginInit();
            this.toolStrip7.SuspendLayout();
            this.m_guiTabASGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASGroupGrid)).BeginInit();
            this.toolStrip9.SuspendLayout();
            this.m_guiTabASPolicy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASPolicyGrid)).BeginInit();
            this.toolStrip10.SuspendLayout();
            this.m_guiTabASAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASAlarmGrid)).BeginInit();
            this.toolStrip11.SuspendLayout();
            this.m_guiTabASSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASScheduleGrid)).BeginInit();
            this.toolStrip12.SuspendLayout();
            this.m_guiTabASInstance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASInstanceGrid)).BeginInit();
            this.toolStrip8.SuspendLayout();
            this.m_guiTabASActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASActivityGrid)).BeginInit();
            this.toolStrip13.SuspendLayout();
            this.m_guiTabS3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_guiS3TabLeftStatusStrip.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.m_guiS3TabRightStatusStrip.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.m_guiTabGlacier.SuspendLayout();
            this.m_guiTabGlacierMain.SuspendLayout();
            this.m_guiTabGlacierVault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiGlacierVaultGrid)).BeginInit();
            this.toolStrip14.SuspendLayout();
            this.m_guiTabGlacierJob.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiGlacierJobGrid)).BeginInit();
            this.toolStrip15.SuspendLayout();
            this.m_guiTabGlacierInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiGlacierInventoryGrid)).BeginInit();
            this.toolStrip16.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_guiTab
            // 
            this.m_guiTab.Controls.Add(this.m_guiTabEC2);
            this.m_guiTab.Controls.Add(this.m_guiTabVPC);
            this.m_guiTab.Controls.Add(this.m_guiTabAS);
            this.m_guiTab.Controls.Add(this.m_guiTabS3);
            this.m_guiTab.Controls.Add(this.m_guiTabGlacier);
            this.m_guiTab.Location = new System.Drawing.Point(32, 65);
            this.m_guiTab.Name = "m_guiTab";
            this.m_guiTab.SelectedIndex = 0;
            this.m_guiTab.Size = new System.Drawing.Size(948, 629);
            this.m_guiTab.TabIndex = 0;
            // 
            // m_guiTabEC2
            // 
            this.m_guiTabEC2.Controls.Add(this.m_guiTabEC2Main);
            this.m_guiTabEC2.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabEC2.Name = "m_guiTabEC2";
            this.m_guiTabEC2.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabEC2.Size = new System.Drawing.Size(940, 603);
            this.m_guiTabEC2.TabIndex = 0;
            this.m_guiTabEC2.Text = "EC2";
            this.m_guiTabEC2.UseVisualStyleBackColor = true;
            // 
            // m_guiTabEC2Main
            // 
            this.m_guiTabEC2Main.Controls.Add(this.m_guiTabEC2Instance);
            this.m_guiTabEC2Main.Controls.Add(this.m_guiTabEC2Ami);
            this.m_guiTabEC2Main.Controls.Add(this.m_guiTabEC2Volume);
            this.m_guiTabEC2Main.Controls.Add(this.m_guiTabEC2Snapshot);
            this.m_guiTabEC2Main.Controls.Add(this.m_guiTabEC2LoadBalancer);
            this.m_guiTabEC2Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiTabEC2Main.Location = new System.Drawing.Point(3, 3);
            this.m_guiTabEC2Main.Name = "m_guiTabEC2Main";
            this.m_guiTabEC2Main.SelectedIndex = 0;
            this.m_guiTabEC2Main.Size = new System.Drawing.Size(934, 597);
            this.m_guiTabEC2Main.TabIndex = 0;
            // 
            // m_guiTabEC2Instance
            // 
            this.m_guiTabEC2Instance.Controls.Add(this.m_guiEC2InstanceGrid);
            this.m_guiTabEC2Instance.Controls.Add(this.toolStrip1);
            this.m_guiTabEC2Instance.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabEC2Instance.Name = "m_guiTabEC2Instance";
            this.m_guiTabEC2Instance.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabEC2Instance.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabEC2Instance.TabIndex = 0;
            this.m_guiTabEC2Instance.Text = "Instances";
            this.m_guiTabEC2Instance.UseVisualStyleBackColor = true;
            // 
            // m_guiEC2InstanceGrid
            // 
            this.m_guiEC2InstanceGrid.AllowUserToAddRows = false;
            this.m_guiEC2InstanceGrid.AllowUserToDeleteRows = false;
            this.m_guiEC2InstanceGrid.AllowUserToOrderColumns = true;
            this.m_guiEC2InstanceGrid.AllowUserToResizeRows = false;
            this.m_guiEC2InstanceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiEC2InstanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiEC2InstanceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_guiEC2InstanceGridInstanceState,
            this.m_guiEC2InstanceGridInstanceStatus,
            this.m_guiEC2InstanceGridInstanceName,
            this.m_guiEC2InstanceGridInstanceId,
            this.m_guiEC2InstanceGridImageId,
            this.m_guiEC2InstanceGridRootDeviceType,
            this.m_guiEC2InstanceGridInstanceType,
            this.m_guiEC2InstanceGridSecurityGroups,
            this.m_guiEC2InstanceGridKeyName,
            this.m_guiEC2InstanceGridPrivateIpAddress,
            this.m_guiEC2InstanceGridPrivateDnsName,
            this.m_guiEC2InstanceGridPublicIp,
            this.m_guiEC2InstanceGridPublicDnsName});
            this.m_guiEC2InstanceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiEC2InstanceGrid.Location = new System.Drawing.Point(3, 28);
            this.m_guiEC2InstanceGrid.Name = "m_guiEC2InstanceGrid";
            this.m_guiEC2InstanceGrid.RowHeadersWidth = 31;
            this.m_guiEC2InstanceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiEC2InstanceGrid.ShowEditingIcon = false;
            this.m_guiEC2InstanceGrid.Size = new System.Drawing.Size(920, 540);
            this.m_guiEC2InstanceGrid.TabIndex = 1;
            // 
            // m_guiEC2InstanceGridInstanceState
            // 
            this.m_guiEC2InstanceGridInstanceState.HeaderText = "State";
            this.m_guiEC2InstanceGridInstanceState.Name = "m_guiEC2InstanceGridInstanceState";
            this.m_guiEC2InstanceGridInstanceState.Width = 38;
            // 
            // m_guiEC2InstanceGridInstanceStatus
            // 
            this.m_guiEC2InstanceGridInstanceStatus.HeaderText = "Status";
            this.m_guiEC2InstanceGridInstanceStatus.Name = "m_guiEC2InstanceGridInstanceStatus";
            this.m_guiEC2InstanceGridInstanceStatus.Width = 62;
            // 
            // m_guiEC2InstanceGridInstanceName
            // 
            this.m_guiEC2InstanceGridInstanceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_guiEC2InstanceGridInstanceName.HeaderText = "Name";
            this.m_guiEC2InstanceGridInstanceName.Name = "m_guiEC2InstanceGridInstanceName";
            this.m_guiEC2InstanceGridInstanceName.Width = 60;
            // 
            // m_guiEC2InstanceGridInstanceId
            // 
            this.m_guiEC2InstanceGridInstanceId.DataPropertyName = "InstanceId";
            this.m_guiEC2InstanceGridInstanceId.HeaderText = "Instance";
            this.m_guiEC2InstanceGridInstanceId.Name = "m_guiEC2InstanceGridInstanceId";
            this.m_guiEC2InstanceGridInstanceId.Width = 73;
            // 
            // m_guiEC2InstanceGridImageId
            // 
            this.m_guiEC2InstanceGridImageId.DataPropertyName = "ImageId";
            this.m_guiEC2InstanceGridImageId.HeaderText = "AMI ID";
            this.m_guiEC2InstanceGridImageId.Name = "m_guiEC2InstanceGridImageId";
            this.m_guiEC2InstanceGridImageId.Width = 51;
            // 
            // m_guiEC2InstanceGridRootDeviceType
            // 
            this.m_guiEC2InstanceGridRootDeviceType.DataPropertyName = "RootDeviceType";
            this.m_guiEC2InstanceGridRootDeviceType.HeaderText = "Root Device";
            this.m_guiEC2InstanceGridRootDeviceType.Name = "m_guiEC2InstanceGridRootDeviceType";
            this.m_guiEC2InstanceGridRootDeviceType.Width = 85;
            // 
            // m_guiEC2InstanceGridInstanceType
            // 
            this.m_guiEC2InstanceGridInstanceType.DataPropertyName = "InstanceType";
            this.m_guiEC2InstanceGridInstanceType.HeaderText = "Type";
            this.m_guiEC2InstanceGridInstanceType.Name = "m_guiEC2InstanceGridInstanceType";
            this.m_guiEC2InstanceGridInstanceType.Width = 56;
            // 
            // m_guiEC2InstanceGridSecurityGroups
            // 
            this.m_guiEC2InstanceGridSecurityGroups.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_guiEC2InstanceGridSecurityGroups.HeaderText = "Security Groups";
            this.m_guiEC2InstanceGridSecurityGroups.Name = "m_guiEC2InstanceGridSecurityGroups";
            this.m_guiEC2InstanceGridSecurityGroups.Width = 98;
            // 
            // m_guiEC2InstanceGridKeyName
            // 
            this.m_guiEC2InstanceGridKeyName.DataPropertyName = "KeyName";
            this.m_guiEC2InstanceGridKeyName.HeaderText = "Key Pair Name";
            this.m_guiEC2InstanceGridKeyName.Name = "m_guiEC2InstanceGridKeyName";
            this.m_guiEC2InstanceGridKeyName.Width = 94;
            // 
            // m_guiEC2InstanceGridPrivateIpAddress
            // 
            this.m_guiEC2InstanceGridPrivateIpAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_guiEC2InstanceGridPrivateIpAddress.DataPropertyName = "PrivateIpAddress";
            this.m_guiEC2InstanceGridPrivateIpAddress.HeaderText = "Private IP";
            this.m_guiEC2InstanceGridPrivateIpAddress.Name = "m_guiEC2InstanceGridPrivateIpAddress";
            this.m_guiEC2InstanceGridPrivateIpAddress.Width = 72;
            // 
            // m_guiEC2InstanceGridPrivateDnsName
            // 
            this.m_guiEC2InstanceGridPrivateDnsName.DataPropertyName = "PrivateDnsName";
            this.m_guiEC2InstanceGridPrivateDnsName.HeaderText = "Private Dns Name";
            this.m_guiEC2InstanceGridPrivateDnsName.Name = "m_guiEC2InstanceGridPrivateDnsName";
            this.m_guiEC2InstanceGridPrivateDnsName.Width = 83;
            // 
            // m_guiEC2InstanceGridPublicIp
            // 
            this.m_guiEC2InstanceGridPublicIp.HeaderText = "Public IP";
            this.m_guiEC2InstanceGridPublicIp.Name = "m_guiEC2InstanceGridPublicIp";
            this.m_guiEC2InstanceGridPublicIp.Width = 69;
            // 
            // m_guiEC2InstanceGridPublicDnsName
            // 
            this.m_guiEC2InstanceGridPublicDnsName.DataPropertyName = "PublicDnsName";
            this.m_guiEC2InstanceGridPublicDnsName.HeaderText = "Public Dns Name";
            this.m_guiEC2InstanceGridPublicDnsName.Name = "m_guiEC2InstanceGridPublicDnsName";
            this.m_guiEC2InstanceGridPublicDnsName.Width = 105;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiEC2InstanceRefresh,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton4});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(920, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_guiEC2InstanceRefresh
            // 
            this.m_guiEC2InstanceRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiEC2InstanceRefresh.Image = ((System.Drawing.Image)(resources.GetObject("m_guiEC2InstanceRefresh.Image")));
            this.m_guiEC2InstanceRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiEC2InstanceRefresh.Name = "m_guiEC2InstanceRefresh";
            this.m_guiEC2InstanceRefresh.Size = new System.Drawing.Size(50, 22);
            this.m_guiEC2InstanceRefresh.Text = "Refresh";
            this.m_guiEC2InstanceRefresh.Click += new System.EventHandler(this.m_guiEC2InstanceRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiEC2InstanceConnectUsingPrivateIP,
            this.m_guiEC2InstanceConnectUsingPublicIP,
            this.toolStripSeparator2,
            this.m_guiEC2InstanceReboot,
            this.m_guiEC2InstanceStart,
            this.m_guiEC2InstanceStop,
            this.m_guiEC2InstanceTerminate,
            this.toolStripSeparator3,
            this.m_guiEC2InstanceAddEditTags,
            this.m_guiEC2InstanceBackup,
            this.m_guiEC2InstanceCreateImage,
            this.m_guiEC2InstanceChangeInstanceType,
            this.m_guiEC2InstanceChangeSecurityGroup,
            this.m_guiEC2InstanceChangeShutdownBehavior,
            this.m_guiEC2InstanceChangeSourceDestCheck,
            this.m_guiEC2InstanceChangeTerminationProtection});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripDropDownButton1.Text = "Actions";
            // 
            // m_guiEC2InstanceConnectUsingPrivateIP
            // 
            this.m_guiEC2InstanceConnectUsingPrivateIP.Name = "m_guiEC2InstanceConnectUsingPrivateIP";
            this.m_guiEC2InstanceConnectUsingPrivateIP.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceConnectUsingPrivateIP.Text = "Connect using Private IP";
            this.m_guiEC2InstanceConnectUsingPrivateIP.Click += new System.EventHandler(this.m_guiEC2InstanceConnectUsingPrivateIP_Click);
            // 
            // m_guiEC2InstanceConnectUsingPublicIP
            // 
            this.m_guiEC2InstanceConnectUsingPublicIP.Name = "m_guiEC2InstanceConnectUsingPublicIP";
            this.m_guiEC2InstanceConnectUsingPublicIP.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceConnectUsingPublicIP.Text = "Connect using Public IP";
            this.m_guiEC2InstanceConnectUsingPublicIP.Click += new System.EventHandler(this.m_guiEC2InstanceConnectUsingPublicIP_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(238, 6);
            // 
            // m_guiEC2InstanceReboot
            // 
            this.m_guiEC2InstanceReboot.Name = "m_guiEC2InstanceReboot";
            this.m_guiEC2InstanceReboot.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceReboot.Text = "Reboot";
            this.m_guiEC2InstanceReboot.Click += new System.EventHandler(this.m_guiEC2InstanceReboot_Click);
            // 
            // m_guiEC2InstanceStart
            // 
            this.m_guiEC2InstanceStart.Name = "m_guiEC2InstanceStart";
            this.m_guiEC2InstanceStart.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceStart.Text = "Start";
            this.m_guiEC2InstanceStart.Click += new System.EventHandler(this.m_guiEC2InstanceStart_Click);
            // 
            // m_guiEC2InstanceStop
            // 
            this.m_guiEC2InstanceStop.Name = "m_guiEC2InstanceStop";
            this.m_guiEC2InstanceStop.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceStop.Text = "Stop";
            this.m_guiEC2InstanceStop.Click += new System.EventHandler(this.m_guiEC2InstanceStop_Click);
            // 
            // m_guiEC2InstanceTerminate
            // 
            this.m_guiEC2InstanceTerminate.Name = "m_guiEC2InstanceTerminate";
            this.m_guiEC2InstanceTerminate.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceTerminate.Text = "Terminate";
            this.m_guiEC2InstanceTerminate.Click += new System.EventHandler(this.m_guiEC2InstanceTerminate_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(238, 6);
            // 
            // m_guiEC2InstanceAddEditTags
            // 
            this.m_guiEC2InstanceAddEditTags.Name = "m_guiEC2InstanceAddEditTags";
            this.m_guiEC2InstanceAddEditTags.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceAddEditTags.Text = "Add/Edit Tags";
            // 
            // m_guiEC2InstanceBackup
            // 
            this.m_guiEC2InstanceBackup.Name = "m_guiEC2InstanceBackup";
            this.m_guiEC2InstanceBackup.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceBackup.Text = "Backup";
            this.m_guiEC2InstanceBackup.Click += new System.EventHandler(this.m_guiEC2InstanceBackup_Click);
            // 
            // m_guiEC2InstanceCreateImage
            // 
            this.m_guiEC2InstanceCreateImage.Name = "m_guiEC2InstanceCreateImage";
            this.m_guiEC2InstanceCreateImage.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceCreateImage.Text = "Create Image";
            // 
            // m_guiEC2InstanceChangeInstanceType
            // 
            this.m_guiEC2InstanceChangeInstanceType.Name = "m_guiEC2InstanceChangeInstanceType";
            this.m_guiEC2InstanceChangeInstanceType.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceChangeInstanceType.Text = "Change Instance Type";
            this.m_guiEC2InstanceChangeInstanceType.Click += new System.EventHandler(this.m_guiEC2InstanceChangeInstanceType_Click);
            // 
            // m_guiEC2InstanceChangeSecurityGroup
            // 
            this.m_guiEC2InstanceChangeSecurityGroup.Name = "m_guiEC2InstanceChangeSecurityGroup";
            this.m_guiEC2InstanceChangeSecurityGroup.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceChangeSecurityGroup.Text = "Change Security Group";
            // 
            // m_guiEC2InstanceChangeShutdownBehavior
            // 
            this.m_guiEC2InstanceChangeShutdownBehavior.Name = "m_guiEC2InstanceChangeShutdownBehavior";
            this.m_guiEC2InstanceChangeShutdownBehavior.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceChangeShutdownBehavior.Text = "Change Shutdown Behavior";
            this.m_guiEC2InstanceChangeShutdownBehavior.Click += new System.EventHandler(this.m_guiEC2InstanceChangeShutdownBehavior_Click);
            // 
            // m_guiEC2InstanceChangeSourceDestCheck
            // 
            this.m_guiEC2InstanceChangeSourceDestCheck.Name = "m_guiEC2InstanceChangeSourceDestCheck";
            this.m_guiEC2InstanceChangeSourceDestCheck.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceChangeSourceDestCheck.Text = "Change Source/Dest Check";
            // 
            // m_guiEC2InstanceChangeTerminationProtection
            // 
            this.m_guiEC2InstanceChangeTerminationProtection.Name = "m_guiEC2InstanceChangeTerminationProtection";
            this.m_guiEC2InstanceChangeTerminationProtection.Size = new System.Drawing.Size(241, 22);
            this.m_guiEC2InstanceChangeTerminationProtection.Text = "Change Termination Protection";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiEC2UpdateSoftwareAllInstances,
            this.m_guiEC2UpdateSoftwareMembersInstances,
            this.m_guiEC2UpdateSoftwareSearchInstances,
            this.m_guiEC2UpdateSoftwareWwwInstances,
            this.m_guiEC2UpdateSoftwareSelectedInstances});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(107, 22);
            this.toolStripDropDownButton3.Text = "Update Software";
            // 
            // m_guiEC2UpdateSoftwareAllInstances
            // 
            this.m_guiEC2UpdateSoftwareAllInstances.Name = "m_guiEC2UpdateSoftwareAllInstances";
            this.m_guiEC2UpdateSoftwareAllInstances.Size = new System.Drawing.Size(244, 22);
            this.m_guiEC2UpdateSoftwareAllInstances.Text = "Update All Instances";
            // 
            // m_guiEC2UpdateSoftwareMembersInstances
            // 
            this.m_guiEC2UpdateSoftwareMembersInstances.Name = "m_guiEC2UpdateSoftwareMembersInstances";
            this.m_guiEC2UpdateSoftwareMembersInstances.Size = new System.Drawing.Size(244, 22);
            this.m_guiEC2UpdateSoftwareMembersInstances.Text = "Update All \"members\" Instances";
            // 
            // m_guiEC2UpdateSoftwareSearchInstances
            // 
            this.m_guiEC2UpdateSoftwareSearchInstances.Name = "m_guiEC2UpdateSoftwareSearchInstances";
            this.m_guiEC2UpdateSoftwareSearchInstances.Size = new System.Drawing.Size(244, 22);
            this.m_guiEC2UpdateSoftwareSearchInstances.Text = "Update All \"search\" Instances";
            // 
            // m_guiEC2UpdateSoftwareWwwInstances
            // 
            this.m_guiEC2UpdateSoftwareWwwInstances.Name = "m_guiEC2UpdateSoftwareWwwInstances";
            this.m_guiEC2UpdateSoftwareWwwInstances.Size = new System.Drawing.Size(244, 22);
            this.m_guiEC2UpdateSoftwareWwwInstances.Text = "Update All \"www\" Instances";
            // 
            // m_guiEC2UpdateSoftwareSelectedInstances
            // 
            this.m_guiEC2UpdateSoftwareSelectedInstances.Name = "m_guiEC2UpdateSoftwareSelectedInstances";
            this.m_guiEC2UpdateSoftwareSelectedInstances.Size = new System.Drawing.Size(244, 22);
            this.m_guiEC2UpdateSoftwareSelectedInstances.Text = "Update Selected Instance(s)";
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiEC2ScheduledOnOffTask});
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(107, 22);
            this.toolStripDropDownButton4.Text = "Scheduled Tasks";
            // 
            // m_guiEC2ScheduledOnOffTask
            // 
            this.m_guiEC2ScheduledOnOffTask.Name = "m_guiEC2ScheduledOnOffTask";
            this.m_guiEC2ScheduledOnOffTask.Size = new System.Drawing.Size(170, 22);
            this.m_guiEC2ScheduledOnOffTask.Text = "Scheduled On/Off";
            // 
            // m_guiTabEC2Ami
            // 
            this.m_guiTabEC2Ami.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabEC2Ami.Name = "m_guiTabEC2Ami";
            this.m_guiTabEC2Ami.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabEC2Ami.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabEC2Ami.TabIndex = 1;
            this.m_guiTabEC2Ami.Text = "AMI";
            this.m_guiTabEC2Ami.UseVisualStyleBackColor = true;
            // 
            // m_guiTabEC2Volume
            // 
            this.m_guiTabEC2Volume.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabEC2Volume.Name = "m_guiTabEC2Volume";
            this.m_guiTabEC2Volume.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabEC2Volume.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabEC2Volume.TabIndex = 2;
            this.m_guiTabEC2Volume.Text = "Volumes";
            this.m_guiTabEC2Volume.UseVisualStyleBackColor = true;
            // 
            // m_guiTabEC2Snapshot
            // 
            this.m_guiTabEC2Snapshot.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabEC2Snapshot.Name = "m_guiTabEC2Snapshot";
            this.m_guiTabEC2Snapshot.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabEC2Snapshot.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabEC2Snapshot.TabIndex = 3;
            this.m_guiTabEC2Snapshot.Text = "Snapshots";
            this.m_guiTabEC2Snapshot.UseVisualStyleBackColor = true;
            // 
            // m_guiTabEC2LoadBalancer
            // 
            this.m_guiTabEC2LoadBalancer.Controls.Add(this.m_guiEC2LoadBalancerGrid);
            this.m_guiTabEC2LoadBalancer.Controls.Add(this.toolStrip2);
            this.m_guiTabEC2LoadBalancer.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabEC2LoadBalancer.Name = "m_guiTabEC2LoadBalancer";
            this.m_guiTabEC2LoadBalancer.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabEC2LoadBalancer.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabEC2LoadBalancer.TabIndex = 4;
            this.m_guiTabEC2LoadBalancer.Text = "Load Balancers";
            this.m_guiTabEC2LoadBalancer.UseVisualStyleBackColor = true;
            // 
            // m_guiEC2LoadBalancerGrid
            // 
            this.m_guiEC2LoadBalancerGrid.AllowUserToAddRows = false;
            this.m_guiEC2LoadBalancerGrid.AllowUserToDeleteRows = false;
            this.m_guiEC2LoadBalancerGrid.AllowUserToOrderColumns = true;
            this.m_guiEC2LoadBalancerGrid.AllowUserToResizeRows = false;
            this.m_guiEC2LoadBalancerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiEC2LoadBalancerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiEC2LoadBalancerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_guiLoadBalancerGridName,
            this.m_guiLoadBalancerGridInstances,
            this.m_guiLoadBalancerGridDNSName,
            this.m_guiLoadBalancerGridScheme,
            this.m_guiLoadBalancerGridVPCId,
            this.m_guiLoadBalancerGridSecurityGroups,
            this.m_guiLoadBalancerGridSubnets});
            this.m_guiEC2LoadBalancerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiEC2LoadBalancerGrid.Location = new System.Drawing.Point(3, 28);
            this.m_guiEC2LoadBalancerGrid.Name = "m_guiEC2LoadBalancerGrid";
            this.m_guiEC2LoadBalancerGrid.RowHeadersWidth = 31;
            this.m_guiEC2LoadBalancerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiEC2LoadBalancerGrid.ShowEditingIcon = false;
            this.m_guiEC2LoadBalancerGrid.Size = new System.Drawing.Size(920, 540);
            this.m_guiEC2LoadBalancerGrid.TabIndex = 2;
            // 
            // m_guiLoadBalancerGridName
            // 
            this.m_guiLoadBalancerGridName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_guiLoadBalancerGridName.DataPropertyName = "LoadBalancerName";
            this.m_guiLoadBalancerGridName.HeaderText = "Name";
            this.m_guiLoadBalancerGridName.Name = "m_guiLoadBalancerGridName";
            this.m_guiLoadBalancerGridName.Width = 60;
            // 
            // m_guiLoadBalancerGridInstances
            // 
            this.m_guiLoadBalancerGridInstances.HeaderText = "Instances";
            this.m_guiLoadBalancerGridInstances.Name = "m_guiLoadBalancerGridInstances";
            this.m_guiLoadBalancerGridInstances.Width = 78;
            // 
            // m_guiLoadBalancerGridDNSName
            // 
            this.m_guiLoadBalancerGridDNSName.DataPropertyName = "DNSName";
            this.m_guiLoadBalancerGridDNSName.HeaderText = "Dns Name";
            this.m_guiLoadBalancerGridDNSName.Name = "m_guiLoadBalancerGridDNSName";
            this.m_guiLoadBalancerGridDNSName.Width = 76;
            // 
            // m_guiLoadBalancerGridScheme
            // 
            this.m_guiLoadBalancerGridScheme.DataPropertyName = "Scheme";
            this.m_guiLoadBalancerGridScheme.HeaderText = "Scheme";
            this.m_guiLoadBalancerGridScheme.Name = "m_guiLoadBalancerGridScheme";
            this.m_guiLoadBalancerGridScheme.Width = 71;
            // 
            // m_guiLoadBalancerGridVPCId
            // 
            this.m_guiLoadBalancerGridVPCId.DataPropertyName = "VPCId";
            this.m_guiLoadBalancerGridVPCId.HeaderText = "VPC ID";
            this.m_guiLoadBalancerGridVPCId.Name = "m_guiLoadBalancerGridVPCId";
            this.m_guiLoadBalancerGridVPCId.Width = 62;
            // 
            // m_guiLoadBalancerGridSecurityGroups
            // 
            this.m_guiLoadBalancerGridSecurityGroups.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_guiLoadBalancerGridSecurityGroups.HeaderText = "Security Groups";
            this.m_guiLoadBalancerGridSecurityGroups.Name = "m_guiLoadBalancerGridSecurityGroups";
            this.m_guiLoadBalancerGridSecurityGroups.Width = 98;
            // 
            // m_guiLoadBalancerGridSubnets
            // 
            this.m_guiLoadBalancerGridSubnets.HeaderText = "Subnets";
            this.m_guiLoadBalancerGridSubnets.Name = "m_guiLoadBalancerGridSubnets";
            this.m_guiLoadBalancerGridSubnets.Width = 71;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.toolStripDropDownButton2});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(920, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton1.Text = "Refresh";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(55, 22);
            this.toolStripDropDownButton2.Text = "Action";
            // 
            // m_guiTabVPC
            // 
            this.m_guiTabVPC.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabVPC.Name = "m_guiTabVPC";
            this.m_guiTabVPC.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabVPC.Size = new System.Drawing.Size(940, 603);
            this.m_guiTabVPC.TabIndex = 1;
            this.m_guiTabVPC.Text = "VPC";
            this.m_guiTabVPC.UseVisualStyleBackColor = true;
            // 
            // m_guiTabAS
            // 
            this.m_guiTabAS.Controls.Add(this.m_guiTabASMain);
            this.m_guiTabAS.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabAS.Name = "m_guiTabAS";
            this.m_guiTabAS.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabAS.Size = new System.Drawing.Size(940, 603);
            this.m_guiTabAS.TabIndex = 3;
            this.m_guiTabAS.Text = "Auto Scaling";
            this.m_guiTabAS.UseVisualStyleBackColor = true;
            // 
            // m_guiTabASMain
            // 
            this.m_guiTabASMain.Controls.Add(this.m_guiTabASLaunchConfiguration);
            this.m_guiTabASMain.Controls.Add(this.m_guiTabASGroup);
            this.m_guiTabASMain.Controls.Add(this.m_guiTabASPolicy);
            this.m_guiTabASMain.Controls.Add(this.m_guiTabASAlarm);
            this.m_guiTabASMain.Controls.Add(this.m_guiTabASSchedule);
            this.m_guiTabASMain.Controls.Add(this.m_guiTabASInstance);
            this.m_guiTabASMain.Controls.Add(this.m_guiTabASActivity);
            this.m_guiTabASMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiTabASMain.Location = new System.Drawing.Point(3, 3);
            this.m_guiTabASMain.Name = "m_guiTabASMain";
            this.m_guiTabASMain.SelectedIndex = 0;
            this.m_guiTabASMain.Size = new System.Drawing.Size(934, 597);
            this.m_guiTabASMain.TabIndex = 0;
            // 
            // m_guiTabASLaunchConfiguration
            // 
            this.m_guiTabASLaunchConfiguration.Controls.Add(this.m_guiASLaunchConfigurationGrid);
            this.m_guiTabASLaunchConfiguration.Controls.Add(this.toolStrip7);
            this.m_guiTabASLaunchConfiguration.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabASLaunchConfiguration.Name = "m_guiTabASLaunchConfiguration";
            this.m_guiTabASLaunchConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabASLaunchConfiguration.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabASLaunchConfiguration.TabIndex = 0;
            this.m_guiTabASLaunchConfiguration.Text = "Launch Configurations";
            this.m_guiTabASLaunchConfiguration.UseVisualStyleBackColor = true;
            // 
            // m_guiASLaunchConfigurationGrid
            // 
            this.m_guiASLaunchConfigurationGrid.AllowUserToAddRows = false;
            this.m_guiASLaunchConfigurationGrid.AllowUserToDeleteRows = false;
            this.m_guiASLaunchConfigurationGrid.AllowUserToOrderColumns = true;
            this.m_guiASLaunchConfigurationGrid.AllowUserToResizeRows = false;
            this.m_guiASLaunchConfigurationGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiASLaunchConfigurationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiASLaunchConfigurationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_guiASLaunchConfigurationGridLaunchConfigurationName,
            this.m_guiASLaunchConfigurationGridImageId,
            this.m_guiASLaunchConfigurationGridKeyName,
            this.m_guiASLaunchConfigurationGridInstanceType,
            this.m_guiASLaunchConfigurationGridCreatedTime,
            this.m_guiASLaunchConfigurationGridInstanceMonitoring,
            this.m_guiASLaunchConfigurationGridEbsOptimized});
            this.m_guiASLaunchConfigurationGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiASLaunchConfigurationGrid.Location = new System.Drawing.Point(3, 28);
            this.m_guiASLaunchConfigurationGrid.Name = "m_guiASLaunchConfigurationGrid";
            this.m_guiASLaunchConfigurationGrid.ReadOnly = true;
            this.m_guiASLaunchConfigurationGrid.RowHeadersWidth = 31;
            this.m_guiASLaunchConfigurationGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiASLaunchConfigurationGrid.ShowEditingIcon = false;
            this.m_guiASLaunchConfigurationGrid.Size = new System.Drawing.Size(920, 540);
            this.m_guiASLaunchConfigurationGrid.TabIndex = 2;
            // 
            // m_guiASLaunchConfigurationGridLaunchConfigurationName
            // 
            this.m_guiASLaunchConfigurationGridLaunchConfigurationName.DataPropertyName = "LaunchConfigurationName";
            this.m_guiASLaunchConfigurationGridLaunchConfigurationName.HeaderText = "Launch Config Name";
            this.m_guiASLaunchConfigurationGridLaunchConfigurationName.Name = "m_guiASLaunchConfigurationGridLaunchConfigurationName";
            this.m_guiASLaunchConfigurationGridLaunchConfigurationName.ReadOnly = true;
            this.m_guiASLaunchConfigurationGridLaunchConfigurationName.Width = 96;
            // 
            // m_guiASLaunchConfigurationGridImageId
            // 
            this.m_guiASLaunchConfigurationGridImageId.DataPropertyName = "ImageId";
            this.m_guiASLaunchConfigurationGridImageId.HeaderText = "Image Id";
            this.m_guiASLaunchConfigurationGridImageId.Name = "m_guiASLaunchConfigurationGridImageId";
            this.m_guiASLaunchConfigurationGridImageId.ReadOnly = true;
            this.m_guiASLaunchConfigurationGridImageId.Width = 68;
            // 
            // m_guiASLaunchConfigurationGridKeyName
            // 
            this.m_guiASLaunchConfigurationGridKeyName.DataPropertyName = "KeyName";
            this.m_guiASLaunchConfigurationGridKeyName.HeaderText = "Key Name";
            this.m_guiASLaunchConfigurationGridKeyName.Name = "m_guiASLaunchConfigurationGridKeyName";
            this.m_guiASLaunchConfigurationGridKeyName.ReadOnly = true;
            this.m_guiASLaunchConfigurationGridKeyName.Width = 75;
            // 
            // m_guiASLaunchConfigurationGridInstanceType
            // 
            this.m_guiASLaunchConfigurationGridInstanceType.DataPropertyName = "InstanceType";
            this.m_guiASLaunchConfigurationGridInstanceType.HeaderText = "Instance Type";
            this.m_guiASLaunchConfigurationGridInstanceType.Name = "m_guiASLaunchConfigurationGridInstanceType";
            this.m_guiASLaunchConfigurationGridInstanceType.ReadOnly = true;
            this.m_guiASLaunchConfigurationGridInstanceType.Width = 92;
            // 
            // m_guiASLaunchConfigurationGridCreatedTime
            // 
            this.m_guiASLaunchConfigurationGridCreatedTime.DataPropertyName = "CreatedTime";
            this.m_guiASLaunchConfigurationGridCreatedTime.HeaderText = "Created";
            this.m_guiASLaunchConfigurationGridCreatedTime.Name = "m_guiASLaunchConfigurationGridCreatedTime";
            this.m_guiASLaunchConfigurationGridCreatedTime.ReadOnly = true;
            this.m_guiASLaunchConfigurationGridCreatedTime.Width = 69;
            // 
            // m_guiASLaunchConfigurationGridInstanceMonitoring
            // 
            this.m_guiASLaunchConfigurationGridInstanceMonitoring.HeaderText = "Detail Monitoring";
            this.m_guiASLaunchConfigurationGridInstanceMonitoring.Name = "m_guiASLaunchConfigurationGridInstanceMonitoring";
            this.m_guiASLaunchConfigurationGridInstanceMonitoring.ReadOnly = true;
            this.m_guiASLaunchConfigurationGridInstanceMonitoring.Width = 102;
            // 
            // m_guiASLaunchConfigurationGridEbsOptimized
            // 
            this.m_guiASLaunchConfigurationGridEbsOptimized.HeaderText = "EBS Optimized";
            this.m_guiASLaunchConfigurationGridEbsOptimized.Name = "m_guiASLaunchConfigurationGridEbsOptimized";
            this.m_guiASLaunchConfigurationGridEbsOptimized.ReadOnly = true;
            this.m_guiASLaunchConfigurationGridEbsOptimized.Width = 94;
            // 
            // toolStrip7
            // 
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiASRefreshLaunchConfiguration,
            this.toolStripSeparator5,
            this.m_guiASAddLaunchConfiguration,
            this.m_guiASDeleteLaunchConfiguration});
            this.toolStrip7.Location = new System.Drawing.Point(3, 3);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Size = new System.Drawing.Size(920, 25);
            this.toolStrip7.TabIndex = 1;
            this.toolStrip7.Text = "toolStrip7";
            // 
            // m_guiASRefreshLaunchConfiguration
            // 
            this.m_guiASRefreshLaunchConfiguration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASRefreshLaunchConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASRefreshLaunchConfiguration.Image")));
            this.m_guiASRefreshLaunchConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASRefreshLaunchConfiguration.Name = "m_guiASRefreshLaunchConfiguration";
            this.m_guiASRefreshLaunchConfiguration.Size = new System.Drawing.Size(50, 22);
            this.m_guiASRefreshLaunchConfiguration.Text = "Refresh";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // m_guiASAddLaunchConfiguration
            // 
            this.m_guiASAddLaunchConfiguration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASAddLaunchConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASAddLaunchConfiguration.Image")));
            this.m_guiASAddLaunchConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASAddLaunchConfiguration.Name = "m_guiASAddLaunchConfiguration";
            this.m_guiASAddLaunchConfiguration.Size = new System.Drawing.Size(60, 22);
            this.m_guiASAddLaunchConfiguration.Text = "Add New";
            // 
            // m_guiASDeleteLaunchConfiguration
            // 
            this.m_guiASDeleteLaunchConfiguration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASDeleteLaunchConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASDeleteLaunchConfiguration.Image")));
            this.m_guiASDeleteLaunchConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASDeleteLaunchConfiguration.Name = "m_guiASDeleteLaunchConfiguration";
            this.m_guiASDeleteLaunchConfiguration.Size = new System.Drawing.Size(44, 22);
            this.m_guiASDeleteLaunchConfiguration.Text = "Delete";
            // 
            // m_guiTabASGroup
            // 
            this.m_guiTabASGroup.Controls.Add(this.m_guiASGroupGrid);
            this.m_guiTabASGroup.Controls.Add(this.toolStrip9);
            this.m_guiTabASGroup.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabASGroup.Name = "m_guiTabASGroup";
            this.m_guiTabASGroup.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabASGroup.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabASGroup.TabIndex = 1;
            this.m_guiTabASGroup.Text = "Groups";
            this.m_guiTabASGroup.UseVisualStyleBackColor = true;
            // 
            // m_guiASGroupGrid
            // 
            this.m_guiASGroupGrid.AllowUserToAddRows = false;
            this.m_guiASGroupGrid.AllowUserToDeleteRows = false;
            this.m_guiASGroupGrid.AllowUserToOrderColumns = true;
            this.m_guiASGroupGrid.AllowUserToResizeRows = false;
            this.m_guiASGroupGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiASGroupGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiASGroupGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_guiASGroupGridAutoScalingGroupName,
            this.m_guiASGroupGridCreatedTime,
            this.m_guiASGroupGridLaunchConfigurationName,
            this.m_guiASGroupGridMinSize,
            this.m_guiASGroupGridMaxSize,
            this.m_guiASGroupGridDesiredCapacity,
            this.m_guiASGroupGridVPCAvailabilityZones,
            this.m_guiASGroupGridVPCZoneIdentifier,
            this.m_guiASGroupGridLoadBalancerNames,
            this.m_guiASGroupGridDefaultCooldown,
            this.m_guiASGroupGridHealthCheckGracePeriod,
            this.m_guiASGroupGridHealthCheckType});
            this.m_guiASGroupGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiASGroupGrid.Location = new System.Drawing.Point(3, 28);
            this.m_guiASGroupGrid.Name = "m_guiASGroupGrid";
            this.m_guiASGroupGrid.ReadOnly = true;
            this.m_guiASGroupGrid.RowHeadersWidth = 31;
            this.m_guiASGroupGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiASGroupGrid.ShowEditingIcon = false;
            this.m_guiASGroupGrid.Size = new System.Drawing.Size(920, 540);
            this.m_guiASGroupGrid.TabIndex = 4;
            // 
            // m_guiASGroupGridAutoScalingGroupName
            // 
            this.m_guiASGroupGridAutoScalingGroupName.DataPropertyName = "AutoScalingGroupName";
            this.m_guiASGroupGridAutoScalingGroupName.HeaderText = "Group Name";
            this.m_guiASGroupGridAutoScalingGroupName.Name = "m_guiASGroupGridAutoScalingGroupName";
            this.m_guiASGroupGridAutoScalingGroupName.ReadOnly = true;
            this.m_guiASGroupGridAutoScalingGroupName.Width = 85;
            // 
            // m_guiASGroupGridCreatedTime
            // 
            this.m_guiASGroupGridCreatedTime.DataPropertyName = "CreatedTime";
            this.m_guiASGroupGridCreatedTime.HeaderText = "Created";
            this.m_guiASGroupGridCreatedTime.Name = "m_guiASGroupGridCreatedTime";
            this.m_guiASGroupGridCreatedTime.ReadOnly = true;
            this.m_guiASGroupGridCreatedTime.Width = 69;
            // 
            // m_guiASGroupGridLaunchConfigurationName
            // 
            this.m_guiASGroupGridLaunchConfigurationName.DataPropertyName = "LaunchConfigurationName";
            this.m_guiASGroupGridLaunchConfigurationName.HeaderText = "Launch Config";
            this.m_guiASGroupGridLaunchConfigurationName.Name = "m_guiASGroupGridLaunchConfigurationName";
            this.m_guiASGroupGridLaunchConfigurationName.ReadOnly = true;
            this.m_guiASGroupGridLaunchConfigurationName.Width = 93;
            // 
            // m_guiASGroupGridMinSize
            // 
            this.m_guiASGroupGridMinSize.DataPropertyName = "MinSize";
            this.m_guiASGroupGridMinSize.HeaderText = "Min Size";
            this.m_guiASGroupGridMinSize.Name = "m_guiASGroupGridMinSize";
            this.m_guiASGroupGridMinSize.ReadOnly = true;
            this.m_guiASGroupGridMinSize.Width = 67;
            // 
            // m_guiASGroupGridMaxSize
            // 
            this.m_guiASGroupGridMaxSize.DataPropertyName = "MaxSize";
            this.m_guiASGroupGridMaxSize.HeaderText = "Max Size";
            this.m_guiASGroupGridMaxSize.Name = "m_guiASGroupGridMaxSize";
            this.m_guiASGroupGridMaxSize.ReadOnly = true;
            this.m_guiASGroupGridMaxSize.Width = 69;
            // 
            // m_guiASGroupGridDesiredCapacity
            // 
            this.m_guiASGroupGridDesiredCapacity.DataPropertyName = "DesiredCapacity";
            this.m_guiASGroupGridDesiredCapacity.HeaderText = "Desired Capacity";
            this.m_guiASGroupGridDesiredCapacity.Name = "m_guiASGroupGridDesiredCapacity";
            this.m_guiASGroupGridDesiredCapacity.ReadOnly = true;
            this.m_guiASGroupGridDesiredCapacity.Width = 103;
            // 
            // m_guiASGroupGridVPCAvailabilityZones
            // 
            this.m_guiASGroupGridVPCAvailabilityZones.HeaderText = "Availability Zones";
            this.m_guiASGroupGridVPCAvailabilityZones.Name = "m_guiASGroupGridVPCAvailabilityZones";
            this.m_guiASGroupGridVPCAvailabilityZones.ReadOnly = true;
            this.m_guiASGroupGridVPCAvailabilityZones.Width = 105;
            // 
            // m_guiASGroupGridVPCZoneIdentifier
            // 
            this.m_guiASGroupGridVPCZoneIdentifier.DataPropertyName = "VPCZoneIdentifier";
            this.m_guiASGroupGridVPCZoneIdentifier.HeaderText = "Subnets";
            this.m_guiASGroupGridVPCZoneIdentifier.Name = "m_guiASGroupGridVPCZoneIdentifier";
            this.m_guiASGroupGridVPCZoneIdentifier.ReadOnly = true;
            this.m_guiASGroupGridVPCZoneIdentifier.Width = 71;
            // 
            // m_guiASGroupGridLoadBalancerNames
            // 
            this.m_guiASGroupGridLoadBalancerNames.HeaderText = "Load Balancers";
            this.m_guiASGroupGridLoadBalancerNames.Name = "m_guiASGroupGridLoadBalancerNames";
            this.m_guiASGroupGridLoadBalancerNames.ReadOnly = true;
            this.m_guiASGroupGridLoadBalancerNames.Width = 97;
            // 
            // m_guiASGroupGridDefaultCooldown
            // 
            this.m_guiASGroupGridDefaultCooldown.DataPropertyName = "DefaultCooldown";
            this.m_guiASGroupGridDefaultCooldown.HeaderText = "Default Cooldown";
            this.m_guiASGroupGridDefaultCooldown.Name = "m_guiASGroupGridDefaultCooldown";
            this.m_guiASGroupGridDefaultCooldown.ReadOnly = true;
            this.m_guiASGroupGridDefaultCooldown.Width = 106;
            // 
            // m_guiASGroupGridHealthCheckGracePeriod
            // 
            this.m_guiASGroupGridHealthCheckGracePeriod.DataPropertyName = "HealthCheckGracePeriod";
            this.m_guiASGroupGridHealthCheckGracePeriod.HeaderText = "Health Check Grace Period";
            this.m_guiASGroupGridHealthCheckGracePeriod.Name = "m_guiASGroupGridHealthCheckGracePeriod";
            this.m_guiASGroupGridHealthCheckGracePeriod.ReadOnly = true;
            this.m_guiASGroupGridHealthCheckGracePeriod.Width = 121;
            // 
            // m_guiASGroupGridHealthCheckType
            // 
            this.m_guiASGroupGridHealthCheckType.DataPropertyName = "HealthCheckType";
            this.m_guiASGroupGridHealthCheckType.HeaderText = "Health Check Type";
            this.m_guiASGroupGridHealthCheckType.Name = "m_guiASGroupGridHealthCheckType";
            this.m_guiASGroupGridHealthCheckType.ReadOnly = true;
            this.m_guiASGroupGridHealthCheckType.Width = 92;
            // 
            // toolStrip9
            // 
            this.toolStrip9.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiASRefreshGroup,
            this.toolStripSeparator6,
            this.m_guiASAddGroup,
            this.m_guiASEditGroup,
            this.m_guiASDeleteGroup,
            this.toolStripSeparator9,
            this.m_guiASSuspendGroup,
            this.m_guiASResumeGroup});
            this.toolStrip9.Location = new System.Drawing.Point(3, 3);
            this.toolStrip9.Name = "toolStrip9";
            this.toolStrip9.Size = new System.Drawing.Size(920, 25);
            this.toolStrip9.TabIndex = 3;
            this.toolStrip9.Text = "toolStrip9";
            // 
            // m_guiASRefreshGroup
            // 
            this.m_guiASRefreshGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASRefreshGroup.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASRefreshGroup.Image")));
            this.m_guiASRefreshGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASRefreshGroup.Name = "m_guiASRefreshGroup";
            this.m_guiASRefreshGroup.Size = new System.Drawing.Size(50, 22);
            this.m_guiASRefreshGroup.Text = "Refresh";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // m_guiASAddGroup
            // 
            this.m_guiASAddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASAddGroup.Image")));
            this.m_guiASAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASAddGroup.Name = "m_guiASAddGroup";
            this.m_guiASAddGroup.Size = new System.Drawing.Size(60, 22);
            this.m_guiASAddGroup.Text = "Add New";
            // 
            // m_guiASEditGroup
            // 
            this.m_guiASEditGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASEditGroup.Image")));
            this.m_guiASEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASEditGroup.Name = "m_guiASEditGroup";
            this.m_guiASEditGroup.Size = new System.Drawing.Size(31, 22);
            this.m_guiASEditGroup.Text = "Edit";
            // 
            // m_guiASDeleteGroup
            // 
            this.m_guiASDeleteGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASDeleteGroup.Image")));
            this.m_guiASDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASDeleteGroup.Name = "m_guiASDeleteGroup";
            this.m_guiASDeleteGroup.Size = new System.Drawing.Size(44, 22);
            this.m_guiASDeleteGroup.Text = "Delete";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // m_guiASSuspendGroup
            // 
            this.m_guiASSuspendGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASSuspendGroup.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASSuspendGroup.Image")));
            this.m_guiASSuspendGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASSuspendGroup.Name = "m_guiASSuspendGroup";
            this.m_guiASSuspendGroup.Size = new System.Drawing.Size(126, 22);
            this.m_guiASSuspendGroup.Text = "Suspend Auto Scaling";
            // 
            // m_guiASResumeGroup
            // 
            this.m_guiASResumeGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASResumeGroup.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASResumeGroup.Image")));
            this.m_guiASResumeGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASResumeGroup.Name = "m_guiASResumeGroup";
            this.m_guiASResumeGroup.Size = new System.Drawing.Size(123, 22);
            this.m_guiASResumeGroup.Text = "Resume Auto Scaling";
            // 
            // m_guiTabASPolicy
            // 
            this.m_guiTabASPolicy.Controls.Add(this.m_guiASPolicyGrid);
            this.m_guiTabASPolicy.Controls.Add(this.toolStrip10);
            this.m_guiTabASPolicy.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabASPolicy.Name = "m_guiTabASPolicy";
            this.m_guiTabASPolicy.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabASPolicy.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabASPolicy.TabIndex = 2;
            this.m_guiTabASPolicy.Text = "Policies";
            this.m_guiTabASPolicy.UseVisualStyleBackColor = true;
            // 
            // m_guiASPolicyGrid
            // 
            this.m_guiASPolicyGrid.AllowUserToAddRows = false;
            this.m_guiASPolicyGrid.AllowUserToDeleteRows = false;
            this.m_guiASPolicyGrid.AllowUserToOrderColumns = true;
            this.m_guiASPolicyGrid.AllowUserToResizeRows = false;
            this.m_guiASPolicyGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiASPolicyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiASPolicyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_guiASPolicyGridScalingPolicyName,
            this.m_guiASPolicyGridScalingGroupName,
            this.m_guiASPolicyGridAdjustmentType,
            this.m_guiASPolicyGridScalingAdjustment,
            this.m_guiASPolicyGridCooldown});
            this.m_guiASPolicyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiASPolicyGrid.Location = new System.Drawing.Point(3, 28);
            this.m_guiASPolicyGrid.Name = "m_guiASPolicyGrid";
            this.m_guiASPolicyGrid.ReadOnly = true;
            this.m_guiASPolicyGrid.RowHeadersWidth = 31;
            this.m_guiASPolicyGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiASPolicyGrid.ShowEditingIcon = false;
            this.m_guiASPolicyGrid.Size = new System.Drawing.Size(920, 540);
            this.m_guiASPolicyGrid.TabIndex = 6;
            // 
            // m_guiASPolicyGridScalingPolicyName
            // 
            this.m_guiASPolicyGridScalingPolicyName.DataPropertyName = "PolicyName";
            this.m_guiASPolicyGridScalingPolicyName.HeaderText = "Policy Name";
            this.m_guiASPolicyGridScalingPolicyName.Name = "m_guiASPolicyGridScalingPolicyName";
            this.m_guiASPolicyGridScalingPolicyName.ReadOnly = true;
            this.m_guiASPolicyGridScalingPolicyName.Width = 84;
            // 
            // m_guiASPolicyGridScalingGroupName
            // 
            this.m_guiASPolicyGridScalingGroupName.DataPropertyName = "AutoScalingGroupName";
            this.m_guiASPolicyGridScalingGroupName.HeaderText = "Group Name";
            this.m_guiASPolicyGridScalingGroupName.Name = "m_guiASPolicyGridScalingGroupName";
            this.m_guiASPolicyGridScalingGroupName.ReadOnly = true;
            this.m_guiASPolicyGridScalingGroupName.Width = 85;
            // 
            // m_guiASPolicyGridAdjustmentType
            // 
            this.m_guiASPolicyGridAdjustmentType.DataPropertyName = "AdjustmentType";
            this.m_guiASPolicyGridAdjustmentType.HeaderText = "Adjustment Type";
            this.m_guiASPolicyGridAdjustmentType.Name = "m_guiASPolicyGridAdjustmentType";
            this.m_guiASPolicyGridAdjustmentType.ReadOnly = true;
            this.m_guiASPolicyGridAdjustmentType.Width = 102;
            // 
            // m_guiASPolicyGridScalingAdjustment
            // 
            this.m_guiASPolicyGridScalingAdjustment.DataPropertyName = "ScalingAdjustment";
            this.m_guiASPolicyGridScalingAdjustment.HeaderText = "Scaling Adjustment";
            this.m_guiASPolicyGridScalingAdjustment.Name = "m_guiASPolicyGridScalingAdjustment";
            this.m_guiASPolicyGridScalingAdjustment.ReadOnly = true;
            this.m_guiASPolicyGridScalingAdjustment.Width = 112;
            // 
            // m_guiASPolicyGridCooldown
            // 
            this.m_guiASPolicyGridCooldown.DataPropertyName = "Cooldown";
            this.m_guiASPolicyGridCooldown.HeaderText = "Cooldown";
            this.m_guiASPolicyGridCooldown.Name = "m_guiASPolicyGridCooldown";
            this.m_guiASPolicyGridCooldown.ReadOnly = true;
            this.m_guiASPolicyGridCooldown.Width = 79;
            // 
            // toolStrip10
            // 
            this.toolStrip10.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiASRefreshPolicy,
            this.toolStripSeparator7,
            this.m_guiASAddPolicy,
            this.m_guiASEditPolicy,
            this.m_guiASDeletePolicy});
            this.toolStrip10.Location = new System.Drawing.Point(3, 3);
            this.toolStrip10.Name = "toolStrip10";
            this.toolStrip10.Size = new System.Drawing.Size(920, 25);
            this.toolStrip10.TabIndex = 5;
            this.toolStrip10.Text = "toolStrip10";
            // 
            // m_guiASRefreshPolicy
            // 
            this.m_guiASRefreshPolicy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASRefreshPolicy.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASRefreshPolicy.Image")));
            this.m_guiASRefreshPolicy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASRefreshPolicy.Name = "m_guiASRefreshPolicy";
            this.m_guiASRefreshPolicy.Size = new System.Drawing.Size(50, 22);
            this.m_guiASRefreshPolicy.Text = "Refresh";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // m_guiASAddPolicy
            // 
            this.m_guiASAddPolicy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASAddPolicy.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASAddPolicy.Image")));
            this.m_guiASAddPolicy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASAddPolicy.Name = "m_guiASAddPolicy";
            this.m_guiASAddPolicy.Size = new System.Drawing.Size(60, 22);
            this.m_guiASAddPolicy.Text = "Add New";
            // 
            // m_guiASEditPolicy
            // 
            this.m_guiASEditPolicy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASEditPolicy.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASEditPolicy.Image")));
            this.m_guiASEditPolicy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASEditPolicy.Name = "m_guiASEditPolicy";
            this.m_guiASEditPolicy.Size = new System.Drawing.Size(31, 22);
            this.m_guiASEditPolicy.Text = "Edit";
            // 
            // m_guiASDeletePolicy
            // 
            this.m_guiASDeletePolicy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASDeletePolicy.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASDeletePolicy.Image")));
            this.m_guiASDeletePolicy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASDeletePolicy.Name = "m_guiASDeletePolicy";
            this.m_guiASDeletePolicy.Size = new System.Drawing.Size(44, 22);
            this.m_guiASDeletePolicy.Text = "Delete";
            // 
            // m_guiTabASAlarm
            // 
            this.m_guiTabASAlarm.Controls.Add(this.m_guiASAlarmGrid);
            this.m_guiTabASAlarm.Controls.Add(this.toolStrip11);
            this.m_guiTabASAlarm.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabASAlarm.Name = "m_guiTabASAlarm";
            this.m_guiTabASAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabASAlarm.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabASAlarm.TabIndex = 4;
            this.m_guiTabASAlarm.Text = "Scale by Alarms";
            this.m_guiTabASAlarm.UseVisualStyleBackColor = true;
            // 
            // m_guiASAlarmGrid
            // 
            this.m_guiASAlarmGrid.AllowUserToAddRows = false;
            this.m_guiASAlarmGrid.AllowUserToDeleteRows = false;
            this.m_guiASAlarmGrid.AllowUserToOrderColumns = true;
            this.m_guiASAlarmGrid.AllowUserToResizeRows = false;
            this.m_guiASAlarmGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiASAlarmGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiASAlarmGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_guiASAlarmGridAlarmName,
            this.m_guiASAlarmGridActionsEnabled,
            this.m_guiASAlarmGridNamespace,
            this.m_guiASAlarmGridMetricName,
            this.m_guiASAlarmGridStatistic,
            this.m_guiASAlarmGridOperator,
            this.m_guiASAlarmGridThreshold,
            this.m_guiASAlarmGridEvaluationPeriods,
            this.m_guiASAlarmGridPeriod,
            this.m_guiASAlarmGridUpdated,
            this.m_guiASAlarmGridUnit,
            this.m_guiASAlarmGridStateReason,
            this.m_guiASAlarmGridStateReasonData,
            this.m_guiASAlarmGridStateValue,
            this.m_guiASAlarmGridStateUpdated});
            this.m_guiASAlarmGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiASAlarmGrid.Location = new System.Drawing.Point(3, 28);
            this.m_guiASAlarmGrid.Name = "m_guiASAlarmGrid";
            this.m_guiASAlarmGrid.ReadOnly = true;
            this.m_guiASAlarmGrid.RowHeadersWidth = 31;
            this.m_guiASAlarmGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiASAlarmGrid.ShowEditingIcon = false;
            this.m_guiASAlarmGrid.Size = new System.Drawing.Size(920, 540);
            this.m_guiASAlarmGrid.TabIndex = 6;
            // 
            // m_guiASAlarmGridAlarmName
            // 
            this.m_guiASAlarmGridAlarmName.DataPropertyName = "AlarmName";
            this.m_guiASAlarmGridAlarmName.HeaderText = "Alarm Name";
            this.m_guiASAlarmGridAlarmName.Name = "m_guiASAlarmGridAlarmName";
            this.m_guiASAlarmGridAlarmName.ReadOnly = true;
            this.m_guiASAlarmGridAlarmName.Width = 82;
            // 
            // m_guiASAlarmGridActionsEnabled
            // 
            this.m_guiASAlarmGridActionsEnabled.DataPropertyName = "ActionsEnabled";
            this.m_guiASAlarmGridActionsEnabled.HeaderText = "Enabled";
            this.m_guiASAlarmGridActionsEnabled.Name = "m_guiASAlarmGridActionsEnabled";
            this.m_guiASAlarmGridActionsEnabled.ReadOnly = true;
            this.m_guiASAlarmGridActionsEnabled.Width = 52;
            // 
            // m_guiASAlarmGridNamespace
            // 
            this.m_guiASAlarmGridNamespace.DataPropertyName = "Namespace";
            this.m_guiASAlarmGridNamespace.HeaderText = "Namespace";
            this.m_guiASAlarmGridNamespace.Name = "m_guiASAlarmGridNamespace";
            this.m_guiASAlarmGridNamespace.ReadOnly = true;
            this.m_guiASAlarmGridNamespace.Width = 89;
            // 
            // m_guiASAlarmGridMetricName
            // 
            this.m_guiASAlarmGridMetricName.DataPropertyName = "MetricName";
            this.m_guiASAlarmGridMetricName.HeaderText = "Metric Name";
            this.m_guiASAlarmGridMetricName.Name = "m_guiASAlarmGridMetricName";
            this.m_guiASAlarmGridMetricName.ReadOnly = true;
            this.m_guiASAlarmGridMetricName.Width = 85;
            // 
            // m_guiASAlarmGridStatistic
            // 
            this.m_guiASAlarmGridStatistic.DataPropertyName = "Statistic";
            this.m_guiASAlarmGridStatistic.HeaderText = "Statistic";
            this.m_guiASAlarmGridStatistic.Name = "m_guiASAlarmGridStatistic";
            this.m_guiASAlarmGridStatistic.ReadOnly = true;
            this.m_guiASAlarmGridStatistic.Width = 69;
            // 
            // m_guiASAlarmGridOperator
            // 
            this.m_guiASAlarmGridOperator.DataPropertyName = "ComparisonOperator";
            this.m_guiASAlarmGridOperator.HeaderText = "Comparision Operator";
            this.m_guiASAlarmGridOperator.Name = "m_guiASAlarmGridOperator";
            this.m_guiASAlarmGridOperator.ReadOnly = true;
            this.m_guiASAlarmGridOperator.Width = 122;
            // 
            // m_guiASAlarmGridThreshold
            // 
            this.m_guiASAlarmGridThreshold.DataPropertyName = "Threshold";
            this.m_guiASAlarmGridThreshold.HeaderText = "Threshold";
            this.m_guiASAlarmGridThreshold.Name = "m_guiASAlarmGridThreshold";
            this.m_guiASAlarmGridThreshold.ReadOnly = true;
            this.m_guiASAlarmGridThreshold.Width = 79;
            // 
            // m_guiASAlarmGridEvaluationPeriods
            // 
            this.m_guiASAlarmGridEvaluationPeriods.DataPropertyName = "EvaluationPeriods";
            this.m_guiASAlarmGridEvaluationPeriods.HeaderText = "Evaluation Periods";
            this.m_guiASAlarmGridEvaluationPeriods.Name = "m_guiASAlarmGridEvaluationPeriods";
            this.m_guiASAlarmGridEvaluationPeriods.ReadOnly = true;
            this.m_guiASAlarmGridEvaluationPeriods.Width = 110;
            // 
            // m_guiASAlarmGridPeriod
            // 
            this.m_guiASAlarmGridPeriod.DataPropertyName = "Period";
            this.m_guiASAlarmGridPeriod.HeaderText = "Period";
            this.m_guiASAlarmGridPeriod.Name = "m_guiASAlarmGridPeriod";
            this.m_guiASAlarmGridPeriod.ReadOnly = true;
            this.m_guiASAlarmGridPeriod.Width = 62;
            // 
            // m_guiASAlarmGridUpdated
            // 
            this.m_guiASAlarmGridUpdated.DataPropertyName = "AlarmConfigurationUpdatedTimestamp";
            this.m_guiASAlarmGridUpdated.HeaderText = "Updated";
            this.m_guiASAlarmGridUpdated.Name = "m_guiASAlarmGridUpdated";
            this.m_guiASAlarmGridUpdated.ReadOnly = true;
            this.m_guiASAlarmGridUpdated.Width = 73;
            // 
            // m_guiASAlarmGridUnit
            // 
            this.m_guiASAlarmGridUnit.DataPropertyName = "Unit";
            this.m_guiASAlarmGridUnit.HeaderText = "Unit";
            this.m_guiASAlarmGridUnit.Name = "m_guiASAlarmGridUnit";
            this.m_guiASAlarmGridUnit.ReadOnly = true;
            this.m_guiASAlarmGridUnit.Width = 51;
            // 
            // m_guiASAlarmGridStateReason
            // 
            this.m_guiASAlarmGridStateReason.DataPropertyName = "StateReason";
            this.m_guiASAlarmGridStateReason.HeaderText = "State Reason";
            this.m_guiASAlarmGridStateReason.Name = "m_guiASAlarmGridStateReason";
            this.m_guiASAlarmGridStateReason.ReadOnly = true;
            this.m_guiASAlarmGridStateReason.Width = 89;
            // 
            // m_guiASAlarmGridStateReasonData
            // 
            this.m_guiASAlarmGridStateReasonData.DataPropertyName = "StateReasonData";
            this.m_guiASAlarmGridStateReasonData.HeaderText = "Reason Data";
            this.m_guiASAlarmGridStateReasonData.Name = "m_guiASAlarmGridStateReasonData";
            this.m_guiASAlarmGridStateReasonData.ReadOnly = true;
            this.m_guiASAlarmGridStateReasonData.Width = 87;
            // 
            // m_guiASAlarmGridStateValue
            // 
            this.m_guiASAlarmGridStateValue.DataPropertyName = "StateValue";
            this.m_guiASAlarmGridStateValue.HeaderText = "State Value";
            this.m_guiASAlarmGridStateValue.Name = "m_guiASAlarmGridStateValue";
            this.m_guiASAlarmGridStateValue.ReadOnly = true;
            this.m_guiASAlarmGridStateValue.Width = 80;
            // 
            // m_guiASAlarmGridStateUpdated
            // 
            this.m_guiASAlarmGridStateUpdated.DataPropertyName = "StateUpdatedTimestamp";
            this.m_guiASAlarmGridStateUpdated.HeaderText = "State Updated";
            this.m_guiASAlarmGridStateUpdated.Name = "m_guiASAlarmGridStateUpdated";
            this.m_guiASAlarmGridStateUpdated.ReadOnly = true;
            this.m_guiASAlarmGridStateUpdated.Width = 93;
            // 
            // toolStrip11
            // 
            this.toolStrip11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiASRefreshAlarm,
            this.toolStripSeparator11,
            this.m_guiASAddAlarm,
            this.m_guiASEditAlarm,
            this.m_guiASDeleteAlarm,
            this.toolStripSeparator10,
            this.m_guiASViewAlarmHistories});
            this.toolStrip11.Location = new System.Drawing.Point(3, 3);
            this.toolStrip11.Name = "toolStrip11";
            this.toolStrip11.Size = new System.Drawing.Size(920, 25);
            this.toolStrip11.TabIndex = 5;
            this.toolStrip11.Text = "toolStrip11";
            // 
            // m_guiASRefreshAlarm
            // 
            this.m_guiASRefreshAlarm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASRefreshAlarm.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASRefreshAlarm.Image")));
            this.m_guiASRefreshAlarm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASRefreshAlarm.Name = "m_guiASRefreshAlarm";
            this.m_guiASRefreshAlarm.Size = new System.Drawing.Size(50, 22);
            this.m_guiASRefreshAlarm.Text = "Refresh";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // m_guiASAddAlarm
            // 
            this.m_guiASAddAlarm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASAddAlarm.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASAddAlarm.Image")));
            this.m_guiASAddAlarm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASAddAlarm.Name = "m_guiASAddAlarm";
            this.m_guiASAddAlarm.Size = new System.Drawing.Size(60, 22);
            this.m_guiASAddAlarm.Text = "Add New";
            // 
            // m_guiASEditAlarm
            // 
            this.m_guiASEditAlarm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASEditAlarm.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASEditAlarm.Image")));
            this.m_guiASEditAlarm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASEditAlarm.Name = "m_guiASEditAlarm";
            this.m_guiASEditAlarm.Size = new System.Drawing.Size(31, 22);
            this.m_guiASEditAlarm.Text = "Edit";
            // 
            // m_guiASDeleteAlarm
            // 
            this.m_guiASDeleteAlarm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASDeleteAlarm.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASDeleteAlarm.Image")));
            this.m_guiASDeleteAlarm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASDeleteAlarm.Name = "m_guiASDeleteAlarm";
            this.m_guiASDeleteAlarm.Size = new System.Drawing.Size(44, 22);
            this.m_guiASDeleteAlarm.Text = "Delete";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // m_guiASViewAlarmHistories
            // 
            this.m_guiASViewAlarmHistories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASViewAlarmHistories.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASViewAlarmHistories.Image")));
            this.m_guiASViewAlarmHistories.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASViewAlarmHistories.Name = "m_guiASViewAlarmHistories";
            this.m_guiASViewAlarmHistories.Size = new System.Drawing.Size(120, 22);
            this.m_guiASViewAlarmHistories.Text = "View Alarm Histories";
            // 
            // m_guiTabASSchedule
            // 
            this.m_guiTabASSchedule.Controls.Add(this.m_guiASScheduleGrid);
            this.m_guiTabASSchedule.Controls.Add(this.toolStrip12);
            this.m_guiTabASSchedule.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabASSchedule.Name = "m_guiTabASSchedule";
            this.m_guiTabASSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabASSchedule.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabASSchedule.TabIndex = 5;
            this.m_guiTabASSchedule.Text = "Scale by Schedules";
            this.m_guiTabASSchedule.UseVisualStyleBackColor = true;
            // 
            // m_guiASScheduleGrid
            // 
            this.m_guiASScheduleGrid.AllowUserToAddRows = false;
            this.m_guiASScheduleGrid.AllowUserToDeleteRows = false;
            this.m_guiASScheduleGrid.AllowUserToOrderColumns = true;
            this.m_guiASScheduleGrid.AllowUserToResizeRows = false;
            this.m_guiASScheduleGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiASScheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiASScheduleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_guiASScheduleGridScheduleName,
            this.m_guiASScheduleGridGroupName,
            this.m_guiASScheduleGridStartTime,
            this.m_guiASScheduleGridEndTime,
            this.m_guiASScheduleGridRecurrence,
            this.m_guiASScheduleGridMinSize,
            this.m_guiASScheduleGridMaxSize,
            this.m_guiASScheduleGridDesiredCapacity});
            this.m_guiASScheduleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiASScheduleGrid.Location = new System.Drawing.Point(3, 28);
            this.m_guiASScheduleGrid.Name = "m_guiASScheduleGrid";
            this.m_guiASScheduleGrid.ReadOnly = true;
            this.m_guiASScheduleGrid.RowHeadersWidth = 31;
            this.m_guiASScheduleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiASScheduleGrid.ShowEditingIcon = false;
            this.m_guiASScheduleGrid.Size = new System.Drawing.Size(920, 540);
            this.m_guiASScheduleGrid.TabIndex = 6;
            // 
            // m_guiASScheduleGridScheduleName
            // 
            this.m_guiASScheduleGridScheduleName.DataPropertyName = "ScheduledActionName";
            this.m_guiASScheduleGridScheduleName.HeaderText = "Schedule Name";
            this.m_guiASScheduleGridScheduleName.Name = "m_guiASScheduleGridScheduleName";
            this.m_guiASScheduleGridScheduleName.ReadOnly = true;
            this.m_guiASScheduleGridScheduleName.Width = 99;
            // 
            // m_guiASScheduleGridGroupName
            // 
            this.m_guiASScheduleGridGroupName.DataPropertyName = "AutoScalingGroupName";
            this.m_guiASScheduleGridGroupName.HeaderText = "Group Name";
            this.m_guiASScheduleGridGroupName.Name = "m_guiASScheduleGridGroupName";
            this.m_guiASScheduleGridGroupName.ReadOnly = true;
            this.m_guiASScheduleGridGroupName.Width = 85;
            // 
            // m_guiASScheduleGridStartTime
            // 
            this.m_guiASScheduleGridStartTime.DataPropertyName = "StartTime";
            this.m_guiASScheduleGridStartTime.HeaderText = "StartTime";
            this.m_guiASScheduleGridStartTime.Name = "m_guiASScheduleGridStartTime";
            this.m_guiASScheduleGridStartTime.ReadOnly = true;
            this.m_guiASScheduleGridStartTime.Width = 77;
            // 
            // m_guiASScheduleGridEndTime
            // 
            this.m_guiASScheduleGridEndTime.DataPropertyName = "EndTime";
            this.m_guiASScheduleGridEndTime.HeaderText = "End Time";
            this.m_guiASScheduleGridEndTime.Name = "m_guiASScheduleGridEndTime";
            this.m_guiASScheduleGridEndTime.ReadOnly = true;
            this.m_guiASScheduleGridEndTime.Width = 71;
            // 
            // m_guiASScheduleGridRecurrence
            // 
            this.m_guiASScheduleGridRecurrence.DataPropertyName = "Recurrence";
            this.m_guiASScheduleGridRecurrence.HeaderText = "Recurrence";
            this.m_guiASScheduleGridRecurrence.Name = "m_guiASScheduleGridRecurrence";
            this.m_guiASScheduleGridRecurrence.ReadOnly = true;
            this.m_guiASScheduleGridRecurrence.Width = 88;
            // 
            // m_guiASScheduleGridMinSize
            // 
            this.m_guiASScheduleGridMinSize.DataPropertyName = "MinSize";
            this.m_guiASScheduleGridMinSize.HeaderText = "MinSize";
            this.m_guiASScheduleGridMinSize.Name = "m_guiASScheduleGridMinSize";
            this.m_guiASScheduleGridMinSize.ReadOnly = true;
            this.m_guiASScheduleGridMinSize.Width = 69;
            // 
            // m_guiASScheduleGridMaxSize
            // 
            this.m_guiASScheduleGridMaxSize.DataPropertyName = "MaxSize";
            this.m_guiASScheduleGridMaxSize.HeaderText = "Max Size";
            this.m_guiASScheduleGridMaxSize.Name = "m_guiASScheduleGridMaxSize";
            this.m_guiASScheduleGridMaxSize.ReadOnly = true;
            this.m_guiASScheduleGridMaxSize.Width = 69;
            // 
            // m_guiASScheduleGridDesiredCapacity
            // 
            this.m_guiASScheduleGridDesiredCapacity.DataPropertyName = "DesiredCapacity";
            this.m_guiASScheduleGridDesiredCapacity.HeaderText = "Desired Capacity";
            this.m_guiASScheduleGridDesiredCapacity.Name = "m_guiASScheduleGridDesiredCapacity";
            this.m_guiASScheduleGridDesiredCapacity.ReadOnly = true;
            this.m_guiASScheduleGridDesiredCapacity.Width = 103;
            // 
            // toolStrip12
            // 
            this.toolStrip12.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiASRefreshSchedule,
            this.toolStripSeparator12,
            this.m_guiASAddSchedule,
            this.m_guiASEditSchedule,
            this.m_guiASDeleteSchedule});
            this.toolStrip12.Location = new System.Drawing.Point(3, 3);
            this.toolStrip12.Name = "toolStrip12";
            this.toolStrip12.Size = new System.Drawing.Size(920, 25);
            this.toolStrip12.TabIndex = 5;
            this.toolStrip12.Text = "toolStrip12";
            // 
            // m_guiASRefreshSchedule
            // 
            this.m_guiASRefreshSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASRefreshSchedule.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASRefreshSchedule.Image")));
            this.m_guiASRefreshSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASRefreshSchedule.Name = "m_guiASRefreshSchedule";
            this.m_guiASRefreshSchedule.Size = new System.Drawing.Size(50, 22);
            this.m_guiASRefreshSchedule.Text = "Refresh";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // m_guiASAddSchedule
            // 
            this.m_guiASAddSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASAddSchedule.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASAddSchedule.Image")));
            this.m_guiASAddSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASAddSchedule.Name = "m_guiASAddSchedule";
            this.m_guiASAddSchedule.Size = new System.Drawing.Size(60, 22);
            this.m_guiASAddSchedule.Text = "Add New";
            // 
            // m_guiASEditSchedule
            // 
            this.m_guiASEditSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASEditSchedule.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASEditSchedule.Image")));
            this.m_guiASEditSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASEditSchedule.Name = "m_guiASEditSchedule";
            this.m_guiASEditSchedule.Size = new System.Drawing.Size(31, 22);
            this.m_guiASEditSchedule.Text = "Edit";
            // 
            // m_guiASDeleteSchedule
            // 
            this.m_guiASDeleteSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASDeleteSchedule.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASDeleteSchedule.Image")));
            this.m_guiASDeleteSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASDeleteSchedule.Name = "m_guiASDeleteSchedule";
            this.m_guiASDeleteSchedule.Size = new System.Drawing.Size(44, 22);
            this.m_guiASDeleteSchedule.Text = "Delete";
            // 
            // m_guiTabASInstance
            // 
            this.m_guiTabASInstance.Controls.Add(this.m_guiASInstanceGrid);
            this.m_guiTabASInstance.Controls.Add(this.toolStrip8);
            this.m_guiTabASInstance.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabASInstance.Name = "m_guiTabASInstance";
            this.m_guiTabASInstance.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabASInstance.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabASInstance.TabIndex = 3;
            this.m_guiTabASInstance.Text = "Instances";
            this.m_guiTabASInstance.UseVisualStyleBackColor = true;
            // 
            // m_guiASInstanceGrid
            // 
            this.m_guiASInstanceGrid.AllowUserToAddRows = false;
            this.m_guiASInstanceGrid.AllowUserToDeleteRows = false;
            this.m_guiASInstanceGrid.AllowUserToOrderColumns = true;
            this.m_guiASInstanceGrid.AllowUserToResizeRows = false;
            this.m_guiASInstanceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiASInstanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiASInstanceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiASInstanceGrid.Location = new System.Drawing.Point(3, 28);
            this.m_guiASInstanceGrid.Name = "m_guiASInstanceGrid";
            this.m_guiASInstanceGrid.ReadOnly = true;
            this.m_guiASInstanceGrid.RowHeadersWidth = 31;
            this.m_guiASInstanceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiASInstanceGrid.ShowEditingIcon = false;
            this.m_guiASInstanceGrid.Size = new System.Drawing.Size(920, 540);
            this.m_guiASInstanceGrid.TabIndex = 6;
            // 
            // toolStrip8
            // 
            this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiASRefreshInstance,
            this.toolStripSeparator8,
            this.m_guiASTerminateInstance});
            this.toolStrip8.Location = new System.Drawing.Point(3, 3);
            this.toolStrip8.Name = "toolStrip8";
            this.toolStrip8.Size = new System.Drawing.Size(920, 25);
            this.toolStrip8.TabIndex = 5;
            this.toolStrip8.Text = "toolStrip8";
            // 
            // m_guiASRefreshInstance
            // 
            this.m_guiASRefreshInstance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASRefreshInstance.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASRefreshInstance.Image")));
            this.m_guiASRefreshInstance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASRefreshInstance.Name = "m_guiASRefreshInstance";
            this.m_guiASRefreshInstance.Size = new System.Drawing.Size(50, 22);
            this.m_guiASRefreshInstance.Text = "Refresh";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // m_guiASTerminateInstance
            // 
            this.m_guiASTerminateInstance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASTerminateInstance.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASTerminateInstance.Image")));
            this.m_guiASTerminateInstance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASTerminateInstance.Name = "m_guiASTerminateInstance";
            this.m_guiASTerminateInstance.Size = new System.Drawing.Size(65, 22);
            this.m_guiASTerminateInstance.Text = "Terminate";
            // 
            // m_guiTabASActivity
            // 
            this.m_guiTabASActivity.Controls.Add(this.m_guiASActivityGrid);
            this.m_guiTabASActivity.Controls.Add(this.toolStrip13);
            this.m_guiTabASActivity.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabASActivity.Name = "m_guiTabASActivity";
            this.m_guiTabASActivity.Size = new System.Drawing.Size(926, 571);
            this.m_guiTabASActivity.TabIndex = 6;
            this.m_guiTabASActivity.Text = "Activities";
            this.m_guiTabASActivity.UseVisualStyleBackColor = true;
            // 
            // m_guiASActivityGrid
            // 
            this.m_guiASActivityGrid.AllowUserToAddRows = false;
            this.m_guiASActivityGrid.AllowUserToDeleteRows = false;
            this.m_guiASActivityGrid.AllowUserToOrderColumns = true;
            this.m_guiASActivityGrid.AllowUserToResizeRows = false;
            this.m_guiASActivityGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiASActivityGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.m_guiASActivityGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiASActivityGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.m_guiASActivityGridStatusColumn,
            this.m_guiASActivityGridProgressColumn});
            this.m_guiASActivityGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiASActivityGrid.Location = new System.Drawing.Point(0, 25);
            this.m_guiASActivityGrid.Name = "m_guiASActivityGrid";
            this.m_guiASActivityGrid.ReadOnly = true;
            this.m_guiASActivityGrid.RowHeadersWidth = 31;
            this.m_guiASActivityGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiASActivityGrid.ShowEditingIcon = false;
            this.m_guiASActivityGrid.Size = new System.Drawing.Size(926, 546);
            this.m_guiASActivityGrid.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AutoScalingGroupName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Cause";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "Cause";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 300;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "StartTime";
            this.dataGridViewTextBoxColumn4.HeaderText = "Start";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "EndTime";
            this.dataGridViewTextBoxColumn5.HeaderText = "End";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // m_guiASActivityGridStatusColumn
            // 
            this.m_guiASActivityGridStatusColumn.DataPropertyName = "StatusCode";
            this.m_guiASActivityGridStatusColumn.HeaderText = "Status";
            this.m_guiASActivityGridStatusColumn.MinimumWidth = 60;
            this.m_guiASActivityGridStatusColumn.Name = "m_guiASActivityGridStatusColumn";
            this.m_guiASActivityGridStatusColumn.ReadOnly = true;
            this.m_guiASActivityGridStatusColumn.Width = 62;
            // 
            // m_guiASActivityGridProgressColumn
            // 
            this.m_guiASActivityGridProgressColumn.DataPropertyName = "Progress";
            this.m_guiASActivityGridProgressColumn.HeaderText = "Progress";
            this.m_guiASActivityGridProgressColumn.MinimumWidth = 60;
            this.m_guiASActivityGridProgressColumn.Name = "m_guiASActivityGridProgressColumn";
            this.m_guiASActivityGridProgressColumn.ReadOnly = true;
            this.m_guiASActivityGridProgressColumn.Width = 73;
            // 
            // toolStrip13
            // 
            this.toolStrip13.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiASRefreshActivity});
            this.toolStrip13.Location = new System.Drawing.Point(0, 0);
            this.toolStrip13.Name = "toolStrip13";
            this.toolStrip13.Size = new System.Drawing.Size(926, 25);
            this.toolStrip13.TabIndex = 6;
            this.toolStrip13.Text = "toolStrip13";
            // 
            // m_guiASRefreshActivity
            // 
            this.m_guiASRefreshActivity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiASRefreshActivity.Image = ((System.Drawing.Image)(resources.GetObject("m_guiASRefreshActivity.Image")));
            this.m_guiASRefreshActivity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiASRefreshActivity.Name = "m_guiASRefreshActivity";
            this.m_guiASRefreshActivity.Size = new System.Drawing.Size(50, 22);
            this.m_guiASRefreshActivity.Text = "Refresh";
            // 
            // m_guiTabS3
            // 
            this.m_guiTabS3.Controls.Add(this.splitContainer1);
            this.m_guiTabS3.Controls.Add(this.toolStrip4);
            this.m_guiTabS3.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabS3.Name = "m_guiTabS3";
            this.m_guiTabS3.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabS3.Size = new System.Drawing.Size(940, 603);
            this.m_guiTabS3.TabIndex = 2;
            this.m_guiTabS3.Text = "S3";
            this.m_guiTabS3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_guiS3TabLeftStatusStrip);
            this.splitContainer1.Panel1.Controls.Add(this.m_guiS3TabLeftListView);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_guiS3TabRightStatusStrip);
            this.splitContainer1.Panel2.Controls.Add(this.m_guiS3TabRightListView);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip6);
            this.splitContainer1.Size = new System.Drawing.Size(934, 572);
            this.splitContainer1.SplitterDistance = 463;
            this.splitContainer1.TabIndex = 1;
            // 
            // m_guiS3TabLeftStatusStrip
            // 
            this.m_guiS3TabLeftStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiS3TabLeftStatusLabel});
            this.m_guiS3TabLeftStatusStrip.Location = new System.Drawing.Point(0, 550);
            this.m_guiS3TabLeftStatusStrip.Name = "m_guiS3TabLeftStatusStrip";
            this.m_guiS3TabLeftStatusStrip.Size = new System.Drawing.Size(463, 22);
            this.m_guiS3TabLeftStatusStrip.TabIndex = 2;
            this.m_guiS3TabLeftStatusStrip.Text = "statusStrip1";
            // 
            // m_guiS3TabLeftStatusLabel
            // 
            this.m_guiS3TabLeftStatusLabel.Name = "m_guiS3TabLeftStatusLabel";
            this.m_guiS3TabLeftStatusLabel.Size = new System.Drawing.Size(448, 17);
            this.m_guiS3TabLeftStatusLabel.Spring = true;
            this.m_guiS3TabLeftStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_guiS3TabLeftListView
            // 
            this.m_guiS3TabLeftListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader7,
            this.columnHeader3});
            this.m_guiS3TabLeftListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_guiS3TabLeftListView.LargeImageList = this.m_guiS3TabSmallImageList;
            this.m_guiS3TabLeftListView.Location = new System.Drawing.Point(0, 25);
            this.m_guiS3TabLeftListView.Name = "m_guiS3TabLeftListView";
            this.m_guiS3TabLeftListView.Size = new System.Drawing.Size(463, 556);
            this.m_guiS3TabLeftListView.SmallImageList = this.m_guiS3TabSmallImageList;
            this.m_guiS3TabLeftListView.TabIndex = 1;
            this.m_guiS3TabLeftListView.UseCompatibleStateImageBehavior = false;
            this.m_guiS3TabLeftListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 210;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Size";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.Width = 130;
            // 
            // m_guiS3TabSmallImageList
            // 
            this.m_guiS3TabSmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_guiS3TabSmallImageList.ImageStream")));
            this.m_guiS3TabSmallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_guiS3TabSmallImageList.Images.SetKeyName(0, "drive.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(1, "folder.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(2, "page.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(3, "page_white.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(4, "page_white_acrobat.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(5, "page_white_actionscript.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(6, "page_white_add.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(7, "page_white_c.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(8, "page_white_camera.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(9, "page_white_cd.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(10, "page_white_code.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(11, "page_white_code_red.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(12, "page_white_coldfusion.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(13, "page_white_compressed.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(14, "page_white_copy.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(15, "page_white_cplusplus.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(16, "page_white_csharp.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(17, "page_white_cup.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(18, "page_white_database.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(19, "page_white_delete.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(20, "page_white_dvd.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(21, "page_white_edit.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(22, "page_white_error.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(23, "page_white_excel.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(24, "page_white_find.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(25, "page_white_flash.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(26, "page_white_freehand.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(27, "page_white_gear.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(28, "page_white_get.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(29, "page_white_go.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(30, "page_white_h.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(31, "page_white_horizontal.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(32, "page_white_key.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(33, "page_white_lightning.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(34, "page_white_link.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(35, "page_white_magnify.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(36, "page_white_medal.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(37, "page_white_office.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(38, "page_white_paint.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(39, "page_white_paintbrush.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(40, "page_white_paste.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(41, "page_white_php.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(42, "page_white_picture.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(43, "page_white_powerpoint.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(44, "page_white_put.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(45, "page_white_ruby.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(46, "page_white_stack.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(47, "page_white_star.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(48, "page_white_swoosh.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(49, "page_white_text.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(50, "page_white_text_width.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(51, "page_white_tux.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(52, "page_white_vector.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(53, "page_white_visualstudio.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(54, "page_white_width.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(55, "page_white_word.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(56, "page_white_world.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(57, "page_white_wrench.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(58, "page_white_zip.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(59, "bullet_arrow_down.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(60, "bullet_arrow_bottom.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(61, "bullet_arrow_top.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(62, "bullet_arrow_up.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(63, "folder_explore.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(64, "drive_disk.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(65, "drive_network.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(66, "drive_cd.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(67, "drive_web.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(68, "drive_go.png");
            this.m_guiS3TabSmallImageList.Images.SetKeyName(69, "drive_cd_empty.png");
            // 
            // toolStrip5
            // 
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiS3TabLeftRefresh,
            this.m_guiS3TabLeftCopyToRight,
            this.m_guiS3TabLeftAddFolder,
            this.m_guiS3TabLeftDelete});
            this.toolStrip5.Location = new System.Drawing.Point(0, 0);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip5.Size = new System.Drawing.Size(463, 25);
            this.toolStrip5.TabIndex = 0;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // m_guiS3TabLeftRefresh
            // 
            this.m_guiS3TabLeftRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_guiS3TabLeftRefresh.Image = global::AwsController.Properties.Resources.arrow_refresh_small;
            this.m_guiS3TabLeftRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiS3TabLeftRefresh.Name = "m_guiS3TabLeftRefresh";
            this.m_guiS3TabLeftRefresh.Size = new System.Drawing.Size(23, 22);
            this.m_guiS3TabLeftRefresh.Text = "Refresh";
            this.m_guiS3TabLeftRefresh.ToolTipText = "Refresh left pane";
            // 
            // m_guiS3TabLeftCopyToRight
            // 
            this.m_guiS3TabLeftCopyToRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_guiS3TabLeftCopyToRight.Image = global::AwsController.Properties.Resources.arrow_right;
            this.m_guiS3TabLeftCopyToRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiS3TabLeftCopyToRight.Name = "m_guiS3TabLeftCopyToRight";
            this.m_guiS3TabLeftCopyToRight.Size = new System.Drawing.Size(23, 22);
            this.m_guiS3TabLeftCopyToRight.Text = "Copy right";
            this.m_guiS3TabLeftCopyToRight.ToolTipText = "Copy selected item(s) to the right";
            // 
            // m_guiS3TabLeftAddFolder
            // 
            this.m_guiS3TabLeftAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_guiS3TabLeftAddFolder.Image = global::AwsController.Properties.Resources.folder_add;
            this.m_guiS3TabLeftAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiS3TabLeftAddFolder.Name = "m_guiS3TabLeftAddFolder";
            this.m_guiS3TabLeftAddFolder.Size = new System.Drawing.Size(23, 22);
            this.m_guiS3TabLeftAddFolder.Text = "Create folder";
            // 
            // m_guiS3TabLeftDelete
            // 
            this.m_guiS3TabLeftDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_guiS3TabLeftDelete.Image = global::AwsController.Properties.Resources.delete;
            this.m_guiS3TabLeftDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiS3TabLeftDelete.Name = "m_guiS3TabLeftDelete";
            this.m_guiS3TabLeftDelete.Size = new System.Drawing.Size(23, 22);
            this.m_guiS3TabLeftDelete.Text = "Delete";
            this.m_guiS3TabLeftDelete.ToolTipText = "Delete selected item(s)";
            // 
            // m_guiS3TabRightStatusStrip
            // 
            this.m_guiS3TabRightStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiS3TabRightStatusLabel});
            this.m_guiS3TabRightStatusStrip.Location = new System.Drawing.Point(0, 550);
            this.m_guiS3TabRightStatusStrip.Name = "m_guiS3TabRightStatusStrip";
            this.m_guiS3TabRightStatusStrip.Size = new System.Drawing.Size(467, 22);
            this.m_guiS3TabRightStatusStrip.TabIndex = 2;
            this.m_guiS3TabRightStatusStrip.Text = "statusStrip2";
            // 
            // m_guiS3TabRightStatusLabel
            // 
            this.m_guiS3TabRightStatusLabel.Name = "m_guiS3TabRightStatusLabel";
            this.m_guiS3TabRightStatusLabel.Size = new System.Drawing.Size(452, 17);
            this.m_guiS3TabRightStatusLabel.Spring = true;
            this.m_guiS3TabRightStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_guiS3TabRightListView
            // 
            this.m_guiS3TabRightListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader6});
            this.m_guiS3TabRightListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_guiS3TabRightListView.LargeImageList = this.m_guiS3TabSmallImageList;
            this.m_guiS3TabRightListView.Location = new System.Drawing.Point(0, 25);
            this.m_guiS3TabRightListView.Name = "m_guiS3TabRightListView";
            this.m_guiS3TabRightListView.Size = new System.Drawing.Size(467, 556);
            this.m_guiS3TabRightListView.SmallImageList = this.m_guiS3TabSmallImageList;
            this.m_guiS3TabRightListView.TabIndex = 1;
            this.m_guiS3TabRightListView.UseCompatibleStateImageBehavior = false;
            this.m_guiS3TabRightListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 210;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Type";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Size";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Date";
            this.columnHeader6.Width = 130;
            // 
            // toolStrip6
            // 
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiS3TabRightRefresh,
            this.m_guiS3TabRightCopyToLeft,
            this.m_guiS3TabRightAddBucket,
            this.m_guiS3TabRightAddFolder,
            this.m_guiS3TabRightDelete});
            this.toolStrip6.Location = new System.Drawing.Point(0, 0);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip6.Size = new System.Drawing.Size(467, 25);
            this.toolStrip6.TabIndex = 0;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // m_guiS3TabRightRefresh
            // 
            this.m_guiS3TabRightRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_guiS3TabRightRefresh.Image = global::AwsController.Properties.Resources.arrow_refresh_small;
            this.m_guiS3TabRightRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiS3TabRightRefresh.Name = "m_guiS3TabRightRefresh";
            this.m_guiS3TabRightRefresh.Size = new System.Drawing.Size(23, 22);
            this.m_guiS3TabRightRefresh.Text = "Refresh";
            this.m_guiS3TabRightRefresh.ToolTipText = "Refresh right pane";
            // 
            // m_guiS3TabRightCopyToLeft
            // 
            this.m_guiS3TabRightCopyToLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_guiS3TabRightCopyToLeft.Image = global::AwsController.Properties.Resources.arrow_left;
            this.m_guiS3TabRightCopyToLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiS3TabRightCopyToLeft.Name = "m_guiS3TabRightCopyToLeft";
            this.m_guiS3TabRightCopyToLeft.Size = new System.Drawing.Size(23, 22);
            this.m_guiS3TabRightCopyToLeft.Text = "Copy left";
            this.m_guiS3TabRightCopyToLeft.ToolTipText = "Copy selected item(s) to the left";
            // 
            // m_guiS3TabRightAddBucket
            // 
            this.m_guiS3TabRightAddBucket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_guiS3TabRightAddBucket.Image = global::AwsController.Properties.Resources.package_add;
            this.m_guiS3TabRightAddBucket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiS3TabRightAddBucket.Name = "m_guiS3TabRightAddBucket";
            this.m_guiS3TabRightAddBucket.Size = new System.Drawing.Size(23, 22);
            this.m_guiS3TabRightAddBucket.Text = "Create bucket";
            // 
            // m_guiS3TabRightAddFolder
            // 
            this.m_guiS3TabRightAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_guiS3TabRightAddFolder.Image = global::AwsController.Properties.Resources.folder_add;
            this.m_guiS3TabRightAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiS3TabRightAddFolder.Name = "m_guiS3TabRightAddFolder";
            this.m_guiS3TabRightAddFolder.Size = new System.Drawing.Size(23, 22);
            this.m_guiS3TabRightAddFolder.Text = "Create folder";
            // 
            // m_guiS3TabRightDelete
            // 
            this.m_guiS3TabRightDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_guiS3TabRightDelete.Image = global::AwsController.Properties.Resources.delete;
            this.m_guiS3TabRightDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiS3TabRightDelete.Name = "m_guiS3TabRightDelete";
            this.m_guiS3TabRightDelete.Size = new System.Drawing.Size(23, 22);
            this.m_guiS3TabRightDelete.Text = "Delete";
            this.m_guiS3TabRightDelete.ToolTipText = "Delete selected item(s)";
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiS3TabOpenTransferQueue});
            this.toolStrip4.Location = new System.Drawing.Point(3, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip4.Size = new System.Drawing.Size(934, 25);
            this.toolStrip4.TabIndex = 0;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // m_guiS3TabOpenTransferQueue
            // 
            this.m_guiS3TabOpenTransferQueue.Image = global::AwsController.Properties.Resources.text_list_bullets;
            this.m_guiS3TabOpenTransferQueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiS3TabOpenTransferQueue.Name = "m_guiS3TabOpenTransferQueue";
            this.m_guiS3TabOpenTransferQueue.Size = new System.Drawing.Size(106, 22);
            this.m_guiS3TabOpenTransferQueue.Text = "Transfer queue";
            // 
            // m_guiTabGlacier
            // 
            this.m_guiTabGlacier.Controls.Add(this.m_guiTabGlacierMain);
            this.m_guiTabGlacier.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabGlacier.Name = "m_guiTabGlacier";
            this.m_guiTabGlacier.Size = new System.Drawing.Size(940, 603);
            this.m_guiTabGlacier.TabIndex = 4;
            this.m_guiTabGlacier.Text = "Glacier";
            this.m_guiTabGlacier.UseVisualStyleBackColor = true;
            // 
            // m_guiTabGlacierMain
            // 
            this.m_guiTabGlacierMain.Controls.Add(this.m_guiTabGlacierVault);
            this.m_guiTabGlacierMain.Controls.Add(this.m_guiTabGlacierJob);
            this.m_guiTabGlacierMain.Controls.Add(this.m_guiTabGlacierInventory);
            this.m_guiTabGlacierMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiTabGlacierMain.Location = new System.Drawing.Point(0, 0);
            this.m_guiTabGlacierMain.Name = "m_guiTabGlacierMain";
            this.m_guiTabGlacierMain.SelectedIndex = 0;
            this.m_guiTabGlacierMain.Size = new System.Drawing.Size(940, 603);
            this.m_guiTabGlacierMain.TabIndex = 0;
            // 
            // m_guiTabGlacierVault
            // 
            this.m_guiTabGlacierVault.Controls.Add(this.m_guiGlacierVaultGrid);
            this.m_guiTabGlacierVault.Controls.Add(this.toolStrip14);
            this.m_guiTabGlacierVault.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabGlacierVault.Name = "m_guiTabGlacierVault";
            this.m_guiTabGlacierVault.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabGlacierVault.Size = new System.Drawing.Size(932, 577);
            this.m_guiTabGlacierVault.TabIndex = 1;
            this.m_guiTabGlacierVault.Text = "Vaults";
            this.m_guiTabGlacierVault.UseVisualStyleBackColor = true;
            // 
            // m_guiGlacierVaultGrid
            // 
            this.m_guiGlacierVaultGrid.AllowUserToAddRows = false;
            this.m_guiGlacierVaultGrid.AllowUserToDeleteRows = false;
            this.m_guiGlacierVaultGrid.AllowUserToOrderColumns = true;
            this.m_guiGlacierVaultGrid.AllowUserToResizeRows = false;
            this.m_guiGlacierVaultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiGlacierVaultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiGlacierVaultGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiGlacierVaultGrid.Location = new System.Drawing.Point(3, 28);
            this.m_guiGlacierVaultGrid.Name = "m_guiGlacierVaultGrid";
            this.m_guiGlacierVaultGrid.RowHeadersWidth = 31;
            this.m_guiGlacierVaultGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiGlacierVaultGrid.ShowEditingIcon = false;
            this.m_guiGlacierVaultGrid.Size = new System.Drawing.Size(926, 546);
            this.m_guiGlacierVaultGrid.TabIndex = 3;
            // 
            // toolStrip14
            // 
            this.toolStrip14.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_guiGlacierVaultRefresh,
            this.toolStripSeparator13,
            this.m_guiGlacierVaultAddNew,
            this.m_guiGlacierVaultEdit,
            this.m_guiGlacierVaultDelete});
            this.toolStrip14.Location = new System.Drawing.Point(3, 3);
            this.toolStrip14.Name = "toolStrip14";
            this.toolStrip14.Size = new System.Drawing.Size(926, 25);
            this.toolStrip14.TabIndex = 0;
            this.toolStrip14.Text = "toolStrip14";
            // 
            // m_guiGlacierVaultRefresh
            // 
            this.m_guiGlacierVaultRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiGlacierVaultRefresh.Image = ((System.Drawing.Image)(resources.GetObject("m_guiGlacierVaultRefresh.Image")));
            this.m_guiGlacierVaultRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiGlacierVaultRefresh.Name = "m_guiGlacierVaultRefresh";
            this.m_guiGlacierVaultRefresh.Size = new System.Drawing.Size(50, 22);
            this.m_guiGlacierVaultRefresh.Text = "Refresh";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // m_guiGlacierVaultAddNew
            // 
            this.m_guiGlacierVaultAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiGlacierVaultAddNew.Image = ((System.Drawing.Image)(resources.GetObject("m_guiGlacierVaultAddNew.Image")));
            this.m_guiGlacierVaultAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiGlacierVaultAddNew.Name = "m_guiGlacierVaultAddNew";
            this.m_guiGlacierVaultAddNew.Size = new System.Drawing.Size(60, 22);
            this.m_guiGlacierVaultAddNew.Text = "Add New";
            // 
            // m_guiGlacierVaultEdit
            // 
            this.m_guiGlacierVaultEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiGlacierVaultEdit.Image = ((System.Drawing.Image)(resources.GetObject("m_guiGlacierVaultEdit.Image")));
            this.m_guiGlacierVaultEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiGlacierVaultEdit.Name = "m_guiGlacierVaultEdit";
            this.m_guiGlacierVaultEdit.Size = new System.Drawing.Size(31, 22);
            this.m_guiGlacierVaultEdit.Text = "Edit";
            // 
            // m_guiGlacierVaultDelete
            // 
            this.m_guiGlacierVaultDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_guiGlacierVaultDelete.Image = ((System.Drawing.Image)(resources.GetObject("m_guiGlacierVaultDelete.Image")));
            this.m_guiGlacierVaultDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_guiGlacierVaultDelete.Name = "m_guiGlacierVaultDelete";
            this.m_guiGlacierVaultDelete.Size = new System.Drawing.Size(44, 22);
            this.m_guiGlacierVaultDelete.Text = "Delete";
            // 
            // m_guiTabGlacierJob
            // 
            this.m_guiTabGlacierJob.Controls.Add(this.m_guiGlacierJobGrid);
            this.m_guiTabGlacierJob.Controls.Add(this.toolStrip15);
            this.m_guiTabGlacierJob.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabGlacierJob.Name = "m_guiTabGlacierJob";
            this.m_guiTabGlacierJob.Padding = new System.Windows.Forms.Padding(3);
            this.m_guiTabGlacierJob.Size = new System.Drawing.Size(932, 577);
            this.m_guiTabGlacierJob.TabIndex = 0;
            this.m_guiTabGlacierJob.Text = "Jobs";
            this.m_guiTabGlacierJob.UseVisualStyleBackColor = true;
            // 
            // m_guiGlacierJobGrid
            // 
            this.m_guiGlacierJobGrid.AllowUserToAddRows = false;
            this.m_guiGlacierJobGrid.AllowUserToDeleteRows = false;
            this.m_guiGlacierJobGrid.AllowUserToOrderColumns = true;
            this.m_guiGlacierJobGrid.AllowUserToResizeRows = false;
            this.m_guiGlacierJobGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiGlacierJobGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiGlacierJobGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiGlacierJobGrid.Location = new System.Drawing.Point(3, 28);
            this.m_guiGlacierJobGrid.Name = "m_guiGlacierJobGrid";
            this.m_guiGlacierJobGrid.RowHeadersWidth = 31;
            this.m_guiGlacierJobGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiGlacierJobGrid.ShowEditingIcon = false;
            this.m_guiGlacierJobGrid.Size = new System.Drawing.Size(926, 546);
            this.m_guiGlacierJobGrid.TabIndex = 5;
            // 
            // toolStrip15
            // 
            this.toolStrip15.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator14,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip15.Location = new System.Drawing.Point(3, 3);
            this.toolStrip15.Name = "toolStrip15";
            this.toolStrip15.Size = new System.Drawing.Size(926, 25);
            this.toolStrip15.TabIndex = 4;
            this.toolStrip15.Text = "toolStrip15";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton2.Text = "Refresh";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton3.Text = "Add New";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(31, 22);
            this.toolStripButton4.Text = "Edit";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton5.Text = "Delete";
            // 
            // m_guiTabGlacierInventory
            // 
            this.m_guiTabGlacierInventory.Controls.Add(this.m_guiGlacierInventoryGrid);
            this.m_guiTabGlacierInventory.Controls.Add(this.toolStrip16);
            this.m_guiTabGlacierInventory.Location = new System.Drawing.Point(4, 22);
            this.m_guiTabGlacierInventory.Name = "m_guiTabGlacierInventory";
            this.m_guiTabGlacierInventory.Size = new System.Drawing.Size(932, 577);
            this.m_guiTabGlacierInventory.TabIndex = 2;
            this.m_guiTabGlacierInventory.Text = "Inventories";
            this.m_guiTabGlacierInventory.UseVisualStyleBackColor = true;
            // 
            // m_guiGlacierInventoryGrid
            // 
            this.m_guiGlacierInventoryGrid.AllowUserToAddRows = false;
            this.m_guiGlacierInventoryGrid.AllowUserToDeleteRows = false;
            this.m_guiGlacierInventoryGrid.AllowUserToOrderColumns = true;
            this.m_guiGlacierInventoryGrid.AllowUserToResizeRows = false;
            this.m_guiGlacierInventoryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_guiGlacierInventoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_guiGlacierInventoryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_guiGlacierInventoryGrid.Location = new System.Drawing.Point(0, 25);
            this.m_guiGlacierInventoryGrid.Name = "m_guiGlacierInventoryGrid";
            this.m_guiGlacierInventoryGrid.RowHeadersWidth = 31;
            this.m_guiGlacierInventoryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_guiGlacierInventoryGrid.ShowEditingIcon = false;
            this.m_guiGlacierInventoryGrid.Size = new System.Drawing.Size(932, 552);
            this.m_guiGlacierInventoryGrid.TabIndex = 5;
            // 
            // toolStrip16
            // 
            this.toolStrip16.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripSeparator15,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9});
            this.toolStrip16.Location = new System.Drawing.Point(0, 0);
            this.toolStrip16.Name = "toolStrip16";
            this.toolStrip16.Size = new System.Drawing.Size(932, 25);
            this.toolStrip16.TabIndex = 4;
            this.toolStrip16.Text = "toolStrip16";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton6.Text = "Refresh";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton7.Text = "Add New";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(31, 22);
            this.toolStripButton8.Text = "Edit";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton9.Text = "Delete";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.m_guiRegionEndpoints});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1016, 25);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel1.Text = "Region:";
            // 
            // m_guiRegionEndpoints
            // 
            this.m_guiRegionEndpoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiRegionEndpoints.Name = "m_guiRegionEndpoints";
            this.m_guiRegionEndpoints.Size = new System.Drawing.Size(180, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.m_guiTab);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AWS Controller";
            this.m_guiTab.ResumeLayout(false);
            this.m_guiTabEC2.ResumeLayout(false);
            this.m_guiTabEC2Main.ResumeLayout(false);
            this.m_guiTabEC2Instance.ResumeLayout(false);
            this.m_guiTabEC2Instance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiEC2InstanceGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.m_guiTabEC2LoadBalancer.ResumeLayout(false);
            this.m_guiTabEC2LoadBalancer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiEC2LoadBalancerGrid)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.m_guiTabAS.ResumeLayout(false);
            this.m_guiTabASMain.ResumeLayout(false);
            this.m_guiTabASLaunchConfiguration.ResumeLayout(false);
            this.m_guiTabASLaunchConfiguration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASLaunchConfigurationGrid)).EndInit();
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.m_guiTabASGroup.ResumeLayout(false);
            this.m_guiTabASGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASGroupGrid)).EndInit();
            this.toolStrip9.ResumeLayout(false);
            this.toolStrip9.PerformLayout();
            this.m_guiTabASPolicy.ResumeLayout(false);
            this.m_guiTabASPolicy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASPolicyGrid)).EndInit();
            this.toolStrip10.ResumeLayout(false);
            this.toolStrip10.PerformLayout();
            this.m_guiTabASAlarm.ResumeLayout(false);
            this.m_guiTabASAlarm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASAlarmGrid)).EndInit();
            this.toolStrip11.ResumeLayout(false);
            this.toolStrip11.PerformLayout();
            this.m_guiTabASSchedule.ResumeLayout(false);
            this.m_guiTabASSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASScheduleGrid)).EndInit();
            this.toolStrip12.ResumeLayout(false);
            this.toolStrip12.PerformLayout();
            this.m_guiTabASInstance.ResumeLayout(false);
            this.m_guiTabASInstance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASInstanceGrid)).EndInit();
            this.toolStrip8.ResumeLayout(false);
            this.toolStrip8.PerformLayout();
            this.m_guiTabASActivity.ResumeLayout(false);
            this.m_guiTabASActivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiASActivityGrid)).EndInit();
            this.toolStrip13.ResumeLayout(false);
            this.toolStrip13.PerformLayout();
            this.m_guiTabS3.ResumeLayout(false);
            this.m_guiTabS3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.m_guiS3TabLeftStatusStrip.ResumeLayout(false);
            this.m_guiS3TabLeftStatusStrip.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.m_guiS3TabRightStatusStrip.ResumeLayout(false);
            this.m_guiS3TabRightStatusStrip.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.m_guiTabGlacier.ResumeLayout(false);
            this.m_guiTabGlacierMain.ResumeLayout(false);
            this.m_guiTabGlacierVault.ResumeLayout(false);
            this.m_guiTabGlacierVault.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiGlacierVaultGrid)).EndInit();
            this.toolStrip14.ResumeLayout(false);
            this.toolStrip14.PerformLayout();
            this.m_guiTabGlacierJob.ResumeLayout(false);
            this.m_guiTabGlacierJob.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiGlacierJobGrid)).EndInit();
            this.toolStrip15.ResumeLayout(false);
            this.toolStrip15.PerformLayout();
            this.m_guiTabGlacierInventory.ResumeLayout(false);
            this.m_guiTabGlacierInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_guiGlacierInventoryGrid)).EndInit();
            this.toolStrip16.ResumeLayout(false);
            this.toolStrip16.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl m_guiTab;
        private System.Windows.Forms.TabPage m_guiTabEC2;
        private System.Windows.Forms.TabControl m_guiTabEC2Main;
        private System.Windows.Forms.TabPage m_guiTabEC2Instance;
        private System.Windows.Forms.TabPage m_guiTabEC2Ami;
        private System.Windows.Forms.TabPage m_guiTabEC2Volume;
        private System.Windows.Forms.TabPage m_guiTabEC2Snapshot;
        private System.Windows.Forms.TabPage m_guiTabVPC;
        private System.Windows.Forms.TabPage m_guiTabS3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_guiEC2InstanceRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceReboot;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceStop;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceStart;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceTerminate;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceBackup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceChangeInstanceType;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceChangeShutdownBehavior;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView m_guiEC2InstanceGrid;
        private System.Windows.Forms.DataGridViewImageColumn m_guiEC2InstanceGridInstanceState;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridInstanceStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridInstanceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridInstanceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridImageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridRootDeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridInstanceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridSecurityGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridKeyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridPrivateIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridPrivateDnsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridPublicIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiEC2InstanceGridPublicDnsName;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceConnectUsingPrivateIP;
        private System.Windows.Forms.TabPage m_guiTabEC2LoadBalancer;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.DataGridView m_guiEC2LoadBalancerGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiLoadBalancerGridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiLoadBalancerGridInstances;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiLoadBalancerGridDNSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiLoadBalancerGridScheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiLoadBalancerGridVPCId;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiLoadBalancerGridSecurityGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiLoadBalancerGridSubnets;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox m_guiRegionEndpoints;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ListView m_guiS3TabLeftListView;
        private System.Windows.Forms.ListView m_guiS3TabRightListView;
        private System.Windows.Forms.ImageList m_guiS3TabSmallImageList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripButton m_guiS3TabLeftCopyToRight;
        private System.Windows.Forms.ToolStripButton m_guiS3TabRightCopyToLeft;
        private System.Windows.Forms.StatusStrip m_guiS3TabLeftStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel m_guiS3TabLeftStatusLabel;
        private System.Windows.Forms.StatusStrip m_guiS3TabRightStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel m_guiS3TabRightStatusLabel;
        private System.Windows.Forms.ToolStripButton m_guiS3TabLeftRefresh;
        private System.Windows.Forms.ToolStripButton m_guiS3TabLeftDelete;
        private System.Windows.Forms.ToolStripButton m_guiS3TabRightRefresh;
        private System.Windows.Forms.ToolStripButton m_guiS3TabRightDelete;
        private System.Windows.Forms.ToolStripButton m_guiS3TabOpenTransferQueue;
        private System.Windows.Forms.ToolStripButton m_guiS3TabLeftAddFolder;
        private System.Windows.Forms.ToolStripButton m_guiS3TabRightAddBucket;
        private System.Windows.Forms.ToolStripButton m_guiS3TabRightAddFolder;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TabPage m_guiTabAS;
        private System.Windows.Forms.TabControl m_guiTabASMain;
        private System.Windows.Forms.TabPage m_guiTabASLaunchConfiguration;
        private System.Windows.Forms.TabPage m_guiTabASGroup;
        private System.Windows.Forms.TabPage m_guiTabASPolicy;
        private System.Windows.Forms.TabPage m_guiTabASInstance;
        private System.Windows.Forms.DataGridView m_guiASLaunchConfigurationGrid;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripButton m_guiASRefreshLaunchConfiguration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TabPage m_guiTabASAlarm;
        private System.Windows.Forms.TabPage m_guiTabASSchedule;
        private System.Windows.Forms.ToolStripButton m_guiASAddLaunchConfiguration;
        private System.Windows.Forms.ToolStripButton m_guiASDeleteLaunchConfiguration;
        private System.Windows.Forms.DataGridView m_guiASGroupGrid;
        private System.Windows.Forms.ToolStrip toolStrip9;
        private System.Windows.Forms.ToolStripButton m_guiASRefreshGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton m_guiASAddGroup;
        private System.Windows.Forms.ToolStripButton m_guiASEditGroup;
        private System.Windows.Forms.ToolStripButton m_guiASDeleteGroup;
        private System.Windows.Forms.DataGridView m_guiASPolicyGrid;
        private System.Windows.Forms.ToolStrip toolStrip10;
        private System.Windows.Forms.ToolStripButton m_guiASRefreshPolicy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton m_guiASAddPolicy;
        private System.Windows.Forms.ToolStripButton m_guiASEditPolicy;
        private System.Windows.Forms.ToolStripButton m_guiASDeletePolicy;
        private System.Windows.Forms.DataGridView m_guiASAlarmGrid;
        private System.Windows.Forms.ToolStrip toolStrip11;
        private System.Windows.Forms.ToolStripButton m_guiASRefreshAlarm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton m_guiASAddAlarm;
        private System.Windows.Forms.ToolStripButton m_guiASEditAlarm;
        private System.Windows.Forms.ToolStripButton m_guiASDeleteAlarm;
        private System.Windows.Forms.DataGridView m_guiASScheduleGrid;
        private System.Windows.Forms.ToolStrip toolStrip12;
        private System.Windows.Forms.ToolStripButton m_guiASRefreshSchedule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton m_guiASAddSchedule;
        private System.Windows.Forms.ToolStripButton m_guiASEditSchedule;
        private System.Windows.Forms.ToolStripButton m_guiASDeleteSchedule;
        private System.Windows.Forms.DataGridView m_guiASInstanceGrid;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton m_guiASRefreshInstance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton m_guiASTerminateInstance;
        private System.Windows.Forms.TabPage m_guiTabASActivity;
        private System.Windows.Forms.DataGridView m_guiASActivityGrid;
        private System.Windows.Forms.ToolStrip toolStrip13;
        private System.Windows.Forms.ToolStripButton m_guiASRefreshActivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASActivityGridStatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASActivityGridProgressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASLaunchConfigurationGridLaunchConfigurationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASLaunchConfigurationGridImageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASLaunchConfigurationGridKeyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASLaunchConfigurationGridInstanceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASLaunchConfigurationGridCreatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASLaunchConfigurationGridInstanceMonitoring;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASLaunchConfigurationGridEbsOptimized;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASPolicyGridScalingPolicyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASPolicyGridScalingGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASPolicyGridAdjustmentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASPolicyGridScalingAdjustment;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASPolicyGridCooldown;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASScheduleGridScheduleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASScheduleGridGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASScheduleGridStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASScheduleGridEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASScheduleGridRecurrence;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASScheduleGridMinSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASScheduleGridMaxSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASScheduleGridDesiredCapacity;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton m_guiASSuspendGroup;
        private System.Windows.Forms.ToolStripButton m_guiASResumeGroup;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceConnectUsingPublicIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridAutoScalingGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridCreatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridLaunchConfigurationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridMinSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridMaxSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridDesiredCapacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridVPCAvailabilityZones;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridVPCZoneIdentifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridLoadBalancerNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridDefaultCooldown;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridHealthCheckGracePeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASGroupGridHealthCheckType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton m_guiASViewAlarmHistories;
        private System.Windows.Forms.TabPage m_guiTabGlacier;
        private System.Windows.Forms.TabControl m_guiTabGlacierMain;
        private System.Windows.Forms.TabPage m_guiTabGlacierJob;
        private System.Windows.Forms.TabPage m_guiTabGlacierVault;
        private System.Windows.Forms.DataGridView m_guiGlacierVaultGrid;
        private System.Windows.Forms.ToolStrip toolStrip14;
        private System.Windows.Forms.ToolStripButton m_guiGlacierVaultRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton m_guiGlacierVaultAddNew;
        private System.Windows.Forms.ToolStripButton m_guiGlacierVaultEdit;
        private System.Windows.Forms.ToolStripButton m_guiGlacierVaultDelete;
        private System.Windows.Forms.TabPage m_guiTabGlacierInventory;
        private System.Windows.Forms.DataGridView m_guiGlacierJobGrid;
        private System.Windows.Forms.ToolStrip toolStrip15;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.DataGridView m_guiGlacierInventoryGrid;
        private System.Windows.Forms.ToolStrip toolStrip16;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridAlarmName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_guiASAlarmGridActionsEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridNamespace;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridMetricName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridStatistic;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridEvaluationPeriods;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridStateReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridStateReasonData;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridStateValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_guiASAlarmGridStateUpdated;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceAddEditTags;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceCreateImage;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceChangeSecurityGroup;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceChangeSourceDestCheck;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2InstanceChangeTerminationProtection;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2UpdateSoftwareAllInstances;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2UpdateSoftwareSelectedInstances;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2UpdateSoftwareMembersInstances;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2UpdateSoftwareSearchInstances;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2UpdateSoftwareWwwInstances;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem m_guiEC2ScheduledOnOffTask;
    }
}

