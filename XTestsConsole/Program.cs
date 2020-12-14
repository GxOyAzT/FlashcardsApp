using System;
using Processor;

namespace XTestsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Abbd Asdfa ";

            IValidateGroupName _processor = new ValidateGroupName();

            _processor.Validate(input);

            foreach (var error in _processor.GetErrorMessages())
                Console.WriteLine(error);
        }
    }
}
