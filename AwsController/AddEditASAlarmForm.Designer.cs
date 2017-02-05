namespace AwsController {
    partial class AddEditASAlarmForm {
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
            this.m_guiPeriod = new System.Windows.Forms.TextBox();
            this.m_guiThreshold = new System.Windows.Forms.TextBox();
            this.m_guiStatistic = new System.Windows.Forms.ComboBox();
            this.m_guiMetric = new System.Windows.Forms.ComboBox();
            this.m_guiName = new System.Windows.Forms.TextBox();
            this.m_guiCancel = new System.Windows.Forms.Button();
            this.m_guiOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_guiComparision = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_guiEvaluationPeriod = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_guiAlarmAction = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_guiDimension = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_guiAddDimension = new System.Windows.Forms.Button();
            this.m_guiEditDimension = new System.Windows.Forms.Button();
            this.m_guiDeleteDimension = new System.Windows.Forms.Button();
            this.m_guiSampleMetric = new System.Windows.Forms.Label();
            this.m_guiSampleStatistic = new System.Windows.Forms.Label();
            this.m_guiSampleComparision = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.m_guiActionsEnabled = new System.Windows.Forms.CheckBox();
            this.m_guiNamespace = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // m_guiPeriod
            // 
            this.m_guiPeriod.Location = new System.Drawing.Point(123, 216);
            this.m_guiPeriod.Name = "m_guiPeriod";
            this.m_guiPeriod.Size = new System.Drawing.Size(100, 20);
            this.m_guiPeriod.TabIndex = 6;
            // 
            // m_guiThreshold
            // 
            this.m_guiThreshold.Location = new System.Drawing.Point(123, 183);
            this.m_guiThreshold.Name = "m_guiThreshold";
            this.m_guiThreshold.Size = new System.Drawing.Size(100, 20);
            this.m_guiThreshold.TabIndex = 5;
            // 
            // m_guiStatistic
            // 
            this.m_guiStatistic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiStatistic.FormattingEnabled = true;
            this.m_guiStatistic.Location = new System.Drawing.Point(123, 115);
            this.m_guiStatistic.Name = "m_guiStatistic";
            this.m_guiStatistic.Size = new System.Drawing.Size(298, 21);
            this.m_guiStatistic.TabIndex = 3;
            // 
            // m_guiMetric
            // 
            this.m_guiMetric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiMetric.FormattingEnabled = true;
            this.m_guiMetric.Location = new System.Drawing.Point(123, 81);
            this.m_guiMetric.Name = "m_guiMetric";
            this.m_guiMetric.Size = new System.Drawing.Size(298, 21);
            this.m_guiMetric.TabIndex = 2;
            // 
            // m_guiName
            // 
            this.m_guiName.Location = new System.Drawing.Point(123, 15);
            this.m_guiName.Name = "m_guiName";
            this.m_guiName.Size = new System.Drawing.Size(298, 20);
            this.m_guiName.TabIndex = 0;
            // 
            // m_guiCancel
            // 
            this.m_guiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_guiCancel.Location = new System.Drawing.Point(540, 414);
            this.m_guiCancel.Name = "m_guiCancel";
            this.m_guiCancel.Size = new System.Drawing.Size(75, 23);
            this.m_guiCancel.TabIndex = 14;
            this.m_guiCancel.Text = "&Cancel";
            this.m_guiCancel.UseVisualStyleBackColor = true;
            this.m_guiCancel.Click += new System.EventHandler(this.m_guiCancel_Click);
            // 
            // m_guiOK
            // 
            this.m_guiOK.Location = new System.Drawing.Point(451, 414);
            this.m_guiOK.Name = "m_guiOK";
            this.m_guiOK.Size = new System.Drawing.Size(75, 23);
            this.m_guiOK.TabIndex = 13;
            this.m_guiOK.Text = "&OK";
            this.m_guiOK.UseVisualStyleBackColor = true;
            this.m_guiOK.Click += new System.EventHandler(this.m_guiOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Period (seconds):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Threshold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Statistic:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Metric:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Namespace:";
            // 
            // m_guiComparision
            // 
            this.m_guiComparision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiComparision.FormattingEnabled = true;
            this.m_guiComparision.Location = new System.Drawing.Point(123, 149);
            this.m_guiComparision.Name = "m_guiComparision";
            this.m_guiComparision.Size = new System.Drawing.Size(298, 21);
            this.m_guiComparision.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Comparision:";
            // 
            // m_guiEvaluationPeriod
            // 
            this.m_guiEvaluationPeriod.Location = new System.Drawing.Point(123, 249);
            this.m_guiEvaluationPeriod.Name = "m_guiEvaluationPeriod";
            this.m_guiEvaluationPeriod.Size = new System.Drawing.Size(100, 20);
            this.m_guiEvaluationPeriod.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Evaluation Period:";
            // 
            // m_guiAlarmAction
            // 
            this.m_guiAlarmAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiAlarmAction.FormattingEnabled = true;
            this.m_guiAlarmAction.Location = new System.Drawing.Point(123, 282);
            this.m_guiAlarmAction.Name = "m_guiAlarmAction";
            this.m_guiAlarmAction.Size = new System.Drawing.Size(298, 21);
            this.m_guiAlarmAction.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Alarm Actions:";
            // 
            // m_guiDimension
            // 
            this.m_guiDimension.FormattingEnabled = true;
            this.m_guiDimension.Location = new System.Drawing.Point(123, 316);
            this.m_guiDimension.Name = "m_guiDimension";
            this.m_guiDimension.Size = new System.Drawing.Size(298, 43);
            this.m_guiDimension.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 316);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Alarm Dimensions:";
            // 
            // m_guiAddDimension
            // 
            this.m_guiAddDimension.Location = new System.Drawing.Point(184, 367);
            this.m_guiAddDimension.Name = "m_guiAddDimension";
            this.m_guiAddDimension.Size = new System.Drawing.Size(75, 23);
            this.m_guiAddDimension.TabIndex = 10;
            this.m_guiAddDimension.Text = "Add...";
            this.m_guiAddDimension.UseVisualStyleBackColor = true;
            this.m_guiAddDimension.Click += new System.EventHandler(this.m_guiAddDimension_Click);
            // 
            // m_guiEditDimension
            // 
            this.m_guiEditDimension.Location = new System.Drawing.Point(265, 367);
            this.m_guiEditDimension.Name = "m_guiEditDimension";
            this.m_guiEditDimension.Size = new System.Drawing.Size(75, 23);
            this.m_guiEditDimension.TabIndex = 11;
            this.m_guiEditDimension.Text = "Edit...";
            this.m_guiEditDimension.UseVisualStyleBackColor = true;
            this.m_guiEditDimension.Click += new System.EventHandler(this.m_guiEditDimension_Click);
            // 
            // m_guiDeleteDimension
            // 
            this.m_guiDeleteDimension.Location = new System.Drawing.Point(346, 367);
            this.m_guiDeleteDimension.Name = "m_guiDeleteDimension";
            this.m_guiDeleteDimension.Size = new System.Drawing.Size(75, 23);
            this.m_guiDeleteDimension.TabIndex = 12;
            this.m_guiDeleteDimension.Text = "Delete";
            this.m_guiDeleteDimension.UseVisualStyleBackColor = true;
            this.m_guiDeleteDimension.Click += new System.EventHandler(this.m_guiDeleteDimension_Click);
            // 
            // m_guiSampleMetric
            // 
            this.m_guiSampleMetric.AutoSize = true;
            this.m_guiSampleMetric.Location = new System.Drawing.Point(435, 85);
            this.m_guiSampleMetric.Name = "m_guiSampleMetric";
            this.m_guiSampleMetric.Size = new System.Drawing.Size(120, 13);
            this.m_guiSampleMetric.TabIndex = 45;
            this.m_guiSampleMetric.Text = "Example: CPUUtilization";
            // 
            // m_guiSampleStatistic
            // 
            this.m_guiSampleStatistic.AutoSize = true;
            this.m_guiSampleStatistic.Location = new System.Drawing.Point(435, 118);
            this.m_guiSampleStatistic.Name = "m_guiSampleStatistic";
            this.m_guiSampleStatistic.Size = new System.Drawing.Size(93, 13);
            this.m_guiSampleStatistic.TabIndex = 46;
            this.m_guiSampleStatistic.Text = "Example: Average";
            // 
            // m_guiSampleComparision
            // 
            this.m_guiSampleComparision.AutoSize = true;
            this.m_guiSampleComparision.Location = new System.Drawing.Point(435, 153);
            this.m_guiSampleComparision.Name = "m_guiSampleComparision";
            this.m_guiSampleComparision.Size = new System.Drawing.Size(160, 13);
            this.m_guiSampleComparision.TabIndex = 47;
            this.m_guiSampleComparision.Text = "Example: GreaterThanThreshold";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(435, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Example: 70";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(435, 219);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "Example: 60";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(435, 252);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Example: 2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(435, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 13);
            this.label14.TabIndex = 51;
            this.label14.Text = "Example: AWS/EC2";
            // 
            // m_guiActionsEnabled
            // 
            this.m_guiActionsEnabled.AutoSize = true;
            this.m_guiActionsEnabled.Location = new System.Drawing.Point(438, 17);
            this.m_guiActionsEnabled.Name = "m_guiActionsEnabled";
            this.m_guiActionsEnabled.Size = new System.Drawing.Size(103, 17);
            this.m_guiActionsEnabled.TabIndex = 52;
            this.m_guiActionsEnabled.Text = "Actions Enabled";
            this.m_guiActionsEnabled.UseVisualStyleBackColor = true;
            // 
            // m_guiNamespace
            // 
            this.m_guiNamespace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiNamespace.FormattingEnabled = true;
            this.m_guiNamespace.Location = new System.Drawing.Point(123, 47);
            this.m_guiNamespace.Name = "m_guiNamespace";
            this.m_guiNamespace.Size = new System.Drawing.Size(298, 21);
            this.m_guiNamespace.TabIndex = 1;
            // 
            // AddEditASAlarmForm
            // 
            this.AcceptButton = this.m_guiOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_guiCancel;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.m_guiNamespace);
            this.Controls.Add(this.m_guiActionsEnabled);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.m_guiSampleComparision);
            this.Controls.Add(this.m_guiSampleStatistic);
            this.Controls.Add(this.m_guiSampleMetric);
            this.Controls.Add(this.m_guiDeleteDimension);
            this.Controls.Add(this.m_guiEditDimension);
            this.Controls.Add(this.m_guiAddDimension);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.m_guiDimension);
            this.Controls.Add(this.m_guiAlarmAction);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_guiEvaluationPeriod);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_guiComparision);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_guiPeriod);
            this.Controls.Add(this.m_guiThreshold);
            this.Controls.Add(this.m_guiStatistic);
            this.Controls.Add(this.m_guiMetric);
            this.Controls.Add(this.m_guiName);
            this.Controls.Add(this.m_guiCancel);
            this.Controls.Add(this.m_guiOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditASAlarmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Alarm";
            this.Load += new System.EventHandler(this.AddEditASAlarm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_guiPeriod;
        private System.Windows.Forms.TextBox m_guiThreshold;
        private System.Windows.Forms.ComboBox m_guiStatistic;
        private System.Windows.Forms.ComboBox m_guiMetric;
        private System.Windows.Forms.TextBox m_guiName;
        private System.Windows.Forms.Button m_guiCancel;
        private System.Windows.Forms.Button m_guiOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox m_guiComparision;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_guiEvaluationPeriod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox m_guiAlarmAction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox m_guiDimension;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button m_guiAddDimension;
        private System.Windows.Forms.Button m_guiEditDimension;
        private System.Windows.Forms.Button m_guiDeleteDimension;
        private System.Windows.Forms.Label m_guiSampleMetric;
        private System.Windows.Forms.Label m_guiSampleStatistic;
        private System.Windows.Forms.Label m_guiSampleComparision;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox m_guiActionsEnabled;
        private System.Windows.Forms.ComboBox m_guiNamespace;
    }
}