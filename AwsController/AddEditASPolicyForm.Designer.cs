namespace AwsController {
    partial class AddEditASPolicyForm {
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
            this.m_guiCancel = new System.Windows.Forms.Button();
            this.m_guiOK = new System.Windows.Forms.Button();
            this.m_guiName = new System.Windows.Forms.TextBox();
            this.m_guiAutoScalingGroup = new System.Windows.Forms.ComboBox();
            this.m_guiAdjustmentType = new System.Windows.Forms.ComboBox();
            this.m_guiCooldown = new System.Windows.Forms.TextBox();
            this.m_guiScalingAdjustment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Group:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Adjustment Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Scaling Adjustment (by type):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cooldown (in seconds):";
            // 
            // m_guiCancel
            // 
            this.m_guiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_guiCancel.Location = new System.Drawing.Point(537, 413);
            this.m_guiCancel.Name = "m_guiCancel";
            this.m_guiCancel.Size = new System.Drawing.Size(75, 23);
            this.m_guiCancel.TabIndex = 14;
            this.m_guiCancel.Text = "&Cancel";
            this.m_guiCancel.UseVisualStyleBackColor = true;
            this.m_guiCancel.Click += new System.EventHandler(this.m_guiCancel_Click);
            // 
            // m_guiOK
            // 
            this.m_guiOK.Location = new System.Drawing.Point(448, 413);
            this.m_guiOK.Name = "m_guiOK";
            this.m_guiOK.Size = new System.Drawing.Size(75, 23);
            this.m_guiOK.TabIndex = 13;
            this.m_guiOK.Text = "&OK";
            this.m_guiOK.UseVisualStyleBackColor = true;
            this.m_guiOK.Click += new System.EventHandler(this.m_guiOK_Click);
            // 
            // m_guiName
            // 
            this.m_guiName.Location = new System.Drawing.Point(179, 14);
            this.m_guiName.Name = "m_guiName";
            this.m_guiName.Size = new System.Drawing.Size(279, 20);
            this.m_guiName.TabIndex = 15;
            // 
            // m_guiAutoScalingGroup
            // 
            this.m_guiAutoScalingGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiAutoScalingGroup.FormattingEnabled = true;
            this.m_guiAutoScalingGroup.Location = new System.Drawing.Point(179, 44);
            this.m_guiAutoScalingGroup.Name = "m_guiAutoScalingGroup";
            this.m_guiAutoScalingGroup.Size = new System.Drawing.Size(279, 21);
            this.m_guiAutoScalingGroup.TabIndex = 16;
            // 
            // m_guiAdjustmentType
            // 
            this.m_guiAdjustmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiAdjustmentType.FormattingEnabled = true;
            this.m_guiAdjustmentType.Location = new System.Drawing.Point(179, 76);
            this.m_guiAdjustmentType.Name = "m_guiAdjustmentType";
            this.m_guiAdjustmentType.Size = new System.Drawing.Size(279, 21);
            this.m_guiAdjustmentType.TabIndex = 17;
            // 
            // m_guiCooldown
            // 
            this.m_guiCooldown.Location = new System.Drawing.Point(179, 141);
            this.m_guiCooldown.Name = "m_guiCooldown";
            this.m_guiCooldown.Size = new System.Drawing.Size(100, 20);
            this.m_guiCooldown.TabIndex = 19;
            // 
            // m_guiScalingAdjustment
            // 
            this.m_guiScalingAdjustment.Location = new System.Drawing.Point(179, 109);
            this.m_guiScalingAdjustment.Name = "m_guiScalingAdjustment";
            this.m_guiScalingAdjustment.Size = new System.Drawing.Size(100, 20);
            this.m_guiScalingAdjustment.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(472, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Example: 1 or -1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(472, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Example: 180";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(472, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Example: ChangeInCapacity";
            // 
            // AddEditASPolicyForm
            // 
            this.AcceptButton = this.m_guiOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_guiCancel;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_guiCooldown);
            this.Controls.Add(this.m_guiScalingAdjustment);
            this.Controls.Add(this.m_guiAdjustmentType);
            this.Controls.Add(this.m_guiAutoScalingGroup);
            this.Controls.Add(this.m_guiName);
            this.Controls.Add(this.m_guiCancel);
            this.Controls.Add(this.m_guiOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditASPolicyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Policy";
            this.Load += new System.EventHandler(this.AddEditASPolicy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_guiCancel;
        private System.Windows.Forms.Button m_guiOK;
        private System.Windows.Forms.TextBox m_guiName;
        private System.Windows.Forms.ComboBox m_guiAutoScalingGroup;
        private System.Windows.Forms.ComboBox m_guiAdjustmentType;
        private System.Windows.Forms.TextBox m_guiCooldown;
        private System.Windows.Forms.TextBox m_guiScalingAdjustment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}