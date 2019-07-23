using System;
using System.Threading;

namespace Combat_and_Catacombs {
    class Game {
        static void Main(string[] args) {
            bool quitting = false;
            Vector2 playerpos = new Vector2(4,4);

            while (!quitting) {
                string input = Console.ReadKey(true).Key.ToString().ToLower();
                switch (input) {
                    case "i":
                    case "n":
                        if (playerpos.y != 0) {
                            playerpos.y--;
                        }
                        break;
                    case "k":
                    case "s":
                        if (playerpos.y != 9) {
                            playerpos.y++;
                        }
                        break;
                    case "j":
                    case "w":
                        if(playerpos.x != 0) {
                            playerpos.x--;
                        }
                        break;
                    case "l":
                    case "e":
                        if (playerpos.x != 9) {
                            playerpos.x++;
                        }
                        break;
                }
                Console.WriteLine(playerpos);

                quitting = CommandParser.Parse(input);
            }
            Console.WriteLine("Quitting...");
            Thread.Sleep(2000);
        }
    }
}
