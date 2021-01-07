using DatabaseModule;
using Models;
using Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTests.Processor
{
    [Collection("Sequential")]
    public class ReCalculateAndUpdatePracticePropertiesListTests
    {
        [Fact]
        public void ReCalculateAndUpdatePracticePropertiesListTestA()
        {
            ResetTestDatabasev5.Reset();

            FlashcardDbModel flashcard;
            FlashcardPracticeModel flashcardPractice;
            using (var db = new FlashcardsDbContext())
            {
                flashcard = db.FlashcardsDbModels.FirstOrDefault(e => e.Id == Guid.Parse("32aee329-6675-4ae8-898a-95bb94ea0143") && e.PracticeDirection == PracticeDirection.FromForeignToNative);

                flashcardPractice = new FlashcardPracticeModel()
                {
                    Id = flashcard.Id,
                    PracticeDirection = flashcard.PracticeDirection,
                    FlashcardKnowledgeInt = 1,
                    CorreactAnsInRow = flashcard.CorreactAnsInRow
                };
            }

            ReCalculateAndUpdatePracticePropertiesList _processor = new ReCalculateAndUpdatePracticePropertiesList(new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate()),
                new UpdateFlashcardsListPracticeProperties(
                    new UpdateFlashcardPracticeProperties()));

            _processor.ReCauculate(new List<FlashcardPracticeModel>() { flashcardPractice });

            using (var db = new FlashcardsDbContext())
            {
                Assert.NotNull(db.FlashcardsDbModels
                    .FirstOrDefault(e => e.Id == Guid.Parse("32aee329-6675-4ae8-898a-95bb94ea0143") &&
                        e.PracticeDirection == PracticeDirection.FromForeignToNative &&
                        e.CorreactAnsInRow == 0 &&
                        e.NextPracticeDate == DateTime.Now.Date));
            }
        }

        [Fact]
        public void ReCalculateAndUpdatePracticePropertiesListTestB()
        {
            ResetTestDatabasev5.Reset();

            FlashcardDbModel flashcard;
            FlashcardPracticeModel flashcardPractice;
            using (var db = new FlashcardsDbContext())
            {
                flashcard = db.FlashcardsDbModels.FirstOrDefault(e => e.Id == Guid.Parse("32aee329-6675-4ae8-898a-95bb94ea0143") && e.PracticeDirection == PracticeDirection.FromForeignToNative);

                flashcardPractice = new FlashcardPracticeModel()
                {
                    Id = flashcard.Id,
                    PracticeDirection = flashcard.PracticeDirection,
                    FlashcardKnowledgeInt = 2,
                    CorreactAnsInRow = flashcard.CorreactAnsInRow
                };
            }

            ReCalculateAndUpdatePracticePropertiesList _processor = new ReCalculateAndUpdatePracticePropertiesList(new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate()),
                new UpdateFlashcardsListPracticeProperties(
                    new UpdateFlashcardPracticeProperties()));

            _processor.ReCauculate(new List<FlashcardPracticeModel>() { flashcardPractice });

            using (var db = new FlashcardsDbContext())
            {
                Assert.NotNull(db.FlashcardsDbModels
                    .FirstOrDefault(e => e.Id == Guid.Parse("32aee329-6675-4ae8-898a-95bb94ea0143") &&
                        e.PracticeDirection == PracticeDirection.FromForeignToNative &&
                        e.CorreactAnsInRow == 3 &&
                        e.NextPracticeDate == DateTime.Now.Date.AddDays(1)));
            }
        }

        [Fact]
        public void ReCalculateAndUpdatePracticePropertiesListTestC()
        {
            ResetTestDatabasev5.Reset();

            FlashcardDbModel flashcard;
            FlashcardPracticeModel flashcardPractice;
            using (var db = new FlashcardsDbContext())
            {
                flashcard = db.FlashcardsDbModels.FirstOrDefault(e => e.Id == Guid.Parse("32aee329-6675-4ae8-898a-95bb94ea0143") && e.PracticeDirection == PracticeDirection.FromForeignToNative);

                flashcardPractice = new FlashcardPracticeModel()
                {
                    Id = flashcard.Id,
                    PracticeDirection = flashcard.PracticeDirection,
                    FlashcardKnowledgeInt = 3,
                    CorreactAnsInRow = flashcard.CorreactAnsInRow
                };
            }

            ReCalculateAndUpdatePracticePropertiesList _processor = new ReCalculateAndUpdatePracticePropertiesList(new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate()),
                new UpdateFlashcardsListPracticeProperties(
                    new UpdateFlashcardPracticeProperties()));

            _processor.ReCauculate(new List<FlashcardPracticeModel>() { flashcardPractice });

            using (var db = new FlashcardsDbContext())
            {
                Assert.NotNull(db.FlashcardsDbModels
                    .FirstOrDefault(e => e.Id == Guid.Parse("32aee329-6675-4ae8-898a-95bb94ea0143") &&
                        e.PracticeDirection == PracticeDirection.FromForeignToNative &&
                        e.CorreactAnsInRow == 4 &&
                        e.NextPracticeDate == DateTime.Now.Date.AddDays(7)));
            }
        }
    }
}
