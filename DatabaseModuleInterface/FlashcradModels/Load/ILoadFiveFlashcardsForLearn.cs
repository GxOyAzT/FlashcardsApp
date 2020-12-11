using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface ILoadFiveFlashcardsForLearn
    {
        List<FlashcardDbModel> Load(Guid groupId);
    }
}
