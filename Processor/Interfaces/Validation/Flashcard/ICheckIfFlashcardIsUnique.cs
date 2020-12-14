using System;

namespace Processor
{
    public interface ICheckIfFlashcardIsUnique
    {
        bool IsUnique(string foreign, string native, Guid groupId);
    }
}
