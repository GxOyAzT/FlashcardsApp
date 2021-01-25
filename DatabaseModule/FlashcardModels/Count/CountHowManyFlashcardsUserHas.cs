using DatabaseModuleInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DatabaseModule
{
    public class CountHowManyFlashcardsUserHas : ICountHowManyFlashcardsUserHas
    {
        public int Count(string userId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.GroupDbModels
                    .Include(e => e.FlashcardDbModels)
                    .Where(e => e.UserId == userId)
                    .SelectMany(e => e.FlashcardDbModels)
                    .Count();
            }
        }
    }
}
