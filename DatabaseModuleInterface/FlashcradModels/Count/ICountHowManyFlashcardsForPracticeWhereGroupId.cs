using System;

namespace DatabaseModuleInterface
{
    public interface ICountHowManyFlashcardsForPracticeWhereGroupId
    {
        public int Count(Guid groupId);
    }
}
