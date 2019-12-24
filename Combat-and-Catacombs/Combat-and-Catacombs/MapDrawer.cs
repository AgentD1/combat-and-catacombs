using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public class MapDrawer {

        //These are here for now to deal with some references in commandparser
        //They will become depandant on the area soon, so those places that use them will be changed
        public const int AREA_WIDTH = 9;
        public const int AREA_HEIGHT = 9;

        public const int AREAS = 9;

        public Area[] rooms = new Area[AREAS];

        public MapDrawer() {
            Random rand = new Random();
            for (int a = 0; a < AREAS; a++) {
                rooms[a] = new Area( AreaTables.roomtables[a], AreaTables.mobtables[a] );
            }
        }

        public void PrintMap(Vector2 playerpos) {
            for (int y = 0; y < AREA_HEIGHT; y++) {
                for (int x = 0; x < AREA_WIDTH; x++) {
                    if (rooms[Game.p.areaPosition - 1].rooms[x, y] != null) {
                        if (x == playerpos.x - 1 && y == playerpos.y - 1) {
                            Console.Write($"({rooms[Game.p.areaPosition - 1].rooms[x, y].renderChar()})");
                        } else {
                            Console.Write($" {rooms[Game.p.areaPosition - 1].rooms[x, y].renderChar()} ");
                        }
                    } else {
                        if (x == playerpos.x - 1 && y == playerpos.y - 1) {
                            Console.WriteLine("( )");
                        } else {
                            Console.Write("   ");
                        }
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
