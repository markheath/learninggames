using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Framework.Quiz
{
    public abstract class TextAnswerProblem : Problem
    {
        public bool SubmitAnswer(string answer)
        {
            bool isCorrect = IsCorrectAnswer(answer);
            RaiseAnswerEvent(isCorrect);
            return isCorrect;
        }

        protected abstract bool IsCorrectAnswer(string answer);
    }
}
