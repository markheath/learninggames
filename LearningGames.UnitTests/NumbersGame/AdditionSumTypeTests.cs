﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class AdditionSumTypeTests
    {
        [Test]
        public void AdditionSumTypeHasCorrectName()
        {
            AdditionSumType additionSumType = new AdditionSumType();
            Assert.IsTrue(additionSumType.Name.Contains("Addition"));
        }

        [Test]
        public void AdditionSumTypeCanCreateRandomQuestion()
        {
            AdditionSumType additionSumType = new AdditionSumType();
            var sum = additionSumType.CreateRandom(new Random());
            Assert.IsInstanceOf<Addition>(sum);
        }
    }
}