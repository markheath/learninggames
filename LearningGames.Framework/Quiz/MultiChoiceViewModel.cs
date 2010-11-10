using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace LearningGames.Framework.Quiz
{
    class MultiChoiceViewModel : ViewModelBase
    {
        private MultiChoiceProblem problem;
        public ObservableCollection<Button> Choices { get; private set; }
        private ICommand selectedCommand;

        public MultiChoiceViewModel(MultiChoiceProblem problem)
        {
            this.problem = problem;
            this.selectedCommand = new RelayCommand<object>(OnSelected);

            this.Choices = new ObservableCollection<Button>();
            foreach (var choice in problem.Choices)
            {
                Button b = CreateChoiceButton(choice);
                this.Choices.Add(b);
            }
        }

        public object Problem
        {
            get { return problem.Content; }
        }

        private Button CreateChoiceButton(object choice)
        {
            Button b = new Button();
            b.CommandParameter = choice;
            b.Content = choice;
            b.Command = selectedCommand;
            return b;
        }

        private void OnSelected(object choice)
        {
            problem.RaiseAnswerEvent(IsCorrectChoice(choice));
        }

        private bool IsCorrectChoice(object choice)
        {
            return choice == this.Choices[problem.CorrectItemIndex].Content;
        }
    }
}
