using Models;
using System.Collections.Generic;

namespace WebUI
{
    public class FlashcardsListViewModel
    {
        public FlashcardsListViewModel(List<FlashcardDbModel> flashcardModels, List<string> errorMessages)
        {
            FlashcardModels = flashcardModels;
            ErrorMessages = errorMessages;
        }

        public List<FlashcardDbModel> FlashcardModels { get; }
        public List<string> ErrorMessages { get; }
    }
}
