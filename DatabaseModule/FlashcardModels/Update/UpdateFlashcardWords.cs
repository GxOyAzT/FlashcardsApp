using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModule
{
    public class UpdateFlashcardWords : IUpdateFlashcardWords
    {
        public void Update(Guid flashcardId, string native, string foreign)
        {
            using (var db = new FlashcardsDbContext())
            {
                var flashcards = db.FlashcardsDbModels.Where(e => e.Id == flashcardId).ToList();

                if (flashcards.Count != 2)
                    return;

                foreach(var item in flashcards)
                {
                    item.NativeLanguage = native;
                    item.ForeignLanguage = foreign;
                }

                db.SaveChanges();
            }
        }
    }
}
