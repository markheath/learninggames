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
        bool SubmitAnswer(string answer);
        object CurrentQuestionContent { get; }
        event EventHandler Finished;
    }
}
