using Models;
using System.Collections.Generic;

namespace Processor
{
    public interface IReCalculateAndUpdatePracticePropertiesList
    {
        public void ReCauculate(List<FlashcardPracticeModel> flashcardPracticeModels);
    }
}
