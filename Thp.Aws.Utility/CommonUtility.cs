using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Thp.Har.Utility {
    public class CommonUtility {
        public const string UPDATE_SOFTWARE_ALL = "all";
        public const string UPDATE_SOFTWARE_MEMBERS = "members";
        public const string UPDATE_SOFTWARE_SEARCH = "search";
        public const string UPDATE_SOFTWARE_WWW = "www";
        public const string UPDATE_SOFTWARE_INSTANCE = "instance";
        public static string[] UPDATE_SOFTWARE_TAGS_MEMBERS = new string[] { "members-server", "har-vpc-members-as-grp01" };
        public static string[] UPDATE_SOFTWARE_TAGS_SEARCH = new string[] { "search-server", "har-vpc-search-as-grp01" };
        public static string[] UPDATE_SOFTWARE_TAGS_WWW = new string[] { "www-server", "har-vpc-www-as-grp01" };

        public const string CRITICAL_ERROR_FILE = @"C:\Temp\CriticalError.log";
        public static readonly char[] ITEM_SEPARATORS = ";".ToCharArray();
        public static readonly char[] PAIR_SEPARATORS = "|".ToCharArray();

        public static string EnsureDirectory(string dir) {
            var result = Path.GetFullPath(dir);

            if (!Directory.Exists(result))
                Directory.CreateDirectory(result);

            return result;
        }

        public static bool DirectoryHasFiles(string path) {
            try {
                return Directory.EnumerateFileSystemEntries(path).Any();
            } catch {
                return false;
            }
        }

        public static bool IsProcessRunning(string name) {
            try {
                Process[] processlist = Process.GetProcesses();

                foreach (Process item in processlist) {
                    if (item.ProcessName.Equals(name, StringComparison.OrdinalIgnoreCase)) {
                        return true;
                    }
                }
            } catch { }

            return false;
        }

        public static Process GetProcessByName(string name) {
            Process[] processlist = Process.GetProcesses();

            foreach (Process item in processlist) {
                if (item.ProcessName.Equals(name, StringComparison.OrdinalIgnoreCase)) {
                    return item;
                }
            }

            return null;
        }

        public static bool IsFileLocked(string path) {
            var file = new FileInfo(path);
            FileStream stream = null;

            try {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            } catch (IOException) {
                return true;
            } finally {
                if (stream != null) {
                    stream.Close();
                }
            }

            return false;
        }
        
        public static void CopyFilesRecursively(DirectoryInfo srcDir, DirectoryInfo dstDir, bool deleteOnSuccess) {
            foreach (DirectoryInfo dir in srcDir.GetDirectories()) {
                try {
                    LoggingUtility.Info(string.Format("Copying from {0} to {1}", dir.FullName, dstDir.FullName));
                    CopyFilesRecursively(dir, dstDir.CreateSubdirectory(dir.Name), deleteOnSuccess);
                } catch (Exception ex) {
                    LoggingUtility.Warning(ex);
                }
            }

            foreach (FileInfo file in srcDir.GetFiles()) {
                file.CopyTo(Path.Combine(dstDir.FullName, file.Name), true);

                if (deleteOnSuccess && !IsFileLocked(file.FullName)) {
                    file.Delete();
                }
            }
        }

        public static void DeleteFilesRecursively(DirectoryInfo deleteDir) {
            DeleteFilesRecursively(deleteDir, 0);
        }

        public static void DeleteFilesRecursively(DirectoryInfo deleteDir, int deleteEntriesOlderThanOrEqualsDays) {
            var now = DateTime.Now;
            LoggingUtility.Info(string.Format("Deleting top level folder {0}", deleteDir.FullName));

            foreach (DirectoryInfo dir in deleteDir.GetDirectories("*.*", SearchOption.TopDirectoryOnly)) {
                if ((now - dir.LastWriteTime).Days >= deleteEntriesOlderThanOrEqualsDays) {
                    try {
                        LoggingUtility.Info(string.Format("Deletinng individual folder {0}", dir.FullName));
                        dir.Delete(true);
                    } catch (Exception ex) {
                        LoggingUtility.Warning(ex);
                    }
                }
            }

            foreach (FileInfo file in deleteDir.GetFiles("*.*", SearchOption.TopDirectoryOnly)) {
                if (!IsFileLocked(file.FullName)) {
                    if ((now - file.LastWriteTime).Days >= deleteEntriesOlderThanOrEqualsDays) {
                        try {
                            LoggingUtility.Info(string.Format("Deletinng individual file {0}", file.FullName));
                            file.Delete();
                        } catch (Exception ex) {
                            LoggingUtility.Warning(ex);
                        }
                    }
                }
            }
        }

        public static string GetUniqueHostId() {
            var result = AmazonEC2Utility.GetCurrentInstanceId();

            if (string.IsNullOrEmpty(result)) {
                result = System.Net.Dns.GetHostName();
            }

            return result;
        }
    }
}
