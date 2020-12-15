using System;

namespace DatabaseModuleInterface
{
    public interface ICheckIfFlashcardIdIsUnique
    {
        bool Check(Guid id);
    }
}
