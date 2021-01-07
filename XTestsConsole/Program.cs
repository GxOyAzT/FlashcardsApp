using System;
using DatabaseModule;
using Processor;
using XUnitTests;

namespace XTestsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ResetTestDatabasev5.Reset();

            var items = (new LoadFiveFlashcardsForLearnWherUserId()).Load("466c7fca-ad58-4e9d-b88a-e3926386735f");
        }
    }
}
