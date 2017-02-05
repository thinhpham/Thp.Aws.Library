namespace AwsController {
    partial class AwsControllerQueueForm {
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
            this.m_guiListView = new System.Windows.Forms.ListView();
            this.m_guiAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_guiSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_guiDestination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_guiStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_guiProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_guiClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_guiListView
            // 
            this.m_guiListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_guiAction,
            this.m_guiSource,
            this.m_guiDestination,
            this.m_guiStatus,
            this.m_guiProgress});
            this.m_guiListView.Location = new System.Drawing.Point(12, 12);
            this.m_guiListView.Name = "m_guiListView";
            this.m_guiListView.Size = new System.Drawing.Size(768, 287);
            this.m_guiListView.TabIndex = 0;
            this.m_guiListView.UseCompatibleStateImageBehavior = false;
            this.m_guiListView.View = System.Windows.Forms.View.Details;
            // 
            // m_guiAction
            // 
            this.m_guiAction.Text = "Action";
            // 
            // m_guiSource
            // 
            this.m_guiSource.Text = "Source";
            this.m_guiSource.Width = 200;
            // 
            // m_guiDestination
            // 
            this.m_guiDestination.Text = "Destination";
            this.m_guiDestination.Width = 200;
            // 
            // m_guiStatus
            // 
            this.m_guiStatus.Text = "Status";
            // 
            // m_guiProgress
            // 
            this.m_guiProgress.Text = "Progress";
            this.m_guiProgress.Width = 220;
            // 
            // m_guiClose
            // 
            this.m_guiClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_guiClose.Location = new System.Drawing.Point(705, 311);
            this.m_guiClose.Name = "m_guiClose";
            this.m_guiClose.Size = new System.Drawing.Size(75, 23);
            this.m_guiClose.TabIndex = 1;
            this.m_guiClose.Text = "Close";
            this.m_guiClose.UseVisualStyleBackColor = true;
            this.m_guiClose.Click += new System.EventHandler(this.m_guiClose_Click);
            // 
            // AwsControllerQueueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_guiClose;
            this.ClientSize = new System.Drawing.Size(792, 346);
            this.ControlBox = false;
            this.Controls.Add(this.m_guiClose);
            this.Controls.Add(this.m_guiListView);
            this.Name = "AwsControllerQueueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Queue";
            this.Load += new System.EventHandler(this.AwsControllerQueueForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView m_guiListView;
        private System.Windows.Forms.Button m_guiClose;
        private System.Windows.Forms.ColumnHeader m_guiSource;
        private System.Windows.Forms.ColumnHeader m_guiAction;
        private System.Windows.Forms.ColumnHeader m_guiProgress;
        private System.Windows.Forms.ColumnHeader m_guiDestination;
        private System.Windows.Forms.ColumnHeader m_guiStatus;
    }
}