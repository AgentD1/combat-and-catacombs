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
                        break;
                    case "S":
                        if (playerpos[0] != 9)
                        {
                            playerpos[0] += 1;
                        }
                        break;
                    case "E":
                        if (playerpos[1] != 9)
                        {
                            playerpos[1] += 1;
                        }
                        break;
                    case "W":
                        if (playerpos[1] != 0)
                        {
                            playerpos[1] -= 1;
                        }
                        break;
                }
                Console.WriteLine($"{playerpos[0]},{playerpos[1]}");
                quitting = CommandParser.Parse(input);
            }
            Console.WriteLine("Quitting...");
            Thread.Sleep(2000);
        }
    }
}
