﻿using DatabaseModuleInterface;
using Models;

namespace DatabaseModule
{
    public class UpdateFlashcardPracticeProperties : IUpdateFlashcardPracticeProperties
    {
        public void Update(FlashcardDbModel input)
        {
            using (var db = new FlashcardsDbContext())
            {
                FlashcardDbModel flashcard = db.FlashcardsDbModels.Find(input.Id, input.PracticeDirection);

                flashcard.CorreactAnsInRow = input.CorreactAnsInRow;
                flashcard.NextPracticeDate = input.NextPracticeDate;

                db.SaveChanges();
            }
        }
    }
}
