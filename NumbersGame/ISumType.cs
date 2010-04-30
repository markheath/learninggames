using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    public interface ISumType
    {
        string Name { get; }
        Sum CreateRandom(Random random, Difficulty difficulty);
    }
}
