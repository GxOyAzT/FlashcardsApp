using DatabaseModuleInterface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseModule
{
    public class LoadFiveFlashcardsForLearn : ILoadFiveFlashcardsForLearn
    {
        public List<FlashcardDbModel> Load(Guid groupId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.FlashcardsDbModels
                        .Where(e => e.GroupDbModelId == groupId)
                        .Where(e => e.CorreactAnsInRow == null)
                        .OrderBy(e => e.NextPracticeDate)
                        .Take(5)
                        .ToList();
            }
        }
    }
}
