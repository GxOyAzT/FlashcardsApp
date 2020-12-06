using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface ICheckIfIdExists
    {
        public bool Check(Guid newId);
    }
}
