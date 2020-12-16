using DatabaseModuleInterface;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseModulePostgreSQL
{
    public class LoadAllUserGroupsPostgreSQl : ILoadAllUserGroups
    {
        public List<GroupDbModel> Load(string userId)
        {
            using (var db = new FlashcardDbContextPostgreSQL())
            {
                return db.GroupDbModels.Where(e => e.UserId == userId).ToList();
            }
        }
    }
}
