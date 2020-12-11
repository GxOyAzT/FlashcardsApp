using Models;
using System;
using System.Collections.Generic;

namespace DatabaseModuleInterface
{
    public interface ILoadFiveFlashcardsForPractice
    {
        List<FlashcardDbModel> Load(Guid groupId);
    }
}
