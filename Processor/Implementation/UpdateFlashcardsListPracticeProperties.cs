using DatabaseModuleInterface;
using Models;
using System.Collections.Generic;

namespace Processor
{
    public class UpdateFlashcardsListPracticeProperties : IUpdateFlashcardsListPracticeProperties
    {
        private readonly IUpdateFlashcardPracticeProperties _updateFlashcardPracticeProperties;

        public UpdateFlashcardsListPracticeProperties(IUpdateFlashcardPracticeProperties updateFlashcardPracticeProperties)
        {
            _updateFlashcardPracticeProperties = updateFlashcardPracticeProperties;
        }
        public void Update(List<FlashcardDbModel> input)
        {
            if (input == null)
                return;

            foreach (var item in input)
                _updateFlashcardPracticeProperties.Update(item);
        }
    }
}
