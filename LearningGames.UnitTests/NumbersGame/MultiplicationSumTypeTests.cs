using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;
using LearningGames.Framework;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class MultiplicationSumTypeTests
    {
        [Test]
        public void MultiplicationSumTypeHasCorrectName()
        {
            MultiplicationProblemGenerator multiplicationSumType = new MultiplicationProblemGenerator(Difficulty.Year3);
            Assert.IsTrue(multiplicationSumType.Name.Contains("Multiplication"));
        }

        [Test]
        public void MultiplicationSumTypeCanCreateRandomQuestion()
        {
            MultiplicationProblemGenerator multiplicationSumType = new MultiplicationProblemGenerator(Difficulty.Year3);
            var sum = multiplicationSumType.CreateRandom(new Random());
            Assert.IsInstanceOf<Multiplication>(sum);
        }
    }
}
