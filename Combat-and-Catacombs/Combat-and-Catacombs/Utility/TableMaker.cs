using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public static class TableMaker {
        public static string[] Rowify(string[] inputStrings) {
            int largest = 0;
            foreach (string s in inputStrings) {
                if (s.Length > largest) {
                    largest = s.Length;
                }
            }

            largest++;

            string[] newStrings = (string[]) inputStrings.Clone();

            for (int index = 0; index < inputStrings.Length; index++) {
                string s = inputStrings[index];
                int length = s.Length;
                string temp = s;
                for (int i = 0; i < largest - length; i++) {
                    temp += " ";
                }
                newStrings[index] = temp;
            }

            return newStrings;
        }
    }
}
