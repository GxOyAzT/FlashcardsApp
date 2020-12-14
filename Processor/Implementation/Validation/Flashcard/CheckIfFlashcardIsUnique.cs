using DatabaseModule;
using System;
using System.Linq;

namespace Processor
{
    public class CheckIfFlashcardIsUnique : ICheckIfFlashcardIsUnique
    {
        public bool IsUnique(string foreign, string native, Guid groupId)
        {
            using (var db = new FlashcardsDbContext())
            {
                return !db.FlashcardsDbModels
                    .Where(e => e.GroupDbModelId == groupId)
                    .Where(e => e.ForeignLanguage == foreign || e.NativeLanguage == native)
                    .Any();
            }
        }
    }
}
