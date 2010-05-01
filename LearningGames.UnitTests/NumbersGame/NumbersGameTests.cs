using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture, RequiresSTA]
    public class NumbersGameTests
    {
        LearningGames.Numbers.NumbersGame game;

        [SetUp]
        public void SetUp()
        {
            game = new LearningGames.Numbers.NumbersGame();
        }

        [Test]
        public void NumbersGameCanCreateGui()
        {
            var gui = game.Gui;
            Assert.IsNotNull(gui);
        }

        [Test]
        public void NumbersGameAssignsViewModel()
        {            
            var dataContext = game.Gui.DataContext;
            Assert.IsNotNull(dataContext);
        }

        [Test]
        public void NumbersGameHasDescription()
        {
            Assert.AreEqual("Numbers", game.Name);
        }
    }
}
