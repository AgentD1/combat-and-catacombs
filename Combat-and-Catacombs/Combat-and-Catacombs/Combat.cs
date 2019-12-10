using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public static class Combat {
        public static bool[] playerdead_win;

        static Combat() { }

        public static int EngageCombat(Player p, Mob[] mobs) {
            bool win = false;
            bool playerDead = false;
            int actionChoice;
            int targetInput;
            int round = 1;
            int lightCooldown = 0;
            int darkCooldown = 0;
            int xpEarned = 0;
            Console.WriteLine($"Player health is at {p.health} out of {p.maxHealth}");
            for (int m = 0; m < mobs.Length; m++) {
                Console.WriteLine($"Mob {m + 1} health: {mobs[m].health}");
            }
            Console.WriteLine();
            while (win == false && playerDead == false) {

                Console.WriteLine($"round {round}");

                for (int f = 0; f < mobs.Length + 1; f++) {
                    switch (f) {
                        case 0:
                            Console.WriteLine("Player turn");
                            Console.WriteLine("1. Attack an enemy");
                            Console.WriteLine("2. Heal");
                            Console.WriteLine("3. Dark blast");
                            while (true) {
                                try {
                                    Console.WriteLine("Which action will you take?");
                                    actionChoice = Convert.ToInt32(Console.ReadKey(true).Key) - 48;
                                    if (actionChoice < 1 | actionChoice > 3) {
                                        Console.WriteLine("Press a number corresponding to an action");
                                        continue;
                                    } else if (actionChoice == 2 & lightCooldown > 0) {
                                        Console.WriteLine($"{lightCooldown} rounds until light magic is available");
                                        continue;
                                    } else if (actionChoice == 3 & darkCooldown > 0) {
                                        Console.WriteLine($"{darkCooldown} rounds until dark magic is available");
                                        continue;
                                    }
                                    break;
                                } catch (FormatException) {
                                    continue;
                                }
                            }
                            switch (actionChoice) {
                                case 1:
                                    while (true) {
                                        try {
                                            Console.WriteLine("Which mob would you like to attack?");
                                            targetInput = Convert.ToInt32(Console.ReadLine());
                                            if (targetInput < 1 | targetInput > mobs.Length) {
                                                Console.WriteLine("Press a number corresponding to a living or dead enemy");
                                                continue;
                                            }
                                            break;
                                        } catch (FormatException) {
                                            Console.WriteLine("Must enter a integer");
                                            continue;
                                        }
                                    }
                                    if (Game.r.Next(1, 100) > mobs[targetInput - 1].agility) {
                                        int pdamage = (p.damage + Game.r.Next(p.damageRange) - mobs[targetInput - 1].resistance);
                                        if (pdamage <= 0) {
                                            Console.WriteLine($"Mob {targetInput} fully resisted the attack!");
                                        } else {
                                            mobs[targetInput - 1].health -= pdamage;
                                            Console.WriteLine($"Player attacked Mob {targetInput} for {pdamage} damage!");
                                        }
                                        if (mobs[targetInput - 1].health < 1 && mobs[targetInput - 1].dead == false) {
                                            mobs[targetInput - 1].dead = true;
                                            Console.WriteLine($"The attack killed Mob {targetInput}!");
                                            xpEarned += mobs[targetInput - 1].xpreward;
                                        }
                                    } else {
                                        Console.WriteLine($"Mob {targetInput} dodged the attack!");
                                    }
                                    break;
                                case 2:
                                    p.health += p.lightMana;
                                    if (p.health > p.maxHealth) {
                                        p.health = p.maxHealth;
                                        Console.WriteLine("You heal yourself to full health ");
                                    } else {
                                        Console.WriteLine($"You heal {p.lightMana} health");
                                    }
                                    lightCooldown = 3;
                                    break;
                                default:
                                    while (true) {
                                        try {
                                            Console.WriteLine("Which mob would you like to blast?");
                                            targetInput = Convert.ToInt32(Console.ReadLine());
                                            if (targetInput < 1 | targetInput > mobs.Length) {
                                                Console.WriteLine("Press a number corresponding to a living or dead enemy");
                                                continue;
                                            }
                                            break;
                                        } catch (FormatException) {
                                            Console.WriteLine("Must enter a integer");
                                            continue;
                                        }
                                    }
                                    mobs[targetInput - 1].health -= p.darkMana;
                                    Console.WriteLine($"Player blasted Mob {targetInput} for {p.darkMana} damage!");
                                    if (mobs[targetInput - 1].health < 1 && mobs[targetInput - 1].dead == false) {
                                        mobs[targetInput - 1].dead = true;
                                        Console.WriteLine($"The attack killed Mob {targetInput}!");
                                        xpEarned += mobs[targetInput - 1].xpreward;
                                    }
                                    darkCooldown = 3;
                                    break;
                            }
                            Console.WriteLine();
                            break;
                        default:
                            if (Game.r.Next(1, 100) > p.agility) {
                                if (mobs[f - 1].dead == false) {
                                    int mdamage = (mobs[f - 1].damage + Game.r.Next(mobs[f - 1].damagerange) - p.resistance);
                                    Console.WriteLine($"Mob {f}'s turn");
                                    Console.WriteLine(mobs[f - 1].damage);
                                    if (mdamage <= 0) {
                                        Console.WriteLine("The Player fully resisted the attack!");
                                    } else {
                                        p.health -= mdamage;
                                        Console.WriteLine($"Mob {f} attacked the player for {mdamage} damage!");
                                    }
                                }
                            } else {
                                Console.WriteLine($"The player dodged mob {f}'s attack!");
                            }
                            break;
                    }
                }
                lightCooldown -= 1;
                darkCooldown -= 1;
                if (p.health < 1) {
                    playerDead = true;
                    break;
                }
                Console.WriteLine();
                Console.WriteLine($"Player health: {p.health} out of {p.maxHealth}");
                win = true;
                for (int m = 0; m < mobs.Length; m++) {
                    if (mobs[m].dead == true) {
                        Console.WriteLine($"mob {m + 1} is dead");
                    } else if (mobs[m].dead == false) {
                        win = false;
                        Console.WriteLine($"Mob {m + 1} health: {mobs[m].health}");
                    }
                }
                Console.WriteLine($"round {round} finished.");
                round += 1;
                Console.WriteLine();
            }
            if (playerDead == true) {
                Console.WriteLine("You died");
                playerdead_win = new bool[] { playerDead, win };
                p.roomPosition.x = 5;
                p.roomPosition.y = 5;
                p.health = p.maxHealth;
            }
            if (win == true) {
                Console.WriteLine("You defeated the mobs");
                playerdead_win = new bool[] { playerDead, win };
                MapDrawer.rooms[p.areaPosition - 1, p.roomPosition.x - 1, p.roomPosition.y - 1].mobscleared = true;
            }
            return xpEarned;
        }
    }
}