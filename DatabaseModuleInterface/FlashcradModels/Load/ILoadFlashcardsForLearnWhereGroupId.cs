using Models;
using System;
using System.Collections.Generic;

namespace DatabaseModuleInterface
{
    public interface ILoadFlashcardsForLearnWhereGroupId
    {
        public List<FlashcardDbModel> Load(Guid groupId, int howMany);
    }
}
