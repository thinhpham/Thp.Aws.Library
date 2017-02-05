namespace AwsController {
    partial class AddEditASLaunchConfigurationForm {
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
            this.m_guiOK = new System.Windows.Forms.Button();
            this.m_guiCancel = new System.Windows.Forms.Button();
            this.m_guiName = new System.Windows.Forms.TextBox();
            this.m_guiInstanceType = new System.Windows.Forms.ComboBox();
            this.m_guiKeyName = new System.Windows.Forms.ComboBox();
            this.m_guiSecurityGroup = new System.Windows.Forms.ComboBox();
            this.m_guiImageId = new System.Windows.Forms.ComboBox();
            this.m_guiEnabledDetailMonitoring = new System.Windows.Forms.CheckBox();
            this.m_guiEbsOptimized = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Image Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Instance Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Key Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Security Group(s):";
            // 
            // m_guiOK
            // 
            this.m_guiOK.Location = new System.Drawing.Point(450, 412);
            this.m_guiOK.Name = "m_guiOK";
            this.m_guiOK.Size = new System.Drawing.Size(75, 23);
            this.m_guiOK.TabIndex = 5;
            this.m_guiOK.Text = "&OK";
            this.m_guiOK.UseVisualStyleBackColor = true;
            this.m_guiOK.Click += new System.EventHandler(this.m_guiOK_Click);
            // 
            // m_guiCancel
            // 
            this.m_guiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_guiCancel.Location = new System.Drawing.Point(539, 412);
            this.m_guiCancel.Name = "m_guiCancel";
            this.m_guiCancel.Size = new System.Drawing.Size(75, 23);
            this.m_guiCancel.TabIndex = 6;
            this.m_guiCancel.Text = "&Cancel";
            this.m_guiCancel.UseVisualStyleBackColor = true;
            this.m_guiCancel.Click += new System.EventHandler(this.m_guiCancel_Click);
            // 
            // m_guiName
            // 
            this.m_guiName.Location = new System.Drawing.Point(117, 10);
            this.m_guiName.Name = "m_guiName";
            this.m_guiName.Size = new System.Drawing.Size(300, 20);
            this.m_guiName.TabIndex = 0;
            // 
            // m_guiInstanceType
            // 
            this.m_guiInstanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiInstanceType.FormattingEnabled = true;
            this.m_guiInstanceType.Location = new System.Drawing.Point(117, 68);
            this.m_guiInstanceType.Name = "m_guiInstanceType";
            this.m_guiInstanceType.Size = new System.Drawing.Size(300, 21);
            this.m_guiInstanceType.TabIndex = 2;
            // 
            // m_guiKeyName
            // 
            this.m_guiKeyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiKeyName.FormattingEnabled = true;
            this.m_guiKeyName.Location = new System.Drawing.Point(117, 97);
            this.m_guiKeyName.Name = "m_guiKeyName";
            this.m_guiKeyName.Size = new System.Drawing.Size(300, 21);
            this.m_guiKeyName.TabIndex = 3;
            // 
            // m_guiSecurityGroup
            // 
            this.m_guiSecurityGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiSecurityGroup.FormattingEnabled = true;
            this.m_guiSecurityGroup.Location = new System.Drawing.Point(117, 126);
            this.m_guiSecurityGroup.Name = "m_guiSecurityGroup";
            this.m_guiSecurityGroup.Size = new System.Drawing.Size(300, 21);
            this.m_guiSecurityGroup.TabIndex = 4;
            // 
            // m_guiImageId
            // 
            this.m_guiImageId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiImageId.FormattingEnabled = true;
            this.m_guiImageId.Location = new System.Drawing.Point(117, 38);
            this.m_guiImageId.Name = "m_guiImageId";
            this.m_guiImageId.Size = new System.Drawing.Size(300, 21);
            this.m_guiImageId.TabIndex = 1;
            // 
            // m_guiEnabledDetailMonitoring
            // 
            this.m_guiEnabledDetailMonitoring.AutoSize = true;
            this.m_guiEnabledDetailMonitoring.Location = new System.Drawing.Point(117, 157);
            this.m_guiEnabledDetailMonitoring.Name = "m_guiEnabledDetailMonitoring";
            this.m_guiEnabledDetailMonitoring.Size = new System.Drawing.Size(138, 17);
            this.m_guiEnabledDetailMonitoring.TabIndex = 7;
            this.m_guiEnabledDetailMonitoring.Text = "Enable detail monitoring";
            this.m_guiEnabledDetailMonitoring.UseVisualStyleBackColor = true;
            // 
            // m_guiEbsOptimized
            // 
            this.m_guiEbsOptimized.AutoSize = true;
            this.m_guiEbsOptimized.Location = new System.Drawing.Point(117, 180);
            this.m_guiEbsOptimized.Name = "m_guiEbsOptimized";
            this.m_guiEbsOptimized.Size = new System.Drawing.Size(173, 17);
            this.m_guiEbsOptimized.TabIndex = 8;
            this.m_guiEbsOptimized.Text = "Enable EBS optimized instance";
            this.m_guiEbsOptimized.UseVisualStyleBackColor = true;
            // 
            // AddEditASLaunchConfiguration
            // 
            this.AcceptButton = this.m_guiOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_guiCancel;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.m_guiEbsOptimized);
            this.Controls.Add(this.m_guiEnabledDetailMonitoring);
            this.Controls.Add(this.m_guiImageId);
            this.Controls.Add(this.m_guiSecurityGroup);
            this.Controls.Add(this.m_guiKeyName);
            this.Controls.Add(this.m_guiInstanceType);
            this.Controls.Add(this.m_guiName);
            this.Controls.Add(this.m_guiCancel);
            this.Controls.Add(this.m_guiOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditASLaunchConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Launch Configuration";
            this.Load += new System.EventHandler(this.AddEditASLaunchConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_guiOK;
        private System.Windows.Forms.Button m_guiCancel;
        private System.Windows.Forms.TextBox m_guiName;
        private System.Windows.Forms.ComboBox m_guiInstanceType;
        private System.Windows.Forms.ComboBox m_guiKeyName;
        private System.Windows.Forms.ComboBox m_guiSecurityGroup;
        private System.Windows.Forms.ComboBox m_guiImageId;
        private System.Windows.Forms.CheckBox m_guiEnabledDetailMonitoring;
        private System.Windows.Forms.CheckBox m_guiEbsOptimized;
    }
}