using DatabaseModule;
using Models;
using System;
using System.Linq;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class LoadFiveFlashcardsForPracticeWhereUserIdTests
    {
        [Fact]
        public void LoadFiveFlashcardsForPracticeWhereUserIdTestB()
        {
            ResetTestDatabasev6.Reset();

            LoadFiveFlashcardsForPracticeWhereUserId _processor = new LoadFiveFlashcardsForPracticeWhereUserId();

            var output = _processor.Load("a2c76aeb-94ff-4020-bc19-059877fe8705");

            Assert.NotNull(output.
                FirstOrDefault(e =>
                e.Id == Guid.Parse("2b134d1a-965d-4e97-888e-bdd64a044eb9") && e.PracticeDirection == PracticeDirection.FromForeignToNative));

            Assert.NotNull(output.
                FirstOrDefault(e =>
                e.Id == Guid.Parse("be5f6658-18e7-49e3-9c61-b3a2e073042f") && e.PracticeDirection == PracticeDirection.FromForeignToNative));

            Assert.Null(output.
                FirstOrDefault(e =>
                e.Id == Guid.Parse("be5f6658-18e7-49e3-9c61-b3a2e073042f") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));

            Assert.Equal(2, output.Count);
        }
    }
}
