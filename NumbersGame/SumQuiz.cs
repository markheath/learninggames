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
        TextAnswerProblem currentSum;

        public SumQuiz(IProblemProvider sumProvider)
        {
            this.sumProvider = sumProvider;
            GetNextProblem();
        }

        private void GetNextProblem()
        {
            this.currentSum = (TextAnswerProblem)this.sumProvider.GetNextProblem();
        }

        public override bool SubmitAnswer(string answer)
        {
            currentSum.SubmitAnswer(answer);
            bool isCorrect = currentSum.IsCorrect;
            if (isCorrect)
            {
                Right++;
                GetNextProblem();
            }
            return isCorrect;
        }

        public Problem CurrentSum
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
