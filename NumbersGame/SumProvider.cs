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
    }
}
 