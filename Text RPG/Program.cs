using System;

namespace Text_RPG {
    class Program {
        static void Main(string[] args) {
            Shop.ResetWeapons();
            Texts.Intro();
            Console.ReadLine();
        }
    }

    /*
     * advice is writen with a red background
     * 
     * player writing is green
     * 
     * enemy writing is red
     * 
     * game dialog is white
     * 
     * 
     */
}
