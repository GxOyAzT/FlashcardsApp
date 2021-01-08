using DatabaseModuleInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DatabaseModule
{
    public class CountHowManyFlashcardsForPracticeWhereUserId : ICountHowManyFlashcardsForPracticeWhereUserId
    {
        public int Count(string userId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.GroupDbModels
                    .Where(e => e.UserId == userId)
                    .Include(e => e.FlashcardDbModels)
                    .SelectMany(e => e.FlashcardDbModels)
                    .Where(e => e.CorreactAnsInRow != null)
                    .Where(e => e.NextPracticeDate <= DateTime.Now.Date)
                    .Count();
            }
        }
    }
}
