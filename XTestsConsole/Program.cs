﻿using DatabaseModule;
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

            using (var db = new FlashcardsDbContext())
            {
                var items = db.GroupDbModels
                    .Include(e => e.FlashcardDbModels)
                    .SelectMany(e => e.FlashcardDbModels)
                    .Where(e => e.CorreactAnsInRow != null)
                    .Where(e => e.NextPracticeDate <= DateTime.Now.Date)
                    .ToList();
            }
        }
    }
}
