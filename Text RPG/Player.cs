using System;
using System.Collections.Generic;
using System.Text;

namespace Text_RPG {
    static class Player {

        public static int money = 100;
        public static int health = 100;
        public static List<Weapon> weapons = new List<Weapon>();
        public static int healthPotions = 2;
        public static string location;
    }

    class Weapon {
        public string name { get; set; }
        public int damage { get; set; }

        /// <summary>
        /// Creates a new weapon type object
        /// </summary>
        /// <param name="_name">The name of the weapon</param>
        /// <param name="_damage">Damage dealt by weapon</param>
        public Weapon(string _name, int _damage) {
            name = _name;
            damage = _damage;  
        }

    }
}
