using System;
using System.Collections.Generic;
using System.Text;

namespace Processor
{
    public interface IValidateFlashcard
    {
        List<string> GetErrorMessages();
        bool Validate(string foreign, string native);
    }
}
