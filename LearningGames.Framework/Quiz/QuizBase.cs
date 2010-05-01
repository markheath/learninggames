using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Framework.Quiz
{
    public class QuizBase : IQuiz
    {
        private IProblemProvider problemProvider;
        public event EventHandler Finished;
        public event EventHandler Updated;

        public int Right { get; private set; }
        public int Wrong { get; private set; }
        public int MaxAttempts { get; set; } 
        public Problem CurrentProblem { get; private set; }

        public QuizBase(IProblemProvider problemProvider)
        {
            this.problemProvider = problemProvider;
            this.MaxAttempts = 1;
            GetNextProblem();
        }

        protected void RaiseFinishedEvent()
        {
            if (Finished != null)
            {
                Finished(this, EventArgs.Empty);
            }
        }

        private void GetNextProblem()
        {
            if (this.CurrentProblem != null)
            {
                this.CurrentProblem.Answered -= new EventHandler(currentProblem_Answered);
            }

            this.CurrentProblem = this.problemProvider.GetNextProblem();

            if (this.CurrentProblem != null)
            {
                this.CurrentProblem.Answered += new EventHandler(currentProblem_Answered);
                RaiseUpdatedEvent();
            }
            else
            {
                RaiseFinishedEvent();
            }
        }

        private void RaiseUpdatedEvent()
        {
            if (Updated != null)
            {
                Updated(this, EventArgs.Empty);
            }
        }

        void currentProblem_Answered(object sender, EventArgs e)
        {
            bool isCorrect = this.CurrentProblem.IsCorrect;
            if (isCorrect)
            {
                Right++;
                GetNextProblem();
            }
            else
            {
                Wrong++;
                if (MaxAttempts > 0 && this.CurrentProblem.Attempts >= MaxAttempts)
                {
                    GetNextProblem();
                }
            }
        }
    }
}
