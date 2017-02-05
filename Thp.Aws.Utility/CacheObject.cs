using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using Amazon;

namespace Thp.Har.Utility {
    public sealed class CacheObject {
        #region Instance Object
        private static volatile CacheObject m_Settings;
        private static object m_Syncroot = new object();

        public static CacheObject Settings {
            get {
                if (m_Settings == null) {
                    lock (m_Syncroot) {
                        if (m_Settings == null) {
                            m_Settings = new CacheObject();
                        }
                    }
                }

                return m_Settings;
            }
        }
        #endregion

        public byte[] EncryptKey = null;
        public byte[] SigningKey = null;

        public string ApiUrl = null;

        public LogLevelEnum LogLevel = LogLevelEnum.Info;
        public string LogDirectory;
        public string TempDirectory = @"C:\Temp";
        public int LogRententionInDays;
        public string ZipCommand;

        public string AWSAccessKey;
        public string AWSSecretKey;
        
        public string OwnerId;
        public string DefaultOwnerId;

        public RegionEndpoint DefaultRegionEndpoint = RegionEndpoint.USEast1;

        public string GitHubCommand;
        public string GitHubItems;
        
        public bool RobocopyEnabled;
        public string RobocopySchedule;
        public int RobocopyInterval = 60000;
        public string RobocopyCommand = "robocopy.exe";
        public string RobocopyUsername;
        public string RobocopyPassword;
        public string RobocopyItems;
        public string RobocopyExcludedFiles;
        public string RobocopyExcludedDirectories;
        public string RobocopyFlag;


        public bool CopyIISLogEnabled;
        public string CopyIISLogSchedule;
        public string CopyIISLogUsername;
        public string CopyIISLogPassword;
        public string CopyIISLogItems;
        public bool CopyIISLogDeleteOnSuccess = true;

        public bool ArchiveIISLogEnabled;
        public string ArchiveIISLogItems;
        public string ArchiveIISLogVaultName;
        public string ArchiveIISLogSchedule;
        public string ArchiveIISLogRecordsetPath;
        public string ArchiveIISLogTempPath;
        public bool ArchiveIISLogDeleteOnSuccess = true;

        public bool FileSystemWatcherEnabled;
        public string FileSystemWatcherUsername;
        public string FileSystemWatcherPassword;
        public string FileSystemWatcherItems;
        public string FileSystemWatcherFlag;

        public bool DynamoDbRefreshEnabled;

