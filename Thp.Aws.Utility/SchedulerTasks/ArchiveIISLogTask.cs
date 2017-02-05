using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedulerEngine;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Thp.Har.Utility.SchedulerTasks {
    public class ArchiveIISLogTask : ITask {
        public const string Name = "ArchiveIISLogTask";

        //VaultName,Description,LocalPath,Size,StatusDate,Status,StatusReason,ArchiveId,Checksum
        private const string m_Recordset_Format = "{0},{1},{2},{3},{4},{5},{6},{7},{8}\r\n";

        public void HandleConditionsMetEvent(object sender, ConditionsMetEventArgs e) {
            var uploadThread = new Thread(new ThreadStart(UploadZipFile));
            uploadThread.Start();

            var zipThread = new Thread(new ThreadStart(ZipLogFile));
            zipThread.Start();
        }

        private void UploadZipFile() {
            var now = DateTime.Now;
            var hostname = CommonUtility.GetUniqueHostId();
            var archiveId = string.Empty;
            var checksum = string.Empty;
            var uploadRecord = string.Empty;

            if (Directory.Exists(CacheObject.Settings.ArchiveIISLogTempPath)) {
                var tempPathInfo = new DirectoryInfo(CacheObject.Settings.ArchiveIISLogTempPath);

                foreach (var zipFileInfo in tempPathInfo.EnumerateFiles()) {
                    if ((now - zipFileInfo.LastWriteTime).Days > 14) {
                        var size = zipFileInfo.Length;
                        var description = string.Format("Machine: {0} - File: {1} - Size: {2} - Created: {3}", hostname, zipFileInfo.Name, size, zipFileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));

                        try {
                            LoggingUtility.Info(string.Format("Uploading archive file older than 14 days. Filename: {0}", zipFileInfo.FullName));
                            var uploadResult = AmazonGlacierUtility.UploadArchive(CacheObject.Settings.DefaultRegionEndpoint, CacheObject.Settings.ArchiveIISLogVaultName, description, zipFileInfo.FullName);
                            archiveId = uploadResult.ArchiveId;
                            checksum = uploadResult.Checksum;
                            LoggingUtility.Info(string.Format("Successfully uploaded zip file {0} with ArchiveId {1}", zipFileInfo.Name, archiveId));

                            if (CacheObject.Settings.ArchiveIISLogDeleteOnSuccess) {
                                LoggingUtility.Info(string.Format("Deleting archive file after upload. Filename: {0}", zipFileInfo.FullName));
                                File.Delete(zipFileInfo.FullName);
                            }

                            uploadRecord = string.Format(m_Recordset_Format, CacheObject.Settings.ArchiveIISLogVaultName, description, zipFileInfo.Name, size, DateTime.Now, "Success", "Finished", archiveId, checksum);
                        } catch (Exception ex) {
                            LoggingUtility.Warning(ex);
                            uploadRecord = string.Format(m_Recordset_Format, CacheObject.Settings.ArchiveIISLogVaultName, description, zipFileInfo.Name, size, DateTime.Now, "Failed", ex.Message, archiveId, checksum);
                        }

                        if (!string.IsNullOrEmpty(uploadRecord)) {
                            File.AppendAllText(CacheObject.Settings.ArchiveIISLogRecordsetPath, uploadRecord);
                        }
                    }
                }
            }
        }

        private static void ZipLogFile() {
            const string archive_7z_name = "7z";

            if (CommonUtility.IsProcessRunning(archive_7z_name)) {
                LoggingUtility.Info("Archiving process is currently running. Will retry later when current process is done");
                return;
            }

            if (string.IsNullOrEmpty(CacheObject.Settings.ZipCommand)) {
                throw new Exception("Zip command is not specified");
            }
            if (string.IsNullOrEmpty(CacheObject.Settings.ArchiveIISLogItems)) {
                throw new Exception("IIS log items not specified for archival");
            }
            if (string.IsNullOrEmpty(CacheObject.Settings.ArchiveIISLogVaultName)) {
                throw new Exception("Glacier vault name not specified for archival");
            }

            var items = CacheObject.Settings.ArchiveIISLogItems.Split(CommonUtility.ITEM_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in items) {
                var dirToArchive = item.Trim();

                LoggingUtility.Info(string.Format("Begin archiving folder {0}", dirToArchive));

                if (CommonUtility.DirectoryHasFiles(dirToArchive)) {
                    var hostname = CommonUtility.GetUniqueHostId();
                    var dirInfo = new DirectoryInfo(dirToArchive);
                    var zipFile = Path.Combine(CacheObject.Settings.ArchiveIISLogTempPath, hostname + "-" + dirInfo.Name + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".7z");
                    var archiveId = string.Empty;
                    var checksum = string.Empty;
                    var uploadRecord = string.Empty;

                    try {
                        LoggingUtility.Info(string.Format("Zipping folder {0} into file {1}", dirToArchive, zipFile));
                        var zipArguments = string.Format("a -t7z -mx5 \"{0}\" \"{1}\"", zipFile, dirToArchive);
                        var zipResult = CommandLineUtility.ExecuteCommandLine(null, CacheObject.Settings.ZipCommand, zipArguments, null, null, true, ProcessPriorityClass.BelowNormal);

                        // Also set the 7z.exe process priority to below normal
                        var proc = CommonUtility.GetProcessByName(archive_7z_name);
                        if (proc != null) {
                            proc.PriorityClass = ProcessPriorityClass.BelowNormal;
                        }

                        if (zipResult.ExitCode == 0) {
                            LoggingUtility.Info(string.Format("Successfully zipped folder {0} into file {1}", dirToArchive, zipFile));

                            if (CacheObject.Settings.ArchiveIISLogDeleteOnSuccess) {
                                LoggingUtility.Info(string.Format("Deleting children files/folders of {0} after zipping", dirToArchive));
                                CommonUtility.DeleteFilesRecursively(dirInfo, 2);
                            }
                        } else {
                            LoggingUtility.Warning(string.Format("Problem zipping folder {0}. Error message: {1}", zipResult.StandardError));
                        }
                    } catch (Exception ex) {
                        LoggingUtility.Warning(ex);
                    }
                }
            }
        }

        public void Initialize(ScheduleDefinition schedule, object parameters) {

        }
    }
}
