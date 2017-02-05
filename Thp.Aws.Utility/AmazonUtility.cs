using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thp.Har.Utility {
    public class AmazonUtility {
        public static List<string> CreateStringList(string resource) {
            var list = new List<string>();
            list.Add(resource);
            return list;
        }
    }
}
