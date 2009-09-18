using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    public abstract class Sum
    {
        public int First { get; set; }
        public int Second { get; set; }
        public Operator Operator { get; set; }
        
        public abstract int Answer
        {
            get;
        }
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
