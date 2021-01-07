using Models;
using System.Collections.Generic;

namespace WebUI
{
    public class PracticeViewModel
    {
        public PracticeViewModel(int totalFlashcards, List<FlashcardPracticeModel> flashcardPracticeModels)
        {
            TotalFlashcards = totalFlashcards;
            FlashcardPracticeModels = flashcardPracticeModels;
        }

        public PracticeViewModel()
        {

        }

        public int TotalFlashcards { get; set; }
        public List<FlashcardPracticeModel> FlashcardPracticeModels { get; set; }
    }
}
