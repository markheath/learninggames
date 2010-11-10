using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework.Quiz;

namespace LearningGames.Numbers
{
    public class Division : TextAnswerProblem
    {
        private object content;
        public int First { get; private set; }
        public int Second { get; private set; }

        public Division(int first, int second)
        {
            this.First = first;
            this.Second = second;
            this.content = ContentBuilder.CreateTextBlock(this.ToString());
        }

        protected override bool IsCorrectAnswer(string answer)
        {
            bool isCorrect = false;
            int answerInt;
            if (Int32.TryParse(answer, out answerInt))
            {
                isCorrect = (answerInt == First / Second);
            }
            return isCorrect;
        }

        public override object Content
        {
            get { return content; }
        }

        public override string ToString()
        {
            if (Second == 2)
            {
                return String.Format("Half of {0}", First);
            }
            return String.Format("{0} ÷ {1}", First, Second);
        }
    }
}
