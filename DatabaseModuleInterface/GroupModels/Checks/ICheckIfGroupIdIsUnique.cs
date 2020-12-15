using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface ICheckIfGroupIdIsUnique
    {
        bool Check(Guid id);
    }
}
