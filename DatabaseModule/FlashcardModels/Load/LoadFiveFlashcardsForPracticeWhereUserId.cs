using DatabaseModuleInterface;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseModule
{
    public class LoadFiveFlashcardsForPracticeWhereUserId : ILoadFiveFlashcardsForPracticeWhereUserId
    {
        public List<FlashcardDbModel> Load(string userId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.GroupDbModels.Where(e => e.UserId == userId)
                        .Include(e => e.FlashcardDbModels)
                        .SelectMany(e => e.FlashcardDbModels)
                        .Where(e => e.CorreactAnsInRow != null)
                        .OrderBy(e => e.NextPracticeDate)
                        .Take(5)
                        .ToList();
            }
        }
    }
}
