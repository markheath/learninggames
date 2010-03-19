using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;

namespace LearningGames.KeyWords
{
    class KeyWordsQuiz : QuizBase
    {
        QuizWordsProvider wordsProvider;

        public KeyWordsQuiz(IEnumerable<KeyWord> keyWords)
        {
            this.wordsProvider = new QuizWordsProvider(keyWords, 20);
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
            wordsProvider.Right();
        }

        public void Incorrect()
        {
            Wrong++;
            wordsProvider.Wrong();
        }

        public KeyWord CurrentWord
        {
            get { return wordsProvider.CurrentWord; }
        }


    }
}
