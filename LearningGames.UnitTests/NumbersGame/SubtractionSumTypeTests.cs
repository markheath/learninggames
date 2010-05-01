using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;
using LearningGames.Framework.Quiz;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class SubtractionSumTypeTests
    {
        [Test]
        public void SubtractionSumTypeHasCorrectName()
        {
            var sumType = new SubtractionProblemGenerator(Difficulty.Year3);
            Assert.IsTrue(sumType.Name.Contains("Subtraction"));
        }

        [Test]
        public void SubtractionSumTypeCanCreateRandomQuestion()
        {
            var sumType = new SubtractionProblemGenerator(Difficulty.Year3);
            var sum = sumType.CreateRandom(new Random());
            Assert.IsInstanceOf<Subtraction>(sum);
        }
    }
}
