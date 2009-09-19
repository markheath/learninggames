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
        IQuiz quiz;
        string answer;        
        QuestionState questionState;

        private ICommand completedCommand;
        private ICommand submitAnswerCommand;
        private EventFirer startCorrectAnswer;
        private EventFirer startWrongAnswer;
        private EventFirer setTextboxFocus;

        public NumbersViewModel(IQuiz quiz)
        {
            this.quiz = quiz;            
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
            // might not have changed, but fire here anyway
            RaisePropertyChangedEvent("Sum");            
        }

        public object Sum
        {
            get 
            { 
                return quiz.CurrentQuestionContent; 
            }
        }

        public int Score
        {
            get
            {
                return quiz.Score;
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
            if (quiz.SubmitAnswer(Answer))
            {
                QuestionState = QuestionState.Correct;
                startCorrectAnswer.Fire(this);
                RaisePropertyChangedEvent("Score");
            }
            else
            {
                QuestionState = QuestionState.Incorrect;
                startWrongAnswer.Fire(this);
            }
        }
    }
}
