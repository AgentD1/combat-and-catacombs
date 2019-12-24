using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Combat-and-CatacombsTests")]

namespace Combat_and_Catacombs
{
    public class Area
    {
        private const int AREA_WIDTH = 9;
        private const int AREA_HEIGHT = 9;

        private int width;
        private int height;

        private Room[,] rooms;

        private HashSet<Room> roomSet = new HashSet<Room>();

        private HashSet<Room> visited_rooms = new HashSet<Room>();
        public void setRoom(int x, int y, Room room)
        {
            if (rooms[x, y] != null)
            {
                roomSet.Remove(rooms[x, y]);
            }

            rooms[x, y] = room;
            if (room != null)
            {
                rooms[x, y].x = x;
                rooms[x, y].y = y;
                roomSet.Add(room);
            }
        }
        private void nullRoom(Room room)
        {
            setRoom(room.x, room.y, null);
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public Room getRoom(int x, int y)
        {
            return rooms[x, y];
        }

        public HashSet<Room> getVisitedRooms()
        {
            return visited_rooms;
        }

        public Room getRoom(Vector2 roomPos)
        {
            return getRoom(roomPos.x - 1, roomPos.y - 1);
        }

        public HashSet<Room> getRoomSet()
        {
            return roomSet;
        }

        public Area(RandomTable<Type> arearoomtable, RandomTable<Type> areamobtable,
            int width = AREA_WIDTH, int height = AREA_HEIGHT, 
            bool populate = true, int nullRooms = 30)
        {
            rooms = new Room[width, height];
            this.width = width;
            this.height = height;

            if (!populate)
            {
                return;
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    setRoom(x, y, (Room)Activator.CreateInstance(arearoomtable.PickRandomly()));
                    rooms[x, y].mobs = AreaTables.CreateMobs(areamobtable.PickRandomly());
                    rooms[x, y].mobscleared = false;
                }
            }

            setRoom(4, 4, new Haven());
            rooms[4, 4].mobscleared = true;
            int[] GiantLairPos = { Game.r.Next(rooms.GetLength(0)), Game.r.Next(rooms.GetLength(1)) };
            while ((rooms[GiantLairPos[0], GiantLairPos[1]] is Haven) || (rooms[GiantLairPos[0], GiantLairPos[1]] is CryptGate))
            {
                GiantLairPos[0] = Game.r.Next(rooms.GetLength(0));
                GiantLairPos[1] = Game.r.Next(rooms.GetLength(1));
            }
            setRoom(GiantLairPos[0], GiantLairPos[1], new GiantLair());
            int[] CryptGatePos = { Game.r.Next(rooms.GetLength(0)), Game.r.Next(rooms.GetLength(1)) };
            while ((rooms[CryptGatePos[0], CryptGatePos[1]] is Haven) || (rooms[CryptGatePos[0], CryptGatePos[1]] is GiantLair))
            {
                CryptGatePos[0] = Game.r.Next(rooms.GetLength(0));
                CryptGatePos[1] = Game.r.Next(rooms.GetLength(1));
            }
            setRoom(CryptGatePos[0], CryptGatePos[1], new CryptGate());

            for (int r = 0; r < nullRooms; r++)
            {
                createNullRoom();
            }
        }

        private Room getRandomRoom()
        {
            int x = Game.r.Next(AREA_WIDTH);
            int y = Game.r.Next(AREA_HEIGHT);

            return getRoom(x, y);
        }








