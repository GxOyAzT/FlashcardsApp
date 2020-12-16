using DatabaseModuleInterface;
using Models;

namespace DatabaseModulePostgreSQL
{
    public class InsertNewGroupPostgreSQL : IInsertNewGroup
    {
        public void Insert(GroupDbModel groupDbModel)
        {
            using (var db = new FlashcardDbContextPostgreSQL())
            {
                db.GroupDbModels.Add(groupDbModel);
                db.SaveChanges();
            }
        }
    }
}
