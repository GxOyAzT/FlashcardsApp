using DatabaseModuleInterface;
using System;
using System.Collections.Generic;

namespace Processor
{
    public class UpdateFlashcard : IUpdateFlashcard
    {
        private readonly ICheckIfFlashcardIsUnique _checkIfFlashcardIsUnique;
        private readonly IValidateFlashcard _validateFlashcard;
        private readonly IUpdateFlashcardWords _updateFlashcardWords;

        public UpdateFlashcard(
            ICheckIfFlashcardIsUnique checkIfFlashcardIsUnique, 
            IValidateFlashcard validateFlashcard,
            IUpdateFlashcardWords updateFlashcardWords)
        {
            _checkIfFlashcardIsUnique = checkIfFlashcardIsUnique;
            _validateFlashcard = validateFlashcard;
            _updateFlashcardWords = updateFlashcardWords;
            UserMessages = new List<string>();
        }

        List<string> UserMessages { get; set; }

        public List<string> GetUserMessages() => UserMessages;

        public bool Update(string native, string foreign, Guid flashcardId, Guid groupId)
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

            _updateFlashcardWords.Update(flashcardId, native, foreign);

            return true;
        }
    }
}
