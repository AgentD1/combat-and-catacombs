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
        public int healthrange;
        public int packsize;
        public int packsizerange;
        public int damage;
        public int damagerange;
        public string name;
        public bool dead = false;
        public Mob() {
        }
        public string givename()
        {
            return this.name;
        }
    }

    class Goblin : Mob {
        public Goblin() : base() {
            this.health = 9;
            this.healthrange = 2;
            this.packsize = 2;
            this.packsizerange = 1;
            this.damage = 1;
            this.damagerange = 1;
            this.name = "Goblin";
        }
    }
    class CrazedMan : Mob {
        public CrazedMan() : base() {
            this.health = 14;
            this.healthrange = 4;
            this.packsize = 1;
            this.packsizerange = 1;
            this.damage = 2;
            this.damagerange = 2;
            this.name = "Crazed man";
        }
    }
    class FaintApparition : Mob {
        public FaintApparition() : base() {
            this.health = 4;
            this.healthrange = 2;
            this.packsize = 4;
            this.packsizerange = 2;
            this.damage = 3;
            this.damagerange = 1;
            this.name = "Faint apparition";
        }
    }
    class Serpent : Mob {
        public Serpent() : base() {
            this.health = 5;
            this.healthrange = 2;
            this.packsize = 3;
            this.packsizerange = 1;
            this.damage = 4;
            this.damagerange = 1;
            this.name = "Serpent";
        }
    }
    class Troll : Mob {
        public Troll() : base() {
            this.health = 23;
            this.healthrange = 5;
            this.packsize = 1;
            this.packsizerange = 0;
            this.damage = 5;
            this.damagerange = 3;
            this.name = "Troll";
        }
    }
    class GiantSpider : Mob {
        public GiantSpider() : base() {
            this.health = 8;
            this.healthrange = 2;
            this.packsize = 1;
            this.packsizerange = 2;
            this.damage = 6;
            this.damagerange = 2;
            this.name = "Giant spider";
        }
    }
    class Bloodhound : Mob {
        public Bloodhound() : base() {
            this.health = 10;
            this.healthrange = 3;
            this.packsize = 1;
            this.packsizerange = 1;
            this.damage = 7;
            this.damagerange = 1;
            this.name = "Bloodhound";
        }
    }
    class BlueSludgii : Mob {
        public BlueSludgii() : base() {
            this.health = 8;
            this.healthrange = 2;
            this.packsize = 2;
            this.packsizerange = 2;
            this.damage = 8;
            this.damagerange = 1;
            this.name = "Blue Sludgii";
        }
    }
    class BlackSludgii : Mob {
        public BlackSludgii() : base() {
            this.health = 15;
            this.healthrange = 3;
            this.packsize = 1;
            this.packsizerange = 0;
            this.damage = 9;
            this.damagerange = 3;
            this.name = "Black Sludgii";
        }
    }
    class Bandit : Mob {
        public Bandit() : base() {
            this.health = 7;
            this.healthrange = 2;
            this.packsize = 3;
            this.packsizerange = 2;
            this.damage = 10;
            this.damagerange = 2;
            this.name = "Bandit";
        }
    }
}
