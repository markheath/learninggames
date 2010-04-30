using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.Framework
{
    public interface IProblemGenerator
    {
        string Name { get; }
        Difficulty Difficulty { get; }
        Problem CreateRandom(Random random);
    }
}
