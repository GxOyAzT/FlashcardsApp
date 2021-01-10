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
        Undefined = 0,
        Practice = 1,
        Learn = 2
    }
}
