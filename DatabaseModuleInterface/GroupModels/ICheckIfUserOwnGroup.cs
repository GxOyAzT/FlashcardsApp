using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface ICheckIfUserOwnGroup
    {
        public bool Check(string userId, Guid groupId);
    }
}
