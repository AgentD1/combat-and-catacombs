using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs
{
    public static class Combat
    {
        public const int MAP_WIDTH = 9;

        static Combat() {}

        public static void engagecombat(Player p, Mob[] mobs)
        {
            bool win = false;
            bool playerdead = false;
            int target = 0;
            int round = 1;
            while (win == false && playerdead == false)
            {
                Console.WriteLine($"round {round}");
                for (int f = 0;f < mobs.Length + 1; f++)
                {
                    switch (f)
                    {
                        case 0:
                            Console.WriteLine("Player turn");
                            mobs[target].health -= p.damage;
                            Console.WriteLine($"Player attacked Mob {target + 1} for {p.damage} damage!");
                            if (mobs[target].health < 1)
                            {
                                mobs[target].dead = true;
                                target += 1;
                                Console.WriteLine($"The attack killed Mob {target}!");
                            }
                            break;
                        default:
                            if (mobs[f-1].dead == false)
                            {
                                Console.WriteLine($"Mob {f}'s turn");
                                Console.WriteLine($"Mob {f} attacked the player for {mobs[f-1].damage} damage!");
                                p.health -= mobs[f - 1].damage;
                            }
                            break;
                    }
                }
                if (p.health < 1)
                {
                    playerdead = true;
                    break;
                }
                Console.WriteLine($"round {round} finished.");
                Console.WriteLine($"Player health is at {p.health} out of {p.maxhealth}");
                for (int m = 0;m < mobs.Length;m++)
                {
                    if (mobs[m].dead == true)
                    {
                        win = true;
                        Console.WriteLine($"mob {m + 1} is dead");
                    }
                    else if (mobs[m].dead == false)
                    {
                        win = false;
                        Console.WriteLine($"Mob {m + 1} health: {mobs[m].health}");
                    }
                }
                round += 1;
                Console.WriteLine();
            }
            if (win == true)
            {
                Console.WriteLine("You defeated the mobs");
            }
            if (playerdead == true)
            {
                Console.WriteLine("You died");
            }
        }
    }
}