        private bool createNullRoom()
        {
            bool okay = false;
            int trycount = 0;
            Room candidateRoom = getRandomRoom();
            while (!(okay))
            {
                while (candidateRoom is BossRoom || candidateRoom is Haven || candidateRoom is null)
                {
                    candidateRoom = getRandomRoom();
                }
                visited_rooms.Clear();
                int[] roomsDim = { rooms.GetLength(0), rooms.GetLength(1) };
                okay = test_access(candidateRoom);
                trycount++;
                if (trycount == 10)
                {
                    Console.WriteLine("Broke the loop!");
                    break;
                }
            }
            Console.WriteLine("Exited loop!");
            if (okay)
            {
                nullRoom(candidateRoom);
                Console.WriteLine("Nulled");
                return (true);
            }
            else
            {
                return (false);
            }
        }
        public bool test_access(Room candidateRoom)
        {
            Console.WriteLine($"Walking from {getWidth()} {getHeight()}");
            Room haven = getRoom(getWidth() / 2, getHeight() / 2 );
            Console.WriteLine($"Walking from {haven.x}, {haven.y}");
            walk_rooms(haven, candidateRoom);

            foreach (Room targetRoom in roomSet) {
                if (targetRoom != candidateRoom)
                {
                    bool okay = test_access_haven_to_room(targetRoom, candidateRoom);
                    if (!(okay))
                    {
                        Console.WriteLine($"Failed ... can't access {targetRoom.x}, {targetRoom.y}");
                        return (false);
                    }
                }
            }

            return (true);
        }

        private bool test_access_haven_to_room(Room targetRoom, Room candidateRoom)
        {
            if (visited_rooms.Contains(targetRoom))
            {
                //Console.WriteLine($"Great news! We already visited {targetRoom[0].ToString()}, {targetRoom[1].ToString()}");
                return true;
            }
            else
            {
                //Console.WriteLine($"So sad. We can't get to {targetRoom[0].ToString()}, {targetRoom[1].ToString()}");
                return false;
            }
        }

        public bool walk_rooms(Room currentRoom, Room candidateRoom)
        {
            //Console.WriteLine($"{currentRoom[0].ToString()}, {currentRoom[1].ToString()}");
            bool result;
            Room nextRoom;

            if (visited_rooms.Contains(currentRoom))
            {
                Console.WriteLine("Been here, done that.");
                return (false);
            }
            //The check "is null" will likely not work, but cause an error earlier. Its ok for now I suppose
            if (currentRoom is null || currentRoom == candidateRoom)
            {
                Console.WriteLine("Null, or Wants to be, or boss");
                return (false);
            }
            visited_rooms.Add(currentRoom);
            if (currentRoom is BossRoom)
            {
                Console.WriteLine("Null, or Wants to be, or boss");
                return (false);
            }
            //.WriteLine($"Visited Room --- {currentRoom[0].ToString()}, {currentRoom[1].ToString()}");
            if (can_go(currentRoom, "west"))
            {
                Console.WriteLine("I can go west!");
                nextRoom = getRoom(currentRoom.x - 1, currentRoom.y);
                result = walk_rooms(nextRoom, candidateRoom);
                if (result == true)
                {
                    return (result);
                }
            }
            if (can_go(currentRoom, "east"))
            {
                Console.WriteLine("I can go east!");
                nextRoom = getRoom(currentRoom.x + 1, currentRoom.y);
                result = walk_rooms(nextRoom, candidateRoom);
                if (result == true)
                {
                    return (result);
                }
            }
            if (can_go(currentRoom, "north"))
            {
                Console.WriteLine("I can go north!");
                nextRoom = getRoom(currentRoom.x, currentRoom.y - 1);
                result = walk_rooms(nextRoom, candidateRoom);
                if (result == true)
                {
                    return (result);
                }
            }
            if (can_go(currentRoom, "south"))
            {
                Console.WriteLine("I can go south!");
                nextRoom = getRoom(currentRoom.x, currentRoom.y + 1);
                result = walk_rooms(nextRoom, candidateRoom);
                if (result == true)
                {
                    return (result);
                }
            }
            return (false);
        }
        bool can_go(Room currentRoom, string direction)
        {
            bool canGo = true;
            switch (direction)
            {
                case "west":
                    if ((currentRoom.x - 1) < 0)
                    {
                        canGo = false;
                    }
                    break;
                case "east":
                    if ((currentRoom.x + 1) > getWidth() - 1)
                    {
                        canGo = false;
                    }
                    break;
                case "north":
                    if ((currentRoom.y - 1) < 0)
                    {
                        canGo = false;
                    }
                    break;
                case "south":
                    if ((currentRoom.y + 1) > getHeight() - 1)
                    {
                        canGo = false;
                    }
                    break;
                default:
                    break;
            }
            return (canGo);
        }
    }
}

