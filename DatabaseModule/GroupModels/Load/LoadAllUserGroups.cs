using DatabaseModuleInterface;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseModule
{
    public class LoadAllUserGroups : ILoadAllUserGroups
    {
        public List<GroupDbModel> Load(string userId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.GroupDbModels.Where(e => e.UserId == userId).ToList();
            }
        }
    }
}
