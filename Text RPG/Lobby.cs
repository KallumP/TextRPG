using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Text_RPG {
    static class Lobby {

        static string input;

        /// <summary>
        /// Normalized input
        /// </summary>
        static int ninput;

        /// <summary>
        /// Asks the user what they want to do once in the lobby
        /// </summary>
        static public void Choice() {

            //keeps asking for an input until there is a correct input 
            do {

                //asks the what the next move should be 
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You are in the base");
                Console.WriteLine("What do you want to do now?");
                Console.WriteLine("1. Go to the shop");
                Console.WriteLine("2. Go to the battle field");
                Console.WriteLine("3. View Map/Inventory");
                Console.WriteLine("4. Re-read intro");

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

                    Console.Write("Traveling to shop");
                    Thread.Sleep(Numbers.shortWait);
                    Console.Write(".");
                    Thread.Sleep(Numbers.shortWait);
                    Console.Write(".");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine(".");
                    Console.Clear();
                    Shop.Choice();

                    break;


                    case 2:

                    Console.Write("Traveling to battlefield");
                    Thread.Sleep(Numbers.shortWait);
                    Console.Write(".");
                    Thread.Sleep(Numbers.shortWait);
                    Console.Write(".");
                    Thread.Sleep(Numbers.shortWait);
                    Console.WriteLine(".");
                    Console.Clear();
                    Texts.Tutorial();

                    break;


                    case 3:

                    Console.Clear();
                    Texts.Map();

                    break;


                    case 4:

                    Console.Clear();
                    Texts.Intro();

                    break;


                    default:

                    //clears out the console
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter one of the numbers stated above");
                    Console.BackgroundColor = ConsoleColor.Black;

                    break;
                } 

            } while (true);

        }

    }
}
