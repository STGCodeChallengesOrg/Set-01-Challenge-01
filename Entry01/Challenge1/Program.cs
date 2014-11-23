using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1 {
    class Program {
        static void Main(string[] args) {

            if (args != null && args.Length > 0) {

                string[] sortedValues = Values.Challenge1(args);

                foreach (string v in sortedValues) {
                    Console.WriteLine(v);
                    System.Diagnostics.Debug.WriteLine(v);
                }

            } else {

                string[] values = { "z20", "b20", "m20", "z18", "j", "34y", "z5", "a2", "t7", "m87", "t4" };

                string[] sortedValues = Values.Challenge1(values);

                foreach (string v in sortedValues) {
                    Console.WriteLine(v);
                    System.Diagnostics.Debug.WriteLine(v);
                }

            }

        }
    }

    public class Values {

        private string[] validChars = { "a", "b", "c", "d", "e", "f", 
                                            "g", "h", "i", "j", "k", "l", 
                                            "m", "n", "o", "p", "q", "r",
                                            "s", "t", "u", "v", "w", "r",
                                            "y", "z"};

        public Values(string val) {

            DaValue = val;

            int pos = -1;
            IsValid = true;

            foreach (char c in val) {

                if (validChars.Contains(c.ToString().ToLower())) {
                    pos++;
                } else {
                    break;
                }
            }

            if (pos == -1) {
                IsValid = false;
            } else {
                DaLetter = val.Substring(0, pos + 1);
                try {
                    DaNumber = int.Parse(val.Substring(pos + 1));
                } catch {
                    IsValid = false;
                }
            }

            DaValueOutput = (IsValid) ? DaValue : DaValue + " -> invalid format";
        }

        public string DaValue { get; set; }
        public string DaValueOutput { get; set; }
        public string DaLetter { get; set; }

        public int DaNumber { get; set; }

        public bool IsValid { get; set; }

        public static string[] Challenge1(string[] values) {

            List<Values> vList = new List<Values>();

            foreach (string s in values) {
                vList.Add(new Values(s));
            }

            return (from v in vList.OrderByDescending(m => m.IsValid).ThenBy(m => m.DaLetter).ThenBy(m => m.DaNumber)
                    select v.DaValueOutput).ToArray();

        }
    }

}
