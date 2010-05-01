using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework.Quiz;

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
            if (this.currentSum != null)
            {
                this.currentSum.Answered -= new EventHandler(currentSum_Answered);
            }

            this.currentSum = (TextAnswerProblem)this.sumProvider.GetNextProblem();
            
            if (this.currentSum != null)
            {
                this.currentSum.Answered += new EventHandler(currentSum_Answered);
            }
        }

        void currentSum_Answered(object sender, EventArgs e)
        {
            bool isCorrect = currentSum.IsCorrect;
            if (isCorrect)
            {
                Right++;
                GetNextProblem();
            }
            else
            {
                Wrong++;
            }
        }

        public override Problem CurrentProblem
        {
            get
            {
                return currentSum;
            }
        }
    }
}
