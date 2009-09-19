﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class MultiplicationSumTypeTests
    {
        [Test]
        public void MultiplicationSumTypeHasCorrectName()
        {
            MultiplicationSumType multiplicationSumType = new MultiplicationSumType();
            Assert.IsTrue(multiplicationSumType.Name.Contains("Multiplication"));
        }

        [Test]
        public void MultiplicationSumTypeCanCreateRandomQuestion()
        {
            MultiplicationSumType multiplicationSumType = new MultiplicationSumType();
            var sum = multiplicationSumType.CreateRandom(new Random());
            Assert.IsInstanceOf<Multiplication>(sum);
        }
    }
}