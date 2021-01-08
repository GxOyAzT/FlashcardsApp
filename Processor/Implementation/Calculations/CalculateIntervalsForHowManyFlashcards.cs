using System;
using System.Collections.Generic;

namespace Processor
{
    public class CalculateIntervalsForHowManyFlashcards : ICalculateIntervalsForHowManyFlashcards
    {
        public List<int> Claculate(int max)
        {
            var output = new List<int>();

            if (max <= 5)
            {
                output.Add(max);

                return output;
            }

            if (max <= 10)
            {
                output.Add(5);
                output.Add(max);

                return output;
            }

            if (max <= 20)
            {
                output.Add(5);
                output.Add(Convert.ToInt32(Math.Floor(Convert.ToDouble(max) * 0.75)));
                output.Add(max);

                return output;
            }

            if (max <= 100)
            {
                output.Add(5);
                output.Add(Convert.ToInt32(Math.Floor(Convert.ToDouble(max) * 0.25)));
                output.Add(Convert.ToInt32(Math.Floor(Convert.ToDouble(max) * 0.5)));
                output.Add(Convert.ToInt32(Math.Floor(Convert.ToDouble(max) * 0.75)));
                output.Add(max);

                return output;
            }

            output.Add(5);
            output.Add(20);
            output.Add(50);
            output.Add(70);
            output.Add(100);

            return output;
        }
    }
}
