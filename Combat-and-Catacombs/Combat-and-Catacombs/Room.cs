using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public abstract class Room {
        public char mapRenderChar = 'O';
        public Room() {}
        public abstract string givename();
        public abstract string describe();
        public abstract char renderChar();
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
        public override char renderChar()
        {
            return 'T';
        }
    }
    public class BurialMound : Room
    {
        public string name;
        public BurialMound() : base()
        {
            this.name = "Burial Mound";
        }
        public override string givename() {
            return name;
        }
        public override string describe()
        {
            return "You enter a room filled with earthern mounds, and the stench of the dead. It's too quiet in here...";
        }
        public override char renderChar()
        {
            return 'G';
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
        public override char renderChar()
        {
            return 'K';
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
        public override char renderChar()
        {
            return 'B';
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
                    return new BurialMound();
                default:
                    return new Kitchen();
            }
        }
    }
}
