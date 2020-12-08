using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModule
{
    public class CheckIfUserOwnGroup : ICheckIfUserOwnGroup
    {
        public bool Check(string userId, Guid groupId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.GroupDbModels.FirstOrDefault(e => e.UserId == userId && e.Id == groupId) != null;
            }
        }
    }
}
