using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Thp.Har.Utility {
    public class GitHubUtility {
        public void Execute() {
            if (string.IsNullOrEmpty(CacheObject.Settings.GitHubItems)) {
                return;
            }

            var items = CacheObject.Settings.GitHubItems.Split(CommonUtility.ITEM_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in items) {
                LoggingUtility.Info(string.Format("Get latest from github using script {0}", item));

                var arguments = string.Format("-i \"{0}\"", item);
                var result = CommandLineUtility.ExecuteCommandLine(null, CacheObject.Settings.GitHubCommand, arguments, null, null, true, ProcessPriorityClass.Normal);

                if (result != null) {
                    if (!string.IsNullOrEmpty(result.StandardError)) {
                        LoggingUtility.Warning(result.StandardError);
                    }

                    if (!string.IsNullOrEmpty(result.StandardOutput)) {
                        LoggingUtility.Info(result.StandardOutput);
                    }
                }
            }
        }
    }
}
