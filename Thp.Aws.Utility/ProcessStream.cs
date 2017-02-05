using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Thp.Har.Utility
{
    public class ProcessStream
    {
        private Thread m_StandardOutputThread;
        private Thread m_StandardErrorThread;
        private Process m_Process;

        private string m_StandardOutput = string.Empty;
        public string StandardOutput
        {
            get { return m_StandardOutput; }
        }

        private string m_StandardError = string.Empty;
        public string StandardError
        {
            get { return m_StandardError; }
        }

        public ProcessStream()
        {
            Init();
        }

        public int Read(Process process)
        {
            Init();

            m_Process = process;

            if (m_Process.StartInfo.RedirectStandardOutput)
            {
                m_StandardOutputThread = new Thread(new ThreadStart(ReadStandardOutput));
                m_StandardOutputThread.Start();
            }

            if (m_Process.StartInfo.RedirectStandardError)
            {
                m_StandardErrorThread = new Thread(new ThreadStart(ReadStandardError));
                m_StandardErrorThread.Start();
            }

            if (m_StandardOutputThread != null) m_StandardOutputThread.Join();
            if (m_StandardErrorThread != null) m_StandardErrorThread.Join();

            return 0;
        }

        private void ReadStandardOutput()
        {
            if (m_Process != null && m_Process.StandardOutput != null)
                using (m_Process.StandardOutput)
                    m_StandardOutput = m_Process.StandardOutput.ReadToEnd().Trim();
        }

        private void ReadStandardError()
        {
            if (m_Process != null && m_Process.StandardError != null)
                using (m_Process.StandardError)
                    m_StandardError = m_Process.StandardError.ReadToEnd().Trim();
        }

        private int Init()
        {
            m_StandardError = string.Empty;
            m_StandardOutput = string.Empty;
            m_Process = null;

            Stop();

            return 0;
        }

        public int Stop()
        {
            try { m_StandardOutputThread.Abort(); } catch { }
            try { m_StandardErrorThread.Abort(); } catch { }

            m_StandardOutputThread = null;
            m_StandardErrorThread = null;

            return 0;
        }
    }
}
