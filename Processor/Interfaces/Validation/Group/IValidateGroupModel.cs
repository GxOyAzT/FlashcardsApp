using System.Collections.Generic;

namespace Processor
{
    public interface IValidateGroupModel
    {
        List<string> GetErrorMessages();
        bool Validate(string groupName, string groupDescription);
        void Reset();
    }
}