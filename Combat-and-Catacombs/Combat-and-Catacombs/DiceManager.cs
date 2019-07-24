using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    static class DiceManager {
        static Random r = new Random();

        public static int RollDice(int sides = 20, int num = 1, int bonus = 0, int advantage = 0) {
            if (advantage > 0) {
                int a = RollDice(sides, num, bonus, advantage - 1);
                int b = RollDice(sides, num, bonus, advantage - 1);
                return Math.Max(a, b);
            } else if (advantage < 0) {
                int a = RollDice(sides, num, bonus, advantage + 1);
                int b = RollDice(sides, num, bonus, advantage + 1);
                return Math.Min(a, b);
            } else {
                int total = 0;
                for (int i = 0; i < num; i++) {
                    if (advantage == 0) {
                        total += (int)Math.Ceiling(r.NextDouble() * sides);
                    }
                }
                total += bonus;
                return total;
            }
        }
    }
}
