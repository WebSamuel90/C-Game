using System;
using System.Collections.Generic;
using System.Text;

namespace hangman
{
    public class Words : List<Word>
    {
        public Words() 
        {
            //this.Add(new Word() { Content = "TESTING" });
            //this.Add(new Word() { Content = "CAPSLOCK" });
            this.Add(new Word() { Content = "REACT" });
            this.Add(new Word() { Content = "LARAVEL" });
            this.Add(new Word() { Content = "WORDPRESS" });
            this.Add(new Word() { Content = "DESIGN" });
            this.Add(new Word() { Content = "FRONTEND" });
            this.Add(new Word() { Content = "BACKEND" });
            this.Add(new Word() { Content = "Programming" });
        }

        public Word Pick
        {
            get
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
