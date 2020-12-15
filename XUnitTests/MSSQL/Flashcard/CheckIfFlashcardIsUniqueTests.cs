using Xunit;
using System;
using DatabaseModuleInterface;
using DatabaseModule;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class CheckIfFlashcardIsUniqueTests
    {
        [Fact]
        public void CheckIfFlashcardIsUniqueTestA()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfFlashcardIsUnique _processor = new CheckIfFlashcardIsUnique();

            Assert.True(_processor.IsUnique("Flashcard 1 Foreign", "Flashcard 1 Native", Guid.Parse("1d917073-68ea-4e11-b4ae-816f30e33e72")));
        }

        [Fact]
        public void CheckIfFlashcardIsUniqueTestB()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfFlashcardIsUnique _processor = new CheckIfFlashcardIsUnique();

            Assert.True(_processor.IsUnique("", "", Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")));
        }

        [Fact]
        public void CheckIfFlashcardIsUniqueTestC()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfFlashcardIsUnique _processor = new CheckIfFlashcardIsUnique();

            Assert.False(_processor.IsUnique("Flashcard 1 Foreign", "Flashcard 1 Native", Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")));
        }

        [Fact]
        public void CheckIfFlashcardIsUniqueTestD()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfFlashcardIsUnique _processor = new CheckIfFlashcardIsUnique();

            Assert.False(_processor.IsUnique("Flashcard 1 Foreign", "Flashcard 1 s", Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")));
        }

        [Fact]
        public void CheckIfFlashcardIsUniqueTestE()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfFlashcardIsUnique _processor = new CheckIfFlashcardIsUnique();

            Assert.True(_processor.IsUnique("XZXX", "Flashcard 1 s", Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")));
        }

        [Fact]
        public void CheckIfFlashcardIsUniqueTestF()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfFlashcardIsUnique _processor = new CheckIfFlashcardIsUnique();

            Assert.True(_processor.IsUnique("Flashcard 6 Foreign", "Flashcard 6 Native", Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")));
        }
    }
}
