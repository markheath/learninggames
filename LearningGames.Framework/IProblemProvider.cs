﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Framework
{
    public interface IProblemProvider
    {
        Problem GetNextProblem();
    }
}