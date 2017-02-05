using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Thp.Har.Utility;
using Amazon.DynamoDB.Model;
using Amazon;
using Thp.Har.Utility.SchedulerTasks;

namespace AwsController {
    public partial class ScheduledOnOffForm : Form {
        public Amazon.RegionEndpoint SelectedRegion { get; set; }

        public ScheduledOnOffForm() {
            InitializeComponent();
        }

        private void ScheduledOnOffForm_Load(object sender, EventArgs e) {
            LoadControls();
        }

        private void LoadControls() {
            var record = AwsControllerScheduledOnOff.GetRecord(SelectedRegion);
            m_guiInstanceIdList.Text = record.InstanceIdList;
            m_guiEnabled.Checked = record.Enabled;
            m_guiStartOn.Value = record.StartOn;
            m_guiStopOn.Value = record.StopOn;

            if (!string.IsNullOrEmpty(record.DaysOfWeek)) {
                var tmp = record.DaysOfWeek.Split(',');
                m_guiSun.Checked = tmp[0].Equals("yes");
                m_guiMon.Checked = tmp[1].Equals("yes");
                m_guiTue.Checked = tmp[2].Equals("yes");
                m_guiWed.Checked = tmp[3].Equals("yes");
                m_guiThu.Checked = tmp[4].Equals("yes");
                m_guiFri.Checked = tmp[5].Equals("yes");
                m_guiSat.Checked = tmp[6].Equals("yes");
            }
        }

        private void SaveData() {
            var item = new AwsControllerScheduledOnOff();
            item.CreatedBy = Environment.UserName;
            item.CreatedOn = DateTime.Now;
            item.Enabled = m_guiEnabled.Checked;
            item.InstanceIdList = m_guiInstanceIdList.Text.Trim();
            item.StartOn = m_guiStartOn.Value;
            item.StopOn = m_guiStopOn.Value;

            var daysOfWeek = new List<string>();
            daysOfWeek.Add(m_guiSun.Checked == true ? "yes" : "no");
            daysOfWeek.Add(m_guiMon.Checked == true ? "yes" : "no");
            daysOfWeek.Add(m_guiTue.Checked == true ? "yes" : "no");
            daysOfWeek.Add(m_guiWed.Checked == true ? "yes" : "no");
            daysOfWeek.Add(m_guiThu.Checked == true ? "yes" : "no");
            daysOfWeek.Add(m_guiFri.Checked == true ? "yes" : "no");
            daysOfWeek.Add(m_guiSat.Checked == true ? "yes" : "no");
            item.DaysOfWeek = string.Join(",", daysOfWeek);

            AwsControllerScheduledOnOff.SaveRecord(SelectedRegion, item);
        }

        private void m_guiOK_Click(object sender, EventArgs e) {
            if (m_guiInstanceIdList.Text.Trim() != string.Empty) {
                SaveData();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            } else {
                MessageBox.Show("Instance id list cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_guiCancel_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
