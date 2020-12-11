using System;
using System.Collections.Generic;
using System.Text;

namespace Processor
{
    public interface IValidateGroupDescription
    {
        List<string> GetErrorMessages();
        bool Validate(string description);
    }
}
