using System.Collections.Generic;

namespace WebUI
{
    public class BeforePracticeViewModel
    {
        public List<int> HowManyNewFlashcardsLearnList { get; set; }
        public List<int> HowManyNewFlashcardsPracticeList { get; set; }
    }

    public enum PracticeOrLearn
    {
        Practice = 1,
        Learn = 2
    }
}
