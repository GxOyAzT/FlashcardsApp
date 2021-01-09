using DatabaseModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
