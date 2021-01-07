using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseModule;
using Models;
using Processor;
using XUnitTests;

namespace XTestsConsole
{
    class Program
    {
        static void Main(string[] args)
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
                    FlashcardKnowledgeInt = 2
                };
            }

            ReCalculateAndUpdatePracticePropertiesList _processor = new ReCalculateAndUpdatePracticePropertiesList(new ReCalculateFlashcardPracticeProps(
                new CalculateNextPracticeDate()),
                new UpdateFlashcardsListPracticeProperties(
                    new UpdateFlashcardPracticeProperties()));

            _processor.ReCauculate(new List<FlashcardPracticeModel>() { flashcardPractice });
        }
    }
}
