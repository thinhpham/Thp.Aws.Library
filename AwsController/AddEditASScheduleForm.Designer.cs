namespace AwsController {
    partial class AddEditASScheduleForm {
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
            this.m_guiName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_guiAutoScalingGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_guiDesiredCapacity = new System.Windows.Forms.TextBox();
            this.m_guiMaxSize = new System.Windows.Forms.TextBox();
            this.m_guiMinSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_guiStartTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_guiEndTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_guiRecurrence = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_guiCronHelpLink = new System.Windows.Forms.LinkLabel();
            this.m_guiCancel = new System.Windows.Forms.Button();
            this.m_guiOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_guiName
            // 
            this.m_guiName.Location = new System.Drawing.Point(176, 13);
            this.m_guiName.Name = "m_guiName";
            this.m_guiName.Size = new System.Drawing.Size(300, 20);
            this.m_guiName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name:";
            // 
            // m_guiAutoScalingGroup
            // 
            this.m_guiAutoScalingGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiAutoScalingGroup.FormattingEnabled = true;
            this.m_guiAutoScalingGroup.Location = new System.Drawing.Point(176, 48);
            this.m_guiAutoScalingGroup.Name = "m_guiAutoScalingGroup";
            this.m_guiAutoScalingGroup.Size = new System.Drawing.Size(300, 21);
            this.m_guiAutoScalingGroup.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Group:";
            // 
            // m_guiDesiredCapacity
            // 
            this.m_guiDesiredCapacity.Location = new System.Drawing.Point(176, 150);
            this.m_guiDesiredCapacity.Name = "m_guiDesiredCapacity";
            this.m_guiDesiredCapacity.Size = new System.Drawing.Size(100, 20);
            this.m_guiDesiredCapacity.TabIndex = 4;
            // 
            // m_guiMaxSize
            // 
            this.m_guiMaxSize.Location = new System.Drawing.Point(176, 118);
            this.m_guiMaxSize.Name = "m_guiMaxSize";
            this.m_guiMaxSize.Size = new System.Drawing.Size(100, 20);
            this.m_guiMaxSize.TabIndex = 3;
            // 
            // m_guiMinSize
            // 
            this.m_guiMinSize.Location = new System.Drawing.Point(176, 85);
            this.m_guiMinSize.Name = "m_guiMinSize";
            this.m_guiMinSize.Size = new System.Drawing.Size(100, 20);
            this.m_guiMinSize.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Desired Capacity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Max Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Min Size:";
            // 
            // m_guiStartTime
            // 
            this.m_guiStartTime.Location = new System.Drawing.Point(176, 185);
            this.m_guiStartTime.Name = "m_guiStartTime";
            this.m_guiStartTime.Size = new System.Drawing.Size(200, 20);
            this.m_guiStartTime.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Start Datetime:";
            // 
            // m_guiEndTime
            // 
            this.m_guiEndTime.Location = new System.Drawing.Point(176, 220);
            this.m_guiEndTime.Name = "m_guiEndTime";
            this.m_guiEndTime.Size = new System.Drawing.Size(200, 20);
            this.m_guiEndTime.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "End Datetime:";
            // 
            // m_guiRecurrence
            // 
            this.m_guiRecurrence.Location = new System.Drawing.Point(176, 256);
            this.m_guiRecurrence.Name = "m_guiRecurrence";
            this.m_guiRecurrence.Size = new System.Drawing.Size(200, 20);
            this.m_guiRecurrence.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Recurrence (cron format):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(391, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "(YYYY-MM-DDThh:mm:ssZ)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(391, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "(YYYY-MM-DDThh:mm:ssZ)";
            // 
            // m_guiCronHelpLink
            // 
            this.m_guiCronHelpLink.AutoSize = true;
            this.m_guiCronHelpLink.LinkColor = System.Drawing.Color.Green;
            this.m_guiCronHelpLink.Location = new System.Drawing.Point(391, 259);
            this.m_guiCronHelpLink.Name = "m_guiCronHelpLink";
            this.m_guiCronHelpLink.Size = new System.Drawing.Size(229, 13);
            this.m_guiCronHelpLink.TabIndex = 33;
            this.m_guiCronHelpLink.TabStop = true;
            this.m_guiCronHelpLink.Text = "(Minute Hour DayOfMonth Month DayOfWeek)";
            this.m_guiCronHelpLink.VisitedLinkColor = System.Drawing.Color.Green;
            this.m_guiCronHelpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_guiCronHelpLink_LinkClicked);
            // 
            // m_guiCancel
            // 
            this.m_guiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_guiCancel.Location = new System.Drawing.Point(542, 416);
            this.m_guiCancel.Name = "m_guiCancel";
            this.m_guiCancel.Size = new System.Drawing.Size(75, 23);
            this.m_guiCancel.TabIndex = 9;
            this.m_guiCancel.Text = "&Cancel";
            this.m_guiCancel.UseVisualStyleBackColor = true;
            this.m_guiCancel.Click += new System.EventHandler(this.m_guiCancel_Click);
            // 
            // m_guiOK
            // 
            this.m_guiOK.Location = new System.Drawing.Point(453, 416);
            this.m_guiOK.Name = "m_guiOK";
            this.m_guiOK.Size = new System.Drawing.Size(75, 23);
            this.m_guiOK.TabIndex = 8;
            this.m_guiOK.Text = "&OK";
            this.m_guiOK.UseVisualStyleBackColor = true;
            this.m_guiOK.Click += new System.EventHandler(this.m_guiOK_Click);
            // 
            // AddEditASScheduleForm
            // 
            this.AcceptButton = this.m_guiOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_guiCancel;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.m_guiCancel);
            this.Controls.Add(this.m_guiOK);
            this.Controls.Add(this.m_guiCronHelpLink);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_guiRecurrence);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_guiEndTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_guiStartTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_guiDesiredCapacity);
            this.Controls.Add(this.m_guiMaxSize);
            this.Controls.Add(this.m_guiMinSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_guiAutoScalingGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_guiName);
            this.Controls.Add(this.label1);
            this.Name = "AddEditASScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Schedule";
            this.Load += new System.EventHandler(this.AddEditASScheduleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_guiName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_guiAutoScalingGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_guiDesiredCapacity;
        private System.Windows.Forms.TextBox m_guiMaxSize;
        private System.Windows.Forms.TextBox m_guiMinSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_guiStartTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_guiEndTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_guiRecurrence;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel m_guiCronHelpLink;
        private System.Windows.Forms.Button m_guiCancel;
        private System.Windows.Forms.Button m_guiOK;
    }
}