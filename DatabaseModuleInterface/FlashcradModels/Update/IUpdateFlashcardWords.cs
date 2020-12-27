using System;

namespace DatabaseModuleInterface
{
    public interface IUpdateFlashcardWords
    {
        public void Update(Guid flashcardId, string native, string foreign);
    }
}
