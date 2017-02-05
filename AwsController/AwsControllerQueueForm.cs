using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AwsController {
    // Ideas for a thread queue from this project
    // http://www.codeproject.com/Articles/14219/Multi-threaded-file-download-manager
    // http://bloodhound.codeplex.com/

    public partial class AwsControllerQueueForm : Form {
        private List<Thread> m_QueueThreads = new List<Thread>();
        private List<QueueTask> m_QueueTasks = new List<QueueTask>();
        private int m_ActiveTaskCount = 0;
        private static readonly object m_Lock = new object();
        private System.Windows.Forms.Timer m_Timer = new System.Windows.Forms.Timer();

        private const int MAX_CONCURRENT_TASK = 3;
        private const int TIMER_INTERVAL = 5000;

        public Amazon.RegionEndpoint SelectedRegion { get; set; }

        public AwsControllerQueueForm() {
            InitializeComponent();

            m_Timer.Interval = TIMER_INTERVAL;
            m_Timer.Tick += new EventHandler(m_Timer_Tick);
            m_Timer.Start();
        }

        private void AwsControllerQueueForm_Load(object sender, EventArgs e) {
            LoadControls();
        }

        private void m_Timer_Tick(object sender, EventArgs e) {
            ExecuteQueue();

            foreach (var task in m_QueueTasks) {
                SetListViewStatus(task);
            }
        }

        private void m_guiClose_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void item_TaskStarted(QueueTask task) {
            SetListViewStatus(task);
        }

        private void item_TaskCompleted(QueueTask task, bool isSuccess) {
            lock (m_Lock) {
                m_ActiveTaskCount--;
            }

            RemoveQueueItem(task);
            LoadControls();

            var parent = ((MainForm)Owner);
            parent.LoadS3LeftFolders();
            parent.LoadS3RightFolders();
        }


        private void SetListViewStatus(QueueTask task) {
            if (!string.IsNullOrEmpty(task.Progress)) {
                Invoke(new MethodInvoker(() => {
                    foreach (ListViewItem item in m_guiListView.Items) {
                        if (item.Name.Equals(task.Id)) {
                            var statusItem = item.SubItems[3];
                            statusItem.Text = task.Status.ToString();

                            var progressItem = item.SubItems[4];
                            progressItem.ForeColor = Color.White;
                            progressItem.BackColor = Color.DarkGreen;
                            progressItem.Text = task.Progress;

                            break;
                        }
                    }
                }));
            }
        }

        public void LoadControls() {
            Invoke(new MethodInvoker(() => {
                for (int i = 0; i < m_QueueTasks.Count; i++) {
                    var task = m_QueueTasks[i];
                    var found = false;

                    for (int j = 0; j < m_guiListView.Items.Count; j++) {
                        if (m_guiListView.Items[j].Name.Equals(task.Id)) {
                            found = true;
                            break;
                        }
                    }

                    if (!found) {
                        var listItem = new ListViewItem(new string[] { task.Action.ToString(), task.Source.Path, task.Destination.Path, task.Status.ToString(), task.Progress });
                        listItem.Name = task.Id;
                        listItem.UseItemStyleForSubItems = false;
                        m_guiListView.Items.Add(listItem);
                    }
                }
            }));
        }

        private void ExecuteQueue() {
            if (m_ActiveTaskCount <= MAX_CONCURRENT_TASK) {
                var i = 0;

                foreach (var thread in m_QueueThreads) {
                    if (m_ActiveTaskCount >= MAX_CONCURRENT_TASK) {
                        break;
                    }

                    var task = m_QueueTasks[i];

                    if (!task.IsStarted) {
                        lock (m_Lock) {
                            thread.Start();
                            m_ActiveTaskCount++;
                        }
                    }

                    i++;
                }
            }
        }

        public void ClearQueue() {
            foreach (Thread t in m_QueueThreads) {
                if (t.IsAlive) {
                    t.Abort();
                }
            }

            m_QueueThreads = new List<Thread>();
            m_QueueTasks = new List<QueueTask>();
        }

        public void RemoveQueueItem(QueueTask task) {
            int i = 0;

            foreach (var item in m_QueueTasks) {
                if (item == task) {
                    lock (m_Lock) {
                        m_QueueThreads.Remove(m_QueueThreads[i]);
                        m_QueueTasks.Remove(item);

                        break;
                    }
                }

                i++;
            }

            Invoke(new MethodInvoker(() => {
                foreach (ListViewItem listItem in m_guiListView.Items) {
                    if (listItem.Name.Equals(task.Id)) {
                        m_guiListView.Items.Remove(listItem);
                        break;
                    }
                }
            }));
        }

        public string EnqueueCopyJob(TaskObject source, TaskObject dest) {
            var item = new QueueTask();

            item.SelectedRegion = SelectedRegion;
            item.Id = Guid.NewGuid().ToString();
            item.Source = source;
            item.Destination = dest;
            item.Action = TaskAction.Copy;
            item.Status = TaskStatus.Queued;
            item.TaskStarted += new QueueTaskStarted(item_TaskStarted);
            item.TaskCompleted += new QueueTaskCompleted(item_TaskCompleted);

            var threadStart = new ThreadStart(item.Execute);
            var thread = new Thread(threadStart);
            thread.IsBackground = true;
            thread.Name = item.Id;

            m_QueueThreads.Add(thread);
            m_QueueTasks.Add(item);

            return item.Id;
        }

        public string EnqueueDeleteJob(TaskObject obj) {
            var item = new QueueTask();

            item.Id = Guid.NewGuid().ToString();
            item.Source = obj;
            item.Action = TaskAction.Delete;
            item.Status = TaskStatus.Queued;
            item.TaskStarted += new QueueTaskStarted(item_TaskStarted);
            item.TaskCompleted += new QueueTaskCompleted(item_TaskCompleted);

            var threadStart = new ThreadStart(item.Execute);
            var thread = new Thread(threadStart);
            thread.Name = item.Id;

            m_QueueThreads.Add(thread);
            m_QueueTasks.Add(item);

            return item.Id;
        }
    }
}
