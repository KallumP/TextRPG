using System;

namespace Text_RPG {
    class Program {
        static void Main(string[] args) {
            ResetEverything();

            Texts.Intro();
            Console.ReadLine();
        }

        static void ResetEverything() {
            Shop.Reset();
            Battle.Reset();
            Player.weapons.Clear();
            Player.weapons.Add(new Weapon("My own fist", 2));
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
     * puzzles in d1-4 and boss only in d4
     * no puzzles in b rooms, but maybe items for the dungeons
     * 
     * maybe remove the help function from the tutorial
     * 
     * 
     * reset function needs to properly set up the bItemsPicked array
     * 
     * 
     * 
     * make the two different options in battle scence (fight and already dead scenario)
     * finish battling logic
     */


}
