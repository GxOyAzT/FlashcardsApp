using Models;
using System.Collections.Generic;

namespace Processor
{
    public interface IUpdateFlashcardsListPracticeProperties
    {
        void Update(List<FlashcardDbModel> input);
    }
}
