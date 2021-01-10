using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModule
{
    public class CountHowManyFlashcardsForPracticeWhereGroupId : ICountHowManyFlashcardsForPracticeWhereGroupId
    {
        public int Count(Guid groupId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return db.FlashcardsDbModels
                    .Where(e => e.GroupDbModelId == groupId)
                    .Where(e => e.CorreactAnsInRow != null)
                    .Where(e => e.NextPracticeDate <= DateTime.Now.Date)
                    .Count();
            }
        }
    }
}
