﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework.Quiz;

namespace LearningGames.Numbers
{
    public class Subtraction : TextAnswerProblem
    {
        public int First { get; private set; }
        public int Second { get; private set; }

        public Subtraction(int first, int second)
        {
            this.First = first;
            this.Second = second;
        }

        protected override bool IsCorrectAnswer(string answer)
        {
            bool isCorrect = false;
            int answerInt;
            if (Int32.TryParse(answer, out answerInt))
            {
                isCorrect = (answerInt == First - Second);
            }
            return isCorrect;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", First, Second);
        }
    }
}
