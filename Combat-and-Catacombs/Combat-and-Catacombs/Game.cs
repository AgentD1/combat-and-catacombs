using System;
using System.Threading;

namespace Combat_and_Catacombs {
    static class Game {
        public static Player p;
        static void Main(string[] args) {
            p = new Player() {
                roomPosition = new Vector2(5, 5)
            };
            bool quitting = false;
            bool displaypos;

            while (!quitting) {
                string input = Console.ReadKey(true).Key.ToString().ToLower();
                displaypos = true;
                MapDrawer.PrintMap();
                switch (input) {
                    case "i":
                    case "n":
                        if (p.roomPosition.y != 1) {
                            p.roomPosition.y--;
                        }
                        break;
                    case "k":
                    case "s":
                        if (p.roomPosition.y != MapDrawer.MAP_HEIGHT) {
                            p.roomPosition.y++;
                        }
                        break;
                    case "j":
                    case "w":
                        if(p.roomPosition.x != 1) {
                            p.roomPosition.x--;
                        }
                        break;
                    case "l":
                    case "e":
                        if (p.roomPosition.x != MapDrawer.MAP_WIDTH) {
                            p.roomPosition.x++;
                        }
                        break;
                    default:
                        displaypos = false;
                        break;
                }
                if (displaypos) {
                    Console.WriteLine(p.roomPosition);
                    Console.WriteLine(MapDrawer.rooms[p.roomPosition.x - 1, p.roomPosition.y - 1].givename());
                    Console.WriteLine(MapDrawer.rooms[p.roomPosition.x - 1, p.roomPosition.y - 1].describe());
                }
                
                quitting = CommandParser.Parse(input);
            }
            Console.WriteLine("Quitting...");
            Thread.Sleep(2000);
        }
    }
}
