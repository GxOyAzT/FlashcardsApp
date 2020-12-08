using System;
using DatabaseModule;

namespace XTestsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadFiveFlashcardsForLearn loadFiveFlashcardsForLearn = new LoadFiveFlashcardsForLearn();

            var items = loadFiveFlashcardsForLearn.Load(Guid.Parse("F34B0017-65E3-4F37-8D1B-4AB096F64046"));

            //using (var db = new FlashcardsDbContext())
            //{
            //    db.SaveChanges();
            //}
        }
    }
}
