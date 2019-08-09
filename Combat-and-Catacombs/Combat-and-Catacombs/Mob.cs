using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs
{
    public class Mob
    {
        public int health;
        public int packsize;
        public string name;
        public Mob() {
        }
        public string givename()
        {
            return this.name;
        }
    }

    class Goblin1 : Mob {
        public Goblin1() : base() {
            this.health = 1;
            this.packsize = 1;
            this.name = "Goblin1";
        }
    }
    class Goblin2 : Mob {
        public Goblin2() : base() {
            this.health = 2;
            this.packsize = 2;
            this.name = "Goblin2";
        }
    }
    class Goblin3 : Mob {
        public Goblin3() : base() {
            this.health = 3;
            this.packsize = 3;
            this.name = "Goblin3";
        }
    }
    class Goblin4 : Mob {
        public Goblin4() : base() {
            this.health = 4;
            this.packsize = 4;
            this.name = "Goblin4";
        }
    }
    class Goblin5 : Mob {
        public Goblin5() : base() {
            this.health = 5;
            this.packsize = 5;
            this.name = "Goblin5";
        }
    }
    class Goblin6 : Mob {
        public Goblin6() : base() {
            this.health = 6;
            this.packsize = 6;
            this.name = "Goblin6";
        }
    }
    class Goblin7 : Mob {
        public Goblin7() : base() {
            this.health = 7;
            this.packsize = 7;
            this.name = "Goblin7";
        }
    }
    class Goblin8 : Mob {
        public Goblin8() : base() {
            this.health = 8;
            this.packsize = 8;
            this.name = "Goblin8";
        }
    }
    class Goblin9 : Mob {
        public Goblin9() : base() {
            this.health = 9;
            this.packsize = 9;
            this.name = "Goblin9";
        }
    }
    class Goblin10 : Mob {
        public Goblin10() : base() {
            this.health = 10;
            this.packsize = 10;
            this.name = "Goblin10";
        }
    }
}
