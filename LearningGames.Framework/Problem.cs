using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearningGames.Framework
{
    public abstract class Problem
    {
        public abstract object Content { get; }
        public event EventHandler Answered;
        public bool IsCorrect { get; private set; }
        public bool IsComplete { get; private set; }

        protected void RaiseAnswerEvent(bool isCorrect)
        {
            this.IsComplete = true;
            this.IsCorrect = isCorrect;

            if (Answered != null)
            {
                Answered(this, EventArgs.Empty);
            }
        }
    }    
}
