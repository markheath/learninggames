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
            int first;
            int second;
            switch (op)
            {
                case Operator.Add:
                    sum = new Addition(random.Next(1, 11), random.Next(1, 11));
                    break;
                case Operator.Subtract:
                    first = random.Next(2, 11);
                    second = random.Next(1, first + 1);
                    sum = new Subtraction(first, second);
                    break;
                case Operator.Multiply:
                    first = random.Next(1, 11);
                    second = random.Next(1, 6);
                    sum = new Multiplication(first, second);
                    break;
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
        }
    }
}
