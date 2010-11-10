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
        private EventFirer setTextboxFocus;

        public TextAnswerViewModel(TextAnswerProblem problem)
        {
            this.problem = problem;
            setTextboxFocus = new EventFirer();
            completedCommand = new RelayCommand(() => OnAnimationCompleted(null));
            submitAnswerCommand = new RelayCommand(() => OnSubmitAnswer(), () => true); // can't do this because of silverlight !String.IsNullOrEmpty(Answer));
        }

        public ICommand CompletedCommand { get { return completedCommand; } }
        public ICommand SubmitAnswerCommand { get { return submitAnswerCommand; } }
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

        void OnAnimationCompleted(object state)
        {
            Answer = "";
            QuestionState = QuestionState.Unanswered;
            setTextboxFocus.Fire(this);
            // might not have changed, but fire here anyway
            RaisePropertyChanged("Problem");
        }

        public object Problem
        {
            get
            {
                return problem;
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
                StoryboardManager.PlayStoryboard("rightAnswerAnimation", OnAnimationCompleted, null);
            }
            else
            {
                QuestionState = QuestionState.Incorrect;
                StoryboardManager.PlayStoryboard("wrongAnswerAnimation", OnAnimationCompleted, null);
            }
        }
    }
}
