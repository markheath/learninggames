using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework.Quiz;
using System.Windows.Controls;
using System.Windows;

namespace LearningGames.KeyWords
{
    public class KeyWordProblem : Problem
    {
        private string word;
        private static ContentPresenter presenter = new ContentPresenter();

        public KeyWordProblem(string word)
        {
            this.word = word;
        }

        public string Word
        {
            get { return word; }
        }

        public override FrameworkElement Presenter
        {
            get { return presenter; }
        }

        public override object GetViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
