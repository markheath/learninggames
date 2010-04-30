using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;
using Moq;
using LearningGames.Framework;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class SumQuizTests
    {
        SumQuiz sumQuiz;
        Mock<IProblemProvider> sumProvider;
        Addition[] sums;
        int sumIndex;

        [SetUp]
        public void SetUp()
        {
            sumIndex = 0;
            sums = new Addition[] {
                new Addition(1, 1),
                new Addition(2, 2)
            };
            sumProvider = new Mock<IProblemProvider>();
            sumProvider.Setup(x => x.GetNextProblem()).Returns(() => sums[sumIndex++]);
            sumQuiz = new SumQuiz(sumProvider.Object);
        }

        [Test]
        public void ScoreIsInitiallyZero()
        {
            Assert.AreEqual(0, sumQuiz.Right);
        }

        [Test]
        public void CurrentSumIsInitiallyPresent()
        {
            Assert.IsNotNull(sumQuiz.CurrentSum);
        }

        [Test]
        public void MovesToNextQuestionOnSubmitCorrectAnswer()
        {
            Assert.AreSame(sums[0], sumQuiz.CurrentSum);
            sumQuiz.SubmitAnswer("2");
            Assert.AreSame(sums[1], sumQuiz.CurrentSum);                       
        }

        [Test]
        public void StaysOnSameQuestionAfterSubmittingWrongAnswer()
        {
            Assert.AreSame(sums[0], sumQuiz.CurrentSum);
            sumQuiz.SubmitAnswer("3");
            Assert.AreSame(sums[0], sumQuiz.CurrentSum);
        }

        [Test]
        public void SubmitAnswerReturnsTrueForCorrectAnswer()
        {
            Assert.IsTrue(sumQuiz.SubmitAnswer("2"));            
        }

        [Test]
        public void SubmitAnswerReturnsFalseForIncorrectAnswer()
        {
            Assert.IsFalse(sumQuiz.SubmitAnswer("3"));
        }

        [Test]
        public void ScoreRemainsSameForIncorrectAnswer()
        {
            sumQuiz.SubmitAnswer("3");
            Assert.AreEqual(0, sumQuiz.Right);
        }

        [Test]
        public void ScoreIncreasesForCorrectAnswer()
        {
            sumQuiz.SubmitAnswer("2");
            Assert.AreEqual(1, sumQuiz.Right);
        }

        [Test]
        public void CanProvideBindableContent()
        {
            Assert.IsNotNull(sumQuiz.CurrentQuestionContent);
        }
    }
}
