using Models;
using System.Collections.Generic;

namespace WebUI
{
    public class FlashcardsListViewModel
    {
        public FlashcardsListViewModel(List<FlashcardDbModel> flashcardModels, List<string> errorMessages, string groupId)
        {
            FlashcardModels = flashcardModels;
            ErrorMessages = errorMessages;
            GroupId = groupId;
        }

        public List<FlashcardDbModel> FlashcardModels { get; }
        public List<string> ErrorMessages { get; }
        public string GroupId { get; set; }
    }
}
