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
    public class SubtractionSumTypeTests
    {
        [Test]
        public void SubtractionSumTypeHasCorrectName()
        {
            var sumType = new SubtractionSumType();
            Assert.IsTrue(sumType.Name.Contains("Subtraction"));
        }

        [Test]
        public void SubtractionSumTypeCanCreateRandomQuestion()
        {
            var sumType = new SubtractionSumType();
            var sum = sumType.CreateRandom(new Random(), Difficulty.Year3);
            Assert.IsInstanceOf<Subtraction>(sum);
        }
    }
}
