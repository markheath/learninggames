using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace LearningGames.Framework.Quiz
{
    public class TextAnswerViewModel : ViewModelBase
    {
        private TextAnswerProblem problem;
        private string answer;
        private QuestionState questionState;

        private ICommand completedCommand;
        private ICommand submitAnswerCommand;
        private EventFirer startCorrectAnswer;
        private EventFirer startWrongAnswer;
        private EventFirer setTextboxFocus;

        public TextAnswerViewModel(TextAnswerProblem problem)
        {
            this.problem = problem;
            startCorrectAnswer = new EventFirer();
            startWrongAnswer = new EventFirer();
            setTextboxFocus = new EventFirer();
            completedCommand = new RelayCommand(() => OnAnimationCompleted());
            submitAnswerCommand = new RelayCommand(() => OnSubmitAnswer(), () => true); // can't do this because of silverlight !String.IsNullOrEmpty(Answer));
        }

        public ICommand CompletedCommand { get { return completedCommand; } }
        public ICommand SubmitAnswerCommand { get { return submitAnswerCommand; } }
        public IEvent StartCorrectAnswer { get { return startCorrectAnswer; } }
        public IEvent StartWrongAnswer { get { return startWrongAnswer; } }
        public IEvent SetTextboxFocus { get { return setTextboxFocus; } }

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

        public bool AllowAnswer
        {
            get
            {
                return QuestionState == QuestionState.Unanswered;
            }
        }

        void OnAnimationCompleted()
        {
            Answer = "";
            QuestionState = QuestionState.Unanswered;
            setTextboxFocus.Fire(this);
            // might not have changed, but fire here anyway
            RaisePropertyChanged("Sum");
        }

        public object Problem
        {
            get
            {
                return problem.Content;
            }
        }

        public string Answer
        {
            get
            {
                return answer;
            }
            set
            {
                if (answer != value)
                {
                    answer = value;
                    RaisePropertyChanged("Answer");
#if !SILVERLIGHT
                    CommandManager.InvalidateRequerySuggested();
#endif
                }
            }
        }

        private void OnSubmitAnswer()
        {
            if (problem.SubmitAnswer(Answer))
            {
                QuestionState = QuestionState.Correct;
                startCorrectAnswer.Fire(this);
                RaisePropertyChanged("Score");
            }
            else
            {
                QuestionState = QuestionState.Incorrect;
                startWrongAnswer.Fire(this);
            }
        }
    }
}
