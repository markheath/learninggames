using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    public class AdditionSumType : ISumType
    {
        public string Name
        {
            get { return "Addition"; }
        }

        public Sum CreateRandom(Random random)
        {
            return new Addition(random.Next(1, 11), random.Next(1, 11));
        }
    }
}
