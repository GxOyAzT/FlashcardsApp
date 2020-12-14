using System;

namespace Processor
{
    public interface ICalculateNextPracticeDate
    {
        DateTime Calculate(int correctAnsInRow);
    }
}