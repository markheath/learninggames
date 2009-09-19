using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class SumQuizTest
    {
        SumQuiz sumQuiz;

        [SetUp]
        public void SetUp()
        {
            sumQuiz = new SumQuiz();
        }

        [Test]
        public void RightAnswersIsInitiallyZero()
        {
            Assert.AreEqual(0, sumQuiz.RightAnswers);
        }
    }
}
