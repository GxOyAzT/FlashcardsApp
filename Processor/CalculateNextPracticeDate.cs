using System;

namespace Processor
{
    public class CalculateNextPracticeDate : ICalculateNextPracticeDate
    {
        public DateTime Calculate(int correctAnsInRow)
        {
            if (correctAnsInRow == 0) return DateTime.Now.Date;
            else if (correctAnsInRow == 1) return DateTime.Now.Date.AddDays(1);
            else if (correctAnsInRow == 2) return DateTime.Now.Date.AddDays(2);
            else if (correctAnsInRow == 3) return DateTime.Now.Date.AddDays(3);
            else if (correctAnsInRow == 4) return DateTime.Now.Date.AddDays(7);
            else if (correctAnsInRow == 5) return DateTime.Now.Date.AddDays(14);
            else if (correctAnsInRow == 6) return DateTime.Now.Date.AddDays(30);
            else if (correctAnsInRow == 7) return DateTime.Now.Date.AddDays(90);
            return DateTime.Now.Date.AddDays(365);
        }
    }
}
