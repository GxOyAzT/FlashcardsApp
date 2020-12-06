using DatabaseModule;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace XTestsConsole
{
    public static class PrintAllDatabase
    {
        public static void Print()
        {
            List<UserDbModel> userDbModels;

            using (var db = new FlashcardsDbContext())
            {
                userDbModels = db.UserDbModels.Include(e => e.GroupDbModels).ThenInclude(d => d.FlashcardDbModels).ToList();
            }

            foreach(var user in userDbModels)
            {
                System.Console.WriteLine($"User: {user.Id} {user.Nick}");
                foreach (var group in user.GroupDbModels)
                {
                    System.Console.WriteLine($"    Group: {group.Id} {group.Name}");
                    foreach (var flashcard in group.FlashcardDbModels)
                    {
                        System.Console.WriteLine($"        Flashcard: {flashcard.Id} {flashcard.NativeLanguage}");
                    }
                }
            }
        }
    }
}
