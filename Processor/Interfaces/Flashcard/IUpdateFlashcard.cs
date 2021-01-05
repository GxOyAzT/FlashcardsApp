using System;
using System.Collections.Generic;

namespace Processor
{
    public interface IUpdateFlashcard
    {
        public bool Update(string native, string foreign, Guid flashcardId, Guid groupId);
        public List<string> GetUserMessages();
    }
}
