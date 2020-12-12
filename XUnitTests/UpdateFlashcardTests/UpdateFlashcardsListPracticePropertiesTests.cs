using DatabaseModule;
using Models;
using Processor;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTests
{
    [Collection("Sequential")]
    public class UpdateFlashcardsListPracticePropertiesTests
    {
        [Fact]
        public void UpdateFlashcardsListPracticePropertiesTestsB()
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

            var flashcard2 = new FlashcardDbModel()
            {
                Id = Guid.Parse("ef05a03f-a56c-4c86-9485-c08686a466c9"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 5 Native",
                ForeignLanguage = "Flashcard 5 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 5),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            };

            flashcard2.CorreactAnsInRow = 3;
            flashcard2.NextPracticeDate = new DateTime(2020, 12, 25);

            List<FlashcardDbModel> input = new List<FlashcardDbModel>() { flashcard, flashcard2 };

            IUpdateFlashcardsListPracticeProperties _processor = new UpdateFlashcardsListPracticeProperties(new UpdateFlashcardPracticeProperties());

            _processor.Update(input);

            using (var db = new FlashcardsDbContext())
            {
                var updatedFlashcard = db.FlashcardsDbModels.Find(flashcard.Id, flashcard.PracticeDirection);

                var updatedFlashcard2 = db.FlashcardsDbModels.Find(flashcard2.Id, flashcard2.PracticeDirection);

                Assert.NotNull(updatedFlashcard);
                Assert.Equal(updatedFlashcard.CorreactAnsInRow, flashcard.CorreactAnsInRow);
                Assert.Equal(updatedFlashcard.NextPracticeDate, flashcard.NextPracticeDate);

                Assert.NotNull(updatedFlashcard2);
                Assert.Equal(updatedFlashcard2.CorreactAnsInRow, flashcard2.CorreactAnsInRow);
                Assert.Equal(updatedFlashcard2.NextPracticeDate, flashcard2.NextPracticeDate);
            }
        }
    }
}
