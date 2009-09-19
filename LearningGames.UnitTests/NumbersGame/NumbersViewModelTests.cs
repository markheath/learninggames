using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;
using Moq;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class NumbersViewModelTests
    {
        NumbersViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            var sumProvider = new Mock<ISumProvider>();
            var quiz = new SumQuiz(sumProvider.Object);
            viewModel = new NumbersViewModel(quiz);
        }
    }
}
