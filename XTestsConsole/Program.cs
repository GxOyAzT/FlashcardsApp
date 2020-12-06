using System;
using DatabaseModule;
using DatabaseModuleInterface;
using Models;

namespace XTestsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDbModel userDbModel1 = new UserDbModel()
            {
                Id = Guid.Parse("e404e71b-db96-4766-992e-177b38ca2450"),
                Nick = "User-1",
                Email = "user1@email.com",
                IsAccountConfirmed = true,
                Password = "ABC"
            };

            UserDbModel userDbModel2 = new UserDbModel()
            {
                Id = Guid.Parse("c93db80d-d6cb-45b2-a10c-f48efb1650df"),
                Nick = "User-2",
                Email = "user2@email.com",
                IsAccountConfirmed = true,
                Password = "ABC"
            };

            GroupDbModel groupDbModel1 = new GroupDbModel()
            {
                Id = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046"),
                Name = "Group-1",
                Description = null,
                UserDbModelId = Guid.Parse("e404e71b-db96-4766-992e-177b38ca2450")
            };

            FlashcardDbModel flashcardDbModelX1 = new FlashcardDbModel()
            {
                Id = Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 1 Native",
                ForeignLanguage = "Flashcard 1 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = null,
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            };

            FlashcardDbModel flashcardDbModelY1 = new FlashcardDbModel()
            {
                Id = Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 1 Native",
                ForeignLanguage = "Flashcard 1 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = null,
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            };

            //using (var db = new FlashcardsDbContext())
            //{
            //    db.UserDbModels.Add(userDbModel2);
            //    db.SaveChanges();
            //}

            var ans = (new CheckIfUserOwnGroup().Check(userDbModel1.Id, groupDbModel1.Id));
        }
    }
}
