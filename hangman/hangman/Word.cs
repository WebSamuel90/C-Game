using System;
using System.Collections.Generic;
using System.Text;

namespace hangman
{
    public class Word
    {
        public Word()
        {
        }

        public string Content { get; set; }

        public Word(string content)
        {
            this.Content = content;
        }

        public int WordLength
        {
            get { return this.Content.Length; }
        }
    }
}
