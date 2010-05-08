using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearningGames.Framework.Quiz
{
    public abstract class MultiChoiceProblem : Problem
    {
        private static MultiChoiceProblemPresenter presenter = new MultiChoiceProblemPresenter();
        public abstract ICollection<object> Choices { get; }
        public abstract int CorrectItemIndex { get; }

        public override FrameworkElement Presenter
        {
            get { return presenter; }
        }

        public override object GetViewModel()
        {
            return new MultiChoiceViewModel(this);
        }
    }
}
