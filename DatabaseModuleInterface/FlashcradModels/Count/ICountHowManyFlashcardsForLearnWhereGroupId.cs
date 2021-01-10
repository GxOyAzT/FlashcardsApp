using System;

namespace DatabaseModuleInterface
{
    public interface ICountHowManyFlashcardsForLearnWhereGroupId
    {
        public int Count(Guid groupId);
    }
}
