using System.Collections.Generic;

namespace Processor
{
    public interface ICreateNewGroup
    {
        List<string> GetUserMessages();
        bool Create(string groupName, string description, string userId);
        void Reset();
    }
}
