using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Framework.Quiz
{
    public interface IQuiz
    {
        int Right { get; }
        int Wrong { get; }
        Problem CurrentProblem { get; }
        event EventHandler Finished;
        event EventHandler Updated; // score, currentproblem
    }
}
