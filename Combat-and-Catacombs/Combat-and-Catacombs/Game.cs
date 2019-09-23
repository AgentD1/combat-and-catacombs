using System;
using System.Threading;

namespace Combat_and_Catacombs {
    static class Game {
        public static Random r = new Random();
        public static Player p;
        static void Main(string[] args) {
            p = new Player() {
                roomPosition = new Vector2(5, 5),
                areaPosition = 1,
                level = 1,
                xp = 0,
                levelthresholds = new int[] {10,50,125,340,760,1400,2750,4230,7640,10000}, //make stuff happen when thresholds reached now
                maxhealth = 999999,
                health = 999999,
                damage = 8,
                damagerange = 3,
                agility = 2,
                resistance = 0,
                lightmana = 10,
                darkmana = 10,
                inventory = new Inventory(30, p)
            };
            bool quitting = false;

            MapDrawer.PrintMap(p.roomPosition);
            Room myRoom = MapDrawer.rooms[p.areaPosition - 1, p.roomPosition.x - 1, p.roomPosition.y - 1];
            Console.WriteLine(myRoom.givename());
            Console.WriteLine(myRoom.describe());
            if (myRoom.mobscleared == false) {
                Console.WriteLine($"You meet {myRoom.mobs.Length} {myRoom.mobs[0].givename()}");
            } else {
                Console.WriteLine("There are no mobs in this room");
            }
            Console.WriteLine();


            while (!quitting) {
                if (p.xp >= p.levelthresholds[p.level - 1]) {
                    p.LevelUp();
                }
                string input = Console.ReadKey(true).Key.ToString().ToLower();
                Console.WriteLine();
                CommandParser.Parse(input, p);
            }
            Console.WriteLine("Quitting...");
            Thread.Sleep(2000);
        }
    }
}
