using DatabaseModule;
using DatabaseModuleInterface;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class UpdateFlashcardPracticePropertiesTests
    {
        [Fact]
        public void UpdateFlashcardPracticePropertiesTestsA()
        {
            ResetTestDatabasev2.Reset();

            var flashcard = new FlashcardDbModel()
            {
                Id = Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 1 Native",
                ForeignLanguage = "Flashcard 1 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 8),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            };

            flashcard.CorreactAnsInRow = 1;
            flashcard.NextPracticeDate = new DateTime(2020, 12, 11);

            IUpdateFlashcardPracticeProperties updateFlashcardPracticeProperties = new UpdateFlashcardPracticeProperties();

            updateFlashcardPracticeProperties.Update(flashcard);

            using (var db = new FlashcardsDbContext())
            {
                var updatedFlashcard = db.FlashcardsDbModels.Find(flashcard.Id, flashcard.PracticeDirection);

                Assert.NotNull(updatedFlashcard);

                Assert.Equal(updatedFlashcard.CorreactAnsInRow, flashcard.CorreactAnsInRow);
                Assert.Equal(updatedFlashcard.NextPracticeDate, flashcard.NextPracticeDate);
            }
        }
    }
}
