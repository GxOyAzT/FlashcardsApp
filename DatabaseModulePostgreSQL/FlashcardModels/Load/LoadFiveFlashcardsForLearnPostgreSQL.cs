using DatabaseModuleInterface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseModulePostgreSQL
{
    public class LoadFiveFlashcardsForLearnPostgreSQL : ILoadFiveFlashcardsForLearn
    {
        public List<FlashcardDbModel> Load(Guid groupId)
        {
            using (var db = new FlashcardDbContextPostgreSQL())
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
