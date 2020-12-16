using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModulePostgreSQL
{
    class CheckIfFlashcardIsUniquePostgreSQL : ICheckIfFlashcardIsUnique
    {
        public bool IsUnique(string foreign, string native, Guid groupId)
        {
            using (var db = new FlashcardDbContextPostgreSQL())
            {
                return !db.FlashcardsDbModels
                    .Where(e => e.GroupDbModelId == groupId)
                    .Where(e => e.ForeignLanguage == foreign || e.NativeLanguage == native)
                    .Any();
            }
        }
    }
}
