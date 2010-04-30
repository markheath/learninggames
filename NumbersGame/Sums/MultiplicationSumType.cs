using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public class MultiplicationSumType : ISumType
    {
        public string Name
        {
            get { return "Multiplication"; }
        }

        public Sum CreateRandom(Random random, Difficulty difficulty)
        {
            int first;
            int second;
            switch (difficulty)
            {
                case Difficulty.Year1:
                case Difficulty.Year2:
                case Difficulty.Year3:
                    first = random.Next(1, 11);
                    second = random.Next(1, 6);
                    break;
                case Difficulty.Year4:
                    first = random.Next(1, 11);
                    second = random.Next(2, 11);
                    break;
                case Difficulty.Year5:
                default:
                    first = random.Next(1, 13);
                    second = random.Next(2, 13);
                    break;
            }
            return new Multiplication(first, second);
        }
    }
}