        public CacheObject() {
            try {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EncryptKey"])) {
                    EncryptKey = CryptographyUtility.HexStringToByteArray(ConfigurationManager.AppSettings["EncryptKey"]);
                }
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SigningKey"])) {
                    SigningKey = CryptographyUtility.HexStringToByteArray(ConfigurationManager.AppSettings["SigningKey"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ApiUrl"])) {
                    ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LogLevel"])) {
                    LogLevel = (LogLevelEnum)Enum.Parse(typeof(LogLevelEnum), ConfigurationManager.AppSettings["LogLevel"]);
                }
                LogDirectory = ConfigurationManager.AppSettings["LogDirectory"];
                if (!string.IsNullOrEmpty(LogDirectory) && !Directory.Exists(LogDirectory)) {
                    Directory.CreateDirectory(LogDirectory);
                }
                if (!Directory.Exists(TempDirectory)) {
                    Directory.CreateDirectory(TempDirectory);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LogRententionInDays"])) {
                    LogRententionInDays = int.Parse(ConfigurationManager.AppSettings["LogRententionInDays"]);
                } else {
                    LogRententionInDays = 21;
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DefaultRegionEndpoint"])) {
                    var tmp = ConfigurationManager.AppSettings["DefaultRegionEndpoint"];
                    DefaultRegionEndpoint = AmazonEC2Utility.GetRegionEndpoint(tmp);
                }

                AWSAccessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
                AWSSecretKey = ConfigurationManager.AppSettings["AWSSecretKey"];
                DefaultOwnerId = ConfigurationManager.AppSettings["DefaultOwnerId"];
                ZipCommand = ConfigurationManager.AppSettings["ZipCommand"];


                GitHubCommand = ConfigurationManager.AppSettings["GitHubCommand"];
                GitHubItems = ConfigurationManager.AppSettings["GitHubItems"];


                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["RobocopyEnabled"])) {
                    RobocopyEnabled = bool.Parse(ConfigurationManager.AppSettings["RobocopyEnabled"]);
                }
                RobocopySchedule = ConfigurationManager.AppSettings["RobocopySchedule"];
                RobocopyCommand = ConfigurationManager.AppSettings["RobocopyCommand"];
                RobocopyUsername = ConfigurationManager.AppSettings["RobocopyUsername"];
                RobocopyPassword = ConfigurationManager.AppSettings["RobocopyPassword"];
                RobocopyItems = ConfigurationManager.AppSettings["RobocopyItems"];
                RobocopyExcludedFiles = ConfigurationManager.AppSettings["RobocopyExcludedFiles"];
                RobocopyExcludedDirectories = ConfigurationManager.AppSettings["RobocopyExcludedDirectories"];
                RobocopyFlag = ConfigurationManager.AppSettings["RobocopyFlag"];


                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["CopyIISLogEnabled"])) {
                    CopyIISLogEnabled = bool.Parse(ConfigurationManager.AppSettings["CopyIISLogEnabled"]);
                }
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["CopyIISLogDeleteOnSuccess"])) {
                    CopyIISLogDeleteOnSuccess = bool.Parse(ConfigurationManager.AppSettings["CopyIISLogDeleteOnSuccess"]);
                }
                CopyIISLogSchedule = ConfigurationManager.AppSettings["CopyIISLogSchedule"];
                CopyIISLogUsername = ConfigurationManager.AppSettings["CopyIISLogUsername"];
                CopyIISLogPassword = ConfigurationManager.AppSettings["CopyIISLogPassword"];
                CopyIISLogItems = ConfigurationManager.AppSettings["CopyIISLogItems"];


                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ArchiveIISLogEnabled"])) {
                    ArchiveIISLogEnabled = bool.Parse(ConfigurationManager.AppSettings["ArchiveIISLogEnabled"]);
                }
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ArchiveIISLogDeleteOnSuccess"])) {
                    ArchiveIISLogDeleteOnSuccess = bool.Parse(ConfigurationManager.AppSettings["ArchiveIISLogDeleteOnSuccess"]);
                }
                ArchiveIISLogSchedule = ConfigurationManager.AppSettings["ArchiveIISLogSchedule"];
                ArchiveIISLogItems = ConfigurationManager.AppSettings["ArchiveIISLogItems"];
                ArchiveIISLogVaultName = ConfigurationManager.AppSettings["ArchiveIISLogVaultName"];
                ArchiveIISLogRecordsetPath = ConfigurationManager.AppSettings["ArchiveIISLogRecordsetPath"];
                if (string.IsNullOrEmpty(ArchiveIISLogRecordsetPath)) {
                    ArchiveIISLogRecordsetPath = Path.Combine(Directory.GetCurrentDirectory(), "aws_glacier_recordset.csv");
                }
                ArchiveIISLogTempPath = ConfigurationManager.AppSettings["ArchiveIISLogTempPath"];
                if (string.IsNullOrEmpty(ArchiveIISLogTempPath)) {
                    ArchiveIISLogTempPath = Path.GetTempPath();
                }


                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["FileSystemWatcherEnabled"])) {
                    FileSystemWatcherEnabled = bool.Parse(ConfigurationManager.AppSettings["FileSystemWatcherEnabled"]);
                }
                FileSystemWatcherUsername = ConfigurationManager.AppSettings["FileSystemWatcherUsername"];
                FileSystemWatcherPassword = ConfigurationManager.AppSettings["FileSystemWatcherPassword"];
                FileSystemWatcherItems = ConfigurationManager.AppSettings["FileSystemWatcherItems"];
                FileSystemWatcherFlag = ConfigurationManager.AppSettings["FileSystemWatcherFlag"];


                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DynamoDbRefreshEnabled"])) {
                    DynamoDbRefreshEnabled = bool.Parse(ConfigurationManager.AppSettings["DynamoDbRefreshEnabled"]);
                }
            } catch (Exception ex) {
                File.AppendAllText(CommonUtility.CRITICAL_ERROR_FILE, "Thp.Har.Utility.CacheObject. Error: " + ex.ToString());
            }
        }

        public string GetOwnerId() {
            if (string.IsNullOrEmpty(OwnerId)) {
                OwnerId = AmazonEC2Utility.GetOwnerId(null);
            }

            return OwnerId;
        }
    }
}
