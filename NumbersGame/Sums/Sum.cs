using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearningGames.Numbers
{
    public abstract class Sum
    {
        public abstract object Content { get; }
        public abstract bool IsCorrect(string answer);
    }
}
