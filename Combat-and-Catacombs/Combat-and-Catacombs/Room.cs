﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public abstract class Room {
        public char mapRenderChar = 'O';
        public Room() {}
        public abstract string givename();
        public abstract string describe();
        public abstract char renderChar();
    }

    #region Area1
    public class OldCellar : Room
    {
        public string name;
        public OldCellar() : base()
        {
            this.name = "Old Cellar";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter an aged, decrepit cellar";
        }
        public override char renderChar()
        {
            return 'C';
        }
    }

    public class HermitShack : Room
    {
        public string name;
        public HermitShack() : base()
        {
            this.name = "Hermit Shack";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter an empty hut that has recently been inhabited. It feels like you are being watched...";
        }
        public override char renderChar()
        {
            return 'H';
        }
    }

    public class Overgrowth : Room
    {
        public string name;
        public Overgrowth() : base()
        {
            this.name = "Overgrowth";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter an unrecognizably overgrown room";
        }
        public override char renderChar()
        {
            return 'O';
        }
    }
    public class SmallCave : Room
    {
        public string name;
        public SmallCave() : base()
        {
            this.name = "Small Cave";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a cramped and narrow cave";
        }
        public override char renderChar()
        {
            return '.';
        }
    }

    public class BurialMound : Room
    {
        public string name;
        public BurialMound() : base()
        {
            this.name = "Burial Mound";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a room filled with earthern mounds, and the stench of the dead. It's too quiet in here...";
        }
        public override char renderChar()
        {
            return 'G';
        }
    }

    public class LargeAbandondedCrossroads : Room
    {
        public string name;
        public LargeAbandondedCrossroads() : base()
        {
            this.name = "Large Abandonded Crossroads";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You arrive at the meeting point of many winding paths, going out in every direction";
        }
        public override char renderChar()
        {
            return '<';
        }
    }

    public class PillagedBarracks : Room
    {
        public string name;
        public PillagedBarracks() : base()
        {
            this.name = "Pillaged Barracks";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter what seems to have once been a well maintained barracks, but little remains of it now";
        }
        public override char renderChar()
        {
            return 'B';
        }
    }
    public class FloodedRoom : Room
    {
        public string name;
        public FloodedRoom() : base()
        {
            this.name = "Flooded Room";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a enter a flooded room, submerging yourself up to your chest. Better hope there are no sharks down here...";
        }
        public override char renderChar()
        {
            return 'F';
        }
    }

    public class GrassyEnclosure : Room
    {
        public string name;
        public GrassyEnclosure() : base()
        {
            this.name = "Grassy Enclosure";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a quiet and peaceful room filled with long grass and shroobberries. It's too bad there's some ugly monster ruining the view";
        }
        public override char renderChar()
        {
            return 'E';
        }
    }

    public class RansackedLibrary : Room
    {
        public string name;
        public RansackedLibrary() : base()
        {
            this.name = "Ransacked Library";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "A room once filled with knowledge, very little if any of its texts remain";
        }
        public override char renderChar()
        {
            return 'L';
        }
    }
    #endregion

    #region Area2
    public class Barracks : Room
    {
        public string name;
        public Barracks() : base()
        {
            this.name = "Barracks";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a surprisingly well maintained barracks. Perhaps the cause has something to with the undead currently rushing to tear you limb from limb...";
        }
        public override char renderChar()
        {
            return 'B';
        }
    }

    public class GuardsQuarters : Room
    {
        public string name;
        public GuardsQuarters() : base()
        {
            this.name = "Guards Quarters";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a room that once housed many guards. Actually, it still does";
        }
        public override char renderChar()
        {
            return 'G';
        }
    }

    public class SupplyRoom : Room
    {
        public string name;
        public SupplyRoom() : base()
        {
            this.name = "Supply Room";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a room filled with food and weapon supplies. Unfortunately, you aren't the only one interested in these right now...";
        }
        public override char renderChar()
        {
            return 'S';
        }
    }
    public class Kitchen : Room
    {
        public string name;
        public Kitchen() : base()
        {
            this.name = "Kitchen";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "you enter a room full of delicious food! And undead, of course";
        }
        public override char renderChar()
        {
            return 'K';
        }
    }
    public class MageRoom : Room
    {
        public string name;
        public MageRoom() : base()
        {
            this.name = "Mage's Room";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter the residence of a potent user of magic. Either he is not here at the moment, or he's invisible";
        }
        public override char renderChar()
        {
            return 'M';
        }
    }

    public class CaptainOffice : Room
    {
        public string name;
        public CaptainOffice() : base()
        {
            this.name = "Captain's Office";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter the office of a rather grouchy guard captain. He must have gotten up on the wrong side of the coffin this morning";
        }
        public override char renderChar()
        {
            return 'C';
        }
    }

    public class ArcheryRange : Room
    {
        public string name;
        public ArcheryRange() : base()
        {
            this.name = "Archery Range";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a room filled with targets to shoot at, complete with one extra target that just entered the room";
        }
        public override char renderChar()
        {
            return 'A';
        }
    }
    public class AlchemistLab : Room
    {
        public string name;
        public AlchemistLab() : base()
        {
            this.name = "Alchemist's Lab";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a room filled with various experiments and strange chemicals. Some of them heading your way at terminal velocity";
        }
        public override char renderChar()
        {
            return 'L';
        }
    }
    public class Bathroom : Room
    {
        public string name;
        public Bathroom() : base()
        {
            this.name = "Bathroom";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a simple Bathroom";
        }
        public override char renderChar()
        {
            return 'B';
        }
    }
public class PrisonCell : Room
    {
        public string name;
        public PrisonCell() : base()
        {
            this.name = "Prison Cell";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a dark and foul smelling cell. Ugh... what died in here? Or un-died, for that matter";
        }
        public override char renderChar()
        {
            return 'B';
        }
    }
    public class Throneroom : Room
    {
        public string name;
        public Throneroom() : base()
        {
            this.name = "Throneroom";
        }
        public override string givename()
        {
            return name;
        }
        public override string describe()
        {
            return "You enter a dazzling, massive hall full of riches";
        }
        public override char renderChar()
        {
            return 'T';
        }
    }
    #endregion

    #region Area3
    #endregion

    #region Area4
    #endregion

    #region Area5
    #endregion

    #region Area6
    #endregion

    #region Area7
    #endregion

    #region Area8
    #endregion

    #region Area9
    #endregion

    public class AreaTables
    {
        public static RandomTable<Room> area1roomtable = new RandomTable<Room>(new Room[] {new OldCellar(),new HermitShack(),new Overgrowth(),new SmallCave(),new BurialMound(),new LargeAbandondedCrossroads(),new PillagedBarracks(),new FloodedRoom(),new GrassyEnclosure(),new RansackedLibrary()},new double[] {0,1,2,3,4,5,6,7,8,9});
        public static RandomTable<Room> area2roomtable = new RandomTable<Room>(new Room[] {new Barracks(),new GuardsQuarters(),new SupplyRoom(),new Kitchen(),new MageRoom(),new CaptainOffice(),new ArcheryRange(),new AlchemistLab(),new Bathroom(),new PrisonCell()},new double[] {0,1,2,3,4,5,6,7,8,9});
        public static RandomTable<Room>[] roomtables = new RandomTable<Room>[] {area1roomtable,area2roomtable};
   }
}
