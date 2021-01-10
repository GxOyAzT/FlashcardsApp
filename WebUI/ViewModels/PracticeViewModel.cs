using Models;
using System.Collections.Generic;

namespace WebUI
{
    public class PracticeViewModel
    {
        public PracticeViewModel(List<FlashcardPracticeModel> flashcardPracticeModels)
        {
            FlashcardPracticeModels = flashcardPracticeModels;
        }

        public PracticeViewModel()
        {
            FlashcardPracticeModels = new List<FlashcardPracticeModel>();
        }

        public int TotalFlashcards 
        { 
            get
            { 
                return FlashcardPracticeModels == null ? 0 : FlashcardPracticeModels.Count; 
            } 
        }

        public List<FlashcardPracticeModel> FlashcardPracticeModels { get; set; }
    }
}
