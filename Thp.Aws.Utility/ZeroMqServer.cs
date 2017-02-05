using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroMQ;
using System.Threading;

namespace Thp.Har.Utility {
    public class ZeroMqServer {
        ZmqContext m_Context = null;
        ZmqSocket m_Socket = null;
        private bool m_Running = true;

        public ZeroMqServer() {
            m_Context = ZmqContext.Create();
            m_Socket = m_Context.CreateSocket(SocketType.XPUB);
        }

        public void Start() {
            Console.WriteLine("ZeroMqServer started");
            m_Socket.Bind(System.Configuration.ConfigurationManager.AppSettings["ZmqBinding"]);
            m_Running = true;

            while (m_Running) {
                string message = m_Socket.Receive(Encoding.Unicode);
                Thread.Sleep(1);
                Console.WriteLine(message);
                m_Socket.Send(message, Encoding.Unicode);
            }
        }

        public void Stop() {
            Console.WriteLine("ZeroMqServer stopped");
            m_Socket.Close();
            m_Running = false;
        }
    }
}
