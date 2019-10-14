using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Text_RPG
{
    static class Battle
    {


        static int ninput;
        static string input;

        static int arrayNumber;

        //an array of fields used to keep track of progress
        static Field[] fields = new Field[9];

        /// <summary>
        /// Resets the values in each field
        /// </summary>
        public static void Reset()
        {

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

            fields[0].awardMoney = 10;
            fields[1].awardMoney = 30;
            fields[2].awardMoney = 50;
            fields[3].awardMoney = 75;
            fields[4].awardMoney = 100;
            fields[5].awardMoney = 0;
            fields[6].awardMoney = 0;
            fields[7].awardMoney = 0;
            fields[8].awardMoney = 5000;

        }

        /// <summary>
        /// Lets the user choose what they want to do when entering the field
        /// </summary>
        static void BattleChoice()
        {
            //writes out where the player is
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(Player.location);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

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
            do
            {

                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a number");
                Console.BackgroundColor = ConsoleColor.Black;

                //gets the input
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.White;

            } while (!Int32.TryParse(input, out ninput));

            switch (ninput)
            {
                case 1:

                    Attack();

                    break;

                case 2:
                    Potion();
                    break;

                case 3:
                    Texts.Map();
                    break;
            }
        }

        /// <summary>
        /// The attack sequence (character attacks monster)
        /// </summary>
        static void Attack()
        {

            bool validNumberForList = false;

            Console.Clear();

            Console.WriteLine("What weapon do you want to attack with?");
            Thread.Sleep(Numbers.shortWait);
            Texts.ShowInventory(true, false);

            do
            {

                //makes sure that the input was a number
                do
                {

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
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number that is listed above");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

            } while (!validNumberForList);

            Console.Clear();

            //tells the user what they did
            Weapon w = Player.weapons[ninput - 1];
            Console.WriteLine("You've attacked with " + w.name + " and did " + w.damage + " damage. " + randomCoolWord());

            fields[arrayNumber].monsterHealth -= w.damage;

            //checks to see if the monster is alive
            if (!fields[arrayNumber].MonsterDead())

                //lets the player defend against the monsters attacks
                Defend();
            else
            {
                Console.WriteLine("You killed the monster! " + randomCoolWord());

                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Press any button to continue (not the power button!)");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ReadLine();
                Console.Clear();
            }

        }

        /// <summary>
        /// The defence sequence (monster attacks character)
        /// </summary>
        static void Defend()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The monster just hit you and dealt " + fields[arrayNumber].monsterDamage + " damage.");
            Console.ForegroundColor = ConsoleColor.White;

            Player.health -= fields[arrayNumber].monsterDamage;

            Console.WriteLine("You have {0} health. The monster has {1} health", Player.health, fields[arrayNumber].monsterHealth);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any button to continue");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadLine();
            Console.Clear();

        }

        /// <summary>
        /// Sequence when taking one health potion
        /// </summary>
        public static void Potion()
        {
            //adds health onto the player
            Player.health += 30;

            //constrains the health to 100
            if (Player.health > 100)

                Player.health = 100;

            //removes one potion from the inventory
            Player.healthPotions--;

            //goes back to the battle sequence
            B1();
        }

        /// <summary>
        /// Generates a cool word
        /// </summary>
        /// <returns>Returns a cool word</returns>
        static string randomCoolWord()
        {

            string[] words = new string[] { "Cool!", "Epic!", "Awesome!", "Nice!", "Right on!" };

            Random rnd = new Random();


            return words[rnd.Next(0, words.Length)];
        }

        /// <summary>
        /// The sequence for entering battle field 1
        /// </summary>
        public static void B1()
        {

            //sets up the player "location" and the index variable
            Player.location = "B1";
            arrayNumber = 0;

            do
            {

                //there are always two different options if 
                if (!fields[arrayNumber].MonsterDead())
                {
                    BattleChoice();
                }
                else
                {

                    //Gives the user the money
                    if (!fields[1].itemPickedUp)
                        Player.money += fields[1].awardMoney;

                    Console.WriteLine("A large monster lays infront of you");
                    Console.WriteLine("The only option left is to go to a new area");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("You can go in three directions");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("1. Battle Field 2");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("2. Battle Field 3");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("3. Base");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("4. View Map/Inventory");
                    Thread.Sleep(Numbers.shortWait);

                    //makes sure that the input was a number
                    do
                    {

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number");
                        Console.BackgroundColor = ConsoleColor.Black;

                        //gets the input
                        Console.ForegroundColor = ConsoleColor.Green;
                        input = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.White;

                    } while (!Int32.TryParse(input, out ninput));

                    switch (ninput)
                    {
                        case 1:

                            B2();
                            break;

                        case 2:
                            B3();
                            break;

                        case 3:
                            Lobby.Choice();
                            Console.Clear();
                            break;

                        case 4:
                            Texts.Map();
                            break;
                    }
                }

            } while (true);
        }

        /// <summary>
        /// The sequence for entering battle field 2
        /// </summary>
        public static void B2()
        {

            //sets up the player "location" and the index variable
            Player.location = "B2";
            arrayNumber = 1;

            do
            {

                //there are always two different options if 
                if (!fields[arrayNumber].MonsterDead())
                {
                    BattleChoice();
                }
                else
                {

                    //Gives the user the money
                    if (!fields[1].itemPickedUp)
                        Player.money += fields[1].awardMoney;

                    Console.WriteLine("A large monster lays infront of you");
                    Console.WriteLine("The only option left is to go to a new area");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("You can go in three directions");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("1. Battle Field 4");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("2. Dungeon 1");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("3. Battle Field 1");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("4. View Map/Inventory");
                    Thread.Sleep(Numbers.shortWait);

                    //makes sure that the input was a number
                    do
                    {

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number");
                        Console.BackgroundColor = ConsoleColor.Black;

                        //gets the input
                        Console.ForegroundColor = ConsoleColor.Green;
                        input = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.White;

                    } while (!Int32.TryParse(input, out ninput));

                    switch (ninput)
                    {
                        case 1:

                            B4();
                            break;

                        case 2:
                            B3();
                            break;

                        case 3:
                            B1();
                            break;

                        case 4:
                            Texts.Map();
                            break;
                    }
                }

            } while (true);
        }

        /// <summary>
        /// The sequence for entering battle field 3
        /// </summary>
        public static void B3()
        {

            //sets up the player "location" and the index variable
            Player.location = "B3";
            arrayNumber = 2;

            do
            {

                //there are always two different options if 
                if (!fields[arrayNumber].MonsterDead())
                {

                    //lets the user choose what to do when confronted by the monster
                    BattleChoice();
                }
                else
                {

                    //Gives the user the money
                    if (!fields[1].itemPickedUp)
                        Player.money += fields[1].awardMoney;

                    Console.WriteLine("A large monster lays infront of you");
                    Console.WriteLine("The only option left is to go to a new area");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("You can go in three directions");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("1. Battle Field 5");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("2. Dungeon 1");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("3. Battle Field 1");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("4. View Map/Inventory");
                    Thread.Sleep(Numbers.shortWait);


                    //makes sure that the input was a number
                    do
                    {

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number");
                        Console.BackgroundColor = ConsoleColor.Black;

                        //gets the input
                        Console.ForegroundColor = ConsoleColor.Green;
                        input = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.White;

                    } while (!Int32.TryParse(input, out ninput));

                    switch (ninput)
                    {
                        case 1:

                            B5();
                            break;

                        case 2:
                            B3();
                            break;

                        case 3:
                            Lobby.Choice();
                            Console.Clear();
                            break;

                        case 4:
                            Texts.Map();
                            break;
                    }
                }

            } while (true);
        }

        /// <summary>
        /// The sequence for entering battle field 4
        /// </summary>
        public static void B4()
        {

            //sets up the player "location" and the index variable
            Player.location = "B4";
            arrayNumber = 2;

            do
            {

                //there are always two different options if 
                if (!fields[arrayNumber].MonsterDead())
                {

                    //lets the user choose what to do when confronted by the monster
                    BattleChoice();
                }
                else
                {

                    //Gives the user the money
                    if (!fields[1].itemPickedUp)
                        Player.money += fields[1].awardMoney;

                    Console.WriteLine("A large monster lays infront of you");
                    Console.WriteLine("The only option left is to go to a new area");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("You can go in three directions");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("1. Battle Field 2");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("2. Dungeon 2");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("3. View Map/Inventory");
                    Thread.Sleep(Numbers.shortWait);


                    //makes sure that the input was a number
                    do
                    {

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number");
                        Console.BackgroundColor = ConsoleColor.Black;

                        //gets the input
                        Console.ForegroundColor = ConsoleColor.Green;
                        input = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.White;

                    } while (!Int32.TryParse(input, out ninput));

                    switch (ninput)
                    {
                        case 1:

                            B2();
                            break;

                        case 2:
                            D2();
                            break;

                        case 3:
                            Texts.Map();
                            break;
                    }
                }

            } while (true);
        }

        /// <summary>
        /// The sequence for entering battle field 5
        /// </summary>
        public static void B5()
        {

            //sets up the player "location" and the index variable
            Player.location = "B5";
            arrayNumber = 3;

            do
            {

                //there are always two different options if 
                if (!fields[arrayNumber].MonsterDead())
                {

                    //lets the user choose what to do when confronted by the monster
                    BattleChoice();
                }
                else
                {

                    //Gives the user the money
                    if (!fields[1].itemPickedUp)
                        Player.money += fields[1].awardMoney;

                    Console.WriteLine("A large monster lays infront of you");
                    Console.WriteLine("The only option left is to go to a new area");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("You can go in three directions");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("1. Battle Field 3");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("2. Dungeon 3");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine("3. View Map/Inventory");
                    Thread.Sleep(Numbers.shortWait);


                    //makes sure that the input was a number
                    do
                    {

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number");
                        Console.BackgroundColor = ConsoleColor.Black;

                        //gets the input
                        Console.ForegroundColor = ConsoleColor.Green;
                        input = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.White;

                    } while (!Int32.TryParse(input, out ninput));

                    switch (ninput)
                    {
                        case 1:

                            B3();
                            break;

                        case 2:
                            D3();
                            break;

                        case 3:
                            Texts.Map();
                            break;
                    }
                }

            } while (true);
        }

        public static void D1()
        {
            Player.location = "D1";

            arrayNumber = 3;
        }

        public static void D2()
        {

        }

        public static void D3() { 
        
        }
        public static void D4() {
        
        }
        class Field
        {

            public int monsterHealth;
            public int monsterDamage;
            public bool itemPickedUp;
            public bool completed;
            public int awardMoney;

            /// <summary>
            /// Returns if the monster is dead
            /// </summary>
            /// <returns>Whether the monster is dead</returns>
            public bool MonsterDead()
            {
                if (monsterHealth <= 0)
                    return true;
                else
                    return false;
            }
        }

    }
}


