using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class DivisionTests
    {
        [TestCase(2, 1, "2")]
        [TestCase(0, 3, "0")]
        [TestCase(10, 5, "2")]
        [TestCase(64, 8, "8")]
        public void TestIsCorrect(int first, int second, string answer)
        {
            Division division = new Division(first, second);
            Assert.IsTrue(division.SubmitAnswer(answer));
        }

        [TestCase(0, 2, "")]
        [TestCase(5, 1, "1")]
        [TestCase(1, 1, "hello")]
        [TestCase(12, 4, "7")]
        [TestCase(9, 9, "18")]
        public void TestIsCorrectWithIncorrectAnswers(int first, int second, string answer)
        {
            Division division = new Division(first, second);
            Assert.IsFalse(division.SubmitAnswer(answer));
        }

        [Test]
        public void CanProvideContent()
        {
            Division division = new Division(2, 1);
            Assert.IsNotNull(division.Content);
        }

        [Test]
        public void DescribesDivideByTwoAsHalf()
        {
            Division division = new Division(4, 2);
            Assert.IsTrue(division.ToString().Contains("Half"));
        }
    }
}
