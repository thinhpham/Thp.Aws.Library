using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedulerEngine;

namespace Thp.Har.Utility.SchedulerTasks {
    public class CleanupOldLogFilesTask : ITask {
        public const string Name = "CleanupOldLogFilesTask";

        public void HandleConditionsMetEvent(object sender, ConditionsMetEventArgs e) {
            LoggingUtility.CleanupOldLogFiles();
        }

        public void Initialize(ScheduleDefinition schedule, object parameters) {
            
        }
    }
}
