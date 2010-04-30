using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public class SubtractionSumType : ISumType
    {
        public string Name
        {
            get { return "Subtraction"; }
        }

        public Sum CreateRandom(Random random, Difficulty difficulty)
        {
            int first;
            int second;
            switch (difficulty)
            {
                case Difficulty.Year1:
                    first = random.Next(2, 6);
                    second = random.Next(1, first + 1);
                    break;
                case Difficulty.Year2:
                    first = random.Next(2, 11);
                    second = random.Next(1, first + 1);
                    break;
                case Difficulty.Year3:
                    first = random.Next(2, 21);
                    second = random.Next(1, Math.Min(first + 1,11));
                    break;
                case Difficulty.Year4:
                    first = random.Next(10, 21);
                    second = random.Next(1, first + 1);
                    break;
                case Difficulty.Year5: // can have negative answers
                default:
                    first = random.Next(10, 21);
                    second = random.Next(1, 21);
                    break;
            }
            return new Subtraction(first, second);
        }
    }
}
