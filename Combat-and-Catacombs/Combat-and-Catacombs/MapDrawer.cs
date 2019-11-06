using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public static class MapDrawer {
        public const int MAP_WIDTH = 9;
        public const int MAP_HEIGHT = 9;
        public const int AREAS = 9;

        public static Room[,,] rooms = new Room[AREAS, MAP_WIDTH, MAP_HEIGHT];

        static MapDrawer() {
            Random rand = new Random();
            for (int a = 0; a < AREAS; a++) {
                for (int x = 0; x < MAP_WIDTH; x++) {
                    for (int y = 0; y < MAP_HEIGHT; y++) {
                        switch (a) {
                            case 0:
                                rooms[a, x, y] = (Room)Activator.CreateInstance(AreaTables.area1roomtable.PickRandomly());
                                rooms[a, x, y].mobs = AreaTables.CreateMobs(AreaTables.area1mobtable.PickRandomly());
                                rooms[a, x, y].mobscleared = false;
                                break;
                            case 1:
                                rooms[a, x, y] = (Room)Activator.CreateInstance(AreaTables.area2roomtable.PickRandomly());
                                rooms[a, x, y].mobs = AreaTables.CreateMobs(AreaTables.area1mobtable.PickRandomly());
                                rooms[a, x, y].mobscleared = false;
                                break;
                            default:
                                rooms[a, x, y] = (Room)Activator.CreateInstance(AreaTables.area2roomtable.PickRandomly());
                                rooms[a, x, y].mobs = AreaTables.CreateMobs(AreaTables.area1mobtable.PickRandomly());
                                rooms[a, x, y].mobscleared = false;
                                break;
                        }
                    }
                }
                rooms[a, 4, 4] = new Haven();
                rooms[a, 4, 4].mobscleared = true;
                int[] GiantLairPos  = {Game.r.Next(8),Game.r.Next(8)};
                while ((rooms[a,GiantLairPos[0],GiantLairPos[1]] is Haven) || (rooms[a,GiantLairPos[0],GiantLairPos[1]] is CryptGate)) {
                    GiantLairPos[0]  = Game.r.Next(8);
                    GiantLairPos[1]  = Game.r.Next(8);
                }
                rooms[a,GiantLairPos[0],GiantLairPos[1]] = new GiantLair();
                int[] CryptGatePos  = {Game.r.Next(8),Game.r.Next(8)};
                while ((rooms[a,CryptGatePos[0],CryptGatePos[1]] is Haven) || (rooms[a,CryptGatePos[0],CryptGatePos[1]] is GiantLair)) {
                    CryptGatePos[0]  = Game.r.Next(8);
                    CryptGatePos[1]  = Game.r.Next(8);
                }
                rooms[a,CryptGatePos[0],CryptGatePos[1]] = new CryptGate();
            }
        }

        public static void PrintMap(Vector2 playerpos) {
            for (int y = 0; y < MAP_HEIGHT; y++) {
                for (int x = 0; x < MAP_WIDTH; x++) {
                    if (x == playerpos.x - 1 && y == playerpos.y - 1) {
                        Console.Write($"({rooms[Game.p.areaPosition - 1, x, y].renderChar()})");
                    } else {
                        Console.Write($" {rooms[Game.p.areaPosition - 1, x, y].renderChar()} ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
