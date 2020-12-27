using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModule
{
    public class DeleteFlashcard : IDeleteFlashcard
    {
        public void Delete(Guid flashcardId)
        {
            using (var db = new FlashcardsDbContext())
            {
                foreach(var item in db.FlashcardsDbModels.Where(e => e.Id == flashcardId))
                {
                    db.FlashcardsDbModels.Remove(item);
                }

                db.SaveChanges();
            }
        }
    }
}
