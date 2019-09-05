using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    interface IUsableItem : IItem {
        void Use(Player p);
    }
}
