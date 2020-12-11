using System;

namespace Models
{
    public class FlashcardPracticeModel : FlashcardDbModel
    {
        public FlashcardKnowledge FlashcardKnowledge { get; set; }
        public int FlashcardKnowledgeInt { get; set; }
    }
}
