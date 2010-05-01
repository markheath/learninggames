using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework.Quiz;

namespace LearningGames.KeyWords
{
    class KeyWordsQuiz : QuizBase
    {
        QuizWordsProvider wordsProvider;
        Problem currentProblem;

        public KeyWordsQuiz(IEnumerable<string> keyWords)
        {
            this.wordsProvider = new QuizWordsProvider(keyWords, 20);
            currentProblem = wordsProvider.GetNextProblem();
        }

        public override Problem CurrentProblem
        {
            get { return currentProblem; }
        }

        private KeyWordProblem CurrentKeyWordProblem
        {
            get { return (KeyWordProblem)currentProblem; }
        }

        public void Correct()
        {
            Right++;
            currentProblem.RaiseAnswerEvent(true);
            currentProblem = wordsProvider.GetNextProblem();
        }

        public void Incorrect()
        {
            Wrong++;
            currentProblem.RaiseAnswerEvent(false);
            currentProblem = wordsProvider.GetNextProblem();
        }
    }
}
