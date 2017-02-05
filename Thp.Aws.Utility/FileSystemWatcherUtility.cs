using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Thp.Har.Utility {
    public class FileSystemWatcherUtility {
        private static readonly char[] m_ItemSeparator = ";".ToCharArray();
        private static readonly char[] m_PairSeparator = "|".ToCharArray();
        private List<FileSystemWatcher> m_WatcherList = new List<FileSystemWatcher>();
        private Dictionary<string, string> m_FileSystemPairs = new Dictionary<string, string>();

        public void Execute() {
            if (string.IsNullOrEmpty(CacheObject.Settings.RobocopyItems)) {
                throw new Exception("Source/destination files/folders cannot be null");
            }

            var items = CacheObject.Settings.FileSystemWatcherItems.Split(m_ItemSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items) {
                var arr = item.Split(m_PairSeparator, StringSplitOptions.RemoveEmptyEntries);
                string src = arr[0];
                string dst = arr[1];

                var watcher = new System.IO.FileSystemWatcher();
                watcher.Filter = "*.*";
                watcher.IncludeSubdirectories = true;
                watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite;
                watcher.Path = src;
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                m_FileSystemPairs.Add(src, dst);

                string arguments = null;
                arguments = string.Format("\"{0}\" \"{1}\" {2}", src.Trim(), dst.Trim(), CacheObject.Settings.RobocopyFlag);

                LoggingUtility.Info(string.Format("Copying data from [{0}] to [{1}]", src, dst));

                CommandLineExecutionStatus result = null;
                result = CommandLineUtility.ExecuteCommandLine(null, CacheObject.Settings.RobocopyCommand, arguments, CacheObject.Settings.RobocopyUsername, CacheObject.Settings.RobocopyPassword, true, ProcessPriorityClass.Normal);

                if (result != null) {
                    if (!string.IsNullOrEmpty(result.StandardError)) {
                        LoggingUtility.Warning(result.StandardError);
                    }

                    if (!string.IsNullOrEmpty(result.StandardOutput)) {
                        LoggingUtility.Debug(result.StandardOutput);
                    }
                }
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e) {
            
        }

        private void OnRenamed(object sender, RenamedEventArgs e) {
        }
    }
}
