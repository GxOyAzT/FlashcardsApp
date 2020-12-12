using DatabaseModuleInterface;
using Models;
using System;
using System.Collections.Generic;

namespace Processor
{
    public class CreateNewGroup : ICreateNewGroup
    {
        private readonly IValidateGroupModel _validateGroupModel;
        private readonly IInsertNewGroup _insertNewGroup;
        private readonly ICheckIfGroupIdIsUnique _checkIfGroupIdIsUnique;

        List<string> UserMessages { get; set; }
        bool WasAlreadyUsed { get; set; }

        public CreateNewGroup(IValidateGroupModel validateGroupModel, IInsertNewGroup insertNewGroup, ICheckIfGroupIdIsUnique checkIfGroupIdIsUnique)
        {
            _validateGroupModel = validateGroupModel;
            _insertNewGroup = insertNewGroup;
            _checkIfGroupIdIsUnique = checkIfGroupIdIsUnique;

            UserMessages = new List<string>();
            WasAlreadyUsed = false;
        }

        public bool Create(string groupName, string description, string userId)
        {
            if (WasAlreadyUsed)
                Reset();

            if (!_validateGroupModel.Validate(groupName, description))
            {
                UserMessages.AddRange(_validateGroupModel.GetErrorMessages());
                return false;
            }

            Guid newId;
            do
            {
                newId = Guid.NewGuid();
            } while (!_checkIfGroupIdIsUnique.Check(newId));

            GroupDbModel model = new GroupDbModel()
            {
                Id = newId,
                UserId = userId,
                Description = description,
                Name = groupName
            };

            _insertNewGroup.Insert(model);

            return true;
        }

        public List<string> GetUserMessages() => UserMessages;

        public void Reset()
        {
            _validateGroupModel.Reset();
            UserMessages = new List<string>();
        }
    }
}
