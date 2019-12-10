using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public static class TableMaker {
        public static string[] Rowify(string[] inputStrings, int[] expandTo) {
            /*if (inputStrings == null || inputStrings.Length == 0 || inputStrings.Contains(null)) {
                return new string[] { "" };
            }
            int largest = 0;
            foreach (string s in inputStrings) {
                if (s.Length > largest) {
                    largest = s.Length;
                }
            }

            largest++;*/

            string[] newStrings = (string[])inputStrings.Clone();

            for (int index = 0; index < inputStrings.Length; index++) {
                if (inputStrings[index] == null) {
                    continue;
                }
                string s = inputStrings[index];
                int length = s.Length;
                string temp = s;
                for (int i = 0; i < expandTo[index] - length; i++) {
                    temp += " ";
                }
                newStrings[index] = temp;
            }

            return newStrings;
        }

        public static string[] Tableify(string[][] inputStrings) {
            int[] largest = new int[inputStrings[0].Length];
            for (int i = 0; i < inputStrings[0].Length; i++) { // For each column
                int bigOne = 0;
                for (int j = 0; j < inputStrings.Length; j++) { // and each row
                    if (inputStrings[j][i] == null) {
                        continue;
                    }
                    if (inputStrings[j][i].Length > bigOne) {
                        bigOne = inputStrings[j][i].Length;
                    }
                }
                largest[i] = bigOne + 2;
            }

            string[] rows = new string[inputStrings.Length];
            for (int i = 0; i < inputStrings.Length; i++) {
                string[] toCombine = Rowify(inputStrings[i], largest);
                string combined = "";
                for (int j = 0; j < toCombine.Length; j++) {
                    combined += toCombine[j];
                }
                rows[i] = combined;
            }
            return rows;
        }
    }
}
