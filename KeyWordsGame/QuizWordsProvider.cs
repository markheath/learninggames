using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.KeyWords
{
    public class QuizWordsProvider
    {
        IList<WordAttempts> keyWordsList;
        int currentIndex = 0;
        int maxAttemptsPerWord = 2;

        public QuizWordsProvider(IEnumerable<KeyWord> keyWords, int words)
        {
            var list = keyWords.ToList();
            list.Shuffle();

            keyWordsList = new List<WordAttempts>();
            foreach(var keyWord in list.Take(words))
            {
                keyWordsList.Add(new WordAttempts() { KeyWord = keyWord });
            }
        }

        public void Wrong()
        {
            keyWordsList[currentIndex].Attempts++;
            MoveNext();
        }

        public void Right()
        {
            keyWordsList[currentIndex].Attempts++;
            keyWordsList[currentIndex].Success = true;
            MoveNext();
        }

        private void MoveNext()
        {
            bool found = false;
            for (int testIndex = currentIndex + 1; testIndex < currentIndex + keyWordsList.Count; testIndex++)
            {
                int realIndex = testIndex % keyWordsList.Count;
                if (keyWordsList[realIndex].Success == false && keyWordsList[realIndex].Attempts < maxAttemptsPerWord)
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

        public KeyWord CurrentWord
        {
            get { return currentIndex == -1 ? null : keyWordsList[currentIndex].KeyWord; }
        }
    }

    class WordAttempts
    {
        public KeyWord KeyWord { get; set; }
        public int Attempts { get; set; }
        public bool Success { get; set; }
    }
}
