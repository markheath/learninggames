using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    public class SumProvider : ISumProvider
    {
        static Random random = new Random();
        List<ISumType> sumTypes;

        public SumProvider(IEnumerable<ISumType> sumTypes)
        {
            this.sumTypes = new List<ISumType>();
            this.sumTypes.AddRange(sumTypes);
        }

        public Sum GetNextSum()
        {
            int sumTypeIndex = random.Next(0, sumTypes.Count);
            return sumTypes[sumTypeIndex].CreateRandom(random);
        }
        /*
        public static Sum CreateRandom()
        {
            Operator op = Operator.Multiply;
            Sum sum = null;
            int first;
            int second;
            switch (op)
            {
                case Operator.Divide:
                    second = random.Next(1, 5);
                    first = random.Next(1, 5) * second;
                    sum = new Division(first, second);
                    break;
                case Operator.Half:
                    first = random.Next(1, 11) * 2;
                    second = 2;
                    sum = new Division(first, second);
                    break;
                case Operator.Double:
                    first = random.Next(1, 11);
                    second = 2;
                    sum = new Multiplication(first, second);
                    break;
                case Operator.TimesTen:
                    first = random.Next(1, 11);
                    second = 10;
                    sum = new Multiplication(first, second);
                    break;
            }
            return sum;
        }*/
    }
}
