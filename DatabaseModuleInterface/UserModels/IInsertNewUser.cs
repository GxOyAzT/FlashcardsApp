using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface IInsertNewUser
    {
        public void Insert(UserDbModel userDbModel);
    }
}
