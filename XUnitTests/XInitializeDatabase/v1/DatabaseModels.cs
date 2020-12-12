﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTests
{
    public class DatabaseModels
    {
        public DatabaseModels()
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
        }
        void InitializeFlashcardDbModels()
        {
            FlashcardDbModels = new List<FlashcardDbModel>();

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
        }

        public List<GroupDbModel> GetGroupDbModels() => GroupDbModels;
        public List<FlashcardDbModel> GetFlashcardDbModels() => FlashcardDbModels;
    }
}
