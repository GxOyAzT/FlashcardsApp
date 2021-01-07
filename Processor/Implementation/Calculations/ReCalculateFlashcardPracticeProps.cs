using Models;
using System;

namespace Processor
{
    public class ReCalculateFlashcardPracticeProps : IReCalculateFlashcardPracticeProps
    {
        private readonly ICalculateNextPracticeDate _calculateNextPracticeDate;

        public ReCalculateFlashcardPracticeProps(ICalculateNextPracticeDate calculateNextPracticeDate)
        {
            _calculateNextPracticeDate = calculateNextPracticeDate;
        }

        public FlashcardDbModel ReCalculate(FlashcardPracticeModel input)
        {
            if (input.FlashcardKnowledge == FlashcardKnowledge.DontKnow)
            {
                input.CorreactAnsInRow = 0;
                input.NextPracticeDate = DateTime.Now.Date;

                return input.CloneFlashcardDbModel();
            }
            else if (input.FlashcardKnowledge == FlashcardKnowledge.AlmostKnow)
            {
                input.CorreactAnsInRow = input.CorreactAnsInRow;
                input.NextPracticeDate = DateTime.Now.Date.AddDays(1);

                return input.CloneFlashcardDbModel();
            }
            else
            {
                if (input.CorreactAnsInRow == null)
                    input.CorreactAnsInRow = 1;
                else
                    input.CorreactAnsInRow++;

                input.NextPracticeDate = _calculateNextPracticeDate.Calculate(input.CorreactAnsInRow.Value);

                return input.CloneFlashcardDbModel();
            }
        }
    }
}
