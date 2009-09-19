using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    public class SubtractionSumType : ISumType
    {
        public string Name
        {
            get { return "Subtraction"; }
        }

        public Sum CreateRandom(Random random)
        {
            int first = random.Next(2, 11);
            int second = random.Next(1, first + 1);
            return new Subtraction(first, second);
        }
    }
}
