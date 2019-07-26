using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Text_RPG {
    static class Battle {


        static int ninput;
        static string input;

        static int arrayNumber;

        //an array of fields used to keep track of progress
        static Field[] fields = new Field[9];

        /// <summary>
        /// Resets the values in each field
        /// </summary>
        public static void Reset() {

            for (int i = 0; i < 9; i++)
                fields[i] = new Field();

            //sets up the health of the monsters (no monsters in dungeons)
            fields[0].monsterHealth = 7;
            fields[1].monsterHealth = 14;
            fields[2].monsterHealth = 34;
            fields[3].monsterHealth = 58;
            fields[4].monsterHealth = 146;
            fields[5].monsterHealth = 0;
            fields[6].monsterHealth = 0;
            fields[7].monsterHealth = 0;
            fields[8].monsterHealth = 300;

            //sets up the damage values of the monsters (no monsters in dungeons)
            fields[0].monsterDamage = 2;
            fields[1].monsterDamage = 12;
            fields[2].monsterDamage = 18;
            fields[3].monsterDamage = 23;
            fields[4].monsterDamage = 25;
            fields[5].monsterDamage = 0;
            fields[6].monsterDamage = 0;
            fields[7].monsterDamage = 0;
            fields[8].monsterDamage = 30;

        }

        public static void B1() {

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("B1");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            arrayNumber = 0;

            do {

                //there are always two different options if 
                if (!fields[arrayNumber].MonsterDead()) {

                    Console.WriteLine("You see a grizzly monster infront of you!");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("What will you do?");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("1. Attack");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("2. Potion");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("3. View Map/Inventory");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("4. Return to base");

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

                        Attack();

                        break;

                    }
                } else {

                }
                
            } while (true);




        }


        static void Attack() {

            bool validNumberForList = false;

            Console.Clear();

            Console.WriteLine("What weapon do you want to attack with?");
            Thread.Sleep(Numbers.shortWait);
            Texts.ShowInventory(true, false);

            do {

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


                Console.Clear();

                if (ninput > 0 && ninput <= Player.weapons.Count)
                    validNumberForList = true;
                else {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number that is listed above");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

            } while (!validNumberForList);

            Console.Clear();

            //tells the user what they did
            Weapon w = Player.weapons[ninput - 1];
            Console.WriteLine("You've attacked with " + w.name + " and did " + w.damage + " damage. " + randomCoolWord());

            fields[arrayNumber].monsterDamage -= w.damage;

            Defend();



            //test whether entereing a number too hight for the list and too low

        }

        static void Defend() {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The monster just hit you and dealt " + fields[arrayNumber].monsterDamage + " damage.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("You have {0} health. The monster has {1} health", Player.health, fields[arrayNumber].monsterHealth);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any button to continue");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadLine()

        }

        public static void Potion() {

        }

        static string randomCoolWord() {

            string[] words = new string[] { "Cool!", "Epic!", "Awesome!", "Nice!", "Right on!" };

            Random rnd = new Random();


            return words[rnd.Next(0, words.Length)];
        }
    }


    class Field {

        public int monsterHealth;
        public int monsterDamage;
        public bool itemPickedUp;
        public bool completed;

        /// <summary>
        /// Returns if the monster dead
        /// </summary>
        /// <returns></returns>
        public bool MonsterDead() {
            if (monsterHealth <= 0)
                return true;
            else
                return false;
        }
    }

}


