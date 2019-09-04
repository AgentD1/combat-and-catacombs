using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public class Inventory {
        public int carryingSlots;
        public Stack[] items;
        public Player p;

        public Inventory(int carryingSlots, Player p) {
            this.carryingSlots = carryingSlots;
            items = new Stack[carryingSlots];
            for (int i = 0; i < carryingSlots; i++) {
                items[i] = null;
            }
            items[0] = new Stack() {
                item = new GoldCoin(),
                number = 4
            };
            items[1] = new Stack() {
                item = new TestPotion(),
                number = 1
            };
            this.p = p;
        }

        public void EnterInventoryMenu() {
            bool exitInventory = false;
            Console.WriteLine("Entered inventory menu, press X to exit");
            while(!exitInventory) {
                DisplayInventory(0);
            }
        }

        void DisplayInventory(int pageNumber) {
            Console.WriteLine($"Inventory Page {pageNumber}/{Math.Ceiling(items.Length / 10d)}");
            for (int i = 0; i < items.Length; i++) {
                if(items[i] == null || items[i].number == 0 || items[i].item == null) {
                    Console.WriteLine()
                } else {

                }
            }
        }
    }
}
