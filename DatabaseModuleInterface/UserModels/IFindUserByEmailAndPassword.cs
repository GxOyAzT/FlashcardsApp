using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface IFindUserByEmailAndPassword
    {
        UserDbModel Find(string email, string password);
    }
}
