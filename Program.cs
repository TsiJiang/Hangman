using System;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's Play Hangman");
            Random wordGen = new Random();
            var index = wordGen.Next(0, Word.GetValues(typeof(ContentAlignment)).Length);
            string mysteryWord = ((Word)index).ToString().ToLower();
            string charGuesses = "";
            string guess = "";
            int badGuess = 0;
            Console.ReadKey();
            do
            {
                do
                {
                    PrintBoard(badGuess);
                    Console.WriteLine(PrintMysteryWord(mysteryWord,charGuesses));
                    Console.WriteLine(charGuesses);
                    Console.Write("\nPlease enter a letter: ");
                    guess = Console.ReadLine();
                    guess = guess.ToLower();
                } while (char.IsLetter(guess.First()) == false);
                charGuesses += $" {char.ToString(guess.First())}";
                if (mysteryWord.Contains(guess) == false) 
                {
                    badGuess++;
                }
                guess = "";

            } while (badGuess < 6 && PrintMysteryWord(mysteryWord, charGuesses).Contains('*'));
            if (PrintMysteryWord(mysteryWord, charGuesses).Contains('*') == false)
            {
                Console.Clear();
                Console.WriteLine("You Win!");
                PrintBoard(badGuess);
                Console.WriteLine(PrintMysteryWord(mysteryWord, charGuesses));
                Console.WriteLine(charGuesses);
            }
            else 
            {
                PrintBoard(badGuess);
                Console.WriteLine(PrintMysteryWord(mysteryWord, charGuesses));
                Console.WriteLine(charGuesses);
            }
            Console.ReadLine();
        } //End of Main
        static void PrintBoard(int badGuess)
        {
            Console.Clear();
            switch (badGuess)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("   O  ");
                    Console.WriteLine("      ");
                    Console.WriteLine("      ");
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("   O  ");
                    Console.WriteLine("   |  ");
                    Console.WriteLine("      ");
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("   O  ");
                    Console.WriteLine("   |  ");
                    Console.WriteLine("  /   ");
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("   O  ");
                    Console.WriteLine("   |  ");
                    Console.WriteLine("  / \\ ");
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine(" \\ O  ");
                    Console.WriteLine("   |  ");
                    Console.WriteLine("  / \\ ");
                    break;
                default:
                    Console.WriteLine("You Lose!");
                    Console.WriteLine(" \\ O /  ");
                    Console.WriteLine("   |  ");
                    Console.WriteLine("  / \\ ");
                    break;
            }
        }
        static string PrintMysteryWord(string mysteryWord, string guessString) 
        {
            string ans = "";
            int i = 0;
            foreach (char c in mysteryWord) 
            {
                foreach(char d in guessString) 
                {
                    if (c == d)
                    {
                        ans += c;
                        i++;
                    }
                }
                if (i < mysteryWord.Length && mysteryWord[i] == c) 
                {
                    ans += "*";
                    i++;
                }
            }
            return ans;
        }
    }
}
//if (guessCount == 1)
//{
//    Console.WriteLine("  O  ");
//}

//else if (guessCount == 2)
//{
//    Console.WriteLine("  O  ");
//    Console.WriteLine("  |  ");
//}

//else if (guessCount == 3)
//{
//    Console.WriteLine("  O  ");
//    Console.WriteLine("  |  ");
//    Console.WriteLine(" |   ");
//}

//else if (guessCount == 4)
//{
//    Console.WriteLine("  O  ");
//    Console.WriteLine("  |  ");
//    Console.WriteLine(" / \\ ");
//}

//else if (guessCount == 5)
//{

//    Console.WriteLine(@" \ O  ");
//    Console.WriteLine("   |  ");
//    Console.WriteLine(@"  / \ ");
//}

//else if (guessCount == 6)
//{
//    Console.WriteLine("You Lose!");
//    Console.WriteLine(@" \ O /  ");
//    Console.WriteLine("   |  ");
//    Console.WriteLine(@"  / \ ");
//    break;
//}


    //while (true)
    //{
    //    char playerGuess = char.Parse(Console.ReadLine());
    //    for (int j = 0; j < mysteryWord.Length; j++)
    //    {
    //        if (playerGuess == mysteryWord[j])
    //            guess[j] = playerGuess;
    //    }
    //    Console.WriteLine(guess);



