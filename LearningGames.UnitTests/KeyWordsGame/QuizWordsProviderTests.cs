using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.KeyWords;
using LearningGames.Framework.Quiz;

namespace LearningGames.UnitTests.KeyWordsGame
{
    [TestFixture]
    public class QuizWordsProviderTests
    {
        private static readonly string[] keyWords =
            {
                "First", "Second", "Third", "Fourth"
            };

        [Test]
        public void FirstWordMustNotBeNull()
        {
            // arrange
            QuizWordsProvider provider = new QuizWordsProvider(keyWords,2);

            // act & assert
            Assert.IsNotNull(provider.GetNextProblem());
        }

        [Test]
        public void RightAnswerMovesToNewWord()
        {
            // arrange
            QuizWordsProvider provider = new QuizWordsProvider(keyWords, 2);
            Problem firstProblem = provider.GetNextProblem();
            firstProblem.RaiseAnswerEvent(true);
            
            // act
            Problem secondProblem = provider.GetNextProblem();

            // assert
            Assert.AreNotEqual(firstProblem, secondProblem);
        }

        [Test]
        public void NullAfterAllWordsCompleted()
        {
            // arrange
            QuizWordsProvider provider = new QuizWordsProvider(keyWords, 2);
            Problem firstProblem = provider.GetNextProblem();
            firstProblem.RaiseAnswerEvent(true);

            // act
            Problem secondProblem = provider.GetNextProblem();
            secondProblem.RaiseAnswerEvent(true); 

            Problem lastProblem = provider.GetNextProblem();

            // assert
            Assert.IsNull(lastProblem);
        }

        [Test]
        public void RetriesAWrongWord()
        {
            // arrange
            QuizWordsProvider provider = new QuizWordsProvider(keyWords, 2);
            Problem firstProblem = provider.GetNextProblem();

            // act
            firstProblem.RaiseAnswerEvent(false);
            Problem secondProblem = provider.GetNextProblem();
            secondProblem.RaiseAnswerEvent(true);

            Problem thirdProblem = provider.GetNextProblem();

            // assert
            Assert.AreEqual(((KeyWordProblem)firstProblem).Word, ((KeyWordProblem)thirdProblem).Word);
        }

        [Test]
        public void GivesUpAfterSecondTry()
        {
            // arrange
            QuizWordsProvider provider = new QuizWordsProvider(keyWords, 2);
            Problem firstProblem = provider.GetNextProblem();

            // act
            firstProblem.RaiseAnswerEvent(false);
            Problem secondProblem = provider.GetNextProblem();
            secondProblem.RaiseAnswerEvent(true);
            Problem thirdProblem = provider.GetNextProblem();
            secondProblem.RaiseAnswerEvent(false);
            Problem fourthProblem = provider.GetNextProblem();
            
            // assert
            Assert.IsNull(fourthProblem);
        }
    }
}
