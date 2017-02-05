using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Amazon;
using Amazon.EC2.Model;
using Thp.Har.Utility;
using System.IO;
using Amazon.S3.Model;
using System.Threading.Tasks;

namespace AwsController {
    public partial class MainForm {
        private const string TAB_S3 = "m_guiTabS3";

        private const string NAVDIR_GO_TOP = ".";
        private const string NAVDIR_GO_UP = "..";
        private const string NAVDIR_GO_DOWN = "DOWN";

        private const string IMAGE_DRIVE = "drive.png";
        private const string IMAGE_DRIVE_DISK = "drive_disk.png";
        private const string IMAGE_DRIVE_NETWORK = "drive_network.png";
        private const string IMAGE_DRIVE_CD = "drive_cd.png";
        private const string IMAGE_DRIVE_CD_EMPTY = "drive_cd_empty.png";
        private const string IMAGE_DRIVE_WEB = "drive_web.png";
        private const string IMAGE_DRIVE_GO = "drive_go.png";

        private const string IMAGE_FOLDER = "folder.png";
        private const string IMAGE_FOLDER_EXPLORE = "folder_explore.png";
        private const string IMAGE_ARROW_TOP = "bullet_arrow_top.png";
        private const string IMAGE_ARROW_UP = "bullet_arrow_up.png";
        private const string IMAGE_PAGE = "page_white_text.png";

        private static string S3_CURRENT_LEFT_NAVDIR = null;
        private static string S3_CURRENT_LEFT_BUCKET = null;
        private static object S3_CURRENT_LEFT_CONTAINER = null;

        private static string S3_CURRENT_RIGHT_NAVDIR = null;
        private static string S3_CURRENT_RIGHT_BUCKET = null;
        private static object S3_CURRENT_RIGHT_CONTAINER = null;

        private static char[] PATH_LOCAL_SEPARATORS = new char[] { Path.DirectorySeparatorChar };


        private void MainFormS3Tab_Constructor() {
            m_guiS3TabOpenTransferQueue.Click += new EventHandler(m_guiS3TabOpenTransferQueue_Click);

            m_guiS3TabLeftListView.View = View.Details;
            m_guiS3TabLeftListView.Click += new EventHandler(m_guiS3TabLeftListView_Click);
            m_guiS3TabLeftListView.DoubleClick += new EventHandler(m_guiS3TabLeftList_DoubleClick);

            m_guiS3TabRightListView.View = View.Details;
            m_guiS3TabRightListView.Click += new EventHandler(m_guiS3TabRightListView_Click);
            m_guiS3TabRightListView.DoubleClick += new EventHandler(m_guiS3TabRightList_DoubleClick);

            m_guiS3TabLeftRefresh.Click += new EventHandler(m_guiS3TabLeftRefresh_Click);
            m_guiS3TabLeftCopyToRight.Click += new EventHandler(m_guiS3TabLeftCopyToRight_Click);
            m_guiS3TabLeftAddFolder.Click += new EventHandler(m_guiS3TabLeftAddFolder_Click);
            m_guiS3TabLeftDelete.Click += new EventHandler(m_guiS3TabLeftDelete_Click);

            m_guiS3TabRightRefresh.Click += new EventHandler(m_guiS3TabRightRefresh_Click);
            m_guiS3TabRightCopyToLeft.Click += new EventHandler(m_guiS3TabRightCopyToLeft_Click);
            m_guiS3TabRightAddBucket.Click += new EventHandler(m_guiS3TabRightAddBucket_Click);
            m_guiS3TabRightAddFolder.Click += new EventHandler(m_guiS3TabRightAddFolder_Click);
            m_guiS3TabRightDelete.Click += new EventHandler(m_guiS3TabRightDelete_Click);
        }

        private void m_guiS3TabOpenTransferQueue_Click(object sender, EventArgs e) {
            OpenTransferQueueForm();
        }

