using System;
using DatabaseModule;
using DatabaseModuleInterface;
using Models;

namespace XTestsConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            FlashcardDbModel flashcardDbModelX1 = new FlashcardDbModel()
            {
                Id = Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 1 Native",
                ForeignLanguage = "Flashcard 1 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = null,
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            };

            FlashcardDbModel flashcardDbModelY1 = new FlashcardDbModel()
            {
                Id = Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 1 Native",
                ForeignLanguage = "Flashcard 1 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = null,
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            };

            //using (var db = new FlashcardsDbContext())
            //{
            //    db.FlashcardsDbModels.Add(flashcardDbModelY1);
            //    db.SaveChanges();
            //}
        }
    }
}
