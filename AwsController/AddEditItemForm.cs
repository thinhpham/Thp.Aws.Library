using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AwsController {
    public partial class AddEditItemForm : Form {
        public string ItemName { get; set; }
        public string ItemToAddEditName { get; set; }

        public AddEditItemForm() {
            InitializeComponent();
        }

        private void AddEditBucketForm_Load(object sender, EventArgs e) {
            Text = "Add/Edit " + ItemToAddEditName;
            m_guiItemLabel.Text = ItemToAddEditName + " name:";
        }

        private void m_guiOK_Click(object sender, EventArgs e) {
            if (m_guiItemText.Text.Length > 0) {
                ItemName = m_guiItemText.Text.Trim();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            } else {
                MessageBox.Show(ItemToAddEditName + " name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_guiCancel_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
