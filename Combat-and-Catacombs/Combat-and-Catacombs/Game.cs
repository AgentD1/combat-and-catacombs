using System;
using System.Threading;

namespace Combat_and_Catacombs {
    class Game {
        static void Main(string[] args) {
            bool quitting = false;
            int[] playerpos = {4,4};

            while (!quitting) {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "N":
                        if (playerpos[0] != 0)
                        {
                            playerpos[0] -= 1;
                        }
                    case "S":
                        if (playerpos[0] != 9)
                        {
                            playerpos[0] += 1;
                        }
                }
                quitting = CommandParser.Parse(input);
            }
            Console.WriteLine("Quitting...");
            Thread.Sleep(2000);
        }
    }
}
