using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;
using LearningGames.Framework.Quiz;

namespace LearningGames.KeyWords
{
    public class QuizWordsProvider : IProblemProvider
    {
        int currentIndex = 0;
        int maxAttemptsPerWord = 2;

        IList<KeyWordProblem> keyWordsList;

        public QuizWordsProvider(IEnumerable<string> keyWords, int words)
        {
            var list = keyWords.ToList();
            list.Shuffle();

            keyWordsList = new List<KeyWordProblem>();
            foreach(var keyWord in list.Take(words))
            {
                keyWordsList.Add(new KeyWordProblem(keyWord));
            }
        }

        public Problem GetNextProblem()
        {
            MoveNext();
            return CurrentProblem;
        }

        private void MoveNext()
        {
            bool found = false;
            for (int testIndex = currentIndex + 1; testIndex < currentIndex + keyWordsList.Count; testIndex++)
            {
                int realIndex = testIndex % keyWordsList.Count;
                if (keyWordsList[realIndex].IsCorrect == false && keyWordsList[realIndex].Attempts < maxAttemptsPerWord)
                {
                    found = true;
                    currentIndex = realIndex;
                    break;
                }
            }
            if (!found)
            {
                currentIndex = -1;
            }
        }

        private KeyWordProblem CurrentProblem
        {
            get { return currentIndex == -1 ? null : keyWordsList[currentIndex]; }
        }
    }

}
