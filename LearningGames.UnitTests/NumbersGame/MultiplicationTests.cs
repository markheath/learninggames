using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class MultiplicationTests
    {
        [TestCase(0, 0, "0")]
        [TestCase(1, 0, "0")]
        [TestCase(3, 4, "12")]
        [TestCase(9, 9, "81")]
        public void TestIsCorrect(int first, int second, string answer)
        {
            Multiplication multiplication = new Multiplication(first, second);
            Assert.IsTrue(multiplication.SubmitAnswer(answer));
        }

        [TestCase(0, 0, "")]
        [TestCase(1, 0, "1")]
        [TestCase(1, 1, "hello")]
        [TestCase(3, 4, "7")]
        [TestCase(9, 9, "18")]
        public void TestIsCorrectWithIncorrectAnswers(int first, int second, string answer)
        {
            Multiplication multiplication = new Multiplication(first, second);
            Assert.IsFalse(multiplication.SubmitAnswer(answer));
        }

        [Test]
        public void CanProvideContent()
        {
            Multiplication multiplication = new Multiplication(1, 2);
            Assert.IsNotNull(multiplication.Content);
        }
    }
}
