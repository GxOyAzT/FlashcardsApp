using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModulePostgreSQL
{
    public class CheckIfGroupIdIsUniquePostgreSQL : ICheckIfGroupIdIsUnique
    {
        public bool Check(Guid id)
        {
            using (var db = new FlashcardDbContextPostgreSQL())
            {
                return !db.GroupDbModels.Where(e => e.Id == id).Any();
            }
        }
    }
}
