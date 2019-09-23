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
        public int[] levelthresholds;
        public int areaPosition;
        public int maxhealth;
        public int health;
        public int damage;
        public int damagerange;
        public int agility;
        public int resistance;
        public int lightmana;
        public int darkmana;
        public bool dead;
        public Inventory inventory;
        public void LevelUp() {
            if (this.level == 1) {
                this.maxhealth += 50;
                this.health += 50;
                this.damage += 5;
                this.agility += 1;
                this.resistance += 2;
                this.lightmana += 5;
                this.darkmana += 5;
                this.level += 1;
            }
        }
        public void ShowStats() {
            Console.WriteLine($"Level {this.level}");
            Console.WriteLine($"XP: {this.xp}");
            Console.WriteLine($"XP needed to level up: {this.levelthresholds[level - 1] - this.xp}");
            Console.WriteLine($"Health: {this.health}/{this.maxhealth}");
            Console.WriteLine($"Damage: {this.damage}-{this.damage + this.damagerange}");
            Console.WriteLine($"Agility: {this.agility}");
            Console.WriteLine($"Resistance: {this.resistance}");
            Console.WriteLine($"Lightmana: {this.lightmana}");
            Console.WriteLine($"Darkmana: {this.darkmana}");
        }
    }
}
