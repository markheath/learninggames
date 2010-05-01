﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LearningGames.Framework.Quiz;
using GalaSoft.MvvmLight.Messaging;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    class NewGameViewModel : ViewModelBase
    {
        private int difficultyLevel;

        public NewGameViewModel()
        {
            NewGameCommand = new RelayCommand(() => OnNewGame());
            DifficultyLevel = 2;
        }

        public ICommand NewGameCommand { get; private set; }

        private void OnNewGame()
        {
            var page = new NumbersPage();
            NumbersViewModel numbers = CreateNumbersViewModel();
            page.DataContext = numbers;
            Messenger.Default.Send(new NavigateMessage() { Target = page });            
        }

        private NumbersViewModel CreateNumbersViewModel()
        {
            IProblemGenerator[] problemGenerators = new IProblemGenerator[] {
                new AdditionProblemGenerator(Difficulty.Year1),
                new AdditionProblemGenerator(Difficulty.Year2),
                new AdditionProblemGenerator(Difficulty.Year3),
                new AdditionProblemGenerator(Difficulty.Year4),
                new AdditionProblemGenerator(Difficulty.Year5),
                new MultiplicationProblemGenerator(Difficulty.Year3),
                new MultiplicationProblemGenerator(Difficulty.Year4),
                new MultiplicationProblemGenerator(Difficulty.Year5),
                new SubtractionProblemGenerator(Difficulty.Year1),
                new SubtractionProblemGenerator(Difficulty.Year2),
                new SubtractionProblemGenerator(Difficulty.Year3),
                new SubtractionProblemGenerator(Difficulty.Year4),
                new SubtractionProblemGenerator(Difficulty.Year5),
            };

            var sumProvider = new ProblemProvider(from p in problemGenerators where p.Difficulty == (Difficulty)DifficultyLevel select p);
            var sumQuiz = new SumQuiz(sumProvider);
            NumbersViewModel numbers = new NumbersViewModel(sumQuiz);
            return numbers;
        }

        public int MinLevel
        {
            get { return 0; }
        }

        public int MaxLevel
        {
            get { return 4; } 
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
