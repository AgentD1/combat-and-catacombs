using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public class Mob {
        public int health;
        public int healthrange;
        public int packsize;
        public int packsizerange;
        public int damage;
        public int damagerange;
        public int agility;
        public int resistance;
        public string name;
        public int xpreward;
        public bool dead = false;
        public Mob() {
        }
        public string givename() {
            return name;
        }
    }

    class Goblin : Mob {
        public Goblin() : base() {
            health = 9;
            healthrange = 2;
            packsize = 2;
            packsizerange = 1;
            damage = 1;
            damagerange = 1;
            agility = 1;
            resistance = 1;
            xpreward = 2;
            name = "Goblin";
        }
    }
    class CrazedMan : Mob {
        public CrazedMan() : base() {
            health = 14;
            healthrange = 4;
            packsize = 1;
            packsizerange = 1;
            damage = 2;
            damagerange = 2;
            agility = 1;
            resistance = 1;
            xpreward = 3;
            name = "Crazed man";
        }
    }
    class FaintApparition : Mob {
        public FaintApparition() : base() {
            health = 4;
            healthrange = 2;
            packsize = 4;
            packsizerange = 2;
            damage = 3;
            damagerange = 1;
            agility = 1;
            resistance = 1;
            xpreward = 1;
            name = "Faint apparition";
        }
    }
    class Serpent : Mob {
        public Serpent() : base() {
            health = 5;
            healthrange = 2;
            packsize = 3;
            packsizerange = 1;
            damage = 4;
            damagerange = 1;
            agility = 1;
            resistance = 1;
            xpreward = 2;
            name = "Serpent";
        }
    }
    class Troll : Mob {
        public Troll() : base() {
            health = 23;
            healthrange = 5;
            packsize = 1;
            packsizerange = 0;
            damage = 5;
            damagerange = 3;
            agility = 1;
            resistance = 1;
            xpreward = 5;
            name = "Troll";
        }
    }
    class GiantSpider : Mob {
        public GiantSpider() : base() {
            health = 8;
            healthrange = 2;
            packsize = 1;
            packsizerange = 2;
            damage = 6;
            damagerange = 2;
            agility = 1;
            resistance = 1;
            xpreward = 4;
            name = "Giant spider";
        }
    }
    class Bloodhound : Mob {
        public Bloodhound() : base() {
            health = 10;
            healthrange = 3;
            packsize = 1;
            packsizerange = 1;
            damage = 7;
            damagerange = 1;
            agility = 1;
            resistance = 1;
            xpreward = 3;
            name = "Bloodhound";
        }
    }
    class BlueSludgii : Mob {
        public BlueSludgii() : base() {
            health = 8;
            healthrange = 2;
            packsize = 2;
            packsizerange = 2;
            damage = 8;
            damagerange = 1;
            agility = 1;
            resistance = 1;
            xpreward = 4;
            name = "Blue Sludgii";
        }
    }
    class BlackSludgii : Mob {
        public BlackSludgii() : base() {
            health = 15;
            healthrange = 3;
            packsize = 1;
            packsizerange = 0;
            damage = 9;
            damagerange = 3;
            agility = 1;
            resistance = 1;
            xpreward = 6;
            name = "Black Sludgii";
        }
    }
    class Bandit : Mob {
        public Bandit() : base() {
            health = 7;
            healthrange = 2;
            packsize = 3;
            packsizerange = 2;
            damage = 10;
            damagerange = 2;
            agility = 1;
            resistance = 1;
            xpreward = 3;
            name = "Bandit";
        }
    }
}
