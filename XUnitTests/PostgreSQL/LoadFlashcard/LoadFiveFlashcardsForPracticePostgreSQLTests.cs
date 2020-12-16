using DatabaseModuleInterface;
using DatabaseModulePostgreSQL;
using Models;
using System;
using System.Linq;
using Xunit;

namespace XUnitTests.PostgreSQL
{
    [Collection("Sequential")]
    public class LoadFiveFlashcardsForPracticePostgreSQLTests
    {
        [Fact]
        public void LoadFiveFlashcardsForPracticePostgreSQLTestA()
        {
            ResetTestDatabasePostgreSQLv2.Reset();

            ILoadFiveFlashcardsForPractice _db = new LoadFiveFlashcardsForPracticePostgreSQl();

            var output = _db.Load(Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046"));

            Assert.NotNull(output.FirstOrDefault(e => e.Id == Guid.Parse("32aee329-6675-4ae8-898a-95bb94ea0143") && e.PracticeDirection == PracticeDirection.FromForeignToNative));

            Assert.Null(output.FirstOrDefault(e => e.Id == Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));
        }
    }
}
