using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModulePostgreSQL
{
    public class CheckIfUserOwnGroupPostgreSQL : ICheckIfUserOwnGroup
    {
        public bool Check(string userId, Guid groupId)
        {
            using (var db = new FlashcardDbContextPostgreSQL())
            {
                return db.GroupDbModels.FirstOrDefault(e => e.UserId == userId && e.Id == groupId) != null;
            }
        }
    }
}
