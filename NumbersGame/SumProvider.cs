﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public class ProblemProvider : IProblemProvider
    {
        static Random random = new Random();
        private List<IProblemGenerator> problemGenerators;

        public ProblemProvider(IEnumerable<IProblemGenerator> problemGenerators)
        {
            this.problemGenerators = new List<IProblemGenerator>();
            this.problemGenerators.AddRange(problemGenerators);
        }

        public Sum GetNextProblem()
        {            
            int sumTypeIndex = random.Next(0, problemGenerators.Count);
            return problemGenerators[sumTypeIndex].CreateRandom(random);
        }
    }
}
 