using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Processor
{
    public class ValidateGroupDescription : IValidateGroupDescription
    {
        List<string> ErrorMessages { get; set; }

        public ValidateGroupDescription()
        {
            ErrorMessages = new List<string>();
        }

        public List<string> GetErrorMessages() => ErrorMessages;

        public bool Validate(string description)
        {
            if (description == null)
            {
                throw new ArgumentNullException();
            }

            if (description == string.Empty)
            {
                return true;
            }

            if (description.Length > 200)
            {
                ErrorMessages.Add("Description cannot be longer then 200 characters.");
            }

            if (description[0] == ' ' || description[^1] == ' ')
            {
                ErrorMessages.Add("Description cannot contain space on the end or begin.");
            }

            return !ErrorMessages.Any();
        }
    }
}
