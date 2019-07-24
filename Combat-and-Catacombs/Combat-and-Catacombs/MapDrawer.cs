﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public static class MapDrawer {
        public const int MAP_WIDTH = 9;
        public const int MAP_HEIGHT = 9;

        public static Room[,] rooms = new Room[MAP_WIDTH, MAP_HEIGHT];

        static MapDrawer() {
            Random rand = new Random();
            for (int x = 0; x < MAP_WIDTH; x++) {
                for (int y = 0; y < MAP_HEIGHT; y++) {
                    rooms[x, y] = RoomFactory.GetRoom();
                }
            }
        }

        public static void PrintMap() {
            for (int x = 0; x < MAP_WIDTH; x++) {
                for (int y = 0; y < MAP_HEIGHT; y++) {
                    Console.Write(rooms[x, y].mapRenderChar);
                }
                Console.Write("\n");
            }
        }
    }
}
