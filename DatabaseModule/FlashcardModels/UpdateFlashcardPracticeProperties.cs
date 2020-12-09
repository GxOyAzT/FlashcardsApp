using DatabaseModuleInterface;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModule
{
    class UpdateFlashcardPracticeProperties : IUpdateFlashcardPracticeProperties
    {
        public void Update(FlashcardDbModel input)
        {
            using (var db = new FlashcardsDbContext())
            {
                FlashcardDbModel flashcard = db.FlashcardsDbModels.Find(input);

                flashcard.CorreactAnsInRow = input.CorreactAnsInRow;
                flashcard.NextPracticeDate = input.NextPracticeDate;

                db.SaveChanges();
            }
        }
    }
}
