using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModuleInterface
{
    public interface IDeleteFlashcard
    {
        void Delete(Guid flashcardId);
    }
}
