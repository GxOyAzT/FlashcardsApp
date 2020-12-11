using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface IInsertNewFlashcard
    {
        public void Insert(FlashcardDbModel flashcardDbModel);
    }
}
