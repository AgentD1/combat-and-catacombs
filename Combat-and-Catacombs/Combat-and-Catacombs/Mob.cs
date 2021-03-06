﻿using System;
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
        public int basedamagerange;
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
    #region Area1
    class Goblin : Mob {
        public Goblin() : base() {
            health = 9;
            healthrange = 2;
            packsize = 2;
            packsizerange = 1;
            damage = 1;
            basedamagerange = 1;
            damagerange = 2;
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
            basedamagerange = 2;
            damagerange = 3;
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
            basedamagerange = 1;
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
            basedamagerange = 1;
            damagerange = 2;
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
            basedamagerange = 3;
            damagerange = 4;
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
            basedamagerange = 2;
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
            basedamagerange = 1;
            damagerange = 2;
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
            basedamagerange = 1;
            damagerange = 3;
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
            basedamagerange = 3;
            damagerange = 5;
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
            basedamagerange = 2;
            damagerange = 2;
            agility = 1;
            resistance = 1;
            xpreward = 3;
            name = "Bandit";
        }
    }
    //Mini Bosses
    class Giant : Mob {
        public Giant() : base() {
            health = 100;
            healthrange = 30;
            packsize = 1;
            packsizerange = 0;
            damage = 17;
            basedamagerange = 5;
            damagerange = 9;
            agility = 5;
            resistance = 6;
            xpreward = 40;
            name = "Giant";
        }
    }
    class UndeadDragonlings : Mob {
        public UndeadDragonlings() : base() {
            health = 65;
            healthrange = 20;
            packsize = 2;
            packsizerange = 0;
            damage = 18;
            basedamagerange = 5;
            damagerange = 5;
            agility = 5;
            resistance = 3;
            xpreward = 30;
            name = "Undead Dragonlings";
        }
    }
    #endregion

    #region Area2
    /*class Goblin : Mob {
        public Goblin() : base() {
            health = 9;
            healthrange = 2;
            packsize = 2;
            packsizerange = 1;
            damage = 1;
            basedamagerange = 1;
            damagerange = 2;
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
            basedamagerange = 2;
            damagerange = 3;
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
            basedamagerange = 1;
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
            basedamagerange = 1;
            damagerange = 2;
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
            basedamagerange = 3;
            damagerange = 4;
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
            basedamagerange = 2;
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
            basedamagerange = 1;
            damagerange = 2;
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
            basedamagerange = 1;
            damagerange = 3;
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
            basedamagerange = 3;
            damagerange = 5;
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
            basedamagerange = 2;
            damagerange = 2;
            agility = 1;
            resistance = 1;
            xpreward = 3;
            name = "Bandit";
        }
    }
    //Mini Bosses
    class Giant : Mob {
        public Giant() : base() {
            health = 100;
            healthrange = 30;
            packsize = 1;
            packsizerange = 0;
            damage = 17;
            basedamagerange = 5;
            damagerange = 9;
            agility = 5;
            resistance = 6;
            xpreward = 40;
            name = "Giant";
        }
    }
    class UndeadDragonlings : Mob {
        public UndeadDragonlings() : base() {
            health = 65;
            healthrange = 20;
            packsize = 2;
            packsizerange = 0;
            damage = 18;
            basedamagerange = 5;
            damagerange = 5;
            agility = 5;
            resistance = 3;
            xpreward = 30;
            name = "Undead Dragonlings";
        }
    }*/
    #endregion
}
