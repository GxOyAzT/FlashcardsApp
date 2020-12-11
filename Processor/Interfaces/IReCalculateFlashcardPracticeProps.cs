using Models;

namespace Processor
{
    public interface IReCalculateFlashcardPracticeProps
    {
        FlashcardDbModel ReCalculate(FlashcardPracticeModel input);
    }
}