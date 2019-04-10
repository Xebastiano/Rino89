using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class GuessTest {
        const string symbol = "*";
        const char emptySpace = ' ';
        string secretWord;
		string charTry;
        string answer;
        string tempWord;
        public string shownWord { get; private set; }

        public GuessTest (string secretWord) {
            if (string.IsNullOrWhiteSpace (secretWord)) {
                Console.WriteLine ("WARNING YOU MADE A GAME WITH EMPTY SECRETWORD");
                return;
            }
            this.secretWord = secretWord;
            for (int i = 0; i < secretWord.Length; i++) {
                if (!(secretWord[i] == emptySpace)) {
                    shownWord += symbol;
                } else {
                    shownWord += emptySpace;
                }
            }
			while (shownWord != secretWord){
				charTry = Console.ReadLine();
				if (charTry == secretWord){
					shownWord = charTry;
                    Console.WriteLine("Your secret word is " + shownWord);
                    Console.WriteLine("Would you like to play again?");
                    Console.WriteLine("Please use Yep or Nope");
                    answer = Console.ReadLine();
                    if (answer == "Yep"){
                        Console.WriteLine("Restarting game");
                        return;
                    }else{
                        if (answer == "Nope"){
                            Console.WriteLine("Stoping Game");
                            { break; }
                        }
                    }
                }else{
                    if (secretWord.Contains(charTry)){
                        tempWord = string.Empty;
                        for (int i = 0; i < secretWord.Length; i++){
                            if (secretWord[i] == charTry[0]){
                                tempWord += secretWord[i];
                            }else{
                                tempWord += shownWord[i];
                            }
                        }
                        shownWord = tempWord;
                    }
                }
                Console.Clear();
                Console.WriteLine("Your secret word is " + shownWord);

			}if (shownWord == secretWord){
                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("Please use Yep or Nope");
                answer = Console.ReadLine();
                if(answer == "Yep"){
                    Console.WriteLine("Restarting game");
                    return;
                }else{
                    if(answer == "Nope"){
                        Console.WriteLine("Stoping Game");

                    }
                }
            }
            Console.WriteLine("Thanks for playing");
        }

		
	}

	
}
