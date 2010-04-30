using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LearningGames.Framework;
using GalaSoft.MvvmLight.Messaging;

namespace LearningGames.Numbers
{
    class NewGameViewModel : ViewModelBase
    {
        private int difficultyLevel;

        public NewGameViewModel()
        {
            NewGameCommand = new RelayCommand(() => OnNewGame());
        }

        public ICommand NewGameCommand { get; private set; }

        private void OnNewGame()
        {
            var page = new NumbersPage();
            ISumType[] sumTypes = new ISumType[] {
                new AdditionSumType(),
                new MultiplicationSumType(),
                new SubtractionSumType()
            };

            var sumProvider = new SumProvider(sumTypes, (Difficulty)DifficultyLevel);
            var sumQuiz = new SumQuiz(sumProvider);
            NumbersViewModel numbers = new NumbersViewModel(sumQuiz);
            page.DataContext = numbers;
            Messenger.Default.Send(new NavigateMessage() { Target = page });            
        }

        public int MinLevel
        {
            get { return 0; }
        }

        public int MaxLevel
        {
            get { return 5; } 
        }

        public int DifficultyLevel
        {
            get { return difficultyLevel; }
            set
            {
                if (difficultyLevel != value)
                {
                    this.difficultyLevel = value;
                    RaisePropertyChanged("DifficultyLevel");
                    RaisePropertyChanged("DifficultyDescription");
                }
            }
        }

        public string DifficultyDescription
        {
            get
            {
                return "Level " + (DifficultyLevel + 1).ToString();
            }
        }
    }
}
