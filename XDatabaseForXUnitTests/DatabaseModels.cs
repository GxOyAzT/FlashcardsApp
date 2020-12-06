using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace XDatabaseForXUnitTests
{
    public class DatabaseModels
    {
        public DatabaseModels()
        {
            InitializeUserDbModels();
            InitializeGroupDbModels();
            InitializeFlashcardDbModels();
        }

        List<UserDbModel> UserDbModels { get; set; }
        List<GroupDbModel> GroupDbModels { get; set; }
        List<FlashcardDbModel> FlashcardDbModels { get; set; }

        public void InitializeUserDbModels()
        {
            UserDbModels = new List<UserDbModel>();

            UserDbModels.Add(new UserDbModel
            {
                Id = Guid.Parse("e404e71b-db96-4766-992e-177b38ca2450"),
                Nick = "User-1",
                Email = "user1@email.com",
                IsAccountConfirmed = true,
                Password = "ABC"
            });

            UserDbModels.Add(new UserDbModel()
            {
                Id = Guid.Parse("c93db80d-d6cb-45b2-a10c-f48efb1650df"),
                Nick = "User-2",
                Email = "user2@email.com",
                IsAccountConfirmed = true,
                Password = "ABC"
            });
        }
        public void InitializeGroupDbModels()
        {
            GroupDbModels = new List<GroupDbModel>();

            GroupDbModels.Add(new GroupDbModel()
            {
                Id = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046"),
                Name = "Group-1",
                Description = null,
                UserDbModelId = Guid.Parse("e404e71b-db96-4766-992e-177b38ca2450")
            });
        }
        public void InitializeFlashcardDbModels()
        {
            FlashcardDbModels = new List<FlashcardDbModel>();

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 1 Native",
                ForeignLanguage = "Flashcard 1 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = null,
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 1 Native",
                ForeignLanguage = "Flashcard 1 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = null,
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });
        }

        public List<UserDbModel> GetUserDbModels() => UserDbModels;
        public List<GroupDbModel> GetGroupDbModels() => GroupDbModels;
        public List<FlashcardDbModel> GetFlashcardDbModels() => FlashcardDbModels;
    }
}
