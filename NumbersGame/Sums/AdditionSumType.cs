using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public class AdditionProblemGenerator : IProblemGenerator
    {
        public AdditionProblemGenerator(Difficulty difficulty)
        {
            this.Difficulty = difficulty;
        }

        public Difficulty Difficulty { get; private set; }

        public string Name
        {
            get { return "Addition"; }
        }

        public Sum CreateRandom(Random random)
        {
            int first;
            int second;
            switch (Difficulty)
            {
                case Difficulty.Year1:
                case Difficulty.Year2:
                    first = random.Next(1, 6);
                    second = random.Next(1, 6);
                    break;
                case Difficulty.Year3:
                    first = random.Next(1, 11);
                    second = random.Next(1, 11);
                    break;
                case Difficulty.Year4:
                    first = random.Next(10, 21);
                    second = random.Next(1, 11);
                    break;
                case Difficulty.Year5:
                default:
                    first = random.Next(10, 51);
                    second = random.Next(1, 51);
                    break;
            }

            return new Addition(first, second);
        }
    }
}
