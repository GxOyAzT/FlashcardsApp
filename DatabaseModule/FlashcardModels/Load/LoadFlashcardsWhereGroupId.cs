using DatabaseModuleInterface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseModule
{
    public class LoadFlashcardsWhereGroupId : ILoadFlashcardsWhereGroupId
    {
        public List<FlashcardDbModel> Load(Guid groupId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.FlashcardsDbModels
                    .Where(e => e.GroupDbModelId == groupId)
                    .ToList();
            }
        }
    }
}
