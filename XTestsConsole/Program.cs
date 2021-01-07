using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseModule;
using Models;
using Processor;
using XUnitTests;

namespace XTestsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ResetTestDatabasev6.Reset();
        }
    }
}
