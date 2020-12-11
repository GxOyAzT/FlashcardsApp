using Models;
using System.Collections.Generic;

namespace DatabaseModuleInterface
{
    public interface ILoadAllUserGroups
    {
        List<GroupDbModel> Load(string userId);
    }
}
