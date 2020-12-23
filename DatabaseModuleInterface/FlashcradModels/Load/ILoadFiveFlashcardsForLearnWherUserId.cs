using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface ILoadFiveFlashcardsForLearnWherUserId
    {
        List<FlashcardDbModel> Load(string userId);
    }
}
