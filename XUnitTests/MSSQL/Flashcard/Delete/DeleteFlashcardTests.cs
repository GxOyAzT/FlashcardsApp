using DatabaseModule;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class DeleteFlashcardTests
    {
        [Fact]
        public void DeleteFlashcardTestA()
        {
            ResetTestDatabasev4.Reset();

            DeleteFlashcard _processor = new DeleteFlashcard();

            _processor.Delete(Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046"));

            List<FlashcardDbModel> flashcardsAfterDelete;

            using (var db = new FlashcardsDbContext())
            {
                flashcardsAfterDelete = db.FlashcardsDbModels.ToList();
            }

            Assert.Null(flashcardsAfterDelete.FirstOrDefault(e => e.Id == Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")));
        }
    }
}
