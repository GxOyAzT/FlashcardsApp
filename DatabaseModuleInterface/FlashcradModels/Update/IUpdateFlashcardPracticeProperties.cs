using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface IUpdateFlashcardPracticeProperties
    {
        void Update(FlashcardDbModel flashcardDbModel);
    }
}
