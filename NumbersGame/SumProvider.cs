using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    public class SumProvider : ISumProvider
    {
        Difficulty difficulty;
        static Random random = new Random();

        public SumProvider(Difficulty difficulty)
        {
            this.difficulty = difficulty;
        }

        public Sum GetNextSum()
        {
            return CreateRandom(difficulty);
        }

        // TODO: difficulty levels
        public static Sum CreateRandom(Difficulty difficulty)
        {
            int max = (difficulty == Difficulty.Easy) ? (int)Operator.Subtract + 1 :
                (difficulty == Difficulty.Medium) ? (int)Operator.TimesTen + 1 :
                (int)Operator.Divide + 1;
            Operator op = Operator.Multiply; //(Operator)random.Next(max);
            Sum sum = null;
            switch (op)
            {
                case Operator.Add:
                    sum = new Addition();
                    sum.First = random.Next(1, 11);
                    sum.Second = random.Next(1, 11);
                    break;
                case Operator.Subtract:
                    sum = new Subtraction();
                    sum.First = random.Next(2, 11);
                    sum.Second = random.Next(1, sum.First + 1);
                    break;
                case Operator.Multiply:
                    sum = new Multiplication();
                    sum.First = random.Next(1, 11);
                    sum.Second = random.Next(1, 6);
                    break;
                case Operator.Divide:
                    sum = new Division();
                    sum.Second = random.Next(1, 5);
                    sum.First = random.Next(1, 5) * sum.First;
                    break;
                case Operator.Half:
                    sum = new Division();
                    sum.First = random.Next(1, 11) * 2;
                    sum.Second = 2;
                    break;
                case Operator.Double:
                    sum = new Multiplication();
                    sum.First = random.Next(1, 11);
                    sum.Second = 2;
                    break;
                case Operator.TimesTen:
                    sum = new Multiplication();
                    sum.First = random.Next(1, 11);
                    sum.Second = 10;
                    break;
            }
            return sum;
        }
    }
}
