using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public interface IItem {
        string Name { get; }
        float Weight { get; }
        int MaxStackSize { get; }
    }
}
