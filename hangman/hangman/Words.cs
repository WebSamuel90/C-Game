using System;
using System.Collections.Generic;
using System.Text;

namespace hangman
{
    public class Words : List<Word>
    {
        public Words() 
        {
            this.Add(new Word() { Content = "TESTING" });
            this.Add(new Word() { Content = "CapsLock" });
        }

        public Word Pick()
        {
            {
                Random RandomWord = new Random();
                int index = (int)(RandomWord.NextDouble() * this.Count);

                Word word = this[index];
                word.Content = word.Content.ToUpper();
                return word;
            }
        }
    }
}
