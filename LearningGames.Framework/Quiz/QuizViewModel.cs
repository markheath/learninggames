using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace LearningGames.Framework.Quiz
{
    public class QuizViewModel : ViewModelBase
    {
        IQuiz quiz;

        public QuizViewModel(IQuiz quiz)
        {
            this.quiz = quiz;
            quiz.Updated += new EventHandler(quiz_Updated);
        }

        void quiz_Updated(object sender, EventArgs e)
        {
            RaisePropertyChanged("Problem");
            RaisePropertyChanged("Score");
        }

        public object Problem
        {
            get
            {
                return quiz.CurrentProblem.Content;
            }
        }

        public int Score
        {
            get
            {
                return quiz.Right;
            }
        }
    }
}
