using System;
using System.Threading;

namespace Combat_and_Catacombs {
    static class Game {
        public static Player p;
        static void Main(string[] args) {
            p = new Player() {
                roomPosition = new Vector2(5, 5),
                areaPosition = 1
            };
            bool quitting = false;
            bool displaypos;
            
            while (!quitting) {
                string input = Console.ReadKey(true).Key.ToString().ToLower();
                displaypos = true;
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
                    case "q":
                        if (p.areaPosition != MapDrawer.AREAS)
                        {
                            p.areaPosition += 1;
                        }
                        break;
                    case "a":
                        if (p.areaPosition != 1)
                        {
                            p.areaPosition -= 1;
                        }
                        break;
                    default:
                        displaypos = false;
                        break;
                }
                if (displaypos) {
                    MapDrawer.PrintMap(p.roomPosition);
                    Console.WriteLine(p.areaPosition.ToString(),p.roomPosition);
                    Console.WriteLine(MapDrawer.rooms[p.areaPosition - 1,p.roomPosition.x - 1, p.roomPosition.y - 1].givename());
                    Console.WriteLine(MapDrawer.rooms[p.areaPosition - 1,p.roomPosition.x - 1, p.roomPosition.y - 1].describe());
                    Console.WriteLine();
                }
                
                quitting = CommandParser.Parse(input);
            }
            Console.WriteLine("Quitting...");
            Thread.Sleep(2000);
        }
    }
}
