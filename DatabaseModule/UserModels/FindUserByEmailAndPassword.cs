using DatabaseModuleInterface;
using Models;
using System.Linq;

namespace DatabaseModule
{
    public class FindUserByEmailAndPassword : IFindUserByEmailAndPassword
    {
        public UserDbModel Find(string email, string password)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.UserDbModels.FirstOrDefault(e => e.Email == email && e.Password == password);
            }
        }
    }
}
