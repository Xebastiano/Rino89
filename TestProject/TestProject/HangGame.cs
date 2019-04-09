using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class HangGame {
        //hola//
        public GuessTest GuessTest;

        public HangGame () {
            Console.WriteLine ("Choose your word: ");
            GuessTest = new GuessTest (Console.ReadLine ());
            Console.Clear ();
            Console.WriteLine ("Your secret word is " + GuessTest.shownWord);
        }
    }
}
