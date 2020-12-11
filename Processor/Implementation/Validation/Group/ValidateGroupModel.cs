using System;
using System.Collections.Generic;
using System.Linq;

namespace Processor
{
    public class ValidateGroupModel : IValidateGroupModel
    {
        private readonly IValidateGroupName _validateGroupName;
        private readonly IValidateGroupDescription _validateGroupDescription;

        List<string> ErrorMessages { get; set; }
        public bool WasAlreadyUsed { get; set; }

        public List<string> GetErrorMessages() => ErrorMessages;

        public ValidateGroupModel(IValidateGroupName validateGroupName, IValidateGroupDescription validateGroupDescription)
        {
            this._validateGroupName = validateGroupName;
            this._validateGroupDescription = validateGroupDescription;

            ErrorMessages = new List<string>();
            WasAlreadyUsed = false;
        }

        public bool Validate(string groupName, string groupDescription)
        {
            if (WasAlreadyUsed)
                throw new Exception("Error. One instation of ValidateGroupModel was used twice.");

            WasAlreadyUsed = true;

            if (!_validateGroupName.Validate(groupName))
                ErrorMessages.AddRange(_validateGroupName.GetErrorMessages());

            if (!_validateGroupDescription.Validate(groupDescription))
                ErrorMessages.AddRange(_validateGroupDescription.GetErrorMessages());

            return !ErrorMessages.Any();
        }
    }
}
