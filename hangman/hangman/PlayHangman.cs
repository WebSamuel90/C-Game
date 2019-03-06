using System;
using System.Collections.Generic;
using System.Text;

namespace hangman
{
    public class PlayHangman
    {
        public Word PickedWord { get; set; }

        private List<string> RightLetters;
        private List<string> GuessedLetters;
        private List<string> WrongLetters;

        public PlayHangman()
        {
            RightLetters = new List<string>();
            GuessedLetters = new List<string>();
            WrongLetters = new List<string>();
        }

        public void Play()
        {
            RightLetters = new List<string>();

            for (int i = 0; i < PickedWord.WordLength; i++)
            {
                RightLetters.Add(" _ ");
            }

            for (int i = 0; i < PickedWord.WordLength; i++)
            {
                string letter = PickedWord.Content.Substring(i, 1);
                if (GuessedLetters.Count > 0)
                {
                    foreach (string guessedLetter in this.GuessedLetters)
                    {
                        if (letter.Equals(guessedLetter.Trim().ToUpper()))
                        {
                            RightLetters.RemoveAt(i);
                            RightLetters.Insert(i, " " + letter + " ");
                        }
                    }
                }
            }

            drawHangman();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(buildString(RightLetters, false));
            Console.WriteLine();
        }

        private string buildString(List<string> inPutString, bool space)
        {
            StringBuilder outPut = new StringBuilder();

            foreach (object item in inPutString)
            {
                if (space)
                {
                    outPut = outPut.Append(item.ToString().ToUpper() + " ");
                }
                else
                {
                    outPut = outPut.Append(item.ToString().ToUpper());
                }
            }

            return outPut.ToString();

        }

        public bool AddGuessedLetters(char letter)
        {
            if (char.IsDigit(letter))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("'" + letter.ToString().ToUpper() + "' is not a valid letter");

                return false;

            } 
            else if (!this.GuessedLetters.Contains(letter.ToString().ToUpper()))
            {
                this.GuessedLetters.Add(letter.ToString().ToUpper());

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Guessed Letters : " + buildString(GuessedLetters, true));

                return true;
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You already guessed '" + letter.ToString().ToUpper() + "'");
            }

            return false;
        }

        private bool checkLetter(string letter)
        {
            for (int i = 0; i < PickedWord.WordLength; i++)
            {
                string splittedLetter = PickedWord.Content.Substring(i, 1).ToUpper();

                if (splittedLetter.Equals(letter.Trim().ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }

        private void drawHangman()
        {
            WrongLetters = new List<string>();

            foreach (string item in GuessedLetters)
            {
                if (!checkLetter(item))
                {
                    WrongLetters.Add(item);
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (WrongLetters.Count == 1)
            {
                Console.WriteLine("                              _____");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |     O");
                Console.WriteLine("                             |");
                Console.WriteLine("                             |");
                Console.WriteLine("                             |");
                Console.WriteLine("                             |");
                Console.WriteLine("                           __|__");
            }
            else if (WrongLetters.Count == 2)
            {
                Console.WriteLine("                              _____");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |     O");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |");
                Console.WriteLine("                             |");
                Console.WriteLine("                             |");
                Console.WriteLine("                           __|__");
            }
            else if (WrongLetters.Count == 3)
            {
                Console.WriteLine("                              _____");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |     O");
                Console.WriteLine("                             |    \\|");
                Console.WriteLine("                             |");
                Console.WriteLine("                             |");
                Console.WriteLine("                             |");
                Console.WriteLine("                           __|__");
            }
            else if (WrongLetters.Count == 4)
            {
                Console.WriteLine("                              _____");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |     O");
                Console.WriteLine("                             |    \\|/");
                Console.WriteLine("                             |");
                Console.WriteLine("                             |");
                Console.WriteLine("                             |");
                Console.WriteLine("                           __|__");

            }
            else if (WrongLetters.Count == 5)
            {
                Console.WriteLine("                              _____");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |     O");
                Console.WriteLine("                             |    \\|/");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |");
                Console.WriteLine("                             |");
                Console.WriteLine("                           __|__");
            }
            else if (WrongLetters.Count == 6)
            {
                Console.WriteLine("                              _____");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |     O");
                Console.WriteLine("                             |    \\|/");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |    /");
                Console.WriteLine("                             |");
                Console.WriteLine("                           __|__");
            }
            else if (WrongLetters.Count == 7)
            {
                Console.WriteLine("                              _____");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |     O");
                Console.WriteLine("                             |    \\|/");
                Console.WriteLine("                             |     |");
                Console.WriteLine("                             |    / \\");
                Console.WriteLine("                             |");
                Console.WriteLine("                           __|__");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public GAMERESULT Result()
        {
            if (WrongLetters.Count == 7)
            {
                return GAMERESULT.LOST;
            }
            else if (PickedWord.Content.ToUpper().Equals(buildString(RightLetters, false).Replace(" ", "")))
            {
                return GAMERESULT.WON;
            }
            else
            {
                return GAMERESULT.CONTINUE;
            }
        }
    }
}
