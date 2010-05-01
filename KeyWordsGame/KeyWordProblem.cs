using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework.Quiz;

namespace LearningGames.KeyWords
{
    public class KeyWordProblem : Problem
    {
        private string word;

        public KeyWordProblem(string word)
        {
            this.word = word;
        }

        public override object Content
        {
            get { return word; }
        }

        public string Word
        {
            get { return word; }
        }

    }
}
