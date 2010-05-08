using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework.Quiz;

namespace LearningGames.Numbers.Selections
{
    class FindTheBiggestProblemGenerator : IProblemGenerator
    {   
        public FindTheBiggestProblemGenerator(Difficulty difficulty)
        {
            this.Difficulty = difficulty;
        }

        public Difficulty Difficulty { get; private set; }

        public string Name
        {
            get { return "Find the Biggest"; }
        }

        public Problem CreateRandom(Random random)
        {
            int options = 3;
            int min = 0;
            int max = 10;
            if (Difficulty >= Difficulty.Year3)
            {
                options = 4;
                min = -10;
            }
            List<int> choices = CreateChoiceList(options, min, max, random);
            return new FindTheBiggest(choices);
        }

        private List<int> CreateChoiceList(int options, int min, int max, Random random)
        {
            List<int> choices = new List<int>();
            while (choices.Count < options)
            {
                int number = random.Next(min, max+1);
                if(!choices.Contains(number))
                {
                    choices.Add(number);
                }
            }
            return choices;
        }
    }
}
