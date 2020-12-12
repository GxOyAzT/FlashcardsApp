using DatabaseModule;
using System;
using System.Linq;

namespace Processor
{
    public class CheckIfFlashcardIdIsUnique : ICheckIfFlashcardIdIsUnique
    {
        public bool Check(Guid id)
        {
            using (var db = new FlashcardsDbContext())
            {
                return !db.FlashcardsDbModels.Where(e => e.Id == id).Any();
            }
        }
    }
}
