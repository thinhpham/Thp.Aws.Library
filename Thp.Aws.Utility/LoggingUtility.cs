using System;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Threading;

namespace Thp.Har.Utility {
    public enum LogLevelEnum : int {
        Debug = 3,
        Info = 2,
        Warning = 1,
        Emergency = 0
    }

    public static class LoggingUtility {
        private const string LOG_FORMAT = "[{0}][{1}] {2}";
        private const string LOG_DATETIME = "HH:mm:ss";
        private const string LOG_SUFFIX = "Thp.Har.Utility.";

        private static Object m_Lock = new Object();

        public static string GetLogFilePath() {
            string logFilePath = Path.Combine(CacheObject.Settings.LogDirectory, LOG_SUFFIX + DateTime.Now.ToString("yyyy-MM-dd") + ".log");

            if (!File.Exists(logFilePath)) {
                try {
                    FileStream fs = File.Create(logFilePath);
                    fs.Close();
                } catch (UnauthorizedAccessException) {
                    logFilePath = Path.Combine(CacheObject.Settings.TempDirectory, LOG_SUFFIX + DateTime.Now.ToString("yyyy-MM-dd") + ".log");

                    if (!File.Exists(logFilePath)) {
                        FileStream fs = File.Create(logFilePath);
                        fs.Close();
                    }
                }
            }

            return logFilePath;
        }

        public static void Append(Exception exception, LogLevelEnum logLevel) {
            string s = "";

            if (exception.InnerException != null && exception.InnerException.Message.Length > 0) {
                Append(exception.InnerException, logLevel);
            } else {
                s = exception.ToString();
            }

            Append(s, logLevel);
        }

        public static void Append(string message, LogLevelEnum logLevel) {
            if (CacheObject.Settings.LogLevel > 0) {
                Append(GetLogFilePath(), message, logLevel);
            }
        }

        public static void Append(string logFilePath, string message, LogLevelEnum logLevel) {
            if (logLevel <= CacheObject.Settings.LogLevel && message.Trim().Length > 0) {
                lock (m_Lock) {
                    try {
                        using (StreamWriter sw = File.AppendText(logFilePath)) {
                            sw.WriteLine(string.Format(LOG_FORMAT, DateTime.Now.ToString(LOG_DATETIME), Enum.GetName(typeof(LogLevelEnum), logLevel), message));
                        }
                    } catch (Exception ex) {
                        File.WriteAllText(@"c:\temp\CriticalError.log", ex.ToString());
                    }
                }
            }
        }

        public static void Debug(string message) {
            Append(message, LogLevelEnum.Debug);
        }

        public static void Debug(Exception exception) {
            Append(exception, LogLevelEnum.Debug);
        }

        public static void Info(string message) {
            Append(message, LogLevelEnum.Info);
        }

        public static void Info(Exception exception) {
            Append(exception, LogLevelEnum.Info);
        }

        public static void Warning(string message) {
            Append(message, LogLevelEnum.Warning);
        }

        public static void Warning(Exception exception) {
            Append(exception, LogLevelEnum.Warning);
        }

        public static void Emergency(string message) {
            Append(message, LogLevelEnum.Emergency);
        }

        public static void Emergency(Exception exception) {
            Append(exception, LogLevelEnum.Emergency);
        }

        public static void CleanupOldLogFiles() {
            LoggingUtility.Info("Cleaning up old log files");

            var logRetentionInDays = CacheObject.Settings.LogRententionInDays;
            var dir = new DirectoryInfo(CacheObject.Settings.LogDirectory);
            var now = DateTime.Now;

            try {
                foreach (var file in dir.EnumerateFiles("*.log")) {
                    if ((now - file.LastWriteTime).Days > logRetentionInDays) {
                        try {
                            LoggingUtility.Info(string.Format("Deleting file [{0}] because it's older than retention period of [{1}] days", file.Name, logRetentionInDays));
                            File.Delete(file.FullName);
                        } catch (Exception ex) {
                            LoggingUtility.Warning(ex);
                        }
                    }
                }
            } catch (Exception ex) {
                LoggingUtility.Warning(ex);
            }
        }
    }
}
