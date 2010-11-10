using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class AdditionTests
    {
        [TestCase(0, 0, "0")]
        [TestCase(1, 0, "1")]
        [TestCase(0, 1, "1")]
        [TestCase(1, 1, "2")]
        [TestCase(3, 4, "7")]
        [TestCase(9, 9, "18")]
        public void TestIsCorrect(int first, int second, string answer)
        {
            Addition addition = new Addition(first, second);
            Assert.IsTrue(addition.SubmitAnswer(answer));
        }

        [TestCase(0, 0, "")]
        [TestCase(1, 0, "0")]
        [TestCase(0, 1, "2")]
        [TestCase(1, 1, "hello")]
        [TestCase(3, 4, "7.")]
        [TestCase(9, 9, ",18")]
        public void TestIsCorrectWithIncorrectAnswers(int first, int second, string answer)
        {
            Addition addition = new Addition(first, second);
            Assert.IsFalse(addition.SubmitAnswer(answer));
        }
    }
}
