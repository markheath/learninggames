using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.KeyWords
{
    class KeyWordsManager
    {
        int right;
        int wrong;
        IList<KeyWord> keyWordsList;
        int currentIndex = 0;

        public KeyWordsManager(IEnumerable<KeyWord> keyWords)
        {
            this.keyWordsList = keyWords.ToList();
            this.keyWordsList.Shuffle();
        }

        public void Correct()
        {
            right++;
            MoveNext();
        }

        public void Incorrect()
        {
            wrong++;
            // put it to the back of the list to be tried again
            keyWordsList.Add(CurrentWord);
            MoveNext();
        }

        public KeyWord CurrentWord
        {
            get { return keyWordsList[currentIndex]; }
        }

        public string Word
        {
            get { return CurrentWord.Word; }
        }

        private void MoveNext()
        {
            if (currentIndex < keyWordsList.Count - 1)
            {
                currentIndex++;

            }
            else
            {
                //TODO: finished
                //MessageBox.Show("Finished");
            }

        }

        public int Right { get { return right; } }
        public int Wrong { get { return wrong; } }
    }
}
