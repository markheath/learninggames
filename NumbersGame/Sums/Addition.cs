using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework.Quiz;
using System.Windows.Controls;
using System.Windows;

namespace LearningGames.Numbers
{
    public class Addition : TextAnswerProblem
    {
        private object content;
        public int First { get; private set; }
        public int Second { get; private set; }

        public Addition(int first, int second)
        {
            this.First = first;
            this.Second = second;
            this.content = ContentBuilder.CreateTextBlock(this.ToString());
        }

        protected override bool IsCorrectAnswer(string answer)
        {
            bool isCorrect = false;
            int answerInt;
            if(Int32.TryParse(answer, out answerInt))
            {
                isCorrect = (answerInt == First + Second);
            }
            return isCorrect;
        }

        public override object Content
        {
            get { return content; }
        }

        public override string ToString()
        {
            return String.Format("{0} + {1}", First, Second);
        }
    }

    public static class ContentBuilder
    {
        public static object CreateTextBlock(string text)
        {
            TextBlock tb = new TextBlock();
            tb.Text = text;
            tb.FontSize = 40;
            tb.FontWeight = FontWeights.Bold;
            return tb;
        }
    }
}
