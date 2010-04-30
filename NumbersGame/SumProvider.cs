using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public class SumProvider : ISumProvider
    {
        static Random random = new Random();
        private List<ISumType> sumTypes;
        private Difficulty difficulty;

        public SumProvider(IEnumerable<ISumType> sumTypes, Difficulty difficulty)
        {
            this.sumTypes = new List<ISumType>();
            this.sumTypes.AddRange(sumTypes);
            this.difficulty = difficulty;
        }

        public Sum GetNextSum()
        {
            int sumTypeIndex = random.Next(0, sumTypes.Count);
            return sumTypes[sumTypeIndex].CreateRandom(random, difficulty);
        }
    }
}
 