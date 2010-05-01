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
        QuestionState questionState;

        private ICommand completedCommand;
        private EventFirer startCorrectAnswer;
        private EventFirer startWrongAnswer;

        public QuizViewModel(IQuiz quiz)
        {
            this.quiz = quiz;
            startCorrectAnswer = new EventFirer();
            startWrongAnswer = new EventFirer();
            completedCommand = new RelayCommand(() => OnAnimationCompleted());
        }

        public ICommand CompletedCommand { get { return completedCommand; } }
        public IEvent StartCorrectAnswer { get { return startCorrectAnswer; } }
        public IEvent StartWrongAnswer { get { return startWrongAnswer; } }

        public QuestionState QuestionState
        {
            get
            {
                return questionState;
            }
            set
            {
                if (questionState != value)
                {
                    questionState = value;
                    RaisePropertyChanged("QuestionState");
                    RaisePropertyChanged("AllowAnswer");
                }
            }
        }

        void OnAnimationCompleted()
        {
            QuestionState = QuestionState.Unanswered;
            // might not have changed, but fire here anyway
            RaisePropertyChanged("Problem");
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
