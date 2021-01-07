using Models;
using System.Collections.Generic;

namespace Processor
{
    public class ReCalculateAndUpdatePracticePropertiesList : IReCalculateAndUpdatePracticePropertiesList
    {
        private readonly IReCalculateFlashcardPracticeProps _reCalculateFlashcardPracticeProps;
        private readonly IUpdateFlashcardsListPracticeProperties _updateFlashcardsListPracticeProperties;

        public ReCalculateAndUpdatePracticePropertiesList(
            IReCalculateFlashcardPracticeProps reCalculateFlashcardPracticeProps,
            IUpdateFlashcardsListPracticeProperties updateFlashcardsListPracticeProperties)
        {
            _reCalculateFlashcardPracticeProps = reCalculateFlashcardPracticeProps;
            _updateFlashcardsListPracticeProperties = updateFlashcardsListPracticeProperties;
        }


        public void ReCauculate(List<FlashcardPracticeModel> flashcardPracticeModels)
        {
            List<FlashcardDbModel> recalculatedFlashcards = new List<FlashcardDbModel>();

            foreach(var item in flashcardPracticeModels)
            {
                item.FlashcardKnowledge = (FlashcardKnowledge)item.FlashcardKnowledgeInt;
                recalculatedFlashcards.Add(_reCalculateFlashcardPracticeProps.ReCalculate(item));
            }

            _updateFlashcardsListPracticeProperties.Update(recalculatedFlashcards);
        }
    }
}
