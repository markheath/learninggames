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
    public class AdditionSumTypeTests
    {
        [Test]
        public void AdditionSumTypeHasCorrectName()
        {
            AdditionProblemGenerator additionSumType = new AdditionProblemGenerator(Difficulty.Year3);
            Assert.IsTrue(additionSumType.Name.Contains("Addition"));
        }

        [Test]
        public void AdditionSumTypeCanCreateRandomQuestion()
        {
            AdditionProblemGenerator additionSumType = new AdditionProblemGenerator(Difficulty.Year3);
            var sum = additionSumType.CreateRandom(new Random());
            Assert.IsInstanceOf<Addition>(sum);
        }
    }
}
