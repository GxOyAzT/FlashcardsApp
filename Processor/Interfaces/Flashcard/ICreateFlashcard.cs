using System;
using System.Collections.Generic;

namespace Processor
{
    public interface ICreateFlashcard
    {
        List<string> GetUserMessages();
        bool Create(string native, string foreign, Guid groupId);
    }
}
