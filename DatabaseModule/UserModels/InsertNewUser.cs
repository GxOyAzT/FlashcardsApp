using DatabaseModuleInterface;
using Models;

namespace DatabaseModule
{
    public class InsertNewUser : IInsertNewUser
    {
        public void Insert(UserDbModel userDbModel)
        {
            using (var db = new FlashcardsDbContext())
            {
                db.UserDbModels.Add(userDbModel);
                db.SaveChanges();
            }
        }
    }
}
