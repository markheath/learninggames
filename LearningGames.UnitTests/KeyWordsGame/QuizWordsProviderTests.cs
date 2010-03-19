using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.KeyWords;

namespace LearningGames.UnitTests.KeyWordsGame
{
    [TestFixture]
    public class QuizWordsProviderTests
    {
        private static readonly KeyWord[] keyWords =
            new KeyWord[] {
                new KeyWord() { Word = "First" },
                new KeyWord() { Word = "Second" },
                new KeyWord() { Word = "Third" },
                new KeyWord() { Word = "Fourth" },
            };

        [Test]
        public void FirstWordMustNotBeNull()
        {
            // arrange
            QuizWordsProvider provider = new QuizWordsProvider(keyWords,2);

            // act & assert
            Assert.IsNotNull(provider.CurrentWord);
        }

        [Test]
        public void RightAnswerMovesToNewWord()
        {
            // arrange
            QuizWordsProvider provider = new QuizWordsProvider(keyWords, 2);
            KeyWord firstWord = provider.CurrentWord;

            // act
            provider.Right();

            // assert
            Assert.AreNotEqual(firstWord, provider.CurrentWord.Word);
        }

        [Test]
        public void NullAfterAllWordsCompleted()
        {
            // arrange
            QuizWordsProvider provider = new QuizWordsProvider(keyWords, 2);
            KeyWord firstWord = provider.CurrentWord;

            // act
            provider.Right();
            provider.Right();

            // assert
            Assert.IsNull(provider.CurrentWord);
        }

        [Test]
        public void RetriesAWrongWord()
        {
            // arrange
            QuizWordsProvider provider = new QuizWordsProvider(keyWords, 2);
            KeyWord firstWord = provider.CurrentWord;

            // act
            provider.Wrong();
            provider.Right();

            // assert
            Assert.AreEqual(firstWord, provider.CurrentWord);
        }

        [Test]
        public void GivesUpAfterSecondTry()
        {
            // arrange
            QuizWordsProvider provider = new QuizWordsProvider(keyWords, 2);
            KeyWord firstWord = provider.CurrentWord;

            // act
            provider.Wrong();
            provider.Right();
            provider.Wrong();

            // assert
            Assert.IsNull(provider.CurrentWord);
        }
    }
}
