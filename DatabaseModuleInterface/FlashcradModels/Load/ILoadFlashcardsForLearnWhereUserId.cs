using Models;
using System.Collections.Generic;

namespace DatabaseModuleInterface
{
    public interface ILoadFlashcardsForLearnWhereUserId
    {
        List<FlashcardDbModel> Load(string userId, int howMany);
    }
}
