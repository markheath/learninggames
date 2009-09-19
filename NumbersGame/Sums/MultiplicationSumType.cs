using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    public class MultiplicationSumType : ISumType
    {
        public string Name
        {
            get { return "Multiplication"; }
        }

        public Sum CreateRandom(Random random)
        {
            int first = random.Next(1, 11);
            int second = random.Next(1, 6);
            return new Multiplication(first, second);
        }
    }
}
