using DatabaseModuleInterface;
using Models;
using System;
using System.Collections.Generic;

namespace Processor
{
    public class CreateFlashcard : ICreateFlashcard
    {
        private readonly ICheckIfFlashcardIdIsUnique _checkIfFlashcardIdIsUnique;
        private readonly ICheckIfFlashcardIsUnique _checkIfFlashcardIsUnique;
        private readonly IInsertNewFlashcard _insertNewFlashcard;
        private readonly IValidateFlashcard _validateFlashcard;

        public CreateFlashcard(ICheckIfFlashcardIdIsUnique checkIfFlashcardIdIsUnique, ICheckIfFlashcardIsUnique checkIfFlashcardIsUnique, IInsertNewFlashcard insertNewFlashcard, IValidateFlashcard validateFlashcard)
        {
            _checkIfFlashcardIdIsUnique = checkIfFlashcardIdIsUnique;
            _checkIfFlashcardIsUnique = checkIfFlashcardIsUnique;
            _insertNewFlashcard = insertNewFlashcard;
            _validateFlashcard = validateFlashcard;
            UserMessages = new List<string>();
        }

        List<string> UserMessages { get; set; }

        public bool Create(string native, string foreign, Guid groupId)
        {
            if (!_validateFlashcard.Validate(foreign, native))
            {
                UserMessages.AddRange(_validateFlashcard.GetErrorMessages());
                return false;
            }

            if (!_checkIfFlashcardIsUnique.IsUnique(foreign, native, groupId))
            {
                UserMessages.Add("Flashcard already exists.");
                return false;
            }

            Guid newId;

            do
            {
                newId = Guid.NewGuid();
            } while (!_checkIfFlashcardIdIsUnique.Check(newId));

            FlashcardDbModel modelA = new FlashcardDbModel()
            {
                Id = newId,
                ForeignLanguage = foreign,
                NativeLanguage = native,
                GroupDbModelId = groupId,
                NextPracticeDate = DateTime.Now.Date,
                PracticeDirection = PracticeDirection.FromForeignToNative
            };

            FlashcardDbModel modelB = new FlashcardDbModel()
            {
                Id = newId,
                ForeignLanguage = foreign,
                NativeLanguage = native,
                GroupDbModelId = groupId,
                NextPracticeDate = DateTime.Now.Date,
                PracticeDirection = PracticeDirection.FromNativeToForeign
            };


            _insertNewFlashcard.Insert(modelA);
            _insertNewFlashcard.Insert(modelB);

            return true;
        }

        public List<string> GetUserMessages() => UserMessages;

        void Reset()
        {
            UserMessages = new List<string>();
        }
    }
}
