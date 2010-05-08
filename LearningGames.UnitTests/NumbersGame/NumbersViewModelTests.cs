using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LearningGames.Numbers;
using Moq;
using LearningGames.Framework.Quiz;
using System.ComponentModel;

namespace LearningGames.UnitTests.NumbersGame
{
    [TestFixture]
    public class TextAnswerViewModelTests
    {
        TextAnswerViewModel viewModel;        
        List<PropertyChangedEventArgs> propertyChangedEvents;

        [SetUp]
        public void SetUp()
        {
            var tap = new Mock<TextAnswerProblem>();
            this.viewModel = new TextAnswerViewModel(tap.Object);
            this.propertyChangedEvents = new List<PropertyChangedEventArgs>();
            this.viewModel.PropertyChanged += (sender, args) => propertyChangedEvents.Add(args);            
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

        /* For QuizViewModel [Test]
        public void ScoreIsReturnedFromQuiz()
        {
            quizMock.Setup(x => x.Right).Returns(5);
            Assert.AreEqual(5, viewModel.Score);
        }*/

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
        public void SubmittingCorrectAnswerShouldCauseScorePropertyChangedEventToFire()
        {
            viewModel.SubmitAnswerCommand.Execute(null);
            Assert.IsNotNull(propertyChangedEvents.Find(p => p.PropertyName == "Score"));
        }

        [Test]
        public void DontAllowAnswerWhilePlayingIncorrectAnswerAnimation()
        {
            viewModel.QuestionState = QuestionState.Incorrect;
            Assert.IsFalse(viewModel.AllowAnswer);
        }

        [Test]
        public void SubmittingAnswerPassesAnswerPropertyToQuiz()
        {
            // TODO: this test does nothing now
            viewModel.Answer = "abcde";
            viewModel.SubmitAnswerCommand.Execute(null);
            //quizMock.Verify(x => x.SubmitAnswer("abcde"));
        }

        [Test]
        public void SubmittingCorrectAnswerSetsQuestionStateToCorrect()
        {
            //quizMock.Setup(x => x.SubmitAnswer(It.IsAny<string>())).Returns(true);
            viewModel.SubmitAnswerCommand.Execute(null);
            Assert.AreEqual(QuestionState.Correct, viewModel.QuestionState);
        }

        [Test]
        public void SubmittingCorrectAnswerCausesStartCorrectAnswerEventToBeFired()
        {
            //quizMock.Setup(x => x.SubmitAnswer(It.IsAny<string>())).Returns(true);
            EventArgs startCorrectAnswerArgs = null;
            viewModel.StartCorrectAnswer.Event += (sender, args) => startCorrectAnswerArgs = args;
            viewModel.SubmitAnswerCommand.Execute(null);            
            Assert.IsNotNull(startCorrectAnswerArgs);
        }

        [Test]
        public void SubmittingIncorrectAnswerCausesStartWrongAnswerEventToBeFired()
        {
            //quizMock.Setup(x => x.SubmitAnswer(It.IsAny<string>())).Returns(false);
            EventArgs startWrongAnswerArgs = null;
            viewModel.StartWrongAnswer.Event += (sender, args) => startWrongAnswerArgs = args;
            viewModel.SubmitAnswerCommand.Execute(null);
            Assert.IsNotNull(startWrongAnswerArgs);
        }

        [Test]
        public void SubmittingIncorrectAnswerSetsQuestionStateToIncorrect()
        {
            //quizMock.Setup(x => x.SubmitAnswer(It.IsAny<string>())).Returns(false);
            viewModel.SubmitAnswerCommand.Execute(null);
            Assert.AreEqual(QuestionState.Incorrect, viewModel.QuestionState);
        }        
    }
}
