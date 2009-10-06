using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public class SumQuiz : QuizBase
    {
        ISumProvider sumProvider;
        Sum currentSum;

        public SumQuiz(ISumProvider sumProvider)
        {
            this.sumProvider = sumProvider;
            this.currentSum = sumProvider.GetNextSum();
        }

        public override bool SubmitAnswer(string answer)
        {
            bool correct = currentSum.IsCorrect(answer);
            if (correct)
            {
                Right++;
                currentSum = sumProvider.GetNextSum();
            }
            return correct;
        }

        public Sum CurrentSum
        {
            get
            {
                return currentSum;
            }
        }

        public override object CurrentQuestionContent
        {
            get
            {
                return currentSum.Content;
            }
        }
    }
}
