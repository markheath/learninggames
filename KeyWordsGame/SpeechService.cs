using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;

namespace LearningGames.KeyWords
{
    class SpeechService : ISpeechService
    {
        SpeechSynthesizer synthesizer;

        public SpeechService()
        {
            this.synthesizer = new SpeechSynthesizer();
        }

        public void Speak(string word, Action finished)
        {
            synthesizer.SpeakAsync(word);
        }
    }
}
