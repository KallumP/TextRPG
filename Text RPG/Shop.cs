using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Text_RPG {
    static class Shop {

        static string input;

        /// <summary>
        /// Normalized input
        /// </summary>
        static int ninput;

        static bool[] bought = new bool[7];

        /// <summary>
        /// Sets all of the weapon bought statuses to false
        /// </summary>
        public static void Reset() {
            for (int i = 0; i < 7; i++)
                bought[i] = false;
        }

        /// <summary>
        /// Lets the user choose what items they want to buy
        /// </summary>
        public static void Choice() {

            do {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You are in the shop");
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("You have: £" + Player.money);
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("What do you want to do now?");
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("1. ($2)Buy Someone else's fists(+5 dmg)");
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("2. ($5)Buy Stick (+10 dmg)");
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("3. ($10)Buy Metal Chair (+25 dmg)");
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("4. ($16)Buy Gun (+40 dmg)");
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("5. ($30)Buy Wand (+70 dmg)");
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("6. ($79)Buy Nuclear Chicken Launcher (+150 dmg)");
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("7. ($100)Buy Double Sided Dildo (+200 dmg)");
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("8. ($10)Health Potion (+30 Health)");
                Thread.Sleep(Numbers.shortWait);
                Console.WriteLine("9. Back to lobby");

                //makes sure that the input was a number
                do {

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number");
                    Console.BackgroundColor = ConsoleColor.Black;

                    //gets the input
                    Console.ForegroundColor = ConsoleColor.Green;
                    input = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.White;

                } while (!Int32.TryParse(input, out ninput));


                switch (ninput) {

                    case 1:
                    BuyWeapon(2, "Someone else's fists", 5, ninput);
                    break;
                    case 2:
                    BuyWeapon(5, "Stick", 10, ninput);
                    break;
                    case 3:
                    BuyWeapon(10, "Buy Metal Chair", 25, ninput);
                    break;
                    case 4:
                    BuyWeapon(16, "Buy Gun", 40, ninput);
                    break;
                    case 5:
                    BuyWeapon(30, "Buy Wand", 70, ninput);
                    break;
                    case 6:
                    BuyWeapon(79, "Buy Nuclear Chicken Launcher", 150, ninput);
                    break;
                    case 7:
                    BuyWeapon(100, "Buy Double Sided Dildo", 500, ninput);
                    break;
                    case 8:
                    Console.WriteLine("**");
                    break;
                    case 9:
                    Console.Write("Traveling to lobby");
                    Thread.Sleep(Numbers.shortWait);
                    Console.Write(".");
                    Thread.Sleep(Numbers.shortWait);
                    Console.Write(".");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine(".");
                    Console.Clear();
                    Lobby.Choice();
                    break;
                }
            } while (true);
        }

        /// <summary>
        /// Checks money and availablity and then buys the weapon
        /// </summary>
        /// <param name="price">Price of the weapon to be bought</param>
        /// <param name="name">Name of the weapon to be bought</param>
        /// <param name="damage">Damage of the weapon to be bought</param>
        /// <param name="choiceNumber">User's input choice</param>
        static void BuyWeapon(int price, string name, int damage, int choiceNumber) {

            Console.WriteLine();

            //checks to see if the weapon had already been purchased
            if (!bought[ninput - 1]) {

                //checks to see if the player has enough money
                if (Player.money >= price) {

                    Player.weapons.Add(new Weapon(name, damage));
                    Player.money -= price;
                    bought[ninput - 1] = true;
                    Console.WriteLine("Weapon Bought");

                } else
                    Console.WriteLine("You don't have enough money for this");
            } else
                Console.WriteLine("You already have this weapon");

            //gives the user time to read the text
            Console.WriteLine("Press any button to continue (not the power button!)");
            Console.ReadLine();
            Console.Clear();

        }

        /// <summary>
        /// Checks money and availablity and then buys the potion
        /// </summary>
        /// <param name="price">Price of the item</param>
        static void BuyPotion(int price) {

            //checks to see if there is enough space in the inventory
            if (Player.healthPotions < 11) {

                //checks to see if the player has enough money
                if (Player.money >= price) {
                    Player.healthPotions++;
                    Player.money -= price;
                    Console.WriteLine("Potion Bought");
                } else
                    Console.WriteLine("You don't have enough money for this");
            } else
                Console.WriteLine("You have too many potions already!");

            //gives the user time to read the text
            Console.WriteLine("Press any button to continue (not the power button!)");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
