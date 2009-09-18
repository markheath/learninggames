using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.KeyWords
{
    interface ISpeechService
    {
        void Speak(string word, Action finished);
    }
}
