namespace AwsController {
    partial class AddEditASAlarmDimensionForm {
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
            this.m_guiCancel = new System.Windows.Forms.Button();
            this.m_guiOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_guiName = new System.Windows.Forms.ComboBox();
            this.m_guiValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // m_guiCancel
            // 
            this.m_guiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_guiCancel.Location = new System.Drawing.Point(308, 229);
            this.m_guiCancel.Name = "m_guiCancel";
            this.m_guiCancel.Size = new System.Drawing.Size(75, 23);
            this.m_guiCancel.TabIndex = 16;
            this.m_guiCancel.Text = "&Cancel";
            this.m_guiCancel.UseVisualStyleBackColor = true;
            this.m_guiCancel.Click += new System.EventHandler(this.m_guiCancel_Click);
            // 
            // m_guiOK
            // 
            this.m_guiOK.Location = new System.Drawing.Point(219, 229);
            this.m_guiOK.Name = "m_guiOK";
            this.m_guiOK.Size = new System.Drawing.Size(75, 23);
            this.m_guiOK.TabIndex = 15;
            this.m_guiOK.Text = "&OK";
            this.m_guiOK.UseVisualStyleBackColor = true;
            this.m_guiOK.Click += new System.EventHandler(this.m_guiOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Value:";
            // 
            // m_guiName
            // 
            this.m_guiName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiName.FormattingEnabled = true;
            this.m_guiName.Location = new System.Drawing.Point(70, 15);
            this.m_guiName.Name = "m_guiName";
            this.m_guiName.Size = new System.Drawing.Size(259, 21);
            this.m_guiName.TabIndex = 19;
            // 
            // m_guiValue
            // 
            this.m_guiValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_guiValue.FormattingEnabled = true;
            this.m_guiValue.Location = new System.Drawing.Point(70, 49);
            this.m_guiValue.Name = "m_guiValue";
            this.m_guiValue.Size = new System.Drawing.Size(259, 21);
            this.m_guiValue.TabIndex = 20;
            // 
            // AddEditASAlarmDimensionForm
            // 
            this.AcceptButton = this.m_guiOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_guiCancel;
            this.ClientSize = new System.Drawing.Size(399, 273);
            this.Controls.Add(this.m_guiValue);
            this.Controls.Add(this.m_guiName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_guiCancel);
            this.Controls.Add(this.m_guiOK);
            this.Name = "AddEditASAlarmDimensionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Alarm Dimension";
            this.Load += new System.EventHandler(this.AddEditASAlarmDimensionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_guiCancel;
        private System.Windows.Forms.Button m_guiOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_guiName;
        private System.Windows.Forms.ComboBox m_guiValue;
    }
}