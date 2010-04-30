using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public class SubtractionProblemGenerator : IProblemGenerator
    {
        public SubtractionProblemGenerator(Difficulty difficulty)
        {
            this.Difficulty = difficulty;
        }

        public Difficulty Difficulty { get; private set; }

        public string Name
        {
            get { return "Subtraction"; }
        }

        public Sum CreateRandom(Random random)
        {
            int first;
            int second;
            switch (Difficulty)
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
