using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Processor
{
    public interface IUpdateFlashcardsListPracticeProperties
    {
        void Update(List<FlashcardDbModel> input);
    }
}
