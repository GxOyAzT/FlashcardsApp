using DatabaseModuleInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DatabaseModule
{
    public class CountHowManyFlashcardsForLearnWhereUserId : ICountHowManyFlashcardsForLearnWhereUserId
    {
        public int Count(string userId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.GroupDbModels
                    .Where(e => e.UserId == userId)
                    .Include(e => e.FlashcardDbModels)
                    .SelectMany(e => e.FlashcardDbModels)
                    .Where(e => e.CorreactAnsInRow == null)
                    .Count();
            }
        }
    }
}
