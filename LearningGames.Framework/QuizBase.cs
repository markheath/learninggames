using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Framework
{
    public abstract class QuizBase : IQuiz
    {
        public event EventHandler Finished;

        public int Right { get; protected set; }
        public int Wrong { get; protected set; }
        
        protected void RaiseFinishedEvent()
        {
            if (Finished != null)
            {
                Finished(this, EventArgs.Empty);
            }
        }

        public abstract object CurrentQuestionContent { get; }
        public abstract bool SubmitAnswer(string answer);
        
    }
}
