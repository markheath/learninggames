using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using LearningGames;
using System.Windows.Controls;

namespace LearningGames.Numbers
{
    [Export(typeof(IGame))]
    public class NumbersGame : IGame
    {
        Page gui;
        public NumbersGame()
        {

        }

        public Page Gui
        {
            get { if (gui == null) CreateGui(); return gui; }
        }

        private void CreateGui()
        {
            var page = new NumbersPage();
            ISumType[] sumTypes = new ISumType[] {
                new AdditionSumType(),
                new MultiplicationSumType(),
                new SubtractionSumType()
            };
            var sumProvider = new SumProvider(sumTypes);
            var sumQuiz = new SumQuiz(sumProvider);
            NumbersViewModel numbers = new NumbersViewModel(sumQuiz);
            page.DataContext = numbers;
            gui = page;
        }

        public string Name
        {
            get { return "Numbers"; }
        }
    }
}
