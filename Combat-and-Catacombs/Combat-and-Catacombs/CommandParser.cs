using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public static class CommandParser {
        public static bool Parse(string stringToParse) {
            //Console.WriteLine(stringToParse);
            return stringToParse.ToLower() == "quit";
        }
    }
}
