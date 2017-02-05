using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace Thp.Har.Utility {
    public class RobocopyUtility {
        public void Execute() {
            if (string.IsNullOrEmpty(CacheObject.Settings.RobocopyItems)) {
                throw new Exception("Source/destination files/folders cannot be null");
            }

            string excludedFlag = string.Empty;

            if (!string.IsNullOrEmpty(CacheObject.Settings.RobocopyExcludedFiles)) {
                var excludedFilesArr = CacheObject.Settings.RobocopyExcludedFiles.Split(CommonUtility.ITEM_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                excludedFlag += "/XF ";

                for (int i = 0; i < excludedFilesArr.Length; i++) {
                    excludedFlag += "\"" + excludedFilesArr[i].Trim() + "\" ";
                }
            }

            if (!string.IsNullOrEmpty(CacheObject.Settings.RobocopyExcludedDirectories)) {
                string[] excludeDirectoriesArr = CacheObject.Settings.RobocopyExcludedDirectories.Split(CommonUtility.ITEM_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                excludedFlag += "/XD ";

                for (int i = 0; i < excludeDirectoriesArr.Length; i++) {
                    excludedFlag += "\"" + excludeDirectoriesArr[i].Trim() + "\" ";
                }
            }

            var items = CacheObject.Settings.RobocopyItems.Split(CommonUtility.ITEM_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items) {
                var arr = item.Split(CommonUtility.PAIR_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                string src = arr[0];
                string dst = arr[1];
                string workingDirectory = null;

                if (arr.Length >= 3) {
                    workingDirectory = arr[2];
                }

                string arguments = null;
                if (string.IsNullOrEmpty(excludedFlag)) {
                    arguments = string.Format("\"{0}\" \"{1}\" {2}", src.Trim(), dst.Trim(), CacheObject.Settings.RobocopyFlag);
                } else {
                    arguments = string.Format("\"{0}\" \"{1}\" {2} {3}", src.Trim(), dst.Trim(), CacheObject.Settings.RobocopyFlag, excludedFlag.Trim());
                }

                LoggingUtility.Info(string.Format("Copying data from [{0}] to [{1}]", src, dst));

                CommandLineExecutionStatus result = null;
                if (!string.IsNullOrEmpty(workingDirectory)) {
                    result = CommandLineUtility.ExecuteCommandLine(workingDirectory, CacheObject.Settings.RobocopyCommand, arguments, CacheObject.Settings.RobocopyUsername, CacheObject.Settings.RobocopyPassword, true, ProcessPriorityClass.Normal);
                } else {
                    result = CommandLineUtility.ExecuteCommandLine(null, CacheObject.Settings.RobocopyCommand, arguments, CacheObject.Settings.RobocopyUsername, CacheObject.Settings.RobocopyPassword, true, ProcessPriorityClass.Normal);
                }

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
    }
}
