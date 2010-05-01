using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Input;
using LearningGames.Framework;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace LearningGames.KeyWords
{
    class KeyWordsViewModel : ViewModelBase
    {
        KeyWordsQuiz quiz;
        ICommand correctCommand;
        ICommand incorrectCommand;
        
        ISpeechService speechService;

        public KeyWordsViewModel(IEnumerable<string> keyWords, ISpeechService speechService)
        {
            this.quiz = new KeyWordsQuiz(keyWords);
            this.speechService = speechService;
        }

        public ICommand Correct
        {
            get
            {
                if (correctCommand == null)
                {
                    correctCommand = new RelayCommand(
                        () => this.OnCorrectClick(),
                        () => true);
                }
                return correctCommand;
            }
        }

        public ICommand Incorrect
        {
            get
            {
                if (incorrectCommand == null)
                {
                    incorrectCommand = new RelayCommand(
                        () => this.OnIncorrectClick(),
                        () => true);
                }
                return incorrectCommand;
            }
        }

        void OnCorrectClick()
        {
            quiz.Correct();
            RaisePropertyChanged("Right");
            RaisePropertyChanged("KeyWord");
        }

        public int Right
        {
            get { return quiz.Right; }
        }

        public int Wrong
        {
            get { return quiz.Wrong; }
        }

        public object KeyWord
        {
            get { return quiz.CurrentProblem.Content; }
        }

        void OnIncorrectClick()
        {
            speechService.Speak((string)KeyWord, null);
            quiz.Incorrect();
            RaisePropertyChanged("Wrong");
            RaisePropertyChanged("KeyWord");
        }
    }
}
