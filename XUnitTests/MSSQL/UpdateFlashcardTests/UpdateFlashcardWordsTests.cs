using DatabaseModule;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class UpdateFlashcardWordsTests
    {
        [Fact]
        public void UpdateFlashcardWordsTestA()
        {
            ResetTestDatabasev4.Reset();

            UpdateFlashcardWords _processor = new UpdateFlashcardWords();

            _processor.Update(Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c"), "native123", "foreign123");

            List<FlashcardDbModel> flashcardsAfterUpdate;

            using (var db = new FlashcardsDbContext())
            {
                flashcardsAfterUpdate = db.FlashcardsDbModels.Where(e => e.Id == Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c")).ToList();
            }

            Assert.True(flashcardsAfterUpdate.Count == 2);

            foreach(var item in flashcardsAfterUpdate)
            {
                Assert.Equal("foreign123", item.ForeignLanguage);
                Assert.Equal("native123", item.NativeLanguage);
            }
        }
    }
}
