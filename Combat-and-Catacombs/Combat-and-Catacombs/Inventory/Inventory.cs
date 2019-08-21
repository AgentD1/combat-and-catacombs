using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public class Inventory {
        public int carryingSlots;
        public Stack[] items;

        public Inventory(int carryingSlots) {
            this.carryingSlots = carryingSlots;
            items = new Stack[carryingSlots];
            for (int i = 0; i < carryingSlots; i++) {
                items[i] = null;
            }
        }

        public static void EnterInventoryMenu(Inventory i, Player p) {

        }
    }
}
