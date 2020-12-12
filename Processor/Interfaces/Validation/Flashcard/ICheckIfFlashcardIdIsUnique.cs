using System;

namespace Processor
{
    public interface ICheckIfFlashcardIdIsUnique
    {
        bool Check(Guid id);
    }
}
