using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public class MapDrawer {
        public const int MAP_WIDTH = 9;
        public const int MAP_HEIGHT = 9;
        public const int AREAS = 9;

        public Room[,,] rooms = new Room[AREAS, MAP_WIDTH, MAP_HEIGHT];

        public MapDrawer() {
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
                int[] GiantLairPos = {Game.r.Next(rooms.GetLength(1)),Game.r.Next(rooms.GetLength(2))};
                while ((rooms[a, GiantLairPos[0], GiantLairPos[1]] is Haven) || (rooms[a, GiantLairPos[0], GiantLairPos[1]] is CryptGate)) {
                    GiantLairPos[0] = Game.r.Next(rooms.GetLength(1));
                    GiantLairPos[1] = Game.r.Next(rooms.GetLength(2));
                }
                rooms[a,GiantLairPos[0],GiantLairPos[1]] = new GiantLair();
                int[] CryptGatePos = {Game.r.Next(rooms.GetLength(1)),Game.r.Next(rooms.GetLength(2))};
                while ((rooms[a, CryptGatePos[0], CryptGatePos[1]] is Haven) || (rooms[a, CryptGatePos[0], CryptGatePos[1]] is GiantLair)) {
                    CryptGatePos[0] = Game.r.Next(rooms.GetLength(1));
                    CryptGatePos[1] = Game.r.Next(rooms.GetLength(2));
                }
                rooms[a, CryptGatePos[0], CryptGatePos[1]] = new CryptGate();
                int[] HavenPos = {4,4};
                int[][] specialRooms = {GiantLairPos, CryptGatePos};
                PrintMap(Game.p.roomPosition);
                //for (int r=0;r < 30;r++) {
                    MapNullMaker.createNullRoom(rooms, a, specialRooms);
                //}
            }
        }

        public void PrintMap(Vector2 playerpos) {
            for (int y = 0; y < MAP_HEIGHT; y++) {
                for (int x = 0; x < MAP_WIDTH; x++) {
                    if (rooms[Game.p.areaPosition - 1,x,y] != null) {
                        if (x == playerpos.x - 1 && y == playerpos.y - 1) {
                            Console.Write($"({rooms[Game.p.areaPosition - 1, x, y].renderChar()})");
                        } else {
                            Console.Write($" {rooms[Game.p.areaPosition - 1, x, y].renderChar()} ");
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
