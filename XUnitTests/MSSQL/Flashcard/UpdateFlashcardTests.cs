using DatabaseModule;
using Processor;
using System;
using System.Linq;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class UpdateFlashcardTests
    {
        [Fact]
        public void UpdateFlashcardTestA()
        {
            ResetTestDatabasev5.Reset();

            var _processor = new UpdateFlashcard(
                new CheckIfFlashcardIsUnique(),
                new ValidateFlashcard(),
                new UpdateFlashcardWords());

            Assert.True(_processor.Update(
                "Flashcard 7.1 native", 
                "Flashcard 7.1 foreign", 
                Guid.Parse("45433894-5820-413f-93fb-46429ba8486a"), 
                Guid.Parse("d7e0f1ef-49de-486e-b88a-d0e0c1d8f496")));

            Assert.Empty(_processor.GetUserMessages());

            using (var db = new FlashcardsDbContext())
            {
                Assert.Equal(2, db.FlashcardsDbModels
                    .Where(e => e.Id == Guid.Parse("45433894-5820-413f-93fb-46429ba8486a") &&
                    e.ForeignLanguage == "Flashcard 7.1 foreign" &&
                    e.NativeLanguage == "Flashcard 7.1 native")
                    .Count());
            }
        }

        [Fact]
        public void UpdateFlashcardTestB()
        {
            ResetTestDatabasev5.Reset();

            var _processor = new UpdateFlashcard(
                new CheckIfFlashcardIsUnique(),
                new ValidateFlashcard(),
                new UpdateFlashcardWords());

            Assert.False(_processor.Update(
                "Flashcard 7.1 native ",
                "Flashcard 7.1 foreign",
                Guid.Parse("45433894-5820-413f-93fb-46429ba8486a"),
                Guid.Parse("d7e0f1ef-49de-486e-b88a-d0e0c1d8f496")));

            Assert.NotEmpty(_processor.GetUserMessages());

            using (var db = new FlashcardsDbContext())
            {
                Assert.Equal(0, db.FlashcardsDbModels
                    .Where(e => e.Id == Guid.Parse("45433894-5820-413f-93fb-46429ba8486a") &&
                    e.ForeignLanguage == "Flashcard 7.1 foreign" &&
                    e.NativeLanguage == "Flashcard 7.1 native")
                    .Count());
            }
        }
    }
}
