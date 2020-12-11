using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Processor
{
    public class ValidateGroupName : IValidateGroupName
    {
        public ValidateGroupName()
        {
            ErrorMessages = new List<string>();
        }

        List<string> ErrorMessages { get; set; }

        public List<string> GetErrorMessages()
        {
            return ErrorMessages;
        }

        public bool Validate(string groupName)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException();
            }

            if (groupName == string.Empty)
            {
                ErrorMessages.Add("Group name cannot be empty.");
                return false;
            }

            if (groupName.Length > 30)
            {
                ErrorMessages.Add("Group name cannot be longer then 30 characters.");
            }

            if (!(new Regex("^[ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890 ]{1,30}$")).IsMatch(groupName))
            {
                ErrorMessages.Add("Group name can contain only letters, numbers or spaces.");
            }

            if (groupName[0] == ' ' || groupName[^1] == ' ')
            {
                ErrorMessages.Add("Group name cannot contain space on the end or begin.");
            }

            return !ErrorMessages.Any();
        }
    }
}
