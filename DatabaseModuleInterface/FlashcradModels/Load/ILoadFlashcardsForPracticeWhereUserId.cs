using Models;
using System.Collections.Generic;

namespace DatabaseModuleInterface
{
    public interface ILoadFlashcardsForPracticeWhereUserId
    {
        public List<FlashcardDbModel> Load(string userId, int howMany);
    }
}
