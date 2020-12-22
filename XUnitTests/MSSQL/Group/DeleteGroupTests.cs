using DatabaseModule;
using DatabaseModuleInterface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class DeleteGroupTests
    {
        [Fact]
        public void DeleteGroupTestA()
        {
            ResetTestDatabasev3.Reset();

            IDeleteGroup _processor = new DeleteGroup();

            _processor.Delete(Guid.Parse("d7e0f1ef-49de-486e-b88a-d0e0c1d8f496"));

            List<FlashcardDbModel> allFlashcards;

            using (var db = new FlashcardsDbContext())
            {
                allFlashcards = db.FlashcardsDbModels.ToList();
            }

            Assert.Null(allFlashcards
                .FirstOrDefault(e => 
                e.Id == Guid.Parse("58d47aaf-ddcd-47d0-b8a1-4febd4e24c7f") || 
                e.Id == Guid.Parse("45433894-5820-413f-93fb-46429ba8486a")));

            Assert.NotNull(allFlashcards
                .FirstOrDefault(e =>
                e.Id == Guid.Parse("0b6799b7-9734-49c2-b701-770ad9601284")));
        }

        [Fact]
        public void DeleteGroupTestB()
        {
            ResetTestDatabasev3.Reset();

            IDeleteGroup _processor = new DeleteGroup();

            _processor.Delete(Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046"));

            List<FlashcardDbModel> allFlashcards;

            using (var db = new FlashcardsDbContext())
            {
                allFlashcards = db.FlashcardsDbModels.ToList();
            }

            Assert.Null(allFlashcards
                .FirstOrDefault(e =>
                e.Id == Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c") ||
                e.Id == Guid.Parse("ec604aff-6706-4c05-8c58-bd72115e3f60") ||
                e.Id == Guid.Parse("32aee329-6675-4ae8-898a-95bb94ea0143") ||
                e.Id == Guid.Parse("ef05a03f-a56c-4c86-9485-c08686a466c9") ||
                e.Id == Guid.Parse("deadec4a-1fa4-4ed8-809d-b92eb5fecc6c")));

            Assert.NotNull(allFlashcards
                .FirstOrDefault(e =>
                e.Id == Guid.Parse("0b6799b7-9734-49c2-b701-770ad9601284")));

            Assert.NotNull(allFlashcards
                .FirstOrDefault(e =>
                e.Id == Guid.Parse("45433894-5820-413f-93fb-46429ba8486a")));

            Assert.NotNull(allFlashcards
                .FirstOrDefault(e =>
                e.Id == Guid.Parse("58d47aaf-ddcd-47d0-b8a1-4febd4e24c7f")));
        }
    }
}
