using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LearningGames.Framework.Quiz;
using GalaSoft.MvvmLight.Messaging;
using LearningGames.Framework;
using LearningGames.Numbers.Selections;

namespace LearningGames.Numbers
{
    public class NewGameViewModel : ViewModelBase
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
            //var page = new NumbersPage();
            //NumbersViewModel numbers = CreateNumbersViewModel();
            var page = new QuizPage();
            var numbers = CreateNumbersViewModel();
            page.DataContext = numbers;
            Messenger.Default.Send(new NavigateMessage() { Target = page });            
        }

        private QuizViewModel CreateNumbersViewModel()
        {
            IProblemGenerator[] problemGenerators = new IProblemGenerator[] {
                new AdditionProblemGenerator(Difficulty.Year1),
                new AdditionProblemGenerator(Difficulty.Year2),
                new AdditionProblemGenerator(Difficulty.Year3),
                new AdditionProblemGenerator(Difficulty.Year4),
                new AdditionProblemGenerator(Difficulty.Year5),
                new MultiplicationProblemGenerator(Difficulty.Year2),
                new MultiplicationProblemGenerator(Difficulty.Year3),
                new MultiplicationProblemGenerator(Difficulty.Year4),
                new MultiplicationProblemGenerator(Difficulty.Year5),
                new SubtractionProblemGenerator(Difficulty.Year1),
                new SubtractionProblemGenerator(Difficulty.Year2),
                new SubtractionProblemGenerator(Difficulty.Year3),
                new SubtractionProblemGenerator(Difficulty.Year4),
                new SubtractionProblemGenerator(Difficulty.Year5),
                new FindTheBiggestProblemGenerator(Difficulty.Year2),
                new FindTheBiggestProblemGenerator(Difficulty.Year3),
            };

            var sumProvider = new ProblemProvider(from p in problemGenerators where p.Difficulty == (Difficulty)DifficultyLevel select p);
            var sumQuiz = new QuizBase(sumProvider);
            sumQuiz.MaxAttempts = 5;
            QuizViewModel numbers = new QuizViewModel(sumQuiz);
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
