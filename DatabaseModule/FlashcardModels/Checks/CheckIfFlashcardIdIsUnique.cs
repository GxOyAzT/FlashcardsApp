using DatabaseModule;
using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModule
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
