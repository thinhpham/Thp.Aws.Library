namespace AwsController {
    partial class ScheduledOnOffForm {
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
            this.m_guiInstanceIdList = new System.Windows.Forms.TextBox();
            this.m_guiStartOn = new System.Windows.Forms.DateTimePicker();
            this.m_guiStopOn = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.m_guiCancel = new System.Windows.Forms.Button();
            this.m_guiOK = new System.Windows.Forms.Button();
            this.m_guiEnabled = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_guiMon = new System.Windows.Forms.CheckBox();
            this.m_guiTue = new System.Windows.Forms.CheckBox();
            this.m_guiWed = new System.Windows.Forms.CheckBox();
            this.m_guiThu = new System.Windows.Forms.CheckBox();
            this.m_guiFri = new System.Windows.Forms.CheckBox();
            this.m_guiSat = new System.Windows.Forms.CheckBox();
            this.m_guiSun = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instance Id List:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stop Time:";
            // 
            // m_guiInstanceIdList
            // 
            this.m_guiInstanceIdList.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_guiInstanceIdList.Location = new System.Drawing.Point(101, 18);
            this.m_guiInstanceIdList.Multiline = true;
            this.m_guiInstanceIdList.Name = "m_guiInstanceIdList";
            this.m_guiInstanceIdList.Size = new System.Drawing.Size(370, 92);
            this.m_guiInstanceIdList.TabIndex = 3;
            // 
            // m_guiStartOn
            // 
            this.m_guiStartOn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.m_guiStartOn.Location = new System.Drawing.Point(101, 158);
            this.m_guiStartOn.Name = "m_guiStartOn";
            this.m_guiStartOn.ShowUpDown = true;
            this.m_guiStartOn.Size = new System.Drawing.Size(158, 20);
            this.m_guiStartOn.TabIndex = 4;
            // 
            // m_guiStopOn
            // 
            this.m_guiStopOn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.m_guiStopOn.Location = new System.Drawing.Point(101, 193);
            this.m_guiStopOn.Name = "m_guiStopOn";
            this.m_guiStopOn.ShowUpDown = true;
            this.m_guiStopOn.Size = new System.Drawing.Size(158, 20);
            this.m_guiStopOn.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "(*) Comma separated values";
            // 
            // m_guiCancel
            // 
            this.m_guiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_guiCancel.Location = new System.Drawing.Point(535, 409);
            this.m_guiCancel.Name = "m_guiCancel";
            this.m_guiCancel.Size = new System.Drawing.Size(75, 23);
            this.m_guiCancel.TabIndex = 16;
            this.m_guiCancel.Text = "&Cancel";
            this.m_guiCancel.UseVisualStyleBackColor = true;
            this.m_guiCancel.Click += new System.EventHandler(this.m_guiCancel_Click);
            // 
            // m_guiOK
            // 
            this.m_guiOK.Location = new System.Drawing.Point(446, 409);
            this.m_guiOK.Name = "m_guiOK";
            this.m_guiOK.Size = new System.Drawing.Size(75, 23);
            this.m_guiOK.TabIndex = 15;
            this.m_guiOK.Text = "&OK";
            this.m_guiOK.UseVisualStyleBackColor = true;
            this.m_guiOK.Click += new System.EventHandler(this.m_guiOK_Click);
            // 
            // m_guiEnabled
            // 
            this.m_guiEnabled.AutoSize = true;
            this.m_guiEnabled.Location = new System.Drawing.Point(101, 230);
            this.m_guiEnabled.Name = "m_guiEnabled";
            this.m_guiEnabled.Size = new System.Drawing.Size(198, 17);
            this.m_guiEnabled.TabIndex = 17;
            this.m_guiEnabled.Text = "Enable task to run at scheduled time";
            this.m_guiEnabled.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Days Of Week:";
            // 
            // m_guiMon
            // 
            this.m_guiMon.AutoSize = true;
            this.m_guiMon.Location = new System.Drawing.Point(101, 126);
            this.m_guiMon.Name = "m_guiMon";
            this.m_guiMon.Size = new System.Drawing.Size(47, 17);
            this.m_guiMon.TabIndex = 19;
            this.m_guiMon.Text = "Mon";
            this.m_guiMon.UseVisualStyleBackColor = true;
            // 
            // m_guiTue
            // 
            this.m_guiTue.AutoSize = true;
            this.m_guiTue.Location = new System.Drawing.Point(161, 126);
            this.m_guiTue.Name = "m_guiTue";
            this.m_guiTue.Size = new System.Drawing.Size(45, 17);
            this.m_guiTue.TabIndex = 20;
            this.m_guiTue.Text = "Tue";
            this.m_guiTue.UseVisualStyleBackColor = true;
            // 
            // m_guiWed
            // 
            this.m_guiWed.AutoSize = true;
            this.m_guiWed.Location = new System.Drawing.Point(216, 126);
            this.m_guiWed.Name = "m_guiWed";
            this.m_guiWed.Size = new System.Drawing.Size(49, 17);
            this.m_guiWed.TabIndex = 21;
            this.m_guiWed.Text = "Wed";
            this.m_guiWed.UseVisualStyleBackColor = true;
            // 
            // m_guiThu
            // 
            this.m_guiThu.AutoSize = true;
            this.m_guiThu.Location = new System.Drawing.Point(276, 126);
            this.m_guiThu.Name = "m_guiThu";
            this.m_guiThu.Size = new System.Drawing.Size(45, 17);
            this.m_guiThu.TabIndex = 22;
            this.m_guiThu.Text = "Thu";
            this.m_guiThu.UseVisualStyleBackColor = true;
            // 
            // m_guiFri
            // 
            this.m_guiFri.AutoSize = true;
            this.m_guiFri.Location = new System.Drawing.Point(331, 126);
            this.m_guiFri.Name = "m_guiFri";
            this.m_guiFri.Size = new System.Drawing.Size(37, 17);
            this.m_guiFri.TabIndex = 23;
            this.m_guiFri.Text = "Fri";
            this.m_guiFri.UseVisualStyleBackColor = true;
            // 
            // m_guiSat
            // 
            this.m_guiSat.AutoSize = true;
            this.m_guiSat.Location = new System.Drawing.Point(379, 126);
            this.m_guiSat.Name = "m_guiSat";
            this.m_guiSat.Size = new System.Drawing.Size(42, 17);
            this.m_guiSat.TabIndex = 24;
            this.m_guiSat.Text = "Sat";
            this.m_guiSat.UseVisualStyleBackColor = true;
            // 
            // m_guiSun
            // 
            this.m_guiSun.AutoSize = true;
            this.m_guiSun.Location = new System.Drawing.Point(432, 126);
            this.m_guiSun.Name = "m_guiSun";
            this.m_guiSun.Size = new System.Drawing.Size(45, 17);
            this.m_guiSun.TabIndex = 25;
            this.m_guiSun.Text = "Sun";
            this.m_guiSun.UseVisualStyleBackColor = true;
            // 
            // ScheduledOnOffForm
            // 
            this.AcceptButton = this.m_guiOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_guiCancel;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.m_guiSun);
            this.Controls.Add(this.m_guiSat);
            this.Controls.Add(this.m_guiFri);
            this.Controls.Add(this.m_guiThu);
            this.Controls.Add(this.m_guiWed);
            this.Controls.Add(this.m_guiTue);
            this.Controls.Add(this.m_guiMon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_guiEnabled);
            this.Controls.Add(this.m_guiCancel);
            this.Controls.Add(this.m_guiOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_guiStopOn);
            this.Controls.Add(this.m_guiStartOn);
            this.Controls.Add(this.m_guiInstanceIdList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ScheduledOnOffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduled On/Off";
            this.Load += new System.EventHandler(this.ScheduledOnOffForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_guiInstanceIdList;
        private System.Windows.Forms.DateTimePicker m_guiStartOn;
        private System.Windows.Forms.DateTimePicker m_guiStopOn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_guiCancel;
        private System.Windows.Forms.Button m_guiOK;
        private System.Windows.Forms.CheckBox m_guiEnabled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox m_guiMon;
        private System.Windows.Forms.CheckBox m_guiTue;
        private System.Windows.Forms.CheckBox m_guiWed;
        private System.Windows.Forms.CheckBox m_guiThu;
        private System.Windows.Forms.CheckBox m_guiFri;
        private System.Windows.Forms.CheckBox m_guiSat;
        private System.Windows.Forms.CheckBox m_guiSun;
    }
}