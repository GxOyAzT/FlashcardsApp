using System;
using System.Collections.Generic;
using System.Text;

namespace Processor
{
    public interface ICheckIfGroupIdIsUnique
    {
        bool Check(Guid id);
    }
}
