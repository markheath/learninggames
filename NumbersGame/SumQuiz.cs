using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    public class SumQuiz
    {
        ISumProvider sumProvider;
        Sum currentSum;

        public SumQuiz(ISumProvider sumProvider)
        {
            this.sumProvider = sumProvider;
            this.currentSum = sumProvider.GetNextSum();
        }

        public int Score { get; private set; }

        public bool SubmitAnswer(string answer)
        {
            bool correct = currentSum.IsCorrect(answer);
            if (correct)
            {
                Score++;
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
    }
}
