using System;
using System.Threading;

namespace Combat_and_Catacombs {
    class Game {
        static void Main(string[] args) {
            bool quitting = false;
            Vector2 playerpos = new Vector2(5,5);
            bool displaypos;

            while (!quitting) {
                string input = Console.ReadKey(true).Key.ToString().ToLower();
                displaypos = true;
                switch (input) {
                    case "i":
                    case "n":
                        if (playerpos.y != 1) {
                            playerpos.y--;
                        }
                        break;
                    case "k":
                    case "s":
                        if (playerpos.y != MapDrawer.MAP_HEIGHT) {
                            playerpos.y++;
                        }
                        break;
                    case "j":
                    case "w":
                        if(playerpos.x != 1) {
                            playerpos.x--;
                        }
                        break;
                    case "l":
                    case "e":
                        if (playerpos.x != MapDrawer.MAP_WIDTH) {
                            playerpos.x++;
                        }
                        break;
                    default:
                        displaypos = false;
                        break;
                }
                if (displaypos) {Console.WriteLine(playerpos);}
                    

                quitting = CommandParser.Parse(input);
            }
            Console.WriteLine("Quitting...");
            Thread.Sleep(2000);
        }
    }
}
