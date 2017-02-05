namespace AwsController {
    partial class AddEditItemForm {
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
            this.m_guiItemLabel = new System.Windows.Forms.Label();
            this.m_guiItemText = new System.Windows.Forms.TextBox();
            this.m_guiOK = new System.Windows.Forms.Button();
            this.m_guiCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_guiItemLabel
            // 
            this.m_guiItemLabel.AutoSize = true;
            this.m_guiItemLabel.Location = new System.Drawing.Point(8, 17);
            this.m_guiItemLabel.Name = "m_guiItemLabel";
            this.m_guiItemLabel.Size = new System.Drawing.Size(59, 13);
            this.m_guiItemLabel.TabIndex = 0;
            this.m_guiItemLabel.Text = "Item name:";
            // 
            // m_guiItemText
            // 
            this.m_guiItemText.Location = new System.Drawing.Point(106, 14);
            this.m_guiItemText.Name = "m_guiItemText";
            this.m_guiItemText.Size = new System.Drawing.Size(274, 20);
            this.m_guiItemText.TabIndex = 1;
            // 
            // m_guiOK
            // 
            this.m_guiOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_guiOK.Location = new System.Drawing.Point(215, 91);
            this.m_guiOK.Name = "m_guiOK";
            this.m_guiOK.Size = new System.Drawing.Size(75, 23);
            this.m_guiOK.TabIndex = 2;
            this.m_guiOK.Text = "&OK";
            this.m_guiOK.UseVisualStyleBackColor = true;
            this.m_guiOK.Click += new System.EventHandler(this.m_guiOK_Click);
            // 
            // m_guiCancel
            // 
            this.m_guiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_guiCancel.Location = new System.Drawing.Point(305, 91);
            this.m_guiCancel.Name = "m_guiCancel";
            this.m_guiCancel.Size = new System.Drawing.Size(75, 23);
            this.m_guiCancel.TabIndex = 3;
            this.m_guiCancel.Text = "&Cancel";
            this.m_guiCancel.UseVisualStyleBackColor = true;
            this.m_guiCancel.Click += new System.EventHandler(this.m_guiCancel_Click);
            // 
            // AddEditItemForm
            // 
            this.AcceptButton = this.m_guiOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_guiCancel;
            this.ClientSize = new System.Drawing.Size(392, 128);
            this.Controls.Add(this.m_guiCancel);
            this.Controls.Add(this.m_guiOK);
            this.Controls.Add(this.m_guiItemText);
            this.Controls.Add(this.m_guiItemLabel);
            this.Name = "AddEditItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Item";
            this.Load += new System.EventHandler(this.AddEditBucketForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_guiItemLabel;
        private System.Windows.Forms.TextBox m_guiItemText;
        private System.Windows.Forms.Button m_guiOK;
        private System.Windows.Forms.Button m_guiCancel;
    }
}