using System;
using System.Collections.Generic;
using System.Linq;

namespace Processor
{
    public class ValidateFlashcard : IValidateFlashcard
    {
        List<string> ErrorMessages { get; set; }
        bool WasAlreadyUsed { get; set; }

        public ValidateFlashcard()
        {
            ErrorMessages = new List<string>();
            WasAlreadyUsed = false;
        }

        public List<string> GetErrorMessages() => ErrorMessages;

        public bool Validate(string foreign, string native)
        {
            if (WasAlreadyUsed)
                throw new Exception("Error. One instation of ValidateFlashcard was used twice.");

            WasAlreadyUsed = true;

            ValidateWord(foreign, "Foreign");
            ValidateWord(native, "Native");

            return !ErrorMessages.Any();
        }

        void ValidateWord(string word, string foreignOrNative)
        {
            if (word == null)
                throw new ArgumentNullException();

            if (word == string.Empty)
            {
                ErrorMessages.Add($"{foreignOrNative} cannot be empty.");
                return;
            }

            if (word.Length > 100)
                ErrorMessages.Add($"{foreignOrNative} cannot be longer then 100 characters.");

            if (word[0] == ' ' || word[^1] == ' ')
                ErrorMessages.Add($"{foreignOrNative} contain spaces on the beginning or end.");
        }
    }
}
