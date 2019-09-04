using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    class GoldCoin : IItem {
        public string Name { get { return "Gold Coin"; } }

        public float Weight { get { return 0; } }

        public int MaxStackSize { get { return int.MaxValue; } }
    }
}
