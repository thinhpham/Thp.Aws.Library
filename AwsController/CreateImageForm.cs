using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Thp.Har.Utility;

namespace AwsController {
    public partial class CreateImageForm : Form {
        public Amazon.RegionEndpoint SelectedRegion { get; set; }
        public Amazon.EC2.Model.RunningInstance Instance { get; set; }
        public bool ShowAutoScalingRotationDialog { get; set; }

        public CreateImageForm() {
            InitializeComponent();
        }

        private void CreateImageForm_Load(object sender, EventArgs e) {
            LoadControls();
        }

        private void LoadControls() {
            var instanceId = Instance.InstanceId;
            m_guiInstanceId.Text = instanceId;

            if (Instance.Tag.Count > 0) {
                foreach (var tag in Instance.Tag) {
                    if (tag.Key.Equals("Name")) {
                        instanceId += " - " + tag.Value;
                        break;
                    }
                }
            }

            var volumeIdList = from item in Instance.BlockDeviceMapping select item.Ebs.VolumeId;
            var volumeList = AmazonEC2Utility.DescribeVolumes(SelectedRegion, null, volumeIdList.ToList<string>());

            var mappings = new List<DeviceMapping>();
            foreach (var volume in volumeList) {
                var attachment = volume.Attachment[0];
                string type = attachment.Device.Equals("/dev/sda1") ? "Root" : "EBS";

                mappings.Add(new DeviceMapping() { DeviceType = type, DeviceName = attachment.Device, Snapshot = volume.SnapshotId, Size = volume.Size, VolumeType = volume.VolumeType, IOPS = volume.IOPS, DeleteOnTermination = attachment.DeleteOnTermination });
            }
            m_guiGrid.DataSource = mappings;
        }

        private void m_guiOK_Click(object sender, EventArgs e) {
            //AmazonEC2Utility.CreateImage();
        }

        private void m_guiCancel_Click(object sender, EventArgs e) {

        }

        private class DeviceMapping {
            public string DeviceType { get; set; }
            public string DeviceName { get; set; }
            public string Snapshot { get; set; }
            public string Size { get; set; }
            public string VolumeType { get; set; }
            public string IOPS { get; set; }
            public bool DeleteOnTermination { get; set; }
        }
    }
}
