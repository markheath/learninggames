using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media.Animation;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public class NumbersViewModel : ViewModelBase
    {
        Sum currentSum;
        ISumProvider sumProvider;
        int score;
        string answer;        
        QuestionState questionState;

        private ICommand completedCommand;
        private ICommand submitAnswerCommand;
        private EventFirer startCorrectAnswer;
        private EventFirer startWrongAnswer;
        private EventFirer setTextboxFocus;

        public NumbersViewModel(ISumProvider provider)
        {
            sumProvider = provider;
            currentSum = provider.GetNextSum();
            startCorrectAnswer = new EventFirer();
            startWrongAnswer = new EventFirer();
            setTextboxFocus = new EventFirer();
            completedCommand = new RelayCommand(() => OnAnimationCompleted());
            submitAnswerCommand = new RelayCommand(() => OnSubmitAnswer(), () => !String.IsNullOrEmpty(Answer));
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
                    RaisePropertyChangedEvent("QuestionState");
                    RaisePropertyChangedEvent("AllowAnswer");
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
            RaisePropertyChangedEvent("SumText");
        }

        public string SumText
        {
            get 
            { 
                return currentSum.ToString(); 
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (score != value)
                {
                    score = value;
                    RaisePropertyChangedEvent("Score");
                }
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
                    RaisePropertyChangedEvent("Answer");
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public void OnSubmitAnswer()
        {
            int answer;
            if (Int32.TryParse(Answer, out answer))
            {
                if (answer == currentSum.Answer)
                {
                    Score++;
                    currentSum = sumProvider.GetNextSum();
                    QuestionState = QuestionState.Correct;
                    startCorrectAnswer.Fire(this);
                    return;
                }
            }
            QuestionState = QuestionState.Incorrect;
            startWrongAnswer.Fire(this);                    
        }
    }
}
