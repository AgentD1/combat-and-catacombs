using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public abstract class Room {
        public char mapRenderChar = '▦';
        //public string name;
        public Room() //string name)
        {
            //this.name = name;
        }

        public abstract string givename();
        public abstract string describe();
    }

    public class Throneroom : Room
    {
        public string name;
        public Throneroom() : base()
        {
            this.name = "Throneroom";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "A dazzling, massive hall full of riches";
        }
    }
    public class Graveyard : Room
    {
        public string name;
        public Graveyard() : base()
        {
            this.name = "Graveyard";
        }
        public override string givename() {
            return name;
        }
        public override string describe()
        {
            return "A room packed with Graves. Its too quiet...";
        }
    }
    public class Kitchen : Room
    {
        public string name;
        public Kitchen() : base()
        {
            this.name = "Kitchen";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "A room full of delicious food! And monsters, of course";
        }
    }
    public class Bathroom : Room
    {
        public string name;
        public Bathroom() : base()
        {
            this.name = "Bathroom";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "A simple Bathroom";
        }
    }

    public static class RoomFactory
    {
        private static Random rand = new Random();

        public static Room GetRoom()
        {
            switch (rand.Next(4))
            {
                case 0:
                    return new Throneroom();
                case 1:
                    return new Bathroom();
                case 2:
                    return new Graveyard();
                default:
                    return new Kitchen();
            }
        }
    }
}
