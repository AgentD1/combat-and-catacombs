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
                maxhealth = 999999,
                health = 999999,
                damage = 8,
                agility = 2,
                resistance = 2,
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
                string input = Console.ReadKey(true).Key.ToString().ToLower();
                Console.WriteLine();
                CommandParser.Parse(input, p);
            }
            Console.WriteLine("Quitting...");
            Thread.Sleep(2000);
        }
    }
}
