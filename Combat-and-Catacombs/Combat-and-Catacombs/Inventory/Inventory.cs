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
            while (!exitInventory) {
                DisplayInventory(0);
                exitInventory = true; // TODO: do something with this
            }
        }

        void DisplayInventory(int pageNumber) {
            Console.WriteLine();
            Console.WriteLine($"Inventory Page {pageNumber}/{Math.Ceiling(items.Length / 10d)}");
            Console.WriteLine();
            string[] finalCopy = new string[items.Length + 1];

            string[][] table = new string[items.Length + 1][];

            for (int i = 0; i < table.GetLength(0); i++) {
                table[i] = new string[3];
            }

            table[0][0] = "No#";
            table[0][1] = "Name";
            table[0][2] = "Description";

            for (int i = 0; i < items.Length; i++) {
                if (items[i] == null || items[i].number == 0 || items[i].item == null) {
                    continue;
                } else {
                    table[i + 1][0] = items[i].number.ToString();
                    table[i + 1][1] = items[i].item.Name;
                    table[i + 1][2] = "None provided"; // TODO: make this work properly
                }
            }

            string[] final = TableMaker.Tableify(table);

            for (int i = 0; i < final.Length; i++) {
                if (final[i] == null || final[i] == "") {
                    continue;
                }
                Console.WriteLine(final[i]);
            }

            Console.WriteLine();
        }
    }
}
