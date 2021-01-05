using Models;
using System;
using System.Collections.Generic;

namespace DatabaseModuleInterface
{
    public interface ILoadFlashcardsWhereGroupId
    {
        List<FlashcardDbModel> Load(Guid groupId);
    }
}
