using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModulePostgreSQL
{
    public class CheckIfFlashcardIdIsUniquePostgreSQL : ICheckIfFlashcardIdIsUnique
    {
        public bool Check(Guid id)
        {
            using (var db = new FlashcardDbContextPostgreSQL())
            {
                return !db.FlashcardsDbModels.Where(e => e.Id == id).Any();
            }
        }
    }
}
