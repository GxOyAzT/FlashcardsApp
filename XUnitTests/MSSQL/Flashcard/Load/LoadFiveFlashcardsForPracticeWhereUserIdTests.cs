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
        public void LoadFiveFlashcardsForPracticeWhereUserIdTestA()
        {
            ResetTestDatabasePostgreSQLv4.Reset();

            LoadFiveFlashcardsForPracticeWhereUserId _processor = new LoadFiveFlashcardsForPracticeWhereUserId();

            var output = _processor.Load("c4a82913-7936-4448-a9e9-d33e5796a414");

            Assert.NotNull(output.
                FirstOrDefault(e => 
                e.Id == Guid.Parse("45433894-5820-413F-93FB-46429BA8486A") && e.PracticeDirection == PracticeDirection.FromForeignToNative));

            Assert.NotNull(output.
                FirstOrDefault(e => 
                e.Id == Guid.Parse("0B6799B7-9734-49C2-B701-770AD9601284") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));

            Assert.NotNull(output.
                FirstOrDefault(e =>
                e.Id == Guid.Parse("58D47AAF-DDCD-47D0-B8A1-4FEBD4E24C7F") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));

            Assert.Null(output.
                FirstOrDefault(e =>
                e.Id == Guid.Parse("DEADEC4A-1FA4-4ED8-809D-B92EB5FECC6C") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));
        }
    }
}
