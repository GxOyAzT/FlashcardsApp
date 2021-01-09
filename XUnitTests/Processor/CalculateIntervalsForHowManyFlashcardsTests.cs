using Processor;
using System.Collections.Generic;
using Xunit;

namespace XUnitTests.Processor
{
    public class CalculateIntervalsForHowManyFlashcardsTests
    {
        [Fact]
        public void CalculateIntervalsForHowManyFlashcardsTestH()
        {
            var _processor = new CalculateIntervalsForHowManyFlashcards();

            Assert.Equal(_processor.Claculate(0), new List<int>() );
        }

            [Fact]
        public void CalculateIntervalsForHowManyFlashcardsTestA()
        {
            var _processor = new CalculateIntervalsForHowManyFlashcards();

            Assert.Equal(_processor.Claculate(2), new List<int>() { 2 });
        }

        [Fact]
        public void CalculateIntervalsForHowManyFlashcardsTestB()
        {
            var _processor = new CalculateIntervalsForHowManyFlashcards();

            Assert.Equal(_processor.Claculate(5), new List<int>() { 5 });
        }

        [Fact]
        public void CalculateIntervalsForHowManyFlashcardsTestC()
        {
            var _processor = new CalculateIntervalsForHowManyFlashcards();

            Assert.Equal(_processor.Claculate(7), new List<int>() { 5, 7 });
        }

        [Fact]
        public void CalculateIntervalsForHowManyFlashcardsTestD()
        {
            var _processor = new CalculateIntervalsForHowManyFlashcards();

            Assert.Equal(_processor.Claculate(13), new List<int>() { 5, 9, 13 });
        }

        [Fact]
        public void CalculateIntervalsForHowManyFlashcardsTestE()
        {
            var _processor = new CalculateIntervalsForHowManyFlashcards();

            Assert.Equal(_processor.Claculate(18), new List<int>() { 5, 13, 18 });
        }

        [Fact]
        public void CalculateIntervalsForHowManyFlashcardsTestF()
        {
            var _processor = new CalculateIntervalsForHowManyFlashcards();

            Assert.Equal(_processor.Claculate(27), new List<int>() { 5, 6, 13, 20, 27 });
        }

        [Fact]
        public void CalculateIntervalsForHowManyFlashcardsTestG()
        {
            var _processor = new CalculateIntervalsForHowManyFlashcards();

            Assert.Equal(_processor.Claculate(201), new List<int>() { 5, 20, 50, 70, 100 });
        }
    }
}
