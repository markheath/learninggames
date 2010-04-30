using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public class SumQuiz : QuizBase
    {
        IProblemProvider sumProvider;
        Sum currentSum;

        public SumQuiz(IProblemProvider sumProvider)
        {
            this.sumProvider = sumProvider;
            this.currentSum = sumProvider.GetNextProblem();
        }

        public override bool SubmitAnswer(string answer)
        {
            bool correct = currentSum.IsCorrect(answer);
            if (correct)
            {
                Right++;
                currentSum = sumProvider.GetNextProblem();
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
