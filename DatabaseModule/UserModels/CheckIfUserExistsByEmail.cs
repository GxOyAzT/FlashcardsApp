using DatabaseModuleInterface;
using System.Linq;

namespace DatabaseModule
{
    public class CheckIfUserExistsByEmail : ICheckIfUserExistsByEmail
    {
        public bool Check(string email)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.UserDbModels.FirstOrDefault(e => e.Email == email) != null;
            }
        }
    }
}
