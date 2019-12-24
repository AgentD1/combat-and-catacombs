using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs
{
    public class Area
    {
        public const int AREA_WIDTH = 9;
        public const int AREA_HEIGHT = 9;
        public Room[,] rooms = new Room[AREA_WIDTH, AREA_HEIGHT];

        public Area(RandomTable<Type> arearoomtable, RandomTable<Type> areamobtable)
        {
            for (int x = 0; x < AREA_WIDTH; x++)
            {
                for (int y = 0; y < AREA_HEIGHT; y++)
                {
                    rooms[x, y] = (Room)Activator.CreateInstance(arearoomtable.PickRandomly());
                    rooms[x, y].mobs = AreaTables.CreateMobs(areamobtable.PickRandomly());
                    rooms[x, y].mobscleared = false;
                }
            }

            rooms[4, 4] = new Haven();
            rooms[4, 4].mobscleared = true;
            int[] GiantLairPos = { Game.r.Next(rooms.GetLength(0)), Game.r.Next(rooms.GetLength(1)) };
            while ((rooms[GiantLairPos[0], GiantLairPos[1]] is Haven) || (rooms[GiantLairPos[0], GiantLairPos[1]] is CryptGate))
            {
                GiantLairPos[0] = Game.r.Next(rooms.GetLength(0));
                GiantLairPos[1] = Game.r.Next(rooms.GetLength(1));
            }
            rooms[GiantLairPos[0], GiantLairPos[1]] = new GiantLair();
            int[] CryptGatePos = { Game.r.Next(rooms.GetLength(0)), Game.r.Next(rooms.GetLength(1)) };
            while ((rooms[CryptGatePos[0], CryptGatePos[1]] is Haven) || (rooms[CryptGatePos[0], CryptGatePos[1]] is GiantLair))
            {
                CryptGatePos[0] = Game.r.Next(rooms.GetLength(0));
                CryptGatePos[1] = Game.r.Next(rooms.GetLength(1));
            }
            rooms[CryptGatePos[0], CryptGatePos[1]] = new CryptGate();
            int[] HavenPos = { 4, 4 };
            int[][] specialRooms = { GiantLairPos, CryptGatePos };
            //for (int r=0;r < 30;r++) {
                MapNullMaker.createNullRoom(rooms, specialRooms);
            //}
        
        }
    }
}