        private void OpenTransferQueueForm() {
            if (m_AwsControllerQueueForm == null) {
                m_AwsControllerQueueForm = new AwsControllerQueueForm();
                m_AwsControllerQueueForm.ShowIcon = true;
                m_AwsControllerQueueForm.ShowInTaskbar = true;
                m_AwsControllerQueueForm.SelectedRegion = m_SelectedRegion;
            }

            if (!m_AwsControllerQueueForm.Visible) {
                m_AwsControllerQueueForm.Show(this);
                m_AwsControllerQueueForm.Focus();
            }

            m_AwsControllerQueueForm.LoadControls();
        }


        private void m_guiS3TabLeftCopyToRight_Click(object sender, EventArgs e) {
            if (m_guiS3TabLeftListView.SelectedItems.Count == 0) {
                MessageBox.Show("You must select source drive or folder to copy from", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (S3_CURRENT_RIGHT_BUCKET == null) {
                MessageBox.Show("You must select a destination bucket or folder to copy to", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dstObject = new TaskObject();
            dstObject.LocationType = TaskLocationType.S3;
            if (S3_CURRENT_RIGHT_CONTAINER is S3Bucket) {
                dstObject.ObjectType = TaskObjectType.Bucket;
                dstObject.Path = ((S3Bucket)S3_CURRENT_RIGHT_CONTAINER).BucketName;
            } else if (S3_CURRENT_RIGHT_CONTAINER is string) {
                dstObject.ObjectType = TaskObjectType.Folder;
                dstObject.Path = S3_CURRENT_RIGHT_BUCKET + AmazonS3Utility.BUCKET_SUFFIX_STRING + (string)S3_CURRENT_RIGHT_CONTAINER;
            }

            foreach (var item in m_guiS3TabLeftListView.SelectedItems) {
                var src = (ListViewItem)item;
                var srcObject = new TaskObject();
                srcObject.LocationType = TaskLocationType.LocalSystem;
                srcObject.Path = src.Name;
                if (src.Tag is DriveInfo) {
                    srcObject.ObjectType = TaskObjectType.Drive;
                } else if (src.Tag is DirectoryInfo) {
                    srcObject.ObjectType = TaskObjectType.Folder;
                } else if (src.Tag is FileSystemInfo) {
                    srcObject.ObjectType = TaskObjectType.File;
                }

                srcObject.Tag = src.Tag;
                m_AwsControllerQueueForm.EnqueueCopyJob(srcObject, dstObject);
            }

            OpenTransferQueueForm();
        }

        private void m_guiS3TabLeftRefresh_Click(object sender, EventArgs e) {
            if (S3_CURRENT_LEFT_CONTAINER == null) {
                LoadS3LeftDrives();
            } else {
                LoadS3LeftFolders();
            }
        }

        private void m_guiS3TabLeftDelete_Click(object sender, EventArgs e) {
            if (m_guiS3TabLeftListView.SelectedItems.Count > 0) {
                if (MessageBox.Show("Are you sure you want to delete the selected item(s)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    foreach (var item in m_guiS3TabLeftListView.SelectedItems) {
                        var obj = ((ListViewItem)item).Tag;

                        if (obj is DriveInfo) {
                            MessageBox.Show("Cannot delete a drive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } else if (obj is DirectoryInfo) {
                            Directory.Delete(((DirectoryInfo)obj).FullName, true);
                        } else {
                            File.Delete(((FileInfo)obj).FullName);
                        }
                    }

                    LoadS3LeftFolders();
                }
            } else {
                MessageBox.Show("Nothing to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_guiS3TabLeftAddFolder_Click(object sender, EventArgs e) {
            var form = new AddEditItemForm();
            form.ItemToAddEditName = "Folder";

            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                if (S3_CURRENT_LEFT_CONTAINER != null) {
                    if (S3_CURRENT_LEFT_CONTAINER is DriveInfo) {
                        var obj = new DirectoryInfo(((DriveInfo)S3_CURRENT_LEFT_CONTAINER).Name);
                        obj.CreateSubdirectory(form.ItemName);
                    } else if (S3_CURRENT_LEFT_CONTAINER is DirectoryInfo) {
                        var obj = new DirectoryInfo(((DirectoryInfo)S3_CURRENT_LEFT_CONTAINER).FullName);
                        obj.CreateSubdirectory(form.ItemName);
                    } else {
                        MessageBox.Show("Cannot create a folder inside a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadS3LeftFolders();
                } else {
                    MessageBox.Show("You must be inside a drive or folder to create a new folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void m_guiS3TabLeftList_DoubleClick(object sender, EventArgs e) {
            var selectedItem = m_guiS3TabLeftListView.SelectedItems[0];
            var selectedView = selectedItem.Name;

            if (selectedView.Equals(NAVDIR_GO_TOP)) {
                LoadS3LeftDrives();
            } else if (selectedView.Equals(NAVDIR_GO_UP)) {
                S3_CURRENT_LEFT_NAVDIR = selectedView;
                LoadS3LeftFolders();
            } else {
                S3_CURRENT_LEFT_NAVDIR = NAVDIR_GO_DOWN;
                S3_CURRENT_LEFT_CONTAINER = selectedItem.Tag;

                if (selectedItem.Tag is DriveInfo || selectedItem.Tag is DirectoryInfo) {
                    LoadS3LeftFolders();
                } else if (selectedItem.Tag is FileSystemInfo) {
                    try { System.Diagnostics.Process.Start(((FileInfo)selectedItem.Tag).FullName); } catch { }
                }
            }
        }

        private void m_guiS3TabLeftListView_Click(object sender, EventArgs e) {
            SetS3LeftControlState();
        }

        private void SetS3LeftControlState() {
            if (S3_CURRENT_LEFT_CONTAINER == null) {
                m_guiS3TabLeftDelete.Enabled = false;
                m_guiS3TabLeftAddFolder.Enabled = false;
            } else {
                m_guiS3TabLeftAddFolder.Enabled = true;

                if (m_guiS3TabLeftListView.SelectedItems.Count > 0) {
                    ListViewItem item = m_guiS3TabLeftListView.SelectedItems[0];

                    if (item.Name.Equals(NAVDIR_GO_TOP) || item.Name.Equals(NAVDIR_GO_UP) || item.Tag is DriveInfo) {
                        m_guiS3TabLeftDelete.Enabled = false;
                    } else {
                        m_guiS3TabLeftDelete.Enabled = true;
                    }
                } else {
                    m_guiS3TabLeftDelete.Enabled = false;
                }
            }
        }

        public void LoadS3LeftDrives() {
            S3_CURRENT_LEFT_NAVDIR = null;
            S3_CURRENT_LEFT_BUCKET = null;
            S3_CURRENT_LEFT_CONTAINER = null;
            FormatStatusLabel(m_guiS3TabLeftStatusLabel, null);

            var thread = new Thread(new ThreadStart(() => {
                var list = DriveInfo.GetDrives();

                Invoke(new MethodInvoker(() => {
                    m_guiS3TabLeftListView.SuspendLayout();
                    m_guiS3TabLeftListView.Items.Clear();

                    foreach (var item in list) {
                        var listItem = new ListViewItem(new string[] { string.Format("{0} ({1})", item.DriveType, item.Name.TrimEnd(PATH_LOCAL_SEPARATORS)), "Drive" });
                        listItem.Name = item.Name;
                        listItem.Tag = item;
                        listItem.ImageKey = GetImageKeyForDriveType(item.DriveType);
                        m_guiS3TabLeftListView.Items.Add(listItem);
                    }

                    m_guiS3TabLeftListView.ResumeLayout();
                    SetS3LeftControlState();
                }));
            }));
            thread.Start();
        }

        public void LoadS3LeftFolders() {
            if (S3_CURRENT_LEFT_CONTAINER != null) {
                var thread = new Thread(new ThreadStart(() => {
                    string path = null;

                    if (S3_CURRENT_LEFT_NAVDIR.Equals(NAVDIR_GO_UP)) {
                        if (S3_CURRENT_LEFT_CONTAINER is DriveInfo) {
                            LoadS3LeftDrives();
                            return;
                        } else {
                            var parent = ((DirectoryInfo)S3_CURRENT_LEFT_CONTAINER).Parent;

                            if (parent != null) {
                                S3_CURRENT_LEFT_CONTAINER = parent;
                                path = parent.FullName;
                            } else {
                                LoadS3LeftDrives();
                                return;
                            }
                        }
                    } else if (S3_CURRENT_LEFT_NAVDIR.Equals(NAVDIR_GO_DOWN)) {
                        if (S3_CURRENT_LEFT_CONTAINER is DriveInfo) {
                            path = ((DriveInfo)S3_CURRENT_LEFT_CONTAINER).Name;
                        } else if (S3_CURRENT_LEFT_CONTAINER is DirectoryInfo) {
                            path = ((DirectoryInfo)S3_CURRENT_LEFT_CONTAINER).FullName;
                        }
                    }

                    var dirInfo = new DirectoryInfo(path);

                    Invoke(new MethodInvoker(() => {
                        try {
                            // Folders
                            var folders = dirInfo.EnumerateDirectories();
                            FormatStatusLabel(m_guiS3TabLeftStatusLabel, path);

                            m_guiS3TabLeftListView.SuspendLayout();
                            m_guiS3TabLeftListView.Items.Clear();
                            AddNavigationItem(m_guiS3TabLeftListView);

                            foreach (var item in folders) {
                                var listItem = new ListViewItem(new string[] { string.Format("{0}", item.Name), "Folder", string.Empty, item.LastWriteTimeUtc.ToString() });
                                listItem.Name = item.FullName;
                                listItem.Tag = item;

                                var attributes = item.Attributes;

                                if (((attributes & FileAttributes.Hidden) != FileAttributes.Hidden) && ((attributes & FileAttributes.System) != FileAttributes.System)) {
                                    listItem.ImageKey = IMAGE_FOLDER;
                                    m_guiS3TabLeftListView.Items.Add(listItem);
                                }
                            }

                            // Files
                            var files = dirInfo.EnumerateFiles();
                            foreach (var item in files) {
                                var size = GetFileSystemDisplaySize(item.Length);
                                var listItem = new ListViewItem(new string[] { string.Format("{0}", item.Name), "File", size, item.LastWriteTimeUtc.ToString() });
                                listItem.Name = item.FullName;
                                listItem.Tag = item;

                                var attributes = item.Attributes;

                                if (((attributes & FileAttributes.Hidden) != FileAttributes.Hidden) && ((attributes & FileAttributes.System) != FileAttributes.System)) {
                                    listItem.ImageKey = GetImageKeyForExtension(item.Extension);
                                    m_guiS3TabLeftListView.Items.Add(listItem);
                                }
                            }
                        } catch (UnauthorizedAccessException) {
                            MessageBox.Show("You do not have permission to view the selected item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } finally {
                            m_guiS3TabLeftListView.ResumeLayout();
                            SetS3LeftControlState();
                        }
                    }));

                }));
                thread.Start();
            }
        }


        private void m_guiS3TabRightCopyToLeft_Click(object sender, EventArgs e) {
            if (m_guiS3TabRightListView.SelectedItems.Count == 0) {
                MessageBox.Show("You must select source bucket or folder to copy from", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (S3_CURRENT_LEFT_CONTAINER == null) {
                MessageBox.Show("You must select a destination folder to copy to", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dstObject = new TaskObject();
            dstObject.LocationType = TaskLocationType.LocalSystem;
            if (S3_CURRENT_LEFT_CONTAINER is DriveInfo) {
                dstObject.ObjectType = TaskObjectType.Drive;
                dstObject.Path = ((DriveInfo)S3_CURRENT_LEFT_CONTAINER).Name;
            } else if (S3_CURRENT_LEFT_CONTAINER is DirectoryInfo) {
                dstObject.ObjectType = TaskObjectType.Folder;
                dstObject.Path = ((DirectoryInfo)S3_CURRENT_LEFT_CONTAINER).FullName;
            }


            foreach (var item in m_guiS3TabRightListView.SelectedItems) {
                var src = (ListViewItem)item;
                var srcObject = new TaskObject();
                srcObject.LocationType = TaskLocationType.S3;
                srcObject.Path = src.Name;

                if (src.Tag is S3Bucket) {
                    srcObject.ObjectType = TaskObjectType.Bucket;
                } else if (src.Tag is S3Object) {
                    srcObject.ObjectType = TaskObjectType.File;
                    srcObject.Path = S3_CURRENT_RIGHT_BUCKET + AmazonS3Utility.BUCKET_SUFFIX_STRING + src.Name;
                } else if (src.Tag is string) {
                    if (src.Tag.ToString().EndsWith("/")) {
                        srcObject.ObjectType = TaskObjectType.Folder;
                        srcObject.Path = S3_CURRENT_RIGHT_BUCKET + AmazonS3Utility.BUCKET_SUFFIX_STRING + src.Name;
                    } else {
                        srcObject.ObjectType = TaskObjectType.File;
                        srcObject.Path = S3_CURRENT_RIGHT_BUCKET + AmazonS3Utility.BUCKET_SUFFIX_STRING + src.Name;
                    }
                }

                m_AwsControllerQueueForm.EnqueueCopyJob(srcObject, dstObject);
            }

            OpenTransferQueueForm();
        }

        private void m_guiS3TabRightRefresh_Click(object sender, EventArgs e) {
            if (S3_CURRENT_RIGHT_CONTAINER == null) {
                LoadS3RightDrives();
            } else {
                LoadS3RightFolders();
            }
        }

        private void m_guiS3TabRightAddBucket_Click(object sender, EventArgs e) {
            var form = new AddEditItemForm();
            form.ItemToAddEditName = "Bucket";

            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                var result = AmazonS3Utility.AddBucket(m_SelectedRegion, form.ItemName);
                LoadS3RightDrives();
            }
        }

        private void m_guiS3TabRightAddFolder_Click(object sender, EventArgs e) {
            var form = new AddEditItemForm();
            form.ItemToAddEditName = "Folder";

            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(S3_CURRENT_RIGHT_BUCKET)) {
                string keyPrefix = string.Empty;
                if (S3_CURRENT_RIGHT_CONTAINER != null) {
                    if (S3_CURRENT_RIGHT_CONTAINER is S3Bucket) {
                    } else if (S3_CURRENT_RIGHT_CONTAINER is string) {
                        keyPrefix = S3_CURRENT_RIGHT_CONTAINER.ToString();
                    }
                }

                var result = AmazonS3Utility.AddFolder(m_SelectedRegion, S3_CURRENT_RIGHT_BUCKET, keyPrefix + form.ItemName);
                LoadS3RightFolders();
            }
        }

        private void m_guiS3TabRightDelete_Click(object sender, EventArgs e) {
            if (m_guiS3TabRightListView.SelectedItems.Count > 0) {
                if (MessageBox.Show("Are you sure you want to delete the selected item(s)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    foreach (var item in m_guiS3TabRightListView.SelectedItems) {
                        string text = null;
                        var obj = (ListViewItem)item;

                        if (obj.Name.EndsWith(AmazonS3Utility.FOLDER_SUFFIX_STRING)) {
                            text = obj.Name;
                        } else {
                            text = obj.Text;
                        }

                        new Thread(new ThreadStart(() => {
                            if (S3_CURRENT_RIGHT_BUCKET == null && S3_CURRENT_RIGHT_CONTAINER == null) {
                                var result = AmazonS3Utility.DeleteBuckets(m_SelectedRegion, text);
                                LoadS3RightDrives();
                            } else {
                                if (S3_CURRENT_RIGHT_CONTAINER is S3Bucket) {
                                    var result = AmazonS3Utility.DeleteObjects(m_SelectedRegion, S3_CURRENT_RIGHT_BUCKET, null, text);
                                } else {
                                    var result = AmazonS3Utility.DeleteObjects(m_SelectedRegion, S3_CURRENT_RIGHT_BUCKET, (string)S3_CURRENT_RIGHT_CONTAINER, text);
                                }

                                LoadS3RightFolders();
                            }
                        })).Start();
                    }
                }
            } else {
                MessageBox.Show("Nothing to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_guiS3TabRightList_DoubleClick(object sender, EventArgs e) {
            var selectedItem = m_guiS3TabRightListView.SelectedItems[0];
            var selectedView = selectedItem.Name;

            if (selectedView.Equals(NAVDIR_GO_TOP)) {
                LoadS3RightDrives();
            } else if (selectedView.Equals(NAVDIR_GO_UP)) {
                S3_CURRENT_RIGHT_NAVDIR = NAVDIR_GO_UP;
                LoadS3RightFolders();
            } else {
                S3_CURRENT_RIGHT_NAVDIR = NAVDIR_GO_DOWN;
                S3_CURRENT_RIGHT_CONTAINER = selectedItem.Tag;

                if (S3_CURRENT_RIGHT_CONTAINER is S3Bucket) {
                    S3_CURRENT_RIGHT_BUCKET = ((S3Bucket)S3_CURRENT_RIGHT_CONTAINER).BucketName;
                } else if (S3_CURRENT_RIGHT_CONTAINER is S3Object) {
                    S3_CURRENT_RIGHT_BUCKET = ((S3Object)S3_CURRENT_RIGHT_CONTAINER).BucketName;
                }

                LoadS3RightFolders();
            }
        }

        private void m_guiS3TabRightListView_Click(object sender, EventArgs e) {
            SetS3RightControlState();
        }

        private void SetS3RightControlState() {
            if (S3_CURRENT_RIGHT_CONTAINER == null) {
                m_guiS3TabRightAddBucket.Enabled = true;
                m_guiS3TabRightAddFolder.Enabled = false;
                m_guiS3TabRightDelete.Enabled = false;

                //if (m_guiS3TabRightListView.SelectedItems.Count > 0) {
                //    m_guiS3TabRightDelete.Enabled = true;
                //} else {
                //    m_guiS3TabRightDelete.Enabled = false;
                //}
            } else {
                m_guiS3TabRightAddBucket.Enabled = false;
                m_guiS3TabRightAddFolder.Enabled = true;

                if (m_guiS3TabRightListView.SelectedItems.Count > 0) {
                    ListViewItem item = m_guiS3TabRightListView.SelectedItems[0];

                    if (item.Name.Equals(NAVDIR_GO_TOP) || item.Name.Equals(NAVDIR_GO_UP)) {
                        m_guiS3TabRightDelete.Enabled = false;
                    } else {
                        m_guiS3TabRightDelete.Enabled = true;
                    }
                } else {
                    m_guiS3TabRightDelete.Enabled = false;
                }
            }
        }

        public void LoadS3RightDrives() {
            S3_CURRENT_RIGHT_NAVDIR = null;
            S3_CURRENT_RIGHT_BUCKET = null;
            S3_CURRENT_RIGHT_CONTAINER = null;
            FormatStatusLabel(m_guiS3TabRightStatusLabel, null);

            var thread = new Thread(new ThreadStart(() => {
                var list = AmazonS3Utility.ListBuckets(m_SelectedRegion);

                Invoke(new MethodInvoker(() => {
                    m_guiS3TabRightListView.SuspendLayout();
                    m_guiS3TabRightListView.Items.Clear();

                    foreach (var item in list.Buckets) {
                        var listItem = new ListViewItem(new string[] { item.BucketName, "Bucket" });
                        listItem.Name = item.BucketName;
                        listItem.Tag = item;
                        listItem.ImageKey = IMAGE_DRIVE_WEB;

                        m_guiS3TabRightListView.Items.Add(listItem);
                    }

                    m_guiS3TabRightListView.ResumeLayout();
                    SetS3RightControlState();
                }));
            }));
            thread.Start();
        }

        public void LoadS3RightFolders() {
            if (S3_CURRENT_RIGHT_CONTAINER != null) {
                var thread = new Thread(new ThreadStart(() => {
                    string path = null;

                    if (S3_CURRENT_RIGHT_NAVDIR.Equals(NAVDIR_GO_UP)) {
                        if (S3_CURRENT_RIGHT_CONTAINER is S3Bucket) {
                            LoadS3RightDrives();
                            return;
                        } else if (S3_CURRENT_RIGHT_CONTAINER is string) {
                            var parts = S3_CURRENT_RIGHT_CONTAINER.ToString().Split(AmazonS3Utility.FOLDER_SUFFIX_ARRAY, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length == 0) {
                                LoadS3RightDrives();
                                return;
                            } else if (parts.Length == 1) {
                                path = null;
                                S3_CURRENT_RIGHT_CONTAINER = string.Empty;
                            } else {
                                path = string.Empty;
                                for (int i = 0; i < parts.Length - 1; i++) {
                                    path += parts[i] + AmazonS3Utility.FOLDER_SUFFIX_STRING;
                                }
                                S3_CURRENT_RIGHT_CONTAINER = path;
                            }
                        }
                    } else if (S3_CURRENT_RIGHT_NAVDIR.Equals(NAVDIR_GO_DOWN)) {
                        if (S3_CURRENT_RIGHT_CONTAINER is S3Bucket) {
                            path = null;
                        } else if (S3_CURRENT_RIGHT_CONTAINER is S3Object) {
                            path = ((S3Object)S3_CURRENT_RIGHT_CONTAINER).Key;
                        } else {
                            path = S3_CURRENT_RIGHT_CONTAINER.ToString();
                        }
                    }

                    var currentObject = S3_CURRENT_RIGHT_CONTAINER;
                    var currentView = S3_CURRENT_RIGHT_NAVDIR;

                    var response = AmazonS3Utility.ListObjects(m_SelectedRegion, S3_CURRENT_RIGHT_BUCKET, path, AmazonS3Utility.FOLDER_SUFFIX_STRING, AmazonS3Utility.MAX_ENUMERATION_KEYS);
                    FormatStatusLabel(m_guiS3TabRightStatusLabel, S3_CURRENT_RIGHT_BUCKET, path);

                    Invoke(new MethodInvoker(() => {
                        m_guiS3TabRightListView.Items.Clear();
                        AddNavigationItem(m_guiS3TabRightListView);

                        if (response.CommonPrefixes.Count > 0) {
                            // Folders
                            foreach (var item in response.CommonPrefixes) {
                                string text = null;
                                if (response.Prefix != null) {
                                    text = item.Substring(response.Prefix.Length);
                                } else {
                                    text = item;
                                }

                                var listItem = new ListViewItem(new string[] { text.TrimEnd(AmazonS3Utility.FOLDER_SUFFIX_ARRAY), "Folder" });
                                listItem.Name = item;
                                listItem.Tag = item;
                                listItem.ImageKey = IMAGE_FOLDER;

                                m_guiS3TabRightListView.Items.Add(listItem);
                            }

                            // Files
                            foreach (var item in response.S3Objects) {
                                if (!item.Key.Equals(response.Prefix)) {
                                    var text = item.Key.Substring(response.Prefix.Length);
                                    var date = DateTime.Parse(item.LastModified);
                                    var listItem = new ListViewItem(new string[] { text, "File", GetFileSystemDisplaySize(item.Size), date.ToString() });
                                    listItem.Name = item.Key;
                                    listItem.Tag = item;
                                    listItem.ImageKey = GetImageKeyForExtension(item.Key);

                                    m_guiS3TabRightListView.Items.Add(listItem);
                                }
                            }
                        } else if (response.S3Objects.Count > 0) {
                            foreach (var item in response.S3Objects) {
                                if (!item.Key.Equals(response.Prefix)) {
                                    var text = item.Key.Substring(response.Prefix.Length);
                                    var date = DateTime.Parse(item.LastModified);
                                    var listItem = new ListViewItem(new string[] { text, "File", GetFileSystemDisplaySize(item.Size), date.ToString() });
                                    listItem.Name = item.Key;
                                    listItem.Tag = item;
                                    listItem.ImageKey = GetImageKeyForExtension(item.Key);

                                    m_guiS3TabRightListView.Items.Add(listItem);
                                }
                            }
                        }

                        SetS3RightControlState();
                    }));
                }));
                thread.Start();
            }
        }


        private void LoadS3TabControls(bool isFromTimer) {
            if (!isFromTimer) {
                LoadS3LeftDrives();
                LoadS3RightDrives();
            }
        }

        private void FormatStatusLabel(ToolStripStatusLabel control, string status) {
            FormatStatusLabel(control, status, null);
        }

        private void FormatStatusLabel(ToolStripStatusLabel control, string status1, string status2) {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(status1) && !string.IsNullOrEmpty(status2)) {
                result = status1 + AmazonS3Utility.BUCKET_SUFFIX_STRING + status2;
            } else if (!string.IsNullOrEmpty(status1)) {
                result = status1;
            }

            if (!string.IsNullOrEmpty(result)) {
                if (result.Length > 80) {
                    result = result.Substring(0, 40) + "  ...  " + result.Substring(result.Length - 40);
                }
            } else {
                result = string.Empty;
            }

            if (InvokeRequired) {
                Invoke(new MethodInvoker(() => { control.Text = result; }));
            } else {
                control.Text = result;
            }
        }

        private string GetImageKeyForDriveType(DriveType value) {
            string result = null;

            switch (value) {
                case DriveType.CDRom:
                    result = IMAGE_DRIVE_CD;
                    break;
                case DriveType.Fixed:
                    result = IMAGE_DRIVE_DISK;
                    break;
                case DriveType.Network:
                    result = IMAGE_DRIVE_NETWORK;
                    break;
                case DriveType.NoRootDirectory:
                    result = IMAGE_DRIVE_CD_EMPTY;
                    break;
                case DriveType.Ram:
                    result = IMAGE_DRIVE;
                    break;
                case DriveType.Removable:
                    result = IMAGE_DRIVE_GO;
                    break;
                case DriveType.Unknown:
                    result = IMAGE_DRIVE;
                    break;
                default:
                    result = IMAGE_DRIVE;
                    break;
            }

            return result;
        }

        private string GetImageKeyForExtension(string extension) {
            var result = IMAGE_PAGE;

            if (!string.IsNullOrEmpty(extension)) {
                var idx = extension.LastIndexOf(".");

                if (idx > -1) {
                    extension = extension.ToLower().Substring(idx);

                    switch (extension) {
                        case ".png":
                        case ".gif":
                        case ".jpg":
                        case ".bmp":
                            result = "page_white_picture.png";
                            break;
                        case ".doc":
                        case ".docx":
                            result = "page_white_word.png";
                            break;
                        case ".xls":
                        case ".xlsx":
                            result = "page_white_excel.png";
                            break;
                        case ".ppt":
                        case ".pptx":
                            result = "page_white_powerpoint.png";
                            break;
                        case ".pdf":
                            result = "page_white_acrobat.png";
                            break;
                        case ".bak":
                        case ".zip":
                            result = "page_white_compressed.png";
                            break;
                        case ".exe":
                        case ".dll":
                        case ".bin":
                        case ".jar":
                        case ".pdb":
                            result = "page_white_gear.png";
                            break;
                        case ".c":
                        case ".cs":
                        case ".cpp":
                        case ".php":
                        case ".asp":
                        case ".aspx":
                        case ".asmx":
                        case ".java":
                            result = "page_white_code.png";
                            break;
                        case ".htm":
                        case ".html":
                        case ".xml":
                        case ".xsl":
                        case ".xslt":
                            result = "page_white_world.png";
                            break;
                        case ".js":
                        case ".json":
                            result = "page_white_cup.png";
                            break;
                        case ".cfm":
                            result = "page_white_coldfusion.png";
                            break;
                    }
                }
            }

            return result;
        }

        private void AddNavigationItem(ListView listView) {
            var go_top = new ListViewItem(NAVDIR_GO_TOP);
            go_top.Tag = go_top.Name = NAVDIR_GO_TOP;
            go_top.ImageKey = IMAGE_ARROW_TOP;
            listView.Items.Add(go_top);

            var go_up = new ListViewItem(NAVDIR_GO_UP);
            go_up.Tag = go_up.Name = NAVDIR_GO_UP;
            go_up.ImageKey = IMAGE_ARROW_UP;
            listView.Items.Add(go_up);
        }

        private string GetFileSystemDisplaySize(long length) {
            const decimal OneKiloByte = 1024M;
            const decimal OneMegaByte = OneKiloByte * 1024M;
            const decimal OneGigaByte = OneMegaByte * 1024M;
            decimal size = Convert.ToDecimal(length);
            string suffix;

            if (size > OneGigaByte) {
                size /= OneGigaByte;
                suffix = " GB";
            } else if (size > OneMegaByte) {
                size /= OneMegaByte;
                suffix = " MB";
            } else if (size > OneKiloByte) {
                size /= OneKiloByte;
                suffix = " KB";
            } else {
                suffix = " B";
            }

            return string.Format("{0:N2}{1}", size, suffix);
        }
    }
}
