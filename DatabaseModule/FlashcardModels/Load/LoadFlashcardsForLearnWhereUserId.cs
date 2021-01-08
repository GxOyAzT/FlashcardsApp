using DatabaseModuleInterface;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseModule
{
    public class LoadFlashcardsForLearnWhereUserId : ILoadFlashcardsForLearnWhereUserId
    {
        public List<FlashcardDbModel> Load(string userId, int howMany)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.GroupDbModels.Where(e => e.UserId == userId)
                        .Include(e => e.FlashcardDbModels)
                        .SelectMany(e => e.FlashcardDbModels)
                        .Where(e => e.CorreactAnsInRow == null)
                        .OrderBy(e => e.NextPracticeDate)
                        .Take(howMany)
                        .ToList();
            }
        }
    }
}
