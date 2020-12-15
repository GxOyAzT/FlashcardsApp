using System;

namespace DatabaseModuleInterface
{
    public interface ICheckIfFlashcardIsUnique
    {
        bool IsUnique(string foreign, string native, Guid groupId);
    }
}