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
                string letter = PickedWord.Content.Substring(i,1);
                if (GuessedLetters.Count > 0)
                {
                    foreach (string guessedLetter in this.GuessedLetters)
                    {
                        if (letter.Equals(guessedLetter.Trim().ToUpper()))
                        {
                            RightLetters.RemoveAt(i);
                            RightLetters.Insert(i, " {$letter} ");
                        }
                    }
                }
            }
        }
    }
}
