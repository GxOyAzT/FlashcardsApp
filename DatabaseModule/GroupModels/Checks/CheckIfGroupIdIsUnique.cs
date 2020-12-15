using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModule
{
    public class CheckIfGroupIdIsUnique : ICheckIfGroupIdIsUnique
    {
        public bool Check(Guid id)
        {
            using (var db = new FlashcardsDbContext())
            {
                return !db.GroupDbModels.Where(e => e.Id == id).Any();
            }
        }
    }
}
