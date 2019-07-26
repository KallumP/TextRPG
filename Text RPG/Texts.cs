using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Text_RPG {
    static class Texts {

        static bool firstTime = true;

        /// <summary>
        /// The intro to the game
        /// </summary>
        public static void Intro() {


            bool validInput = false;
            bool skip = false;
            string inp;

            //Checks to see if this is the first time the game is played
            if (firstTime) {

                //sets this variable such that the game knows its no longer the first time
                firstTime = false;

                //keeps asking until the player enters a valid input
                do {

                    //asks the user if they want to see the intro
                    Console.WriteLine("Would you like to see the intro (Y/N)");
                    inp = Console.ReadLine().ToLower();

                    //checks to see if the input was valid
                    if (inp == "y" || inp == "n") {

                        //sets the boolean depending on what the user chose
                        if (inp == "y")
                            skip = false;
                        else
                            skip = true;

                        //allows the player to leave this section
                        validInput = true;

                    } else {

                        //lets the user know what they need to enter
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter either Y (for yes) or N (for no)");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }

                } while (!validInput);
            }

            Console.Clear();

            //shows the intro if the player chose to see it
            if (!skip) {
                Console.WriteLine("In the year 3046, a great war broke out.");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("All technology was destroyed");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("The weak perished, and the strong fought to survive");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("Nuclear fallout resulted in the growth of monsters that roamed the world,");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("Humans had to work together to set up a safe base");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("The base was a success, and a positive future for humanity was forming");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("However, in the last 20 years, we have undergone many attacks,");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("And the walls that hold the beasts out are weakening, and soon they will fall");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("A hero is needed to save humanity.");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("Will you be the one");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("Will you be strong enough to to take on the beasts");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("Train youself up");
                Thread.Sleep(Numbers.longWait);
                Console.Write("Go out there and fight");
                Thread.Sleep(Numbers.longWait);
            } else
                Console.Write("Intro Skipped");

            //lets the user read the intro
            Console.Write(".");
            Thread.Sleep(Numbers.shortWait);
            Console.Write(".");
            Thread.Sleep(Numbers.shortWait);
            Console.WriteLine(".");
            Thread.Sleep(Numbers.longWait);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Press enter to continue");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadLine();

            Console.Clear();

            //goes to the lobby
            Lobby.Choice();
        }

        /// <summary>
        /// The tutorial for the battle sequences
        /// </summary>
        public static void Tutorial() {

            bool validInput = false;
            bool skip = true;
            string inp;

            //sets this variable such that the game knows its no longer the first time
            firstTime = false;

            //keeps asking until the player enters a valid input
            do {

                //asks the user if they want to see the intro
                Console.WriteLine("Would you like to see the battle tutorial (Y/N)");
                inp = Console.ReadLine().ToLower();

                //checks to see if the input was valid
                if (inp == "y" || inp == "n") {

                    //sets the boolean depending on what the user chose
                    if (inp == "y")
                        skip = false;
                    else
                        skip = true;

                    //allows the player to leave this section
                    validInput = true;

                } else {

                    //lets the user know what they need to enter
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter either Y (for yes) or N (for no)");
                    Console.BackgroundColor = ConsoleColor.Black;

                }

            } while (!validInput);

            Console.Clear();

            //shows the tutorial if the player choose to see it
            if (!skip) {
                Console.WriteLine("You are about to enter the battle fields");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("This is a dangerous place");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("This is how the battle plains are layed out");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("There are 5 battle fields, and 4 dungeons");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("In each battle field (B Square), there is a monster that has to be defeated.");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("In each dungeon (D Square), there is a puzzle that must be solved");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("Some of the locations can have items, these will help you out in the dungeons");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("This is a map of the locations");
                Console.WriteLine(" _______   _______   _______  ");
                Console.WriteLine("|       | |       | |       | ");
                Console.WriteLine("|   B4  | |   D2  | |   D4  | ");
                Console.WriteLine("|_______| |_______| |_______| ");
                Console.WriteLine("");
                Console.WriteLine(" _______   _______   _______  ");
                Console.WriteLine("|       | |       | |       | ");
                Console.WriteLine("|   B2  | |   D1  | |   D3  | ");
                Console.WriteLine("|_______| |_______| |_______| ");
                Console.WriteLine("");
                Console.WriteLine(" _______   _______   _______  ");
                Console.WriteLine("|       | |       | |       | ");
                Console.WriteLine("|   B1  | |   B3  | |   B5  | ");
                Console.WriteLine("|_______| |_______| |_______| ");
                Console.WriteLine();
                Thread.Sleep(Numbers.longWait * 3);
                Console.WriteLine("You start of at B1");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("You can move one square at a time (not diagonally)");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("When you fight a monster, you will take turns to attack");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("You will you always will go first.");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("In your turn, you can either take a potion and then attack, or attack straight away");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("Once you have killed a monster, it will not come back");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("In the dungeons, there are puzzles to solve");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("If you don't know what to do in a dungeon; type <help>");
                Thread.Sleep(Numbers.longWait);
                Console.WriteLine("This will tell you what to do");
                Thread.Sleep(Numbers.longWait);
                Console.Write("Good Luck");
                Thread.Sleep(Numbers.longWait);
            } else
                Console.Write("Tutorial skipped");

            //lets the user read the intro
            Console.Write(".");
            Thread.Sleep(Numbers.shortWait);
            Console.Write(".");
            Thread.Sleep(Numbers.shortWait);
            Console.WriteLine(".");
            Thread.Sleep(Numbers.longWait);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Press enter to continue");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadLine();

            Console.Clear();

            //goes to the lobby
            Battle.B1();

        }

        /// <summary>
        /// Shows the map and inventory
        /// </summary>
        public static void Map() {

            //shows the map
            Console.WriteLine("This is a map of the locations");
            Console.WriteLine(" _______   _______   _______  ");
            Console.WriteLine("|       | |       | |       | ");
            Console.WriteLine("|   B4  | |   D2  | |   D4  | ");
            Console.WriteLine("|_______| |_______| |_______| ");
            Console.WriteLine("");
            Console.WriteLine(" _______   _______   _______  ");
            Console.WriteLine("|       | |       | |       | ");
            Console.WriteLine("|   B2  | |   D1  | |   D3  | ");
            Console.WriteLine("|_______| |_______| |_______| ");
            Console.WriteLine("");
            Console.WriteLine(" _______   _______   _______  ");
            Console.WriteLine("|       | |       | |       | ");
            Console.WriteLine("|   B1  | |   B3  | |   B5  | ");
            Console.WriteLine("|_______| |_______| |_______| ");
            Console.WriteLine();

            //Shows the player's money
            Console.WriteLine("You have £" + Player.money);
            Thread.Sleep(Numbers.shortWait);

            //shows inventory with potions
            ShowInventory(true, true);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any button to continue (not the power button!)");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadLine();
            Console.Clear();

        }

        /// <summary>
        /// Shows the inventory 
        /// </summary>
        /// <param name="withWeapons">Whether you want to show the weapons</param>
        /// <param name="withPotions">Whether you want to show the potions</param>
        public static void ShowInventory(bool withWeapons, bool withPotions) {

            //shows the players inventory
            Console.WriteLine("This is your current inventory");
            Thread.Sleep(Numbers.shortWait);

            if (withWeapons) {
                //goes through each weapon in the players inventory and lists them out
                for (int i = 1; i <= Player.weapons.Count; i++) {

                    Console.WriteLine(i.ToString() + ". " + Player.weapons[i - 1].name);
                    Thread.Sleep(Numbers.shortWait);
                }
            }


            if (withPotions) {
                Console.WriteLine(Player.healthPotions + "x Health Potions");
                Thread.Sleep(Numbers.shortWait);
            }
        }
    }
}
