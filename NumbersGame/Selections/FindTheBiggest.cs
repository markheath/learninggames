using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework.Quiz;
using System.Windows.Controls;
using System.Windows;

namespace LearningGames.Numbers.Selections
{
    class FindTheBiggest : MultiChoiceProblem
    {
        private int correctItemIndex;

        private List<object> labels;

        public FindTheBiggest(IEnumerable<int> choices)
        {
            var choicesList = new List<int>(choices);
            int max = choicesList.Max();
            this.correctItemIndex = choicesList.IndexOf(max);

            this.labels = new List<object>();
            foreach (var choice in choicesList)
            {
                var label = new Label();
                label.FontSize = 50;
                label.FontWeight = FontWeights.Bold;
                label.Content = choice.ToString();
                labels.Add(label);
            }
        }

        public override object Content
        {
            get { return "Find the Biggest"; }
        }

        public override ICollection<object> Choices
        {
            get { return labels; }
        }

        public override int CorrectItemIndex { get { return this.correctItemIndex; } }
    }
}
