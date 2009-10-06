using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.KeyWords
{
    class KeyWordsQuiz : QuizBase
    {
        IList<KeyWord> keyWordsList;
        int currentIndex = 0;

        public KeyWordsQuiz(IEnumerable<KeyWord> keyWords)
        {
            var list = keyWords.ToList();
            list.Shuffle();
            var truncatedList = new List<KeyWord>();

            truncatedList.AddRange(list.Take(20));
            keyWordsList = truncatedList;
        }

        public override bool SubmitAnswer(string answer)
        {
            throw new NotImplementedException();
        }

        public override object CurrentQuestionContent
        {
            get { return CurrentWord.Word; }
        }

        public void Correct()
        {
            Right++;
            MoveNext();
        }

        public void Incorrect()
        {
            Wrong++;
            // put it to the back of the list to be tried again
            keyWordsList.Add(CurrentWord);
            MoveNext();
        }

        public KeyWord CurrentWord
        {
            get { return keyWordsList[currentIndex]; }
        }

        private void MoveNext()
        {
            if (currentIndex < keyWordsList.Count - 1)
            {
                currentIndex++;
            }
            else
            {

            }
        }
    }
}
