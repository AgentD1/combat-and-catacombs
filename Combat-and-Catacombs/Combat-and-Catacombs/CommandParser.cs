using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public static class CommandParser {
        public static bool Parse(string keyPressed, Player p) {
            bool displayInfo = true;
            bool displayPos = false;

            //
            // We're using A C E I J K L N P Q S W
            // 

            switch (keyPressed) {
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
                    if (p.roomPosition.x != 1) {
                        p.roomPosition.x--;
                    }
                    break;
                case "l":
                case "e":
                    if (p.roomPosition.x != MapDrawer.MAP_WIDTH) {
                        p.roomPosition.x++;
                    }
                    break;
                case "p":
                    if (Game.mapDrawer.rooms[p.areaPosition - 1, p.roomPosition.x - 1, p.roomPosition.y - 1].mobscleared == false) {
                        p.xp += Combat.EngageCombat(p, Game.mapDrawer.rooms[p.areaPosition - 1, p.roomPosition.x - 1, p.roomPosition.y - 1].mobs);
                    } else {
                        displayInfo = false;
                    }
                    break;
                case "m":
                    displayPos = true;
                    displayInfo = false;
                    break;
                case "q":
                    if (p.areaPosition != MapDrawer.AREAS) {
                        p.areaPosition += 1;
                        p.roomPosition.x = 5;
                        p.roomPosition.y = 5;
                    }
                    break;
                case "a":
                    if (p.areaPosition != 1) {
                        p.areaPosition -= 1;
                        p.roomPosition.x = 5;
                        p.roomPosition.y = 5;
                    }
                    break;
                case "c":
                    p.inventory.EnterInventoryMenu();
                    break;
                case "x":
                    p.ShowStats();
                    displayInfo = false;
                    break;
                default:
                    Console.WriteLine("Move (NSEW), Engage in Combat (P), Open Inventory (C), Exit (X)");
                    displayInfo = false;
                    break;
            }
            if (displayInfo) {
                Game.mapDrawer.rooms[p.areaPosition - 1, p.roomPosition.x - 1, p.roomPosition.y - 1].DisplayRoomInformation();
            }
            if (displayPos) {
                Game.mapDrawer.PrintMap(p.roomPosition);
            }
            if (Game.mapDrawer.rooms[p.areaPosition - 1, p.roomPosition.x - 1, p.roomPosition.y - 1].mobscleared == false) {
                p.xp += Combat.EngageCombat(p, Game.mapDrawer.rooms[p.areaPosition - 1, p.roomPosition.x - 1, p.roomPosition.y - 1].mobs);
            }
            return keyPressed.ToLower() == "x";
        }


    }
}
