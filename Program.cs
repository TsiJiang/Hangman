using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's Play Hangman");
            string[] listwords = {"mongolian", "elephant", "canada", "morrocco", "construction",
                                  "banana", "scrumptious", "serendipity", "california", "cavalier"};
            Random wordGen = new Random();
            var index = wordGen.Next(0, 9);
            string mysteryWord = listwords[index];
            char[] guess = new char[mysteryWord.Length];
            Console.WriteLine("Please enter a letter: ");
            int guessCount = 0;
            for (int i = 0; i < mysteryWord.Length; i++)
            {
                guess[i] = '*';

                while (true)
                {
                    for (int j = 0; j < mysteryWord.Length; j++)
                    {
                        char playerGuess = char.Parse(Console.ReadLine());
                        if (playerGuess == mysteryWord[j])
                        {
                            guess[j] = playerGuess;
                        }
                        else if (playerGuess != mysteryWord[j])
                        {
                            if (guessCount == 1)
                            {
                                Console.WriteLine("  O  ");
                            }

                            else if (guessCount == 2)
                            {
                                Console.WriteLine("  O  ");
                                Console.WriteLine("  |  ");
                            }

                            else if (guessCount == 3)
                            {
                                Console.WriteLine("  O  ");
                                Console.WriteLine("  |  ");
                                Console.WriteLine(" |   ");
                            }

                            else if (guessCount == 4)
                            {
                                Console.WriteLine("  O  ");
                                Console.WriteLine("  |  ");
                                Console.WriteLine(@" / \ ");
                            }

                            else if (guessCount == 5)
                            {

                                Console.WriteLine(@" \ O  ");
                                Console.WriteLine("   |  ");
                                Console.WriteLine(@"  / \ ");
                            }

                            else if (guessCount == 6)
                            {
                                Console.WriteLine("You Lose!");
                                Console.WriteLine(@" \ O /  ");
                                Console.WriteLine("   |  ");
                                Console.WriteLine(@"  / \ ");
                                break;
                            }

                        }
                        guessCount++;
                        Console.WriteLine(guess);
                    }
                }
            }
        }
    }
}
    

    //while (true)
    //{
    //    char playerGuess = char.Parse(Console.ReadLine());
    //    for (int j = 0; j < mysteryWord.Length; j++)
    //    {
    //        if (playerGuess == mysteryWord[j])
    //            guess[j] = playerGuess;
    //    }
    //    Console.WriteLine(guess);



