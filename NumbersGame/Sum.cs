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
    
    public interface ISumType
    {
        string Name { get; }
        Sum CreateRandom(Random random, Difficulty difficulty);
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public enum Operator
    {
        Add,
        Subtract,
        Half,
        Double,
        TimesTen,
        Multiply,
        Divide,
    }
}
