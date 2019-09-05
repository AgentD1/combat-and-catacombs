using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    class TestPotion : IUsableItem {
        public string Name { get { return "Test Potion"; } }

        public float Weight { get { return 369; } }

        public int MaxStackSize { get { return int.MaxValue; } }

        public void Use(Player p) {
            Console.WriteLine("You just used the Test Potion! Poof! +5 agility");
            p.agility += 5;
        }
    }
}
