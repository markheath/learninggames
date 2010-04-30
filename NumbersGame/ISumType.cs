using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public interface IProblemGenerator
    {
        string Name { get; }
        Difficulty Difficulty { get; }
        Sum CreateRandom(Random random);
    }
}
