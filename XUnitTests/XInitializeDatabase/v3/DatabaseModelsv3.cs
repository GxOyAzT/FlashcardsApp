using Models;
using System;
using System.Collections.Generic;

namespace XUnitTests
{
    public class DatabaseModelsv3
    {
        public DatabaseModelsv3()
        {
            InitializeGroupDbModels();
            InitializeFlashcardDbModels();
        }

        List<GroupDbModel> GroupDbModels { get; set; }
        List<FlashcardDbModel> FlashcardDbModels { get; set; }

        void InitializeGroupDbModels()
        {
            GroupDbModels = new List<GroupDbModel>();

            GroupDbModels.Add(new GroupDbModel()
            {
                Id = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046"),
                Name = "Group-1",
                Description = null,
                UserId = "00782523-7206-403a-b953-75cfa7ccb4e1"
            });

            GroupDbModels.Add(new GroupDbModel()
            {
                Id = Guid.Parse("1d917073-68ea-4e11-b4ae-816f30e33e72"),
                Name = "Group-2",
                Description = "same user as 3.",
                UserId = "c4a82913-7936-4448-a9e9-d33e5796a414"
            });

            GroupDbModels.Add(new GroupDbModel()
            {
                Id = Guid.Parse("d7e0f1ef-49de-486e-b88a-d0e0c1d8f496"),
                Name = "Group-3",
                Description = "same user as 2.",
                UserId = "c4a82913-7936-4448-a9e9-d33e5796a414"
            });
        }
        void InitializeFlashcardDbModels()
        {
            FlashcardDbModels = new List<FlashcardDbModel>();

            // Group-1

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 1 Native",
                ForeignLanguage = "Flashcard 1 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 8),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 1 Native",
                ForeignLanguage = "Flashcard 1 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 8),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("ec604aff-6706-4c05-8c58-bd72115e3f60"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 2 Native",
                ForeignLanguage = "Flashcard 2 Foreign",
                CorreactAnsInRow = 2,
                NextPracticeDate = new DateTime(2020,12,12),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("ec604aff-6706-4c05-8c58-bd72115e3f60"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 2 Native",
                ForeignLanguage = "Flashcard 2 Foreign",
                CorreactAnsInRow = 2,
                NextPracticeDate = new DateTime(2020, 12, 12),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("deadec4a-1fa4-4ed8-809d-b92eb5fecc6c"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 3 Native",
                ForeignLanguage = "Flashcard 3 Foreign",
                CorreactAnsInRow = 1,
                NextPracticeDate = new DateTime(2020, 12, 8),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("deadec4a-1fa4-4ed8-809d-b92eb5fecc6c"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 3 Native",
                ForeignLanguage = "Flashcard 3 Foreign",
                CorreactAnsInRow = 1,
                NextPracticeDate = new DateTime(2020, 12, 8),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("32aee329-6675-4ae8-898a-95bb94ea0143"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 4 Native",
                ForeignLanguage = "Flashcard 4 Foreign",
                CorreactAnsInRow = 1,
                NextPracticeDate = new DateTime(2020, 12, 7),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("32aee329-6675-4ae8-898a-95bb94ea0143"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 4 Native",
                ForeignLanguage = "Flashcard 4 Foreign",
                CorreactAnsInRow = 3,
                NextPracticeDate = new DateTime(2020, 12, 7),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("ef05a03f-a56c-4c86-9485-c08686a466c9"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 5 Native",
                ForeignLanguage = "Flashcard 5 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 5),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("ef05a03f-a56c-4c86-9485-c08686a466c9"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 5 Native",
                ForeignLanguage = "Flashcard 5 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 5),
                GroupDbModelId = Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")
            });

            // Group-2

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("0b6799b7-9734-49c2-b701-770ad9601284"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 6 Native",
                ForeignLanguage = "Flashcard 6 Foreign",
                CorreactAnsInRow = 2,
                NextPracticeDate = new DateTime(2020, 10, 7),
                GroupDbModelId = Guid.Parse("1d917073-68ea-4e11-b4ae-816f30e33e72")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("0b6799b7-9734-49c2-b701-770ad9601284"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 6 Native",
                ForeignLanguage = "Flashcard 6 Foreign",
                CorreactAnsInRow = 5,
                NextPracticeDate = new DateTime(2021, 5, 7),
                GroupDbModelId = Guid.Parse("1d917073-68ea-4e11-b4ae-816f30e33e72")
            });

            // Group-3

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("45433894-5820-413f-93fb-46429ba8486a"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 7 Native",
                ForeignLanguage = "Flashcard 7 Foreign",
                CorreactAnsInRow = 4,
                NextPracticeDate = new DateTime(2020, 5, 7),
                GroupDbModelId = Guid.Parse("d7e0f1ef-49de-486e-b88a-d0e0c1d8f496")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("45433894-5820-413f-93fb-46429ba8486a"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 7 Native",
                ForeignLanguage = "Flashcard 7 Foreign",
                CorreactAnsInRow = 5,
                NextPracticeDate = new DateTime(2020, 12, 31),
                GroupDbModelId = Guid.Parse("d7e0f1ef-49de-486e-b88a-d0e0c1d8f496")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("58d47aaf-ddcd-47d0-b8a1-4febd4e24c7f"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 8 Native",
                ForeignLanguage = "Flashcard 8 Foreign",
                CorreactAnsInRow = 2,
                NextPracticeDate = new DateTime(2020, 12, 9),
                GroupDbModelId = Guid.Parse("d7e0f1ef-49de-486e-b88a-d0e0c1d8f496")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("58d47aaf-ddcd-47d0-b8a1-4febd4e24c7f"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 8 Native",
                ForeignLanguage = "Flashcard 8 Foreign",
                CorreactAnsInRow = 2,
                NextPracticeDate = new DateTime(2021, 04, 30),
                GroupDbModelId = Guid.Parse("d7e0f1ef-49de-486e-b88a-d0e0c1d8f496")
            });
        }

        public List<GroupDbModel> GetGroupDbModels() => GroupDbModels;
        public List<FlashcardDbModel> GetFlashcardDbModels() => FlashcardDbModels;
    }
}
