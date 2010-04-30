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
        public abstract bool IsCorrect(string answer);
    }
}
