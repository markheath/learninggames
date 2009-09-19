using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Framework
{
    public interface IQuiz
    {
        int Score { get; }
        bool SubmitAnswer(string answer);
        object CurrentQuestionContent { get; }
    }
}
