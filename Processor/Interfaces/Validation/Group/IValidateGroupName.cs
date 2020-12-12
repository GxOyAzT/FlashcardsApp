using System;
using System.Collections.Generic;
using System.Text;

namespace Processor
{
    public interface IValidateGroupName
    {
        List<string> GetErrorMessages();
        bool Validate(string groupName);
        void Reset();
    }
}
