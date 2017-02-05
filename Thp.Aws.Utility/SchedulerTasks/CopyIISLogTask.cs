using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedulerEngine;
using System.IO;
using System.Net;

namespace Thp.Har.Utility.SchedulerTasks {
    public class CopyIISLogTask : ITask {
        public const string Name = "CopyIISLogTask";

        public void HandleConditionsMetEvent(object sender, ConditionsMetEventArgs e) {
            if (string.IsNullOrEmpty(CacheObject.Settings.CopyIISLogItems)) {
                throw new Exception("Source/destination files/folders cannot be null");
            }

            try {
                var items = CacheObject.Settings.CopyIISLogItems.Split(CommonUtility.ITEM_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in items) {
                    var arr = item.Split(CommonUtility.PAIR_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                    string src = arr[0];
                    string dst = arr[1];

                    LoggingUtility.Info(string.Format("Copying IIS log file from [{0}] to [{1}]", src, dst));

                    if (Directory.Exists(src)) {
                        var hostname = CommonUtility.GetUniqueHostId();
                        var dstDir = Path.Combine(dst, hostname);
                        CommonUtility.EnsureDirectory(dstDir);

                        var srcDirInfo = new DirectoryInfo(src);
                        var dstDirInfo = new DirectoryInfo(dstDir);

                        CommonUtility.CopyFilesRecursively(srcDirInfo, dstDirInfo, CacheObject.Settings.CopyIISLogDeleteOnSuccess);
                    } else {
                        LoggingUtility.Warning("Source IIS log folder doesn't exist to copy");
                    }
                }
            } catch (Exception ex) {
                LoggingUtility.Warning(ex);
            }
        }

        public void Initialize(ScheduleDefinition schedule, object parameters) {

        }
    }
}
