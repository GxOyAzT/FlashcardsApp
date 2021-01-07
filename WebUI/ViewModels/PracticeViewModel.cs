using System.Collections.Generic;

namespace WebUI
{
    public class PracticeViewModel
    {
        public PracticeViewModel(int totalFlashcards, List<PracticeFlashcard> practiceFlashcards)
        {
            TotalFlashcards = totalFlashcards;
            PracticeFlashcards = practiceFlashcards;
        }

        public PracticeViewModel()
        {

        }

        public int TotalFlashcards { get; set; }
        public List<PracticeFlashcard> PracticeFlashcards { get; set; }
    }
}
