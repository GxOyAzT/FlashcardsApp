using DatabaseModuleInterface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseModule
{
    public class LoadFlashcardsForLearnWhereGroupId : ILoadFlashcardsForLearnWhereGroupId
    {
        public List<FlashcardDbModel> Load(Guid groupId, int howMany)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.FlashcardsDbModels
                    .Where(e => e.GroupDbModelId == groupId)
                    .Where(e => e.CorreactAnsInRow == null)
                    .OrderBy(e => e.NextPracticeDate)
                    .Take(howMany)
                    .ToList();
            }
        }
    }
}
