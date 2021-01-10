using System;

namespace Models
{
    public class FlashcardDbModel
    {
        public Guid Id { get; set; }
        public PracticeDirection PracticeDirection { get; set; }
        public string NativeLanguage { get; set; }
        public string ForeignLanguage { get; set; }
        public int? CorreactAnsInRow { get; set; }
        public DateTime NextPracticeDate { get; set; }
        public Guid GroupDbModelId { get; set; }
        
        public virtual GroupDbModel GroupDbModel { get; set; }

        public FlashcardDbModel CloneFlashcardDbModel()
        {
            return new FlashcardDbModel()
            {
                Id = Id,
                PracticeDirection = PracticeDirection,
                NativeLanguage = NativeLanguage,
                ForeignLanguage = ForeignLanguage,
                CorreactAnsInRow = CorreactAnsInRow,
                NextPracticeDate = NextPracticeDate,
                GroupDbModelId = GroupDbModelId
            };
        }

        public FlashcardPracticeModel ConvertToFlashcardPracticeModel()
        {
            return new FlashcardPracticeModel()
            {
                Id = Id,
                PracticeDirection = PracticeDirection,
                NativeLanguage = NativeLanguage,
                ForeignLanguage = ForeignLanguage,
                CorreactAnsInRow = CorreactAnsInRow,
                NextPracticeDate = NextPracticeDate,
                GroupDbModelId = GroupDbModelId,
                FlashcardKnowledgeInt = 0
            };
        }
    }
}
