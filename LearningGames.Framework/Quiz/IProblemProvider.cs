using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Framework.Quiz
{
    public interface IProblemProvider
    {
        Problem GetNextProblem();
    }
}
