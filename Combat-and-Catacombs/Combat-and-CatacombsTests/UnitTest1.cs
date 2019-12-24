using Microsoft.VisualStudio.TestTools.UnitTesting;

using Combat_and_Catacombs;
using System.Collections.Generic;

namespace Combat_and_CatacombsTests
{
    [TestClass]
    public class AreaTests
    {
        [TestMethod]
        public void HasRoomSet()
        {
            Area area = new Area(
                AreaTables.roomtables[0],
                AreaTables.mobtables[0],
                5, 5,
                true, 0);

            Assert.AreEqual(area.getWidth() * area.getHeight(), area.getRoomSet().Count);
        }

        [TestMethod]
        public void HasHaven()
        {
            Area area = new Area(
                AreaTables.roomtables[0],
                AreaTables.mobtables[0]);

            int havenCount = 0;
            foreach(Room r in area.getRoomSet())
            {
                if (r is Haven)
                {
                    havenCount++;
                }
            }

            Assert.AreEqual(1, havenCount);
        }

        [TestMethod]
        public void AccessTest1()
        {
            Area area = new Area(
                AreaTables.roomtables[0],
                AreaTables.mobtables[0],
                3, 3, false);
            Room start = new Haven();
            Room candidate = null;

            area.setRoom(0, 0, new OldCellar());
            area.setRoom(1, 0, new OldCellar());
            area.setRoom(1, 1, start);

            area.walk_rooms(start, candidate);

            HashSet<Room> visited = area.getVisitedRooms();

            Assert.IsTrue(visited.Contains(area.getRoom(0, 0)));
            Assert.IsTrue(visited.Contains(area.getRoom(1, 0)));
            Assert.IsTrue(visited.Contains(area.getRoom(1, 1)));
        }

        [TestMethod]
        public void AccessTest2()
        {
            Area area = new Area(
                AreaTables.roomtables[0],
                AreaTables.mobtables[0],
                5, 5, false);
            Room start = new Haven();
            Room candidate = null;

            area.setRoom(0, 0, new OldCellar());
            area.setRoom(1, 0, new OldCellar());
            area.setRoom(2, 2, start);

            area.walk_rooms(start, candidate);

            HashSet<Room> visited = area.getVisitedRooms();

            Assert.IsFalse(visited.Contains(area.getRoom(0, 0)));
            Assert.IsFalse(visited.Contains(area.getRoom(1, 0)));
            Assert.IsTrue(visited.Contains(area.getRoom(2, 2)));
        }

        [TestMethod]
        public void AccessTest3()
        {
            Area area = new Area(
                AreaTables.roomtables[0],
                AreaTables.mobtables[0],
                5, 5, false);
            Room start = new Haven();
            Room candidate = null;

            area.setRoom(0, 0, new OldCellar());
            area.setRoom(1, 0, new OldCellar());
            area.setRoom(2, 0, new OldCellar());
            area.setRoom(2, 1, new OldCellar());
            area.setRoom(2, 2, start);
            area.setRoom(4, 4, new OldCellar());

            area.walk_rooms(start, candidate);

            HashSet<Room> visited = area.getVisitedRooms();

            Assert.IsTrue(visited.Contains(area.getRoom(0, 0)));
            Assert.IsTrue(visited.Contains(area.getRoom(1, 0)));
            Assert.IsTrue(visited.Contains(area.getRoom(2, 2)));
            Assert.IsFalse(visited.Contains(area.getRoom(4, 4)));
        }

        [TestMethod]
        public void AccessTest4()
        {
            Area area = new Area(
                AreaTables.roomtables[0],
                AreaTables.mobtables[0],
                5, 5, false);
            Room start = new Haven();
            Room candidate = new OldCellar();

            area.setRoom(0, 0, candidate);
            area.setRoom(1, 0, new OldCellar());
            area.setRoom(2, 0, new OldCellar());
            area.setRoom(2, 1, new OldCellar());
            area.setRoom(2, 2, start);

            Assert.IsTrue(area.test_access(candidate));
        }

        [TestMethod]
        public void AccessTest5()
        {
            Area area = new Area(
                AreaTables.roomtables[0],
                AreaTables.mobtables[0],
                5, 5, false);
            Room start = new Haven();
            Room candidate = new OldCellar();

            area.setRoom(0, 0, new OldCellar());
            area.setRoom(1, 0, candidate);
            area.setRoom(2, 0, new OldCellar());
            area.setRoom(2, 1, new OldCellar());
            area.setRoom(2, 2, start);

            Assert.IsFalse(area.test_access(candidate));
        }
    }
}
