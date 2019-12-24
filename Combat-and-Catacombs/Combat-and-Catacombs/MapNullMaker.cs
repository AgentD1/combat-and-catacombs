using System;
using System.Collections.Generic;

namespace Combat_and_Catacombs {
    public static class MapNullMaker
    {
        static HashSet<int> visited_rooms = new HashSet<int>();

        public static bool createNullRoom(Room[,,] rooms, int area, int[][] specialRooms)
        {
            bool okay = false;
            int trycount = 0;
            int[] candidateRoom = new int[2];
            while (!(okay)) {
                do {
                candidateRoom[0] = Game.r.Next(9);
                candidateRoom[1] = Game.r.Next(9);
                } while (candidateRoom == specialRooms[0] || candidateRoom == specialRooms[1] || candidateRoom == specialRooms[0]);
                visited_rooms.Clear(); 
                int[] roomsDim = {rooms.GetLength(1),rooms.GetLength(2)};
                okay = test_access(roomsDim, candidateRoom, specialRooms);
                trycount++;
                if (trycount == 1) {
                    Console.WriteLine("Broke the loop!");
                    break;
                }
            }
            Console.WriteLine("Exited loop!");
            if (okay) {
                rooms[area, candidateRoom[0], candidateRoom[1]] = null;
                Console.WriteLine("Nulled");
                return(true);
            } else {
                return(false);
            }
        }
        static bool test_access(int[] roomsDim, int[] candidateRoom, int[][] specialRooms) {
            int[] haven = {roomsDim[0]/2,roomsDim[1]/2};
            walk_rooms(roomsDim,haven,candidateRoom,specialRooms);

            for (int x = 0;x < roomsDim[0];x++) {
                for (int y = 0;y < roomsDim[1];y++) {
                    int[] targetRoom = {x,y};
                    bool okay = test_access_haven_to_room(roomsDim, targetRoom, candidateRoom, specialRooms);
                    if (!(okay)) {
                        return(false);
                    }
                }
            }
        
            return(true);
        }

        static bool test_access_haven_to_room(int[] roomsDim, int[] targetRoom, int[] candidateRoom, int[][] specialRooms) {
            if (visited_rooms.Contains(roomID(targetRoom))) {
                Console.WriteLine($"Great news! We already visited {targetRoom[0].ToString()}, {targetRoom[1].ToString()}");
                return(true);
            } else {
                Console.WriteLine($"So sad. We can't get to {targetRoom[0].ToString()}, {targetRoom[1].ToString()}");
               return(false);


                //It freaks out because it cant visit boss rooms


            }
        }

        static bool walk_rooms(int[] roomsDim, int[] currentRoom, int[] candidateRoom, int[][] specialRooms) {
            Console.WriteLine($"{currentRoom[0].ToString()}, {currentRoom[1].ToString()}");
            bool result;
            int[] nextRoom;
            
            if (visited_rooms.Contains(roomID(currentRoom))) {
                Console.WriteLine("Been here, done that.");
                return(false);
            }
            //The check "is null" will likely not work, but cause an error earlier. Its ok for now I suppose
            if (currentRoom is null || currentRoom == candidateRoom) {
                Console.WriteLine("Null, or Wants to be, or boss");
                    return(false);
            }
            for (int i = 0;i<specialRooms.Length;i++) {
                if (roomID(specialRooms[i]) == roomID(currentRoom)) {
                    Console.WriteLine("Null, or Wants to be, or boss");
                    return(false);
                }
            }
            visited_rooms.Add(roomID(currentRoom));
            Console.WriteLine($"Visited Room --- {currentRoom[0].ToString()}, {currentRoom[1].ToString()}");
            if (can_go(roomsDim, currentRoom, "west")) {
                Console.WriteLine("I can go west!");
                nextRoom = new int[] {currentRoom[0]-1,currentRoom[1]};
                result = walk_rooms(roomsDim,nextRoom,candidateRoom,specialRooms);
                if (result == true) {
                    return(result);
                }
            }
            if (can_go(roomsDim, currentRoom, "east")) {
                Console.WriteLine("I can go east!");
                nextRoom = new int[] {currentRoom[0]+1,currentRoom[1]};
                result = walk_rooms(roomsDim,nextRoom,candidateRoom,specialRooms);
                if (result == true) {
                    return(result);
                }
            }
            if (can_go(roomsDim, currentRoom, "north")) {
                Console.WriteLine("I can go north!");
                nextRoom = new int[] {currentRoom[0],currentRoom[1]-1};
                result = walk_rooms(roomsDim,nextRoom,candidateRoom,specialRooms);
                if (result == true) {
                    return(result);
                }
            }
            if (can_go(roomsDim, currentRoom, "south")) {
                Console.WriteLine("I can go south!");
                nextRoom = new int[] {currentRoom[0],currentRoom[1]+1};
                result = walk_rooms(roomsDim,nextRoom,candidateRoom,specialRooms);
                if (result == true) {
                    return(result);
                }
            }
            return(false);
        }
        static int roomID(int [] pos) {
            return(9*pos[0]+pos[1]);
        }
        static bool can_go(int[] roomsDim, int[] currentRoom, string direction) {
            bool canGo = true;
            switch(direction) {
                case "west":
                    if ((currentRoom[0] - 1) < 0)  {
                        canGo = false;
                    }
                    break;
                case "east":
                    if ((currentRoom[0] + 1) > roomsDim[0] - 1)  {
                        canGo = false;
                    }
                    break;
                case "north":
                    if ((currentRoom[1] - 1) < 0)  {
                        canGo = false;
                    }
                    break;
                case "south":
                    if ((currentRoom[1] + 1) > roomsDim[1] - 1)  {
                        canGo = false;
                    }
                    break;
                default:
                    break;
            }
            return(canGo);
        }
    }
}
