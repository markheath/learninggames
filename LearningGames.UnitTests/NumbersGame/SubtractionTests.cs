using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class SubtractionTests
    {
        [TestCase(0, 0, "0")]
        [TestCase(1, 0, "1")]
        [TestCase(0, 1, "-1")]
        [TestCase(1, 1, "0")]
        [TestCase(6, 4, "2")]
        [TestCase(19, 5, "14")]
        public void TestIsCorrect(int first, int second, string answer)
        {
            Subtraction subtraction = new Subtraction(first, second);
            Assert.IsTrue(subtraction.SubmitAnswer(answer));
        }

        [TestCase(0, 0, "")]
        [TestCase(1, 0, "0")]
        [TestCase(0, 1, "2")]
        [TestCase(1, 1, "hello")]
        [TestCase(3, 4, "7.")]
        [TestCase(9, 9, ",18")]
        public void TestIsCorrectWithIncorrectAnswers(int first, int second, string answer)
        {
            Subtraction subtraction = new Subtraction(first, second);
            Assert.IsFalse(subtraction.SubmitAnswer(answer));
        }

        [Test]
        public void CanProvideContent()
        {
            Subtraction subtraction = new Subtraction(1, 2);
            Assert.IsNotNull(subtraction.Content);
        }
    }
}
