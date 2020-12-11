using Models;
using Processor;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTests
{
    [Collection("Sequential")]
    public class ReCalculateFlashcardPracticePropsTests
    {
        // New flashcards
        [Fact]
        public void ReCalculateFlashcardPracticePropsTestsA()
        {
            FlashcardPracticeModel model = new FlashcardPracticeModel()
            {
                Id = Guid.Parse("ef12bd07-ed68-46da-93ff-f7083ca16880"),
                CorreactAnsInRow = null,
                NextPracticeDate = DateTime.Now.Date,
                FlashcardKnowledge = FlashcardKnowledge.DontKnow
            };

            IReCalculateFlashcardPracticeProps _processor = new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate());

            FlashcardDbModel answer = _processor.ReCalculate(model);

            Assert.IsType(typeof(FlashcardDbModel), answer);
            Assert.Equal(model.Id, answer.Id);
            Assert.Equal(0, answer.CorreactAnsInRow);
            Assert.Equal(DateTime.Now.Date, answer.NextPracticeDate);
        }

        [Fact]
        public void ReCalculateFlashcardPracticePropsTestsB()
        {
            FlashcardPracticeModel model = new FlashcardPracticeModel()
            {
                Id = Guid.Parse("ef12bd07-ed68-46da-93ff-f7083ca16880"),
                CorreactAnsInRow = null,
                NextPracticeDate = DateTime.Now.Date,
                FlashcardKnowledge = FlashcardKnowledge.AlmostKnow
            };

            IReCalculateFlashcardPracticeProps _processor = new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate());

            FlashcardDbModel answer = _processor.ReCalculate(model);

            Assert.IsType(typeof(FlashcardDbModel), answer);
            Assert.Equal(model.Id, answer.Id);
            Assert.Null(answer.CorreactAnsInRow);
            Assert.Equal(DateTime.Now.Date.AddDays(1), answer.NextPracticeDate);
        }

        [Fact]
        public void ReCalculateFlashcardPracticePropsTestsC()
        {
            FlashcardPracticeModel model = new FlashcardPracticeModel()
            {
                Id = Guid.Parse("ef12bd07-ed68-46da-93ff-f7083ca16880"),
                CorreactAnsInRow = null,
                NextPracticeDate = DateTime.Now.Date,
                FlashcardKnowledge = FlashcardKnowledge.Know
            };

            IReCalculateFlashcardPracticeProps _processor = new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate());

            FlashcardDbModel answer = _processor.ReCalculate(model);

            Assert.IsType(typeof(FlashcardDbModel), answer);
            Assert.Equal(model.Id, answer.Id);
            Assert.Equal(1, answer.CorreactAnsInRow);
            Assert.Equal(DateTime.Now.Date.AddDays(1), answer.NextPracticeDate);
        }

        // Not new Flashcards
        [Fact]
        public void ReCalculateFlashcardPracticePropsTestsD()
        {
            FlashcardPracticeModel model = new FlashcardPracticeModel()
            {
                Id = Guid.Parse("ef12bd07-ed68-46da-93ff-f7083ca16880"),
                CorreactAnsInRow = 2,
                NextPracticeDate = DateTime.Now.Date,
                FlashcardKnowledge = FlashcardKnowledge.Know
            };

            IReCalculateFlashcardPracticeProps _processor = new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate());

            FlashcardDbModel answer = _processor.ReCalculate(model);

            Assert.IsType(typeof(FlashcardDbModel), answer);
            Assert.Equal(model.Id, answer.Id);
            Assert.Equal(3, answer.CorreactAnsInRow);
            Assert.Equal(DateTime.Now.Date.AddDays(3), answer.NextPracticeDate);
        }

        [Fact]
        public void ReCalculateFlashcardPracticePropsTestsE()
        {
            FlashcardPracticeModel model = new FlashcardPracticeModel()
            {
                Id = Guid.Parse("ef12bd07-ed68-46da-93ff-f7083ca16880"),
                CorreactAnsInRow = 0,
                NextPracticeDate = DateTime.Now.Date,
                FlashcardKnowledge = FlashcardKnowledge.Know
            };

            IReCalculateFlashcardPracticeProps _processor = new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate());

            FlashcardDbModel answer = _processor.ReCalculate(model);

            Assert.IsType(typeof(FlashcardDbModel), answer);
            Assert.Equal(model.Id, answer.Id);
            Assert.Equal(1, answer.CorreactAnsInRow);
            Assert.Equal(DateTime.Now.Date.AddDays(1), answer.NextPracticeDate);
        }

        [Fact]
        public void ReCalculateFlashcardPracticePropsTestsF()
        {
            FlashcardPracticeModel model = new FlashcardPracticeModel()
            {
                Id = Guid.Parse("ef12bd07-ed68-46da-93ff-f7083ca16880"),
                CorreactAnsInRow = 2,
                NextPracticeDate = DateTime.Now.Date,
                FlashcardKnowledge = FlashcardKnowledge.AlmostKnow
            };

            IReCalculateFlashcardPracticeProps _processor = new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate());

            FlashcardDbModel answer = _processor.ReCalculate(model);

            Assert.IsType(typeof(FlashcardDbModel), answer);
            Assert.Equal(model.Id, answer.Id);
            Assert.Equal(2, answer.CorreactAnsInRow);
            Assert.Equal(DateTime.Now.Date.AddDays(1), answer.NextPracticeDate);
        }

        [Fact]
        public void ReCalculateFlashcardPracticePropsTestsG()
        {
            FlashcardPracticeModel model = new FlashcardPracticeModel()
            {
                Id = Guid.Parse("ef12bd07-ed68-46da-93ff-f7083ca16880"),
                CorreactAnsInRow = 2,
                NextPracticeDate = DateTime.Now.Date,
                FlashcardKnowledge = FlashcardKnowledge.DontKnow
            };

            IReCalculateFlashcardPracticeProps _processor = new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate());

            FlashcardDbModel answer = _processor.ReCalculate(model);

            Assert.IsType(typeof(FlashcardDbModel), answer);
            Assert.Equal(model.Id, answer.Id);
            Assert.Equal(0, answer.CorreactAnsInRow);
            Assert.Equal(DateTime.Now.Date, answer.NextPracticeDate);
        }
    }
}
