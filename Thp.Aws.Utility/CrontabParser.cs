using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Thp.Har.Utility {
    public class CrontabParser {
        private string m_CrontabEntry;
        public string CrontabEntry {
            get { return m_CrontabEntry; }
            set {
                m_CrontabEntry = value;
                ReadCrontab(m_CrontabEntry);
            }
        }

        public List<int> Months { get; set; }
        public List<int> DaysOfMonth { get; set; }
        public List<int> DaysOfWeek { get; set; }
        public List<int> Hours { get; set; }
        public List<int> Minutes { get; set; }

        public CrontabParser() {
        }

        private static bool Contains(IList list, int val) {
            // -1 represents the star * from the crontab
            return list.Contains(val) || list.Contains(-1);
        }

        //private static int GetDayOfMonth(DateTime date) {
        //    date.AddMonths(-(date.Month - 1));
        //    return date.DayOfYear;
        //}

        //private static int GetDayOfWeek(DateTime date) {
        //    if (date.DayOfWeek.Equals(DayOfWeek.Sunday))
        //        return 7;
        //    else
        //        return (int)date.DayOfWeek;
        //}

        private void ReadCrontab(string line) {
            line = line.Trim();

            if (line.Length == 0 || line.StartsWith("#"))
                return;

            // re-escape space- and backslash-escapes in a cheap fashion
            line = line.Replace("\\\\", "<BACKSLASH>");
            line = line.Replace("\\ ", "<SPACE>");

            // split string on whitespace
            String[] cols = line.Split(new[] { ' ', '\t' });

            for (int i = 0; i < cols.Length; i++) {
                cols[i] = cols[i].Replace("<BACKSLASH>", "\\");
                cols[i] = cols[i].Replace("<SPACE>", " ");
            }

            if (cols.Length < 5) {
                throw new ArgumentException("Parse error in crontab (line too short).");
            }

            Minutes = ParseTimes(cols[0], 0, 59);
            Hours = ParseTimes(cols[1], 0, 23);
            Months = ParseTimes(cols[3], 1, 12);

            if (!cols[2].Equals("*") && cols[3].Equals("*")) {
                // every n monthdays, disregarding weekdays
                DaysOfMonth = ParseTimes(cols[2], 1, 31);
                DaysOfWeek = new List<int>();
                DaysOfWeek.Add(-1); // empty value
            } else if (cols[2].Equals("*") && !cols[3].Equals("*")) {
                // every n weekdays, disregarding monthdays
                DaysOfMonth = new List<int>();
                DaysOfMonth.Add(-1); // empty value
                DaysOfWeek = ParseTimes(cols[4], 0, 6); // 60 * 24 * 7
            } else {
                // every n weekdays, every m monthdays
                DaysOfMonth = ParseTimes(cols[2], 1, 31);
                DaysOfWeek = ParseTimes(cols[4], 0, 6); // 60 * 24 * 7
            }
        }

        private static List<int> ParseTimes(String line, int startNr, int maxNr) {
            var vals = new List<int>();

            var list = line.Split(new char[] { ',' });

            foreach (String entry in list) {
                int start, end, interval;

                string[] parts = entry.Split(new char[] { '-', '/' });

                if (parts[0].Equals("*")) {
                    if (parts.Length > 1) {
                        start = startNr;
                        end = maxNr;

                        interval = int.Parse(parts[1]);
                    } else {
                        // put a -1 in place
                        //start = -1;
                        //end = -1;
                        start = startNr;
                        end = maxNr;
                        interval = 1;
                    }
                } else {
                    // format is 0-8/2
                    start = int.Parse(parts[0]);
                    end = parts.Length > 1 ? int.Parse(parts[1]) : int.Parse(parts[0]);
                    interval = parts.Length > 2 ? int.Parse(parts[2]) : 1;
                }

                for (int i = start; i <= end; i += interval) {
                    vals.Add(i);
                }
            }
            return vals;
        }
    }
}
