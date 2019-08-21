using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public class RandomTable<T> {

        public T[] possibleThings;
        public double[] chances;

        public RandomTable(T[] things, double[] thingChances) {

            possibleThings = things;
            chances = new double[thingChances.Length + 1];
            chances[0] = 0.0;
            for (int i = 0; i < thingChances.Length; i++) {
                chances[i + 1] = thingChances[i];
            }

            if (things.Length != thingChances.Length) {
                throw new FormatException("things.Length and thingChances.Length should be the same!");
            }

            for (int i = 1; i < things.Length; i++) {
                if (thingChances[i] <= thingChances[i - 1]) {
                    throw new FormatException("thingChances must be in ascending order!");
                }
            }
        }

        public T PickRandomly() {
            double random = Game.r.NextDouble() * chances[chances.Length - 1];
            T currentPick = possibleThings[0];
            for (int i = 1; i < possibleThings.Length; i++) {
                if (random > chances[i]) {
                    currentPick = possibleThings[i];
                } else {
                    return currentPick;
                }
            }
            return currentPick;
        }
    }
}
