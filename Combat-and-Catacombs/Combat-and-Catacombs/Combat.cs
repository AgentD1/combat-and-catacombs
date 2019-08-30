using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public static class Combat {
        public static bool[] playerdead_win;

        static Combat() { }

        public static void EngageCombat(Player p, Mob[] mobs) {
            bool win = false;
            bool playerdead = false;
            int actionchoice;
            int targetinput;
            int round = 1;
            Console.WriteLine($"Player health is at {p.health} out of {p.maxhealth}");
            for (int m = 0; m < mobs.Length; m++) {
                Console.WriteLine($"Mob {m + 1} health: {mobs[m].health}");
            }
            Console.WriteLine();
            while (win == false && playerdead == false) {

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
                                    actionchoice = Convert.ToInt32(Console.ReadKey(true).Key) - 48;
                                    if (actionchoice < 1 | actionchoice > 3) {
                                        Console.WriteLine("Press a number corresponding to an action");
                                        continue;
                                    }
                                    break;
                                } catch (FormatException) {
                                    Console.WriteLine("Press a number");
                                    continue;
                                }
                            }
                            switch (actionchoice) {
                                case 1:
                                    while (true) {
                                        try {
                                            Console.WriteLine("Which mob would you like to attack?");
                                            targetinput = Convert.ToInt32(Console.ReadLine());
                                            if (targetinput < 1 | targetinput > mobs.Length) {
                                                Console.WriteLine("Press a number corresponding to a living or dead enemy");
                                                continue;
                                            }
                                            break;
                                        } catch (FormatException) {
                                            Console.WriteLine("Must enter a integer");
                                            continue;
                                        }
                                    }
                                    mobs[targetinput - 1].health -= p.damage;
                                    Console.WriteLine($"Player attacked Mob {targetinput} for {p.damage} damage!");
                                    if (mobs[targetinput - 1].health < 1 && mobs[targetinput - 1].dead == false) {
                                        mobs[targetinput - 1].dead = true;
                                        Console.WriteLine($"The attack killed Mob {targetinput}!");
                                    }
                                    break;
                                case 2:
                                    p.health += p.lightmana;
                                    if (p.health > p.maxhealth) {
                                        p.health = p.maxhealth;
                                        Console.WriteLine("You heal yourself to full health ");
                                    } else {
                                        Console.WriteLine($"You heal {p.lightmana} health");
                                    }
                                    break;
                                default:
                                    while (true) {
                                        try {
                                            Console.WriteLine("Which mob would you like to blast?");
                                            targetinput = Convert.ToInt32(Console.ReadLine());
                                            if (targetinput < 1 | targetinput > mobs.Length) {
                                                Console.WriteLine("Press a number corresponding to a living or dead enemy");
                                                continue;
                                            }
                                            break;
                                        } catch (FormatException) {
                                            Console.WriteLine("Must enter a integer");
                                            continue;
                                        }
                                    }
                                    mobs[targetinput - 1].health -= p.darkmana;
                                    Console.WriteLine($"Player blasted Mob {targetinput} for {p.darkmana} damage!");
                                    if (mobs[targetinput - 1].health < 1 && mobs[targetinput - 1].dead == false) {
                                        mobs[targetinput - 1].dead = true;
                                        Console.WriteLine($"The attack killed Mob {targetinput}!");
                                    }
                                    break;
                            }
                            break;
                        default:
                            if (mobs[f - 1].dead == false) {
                                Console.WriteLine($"Mob {f}'s turn");
                                Console.WriteLine($"Mob {f} attacked the player for {mobs[f - 1].damage} damage!");
                                p.health -= mobs[f - 1].damage;
                            }
                            break;
                    }
                }
                if (p.health < 1) {
                    playerdead = true;
                    break;
                }
                Console.WriteLine();
                Console.WriteLine($"Player health: {p.health} out of {p.maxhealth}");
                for (int m = 0; m < mobs.Length; m++) {
                    if (mobs[m].dead == true) {
                        win = true;
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
            if (playerdead == true) {
                Console.WriteLine("You died");
                playerdead_win = new bool[] { playerdead, win };
                p.roomPosition.x = 5;
                p.roomPosition.y = 5;
                p.health = p.maxhealth;
            }
            if (win == true) {
                Console.WriteLine("You defeated the mobs");
                playerdead_win = new bool[] { playerdead, win };
                MapDrawer.rooms[p.areaPosition - 1, p.roomPosition.x - 1, p.roomPosition.y - 1].mobscleared = true;
            }
        }
    }
}