using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;
using Moq;
using LearningGames.Framework;
using System.ComponentModel;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class NumbersViewModelTests
    {
        NumbersViewModel viewModel;
        Mock<IQuiz> quizMock;
        List<PropertyChangedEventArgs> propertyChangedEvents;

        [SetUp]
        public void SetUp()
        {
            this.quizMock = new Mock<IQuiz>();
            this.viewModel = new NumbersViewModel(quizMock.Object);
            this.propertyChangedEvents = new List<PropertyChangedEventArgs>();
            this.viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        [Test]
        public void SumPropertyChangedEventShouldFireWhenAnimationCompletes()
        {
            viewModel.CompletedCommand.Execute(null);
            Assert.IsNotNull(propertyChangedEvents.Find(p => p.PropertyName == "Sum"));
        }

        [Test]
        public void AllowAnswerInitially()
        {
            Assert.IsTrue(viewModel.AllowAnswer);
        }

        [Test]
        public void DontAllowAnswerWhilePlayingCorrectAnswerAnimation()
        {
            viewModel.QuestionState = QuestionState.Correct;
            Assert.IsFalse(viewModel.AllowAnswer);
        }

        [Test]
        public void AllowAnswerPropertyChangedEventShouldFireWhenChangingQuestionState()
        {
            viewModel.QuestionState = QuestionState.Correct;
            Assert.IsNotNull(propertyChangedEvents.Find(p => p.PropertyName == "AllowAnswer"));
        }

        [Test]
        public void DontAllowAnswerWhilePlayingIncorrectAnswerAnimation()
        {
            viewModel.QuestionState = QuestionState.Incorrect;
            Assert.IsFalse(viewModel.AllowAnswer);
        }

        void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.propertyChangedEvents.Add(e);
        }
    }
}
