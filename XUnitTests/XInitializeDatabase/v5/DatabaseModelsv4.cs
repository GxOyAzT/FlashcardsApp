using Models;
using System;
using System.Collections.Generic;

namespace XUnitTests
{
    public class DatabaseModelsv5
    {
        public DatabaseModelsv5()
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
                Description = "same user as 3 and 4.",
                UserId = "466c7fca-ad58-4e9d-b88a-e3926386735f"
            });

            GroupDbModels.Add(new GroupDbModel()
            {
                Id = Guid.Parse("d7e0f1ef-49de-486e-b88a-d0e0c1d8f496"),
                Name = "Group-3",
                Description = "same user as 2 and 4.",
                UserId = "466c7fca-ad58-4e9d-b88a-e3926386735f"
            });

            GroupDbModels.Add(new GroupDbModel()
            {
                Id = Guid.Parse("189d32d1-22b8-4617-8fba-0267880f303e"),
                Name = "Group-4",
                Description = "same user as 2 and 3.",
                UserId = "466c7fca-ad58-4e9d-b88a-e3926386735f"
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

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("46acf237-9d3c-4fac-8464-0a03ca5d89ae"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 12 Native",
                ForeignLanguage = "Flashcard 12 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 7),
                GroupDbModelId = Guid.Parse("1d917073-68ea-4e11-b4ae-816f30e33e72")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("46acf237-9d3c-4fac-8464-0a03ca5d89ae"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 12 Native",
                ForeignLanguage = "Flashcard 12 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 7),
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

            // Group 4

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("0c2c07a0-d258-45b3-817e-d6fe926dee69"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 9 Native",
                ForeignLanguage = "Flashcard 9 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12,20),
                GroupDbModelId = Guid.Parse("189d32d1-22b8-4617-8fba-0267880f303e")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("0c2c07a0-d258-45b3-817e-d6fe926dee69"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 9 Native",
                ForeignLanguage = "Flashcard 9 Foreign",
                CorreactAnsInRow = 1,
                NextPracticeDate = new DateTime(2021, 12, 3),
                GroupDbModelId = Guid.Parse("189d32d1-22b8-4617-8fba-0267880f303e")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("fb014f21-452e-44c2-8538-9503933a1e4e"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 10 Native",
                ForeignLanguage = "Flashcard 10 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 3),
                GroupDbModelId = Guid.Parse("189d32d1-22b8-4617-8fba-0267880f303e")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("fb014f21-452e-44c2-8538-9503933a1e4e"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 10 Native",
                ForeignLanguage = "Flashcard 10 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 3),
                GroupDbModelId = Guid.Parse("189d32d1-22b8-4617-8fba-0267880f303e")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("e53cdb26-cc6a-47ab-8e46-0451ac4dcfd1"),
                PracticeDirection = PracticeDirection.FromNativeToForeign,
                NativeLanguage = "Flashcard 11 Native",
                ForeignLanguage = "Flashcard 11 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 1),
                GroupDbModelId = Guid.Parse("189d32d1-22b8-4617-8fba-0267880f303e")
            });

            FlashcardDbModels.Add(new FlashcardDbModel()
            {
                Id = Guid.Parse("e53cdb26-cc6a-47ab-8e46-0451ac4dcfd1"),
                PracticeDirection = PracticeDirection.FromForeignToNative,
                NativeLanguage = "Flashcard 11 Native",
                ForeignLanguage = "Flashcard 11 Foreign",
                CorreactAnsInRow = null,
                NextPracticeDate = new DateTime(2020, 12, 1),
                GroupDbModelId = Guid.Parse("189d32d1-22b8-4617-8fba-0267880f303e")
            });
        }

        public List<GroupDbModel> GetGroupDbModels() => GroupDbModels;
        public List<FlashcardDbModel> GetFlashcardDbModels() => FlashcardDbModels;
    }
}
