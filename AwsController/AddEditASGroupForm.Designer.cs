namespace AwsController {
    partial class AddEditASGroupForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_guiCancel = new System.Windows.Forms.Button();
            this.m_guiOK = new System.Windows.Forms.Button();
            this.m_guiName = new System.Windows.Forms.TextBox();
            this.m_guiLaunchConfiguration = new System.Windows.Forms.ComboBox();
            this.m_guiMinSize = new System.Windows.Forms.TextBox();
            this.m_guiMaxSize = new System.Windows.Forms.TextBox();
            this.m_guiDesiredCapacity = new System.Windows.Forms.TextBox();
            this.m_guiDefaultCooldown = new System.Windows.Forms.TextBox();
            this.m_guiHealthCheckGracePeriod = new System.Windows.Forms.TextBox();
            this.m_guiHealthCheckType = new System.Windows.Forms.ComboBox();
            this.m_guiAvailabilityZones = new System.Windows.Forms.ListBox();
            this.m_guiLoadBalancerNames = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_guiVPCZoneIdentifier = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Launch Configuration:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Min Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Desired Capacity:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Default Cool Down:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Health Check Grace Period:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(364, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Health Check Type:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Availability Zones:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 336);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Load Balancer Names:";
            // 
            // m_guiCancel
            // 
            this.m_guiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_guiCancel.Location = new System.Drawing.Point(539, 414);
            this.m_guiCancel.Name = "m_guiCancel";
            this.m_guiCancel.Size = new System.Drawing.Size(75, 23);
            this.m_guiCancel.TabIndex = 25;
            this.m_guiCancel.Text = "&Cancel";
            this.m_guiCancel.UseVisualStyleBackColor = true;
            this.m_guiCancel.Click += new System.EventHandler(this.m_guiCancel_Click);
            // 
            // m_guiOK
            // 
            this.m_guiOK.Location = new System.Drawing.Point(450, 414);
            this.m_guiOK.Name = "m_guiOK";
            this.m_guiOK.Size = new System.Drawing.Size(75, 23);
            this.m_guiOK.TabIndex = 24;
            this.m_guiOK.Text = "&OK";
            this.m_guiOK.UseVisualStyleBackColor = true;
            this.m_guiOK.Click += new System.EventHandler(this.m_guiOK_Click);
            // 
            // m_guiName
            // 
            this.m_guiName.Location = new System.Drawing.Point(163, 13);
            this.m_guiName.Name = "m_guiName";
            this.m_guiName.Size = new System.Drawing.Size(451, 20);
            this.m_guiName.TabIndex = 0;
            // 
            // m_guiLaunchConfiguration
            // 
            this.m_guiLaunchConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiLaunchConfiguration.FormattingEnabled = true;
            this.m_guiLaunchConfiguration.Location = new System.Drawing.Point(163, 42);
            this.m_guiLaunchConfiguration.Name = "m_guiLaunchConfiguration";
            this.m_guiLaunchConfiguration.Size = new System.Drawing.Size(451, 21);
            this.m_guiLaunchConfiguration.TabIndex = 1;
            // 
            // m_guiMinSize
            // 
            this.m_guiMinSize.Location = new System.Drawing.Point(163, 74);
            this.m_guiMinSize.Name = "m_guiMinSize";
            this.m_guiMinSize.Size = new System.Drawing.Size(140, 20);
            this.m_guiMinSize.TabIndex = 15;
            // 
            // m_guiMaxSize
            // 
            this.m_guiMaxSize.Location = new System.Drawing.Point(163, 107);
            this.m_guiMaxSize.Name = "m_guiMaxSize";
            this.m_guiMaxSize.Size = new System.Drawing.Size(140, 20);
            this.m_guiMaxSize.TabIndex = 17;
            // 
            // m_guiDesiredCapacity
            // 
            this.m_guiDesiredCapacity.Location = new System.Drawing.Point(474, 74);
            this.m_guiDesiredCapacity.Name = "m_guiDesiredCapacity";
            this.m_guiDesiredCapacity.Size = new System.Drawing.Size(140, 20);
            this.m_guiDesiredCapacity.TabIndex = 16;
            // 
            // m_guiDefaultCooldown
            // 
            this.m_guiDefaultCooldown.Location = new System.Drawing.Point(474, 106);
            this.m_guiDefaultCooldown.Name = "m_guiDefaultCooldown";
            this.m_guiDefaultCooldown.Size = new System.Drawing.Size(140, 20);
            this.m_guiDefaultCooldown.TabIndex = 18;
            // 
            // m_guiHealthCheckGracePeriod
            // 
            this.m_guiHealthCheckGracePeriod.Location = new System.Drawing.Point(163, 139);
            this.m_guiHealthCheckGracePeriod.Name = "m_guiHealthCheckGracePeriod";
            this.m_guiHealthCheckGracePeriod.Size = new System.Drawing.Size(140, 20);
            this.m_guiHealthCheckGracePeriod.TabIndex = 19;
            // 
            // m_guiHealthCheckType
            // 
            this.m_guiHealthCheckType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiHealthCheckType.FormattingEnabled = true;
            this.m_guiHealthCheckType.Location = new System.Drawing.Point(474, 139);
            this.m_guiHealthCheckType.Name = "m_guiHealthCheckType";
            this.m_guiHealthCheckType.Size = new System.Drawing.Size(140, 21);
            this.m_guiHealthCheckType.TabIndex = 20;
            // 
            // m_guiAvailabilityZones
            // 
            this.m_guiAvailabilityZones.FormattingEnabled = true;
            this.m_guiAvailabilityZones.Location = new System.Drawing.Point(163, 171);
            this.m_guiAvailabilityZones.Name = "m_guiAvailabilityZones";
            this.m_guiAvailabilityZones.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.m_guiAvailabilityZones.Size = new System.Drawing.Size(451, 69);
            this.m_guiAvailabilityZones.TabIndex = 22;
            // 
            // m_guiLoadBalancerNames
            // 
            this.m_guiLoadBalancerNames.FormattingEnabled = true;
            this.m_guiLoadBalancerNames.Location = new System.Drawing.Point(163, 334);
            this.m_guiLoadBalancerNames.Name = "m_guiLoadBalancerNames";
            this.m_guiLoadBalancerNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.m_guiLoadBalancerNames.Size = new System.Drawing.Size(451, 69);
            this.m_guiLoadBalancerNames.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Subnets:";
            // 
            // m_guiVPCZoneIdentifier
            // 
            this.m_guiVPCZoneIdentifier.FormattingEnabled = true;
            this.m_guiVPCZoneIdentifier.Location = new System.Drawing.Point(163, 252);
            this.m_guiVPCZoneIdentifier.Name = "m_guiVPCZoneIdentifier";
            this.m_guiVPCZoneIdentifier.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.m_guiVPCZoneIdentifier.Size = new System.Drawing.Size(451, 69);
            this.m_guiVPCZoneIdentifier.TabIndex = 28;
            // 
            // AddEditASGroupForm
            // 
            this.AcceptButton = this.m_guiOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_guiCancel;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.m_guiVPCZoneIdentifier);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_guiLoadBalancerNames);
            this.Controls.Add(this.m_guiAvailabilityZones);
            this.Controls.Add(this.m_guiHealthCheckType);
            this.Controls.Add(this.m_guiHealthCheckGracePeriod);
            this.Controls.Add(this.m_guiDefaultCooldown);
            this.Controls.Add(this.m_guiDesiredCapacity);
            this.Controls.Add(this.m_guiMaxSize);
            this.Controls.Add(this.m_guiMinSize);
            this.Controls.Add(this.m_guiLaunchConfiguration);
            this.Controls.Add(this.m_guiName);
            this.Controls.Add(this.m_guiCancel);
            this.Controls.Add(this.m_guiOK);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditASGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Auto Scaling Group";
            this.Load += new System.EventHandler(this.AddEditASGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button m_guiCancel;
        private System.Windows.Forms.Button m_guiOK;
        private System.Windows.Forms.TextBox m_guiName;
        private System.Windows.Forms.ComboBox m_guiLaunchConfiguration;
        private System.Windows.Forms.TextBox m_guiMinSize;
        private System.Windows.Forms.TextBox m_guiMaxSize;
        private System.Windows.Forms.TextBox m_guiDesiredCapacity;
        private System.Windows.Forms.TextBox m_guiDefaultCooldown;
        private System.Windows.Forms.TextBox m_guiHealthCheckGracePeriod;
        private System.Windows.Forms.ComboBox m_guiHealthCheckType;
        private System.Windows.Forms.ListBox m_guiAvailabilityZones;
        private System.Windows.Forms.ListBox m_guiLoadBalancerNames;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox m_guiVPCZoneIdentifier;
    }
}