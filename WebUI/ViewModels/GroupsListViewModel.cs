using Models;
using System.Collections.Generic;

namespace WebUI
{
    public class GroupsListViewModel
    {
        public GroupsListViewModel(List<GroupDbModel> groupModels, List<string> errorMessages)
        {
            GroupModels = groupModels;
            ErrorMessages = errorMessages;
        }

        public List<GroupDbModel> GroupModels { get; }
        public List<string> ErrorMessages { get; }
    }
}
