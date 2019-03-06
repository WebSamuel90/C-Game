using System;
using System.Collections.Generic;
using System.Text;

namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to hangman. You get seven chances to guess the hidden word.");

            string yesNo = string.Empty;

            do
            {
                Console.WriteLine();
                yesNo = PlayGame();
            } while (yesNo.ToUpper().Equals("Y"));
        }

        private static string PlayGame()
        {
            Words words = new Words();
            Word pickedWord = words.Pick;
            PlayHangman playHangman = new PlayHangman();
            playHangman.PickedWord = pickedWord;
            ConsoleKeyInfo yesNo = new ConsoleKeyInfo();

            for (int i = 0; i < pickedWord.WordLength; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" _ ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            while (playHangman.Result() == GAMERESULT.CONTINUE)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Pick a letter --> ");
                ConsoleKeyInfo guessedLetter = Console.ReadKey();
                Console.WriteLine();

                if (playHangman.AddGuessedLetters(guessedLetter.KeyChar))
                {
                    playHangman.Play();
                }
            }

            if (playHangman.Result() == GAMERESULT.LOST)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Game Over !");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("The word was : " + pickedWord.Content.ToUpper());
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Do you want to play again ? Y/N");

                yesNo = Console.ReadKey();
                return yesNo.KeyChar.ToString();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Won !!");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Do you want to play again ? Y/N");

                yesNo = Console.ReadKey();
                return yesNo.KeyChar.ToString();
            }

        }
    }
}
