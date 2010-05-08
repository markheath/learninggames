using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearningGames.Framework.Quiz
{
    public abstract class TextAnswerProblem : Problem
    {
        static TextProblemPresenter presenter = new TextProblemPresenter();

        public bool SubmitAnswer(string answer)
        {
            bool isCorrect = IsCorrectAnswer(answer);
            RaiseAnswerEvent(isCorrect);
            return isCorrect;
        }

        public override FrameworkElement Presenter
        {
            get { return presenter; }
        }

        public override object GetViewModel()
        {
            return new TextAnswerViewModel(this);
        }

        protected abstract bool IsCorrectAnswer(string answer);
    }
}
