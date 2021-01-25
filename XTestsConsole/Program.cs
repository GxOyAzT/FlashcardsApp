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

            var process = new CountNewFlashcardsWhereUserId();

            var output = process.Count("a2c76aeb-94ff-4020-bc19-059877fe8705");
        }
    }
}
