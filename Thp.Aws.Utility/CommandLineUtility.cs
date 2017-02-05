using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Security;

namespace Thp.Har.Utility {
    public class CommandLineExecutionStatus {
        public string StandardOutput { get; set; }
        public string StandardError { get; set; }
        public int ExitCode { get; set; }
    }

    public class CommandLineUtility {
        //public static CommandLineExecutionStatus ExecuteCommandLine(string workingDirectory, string filename, string arguments, bool waitForExit) {
        //    return ExecuteCommandLine(workingDirectory, filename, arguments, null, null, waitForExit);
        //}

        public static CommandLineExecutionStatus ExecuteCommandLine(string workingDirectory, string filename, string arguments, string username, string password, bool waitForExit, ProcessPriorityClass priorityClass) {
            using (var process = new Process()) {
                var processInfo = new ProcessStartInfo();
                var processStream = new ProcessStream();
                var processOutput = string.Empty;
                var processError = string.Empty;
                var processExitCode = 0;

                processInfo.RedirectStandardInput = false;
                processInfo.RedirectStandardOutput = true;
                processInfo.RedirectStandardError = true;
                processInfo.ErrorDialog = false;
                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = true;
                processInfo.WindowStyle = ProcessWindowStyle.Hidden;

                if (!string.IsNullOrEmpty(username)) {
                    var idx = username.IndexOf("\\");

                    if (idx > -1) {
                        processInfo.Domain = username.Substring(0, idx);
                        processInfo.UserName = username.Substring(idx + 1, username.Length - idx - 1);
                    } else {
                        processInfo.UserName = username;
                    }

                    LoggingUtility.Debug("Use assigned username");
                }

                if (!string.IsNullOrEmpty(password)) {
                    var securePassword = new SecureString();
                    foreach (var c in password) {
                        securePassword.AppendChar(c);
                    }
                    processInfo.Password = securePassword;
                    LoggingUtility.Debug("Use assigned password");
                }

                if (!string.IsNullOrEmpty(workingDirectory)) {
                    processInfo.WorkingDirectory = workingDirectory;
                }

                processInfo.FileName = filename;
                processInfo.Arguments = arguments;

                process.StartInfo = processInfo;
                process.Start();

                if (process.PriorityClass != priorityClass) {
                    process.PriorityClass = priorityClass;
                }

                processStream.Read(process);

                if (waitForExit) {
                    process.WaitForExit();
                }

                processOutput = processStream.StandardOutput;
                processError = processStream.StandardError;
                processExitCode = process.ExitCode;

                return new CommandLineExecutionStatus() { ExitCode = processExitCode, StandardError = processError, StandardOutput = processOutput };
            }
        }
    }
}
