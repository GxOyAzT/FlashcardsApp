using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModule
{
    public class CheckIfUserOwnGroup : ICheckIfUserOwnGroup
    {
        public bool Check(Guid userId, Guid groupId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.GroupDbModels.FirstOrDefault(e => e.UserDbModelId == userId && e.Id == groupId) != null;
            }
        }
    }
}
