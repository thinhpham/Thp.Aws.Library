using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Thp.Har.Utility {
    public class NetworkUtility {
        public static List<IPAddress> GetCurrentIpV4() {
            var list = new List<IPAddress>();
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList) {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                    list.Add(ip);
                }
            }

            return list;
        }

        public static List<IPAddress> GetCurrentIpV6() {
            var list = new List<IPAddress>();
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList) {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) {
                    list.Add(ip);
                }
            }

            return list;
        }

        public static List<IPAddress> GetCurrentIp() {
            var list = GetCurrentIpV4();
            list.AddRange(GetCurrentIpV6());
            return list;
        }
    }
}
