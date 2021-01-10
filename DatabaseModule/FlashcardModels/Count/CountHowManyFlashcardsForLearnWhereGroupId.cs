using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModule
{
    public class CountHowManyFlashcardsForLearnWhereGroupId : ICountHowManyFlashcardsForLearnWhereGroupId
    {
        public int Count(Guid groupId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.FlashcardsDbModels
                    .Where(e => e.GroupDbModelId == groupId)
                    .Where(e => e.CorreactAnsInRow == null)
                    .Count();
            }
        }
    }
}
