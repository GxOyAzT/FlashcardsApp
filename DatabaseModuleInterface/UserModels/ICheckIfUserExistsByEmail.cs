using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface ICheckIfUserExistsByEmail
    {
        bool Check(string email);
    }
}
