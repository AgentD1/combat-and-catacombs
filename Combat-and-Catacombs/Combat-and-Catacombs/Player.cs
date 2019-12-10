using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public class Player {
        public Vector2 roomPosition;
        public int level;
        public int xp;
        public int[] levelThresholds;
        public int areaPosition;
        public int maxHealth;
        public int health;
        public int damage;
        public int damageRange;
        public int agility;
        public int resistance;
        public int lightMana;
        public int darkMana;
        public bool dead;
        public Inventory inventory;
        public void LevelUp() {
            maxHealth += 50;
            health += 50;
            damage += 5;
            agility += 1;
            resistance += 2;
            lightMana += 5;
            darkMana += 5;
            level += 1;
        }
        public void ShowStats() {
            Console.WriteLine($"Level {level}");
            Console.WriteLine($"XP: {xp}");
            Console.WriteLine($"XP needed to level up: {levelThresholds[level - 1] - xp}");
            Console.WriteLine($"Health: {health}/{maxHealth}");
            Console.WriteLine($"Damage: {damage}-{damage + damageRange}");
            Console.WriteLine($"Agility: {agility}");
            Console.WriteLine($"Resistance: {resistance}");
            Console.WriteLine($"Lightmana: {lightMana}");
            Console.WriteLine($"Darkmana: {darkMana}");
        }
    }
}
