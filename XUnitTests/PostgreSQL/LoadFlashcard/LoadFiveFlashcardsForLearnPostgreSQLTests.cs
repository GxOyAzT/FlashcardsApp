using DatabaseModuleInterface;
using DatabaseModulePostgreSQL;
using Models;
using System;
using System.Linq;
using Xunit;

namespace XUnitTests.PostgreSQL
{
    [Collection("Sequential")]
    public class LoadFiveFlashcardsForLearnPostgreSQLTests
    {
        [Fact]
        public void LoadFiveFlashcardsForLearnPostgreSQLTestA()
        {
            ResetTestDatabasePostgreSQLv2.Reset();

            ILoadFiveFlashcardsForLearn _db = new LoadFiveFlashcardsForLearnPostgreSQL();

            var items = _db.Load(Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046"));

            Assert.NotNull(items.FirstOrDefault(e => e.Id == Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));

            Assert.Null(items.FirstOrDefault(e => e.Id == Guid.Parse("ec604aff-6706-4c05-8c58-bd72115e3f60") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));
        }
    }
}
