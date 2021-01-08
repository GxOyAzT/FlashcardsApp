using DatabaseModule;
using System;
using System.Linq;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class LoadFlashcardsForPracticeWhereUserIdTests
    {
        [Fact]
        public void LoadFlashcardsForLearnWhereUserIdTestA()
        {
            ResetTestDatabasev6.Reset();

            var _processor = new LoadFlashcardsForPracticeWhereUserId();

            var output = _processor.Load("466c7fca-ad58-4e9d-b88a-e3926386735f", 4);

            Assert.Equal(4, output.Count);

            Assert.NotNull(output
                .FirstOrDefault(e => e.Id == Guid.Parse("45433894-5820-413F-93FB-46429BA8486A") &&
                    e.PracticeDirection == Models.PracticeDirection.FromForeignToNative));

            Assert.NotNull(output
                .FirstOrDefault(e => e.Id == Guid.Parse("0B6799B7-9734-49C2-B701-770AD9601284") &&
                    e.PracticeDirection == Models.PracticeDirection.FromNativeToForeign));

            Assert.NotNull(output
                .FirstOrDefault(e => e.Id == Guid.Parse("58D47AAF-DDCD-47D0-B8A1-4FEBD4E24C7F") &&
                    e.PracticeDirection == Models.PracticeDirection.FromForeignToNative));

            Assert.NotNull(output
                .FirstOrDefault(e => e.Id == Guid.Parse("45433894-5820-413F-93FB-46429BA8486A") &&
                    e.PracticeDirection == Models.PracticeDirection.FromNativeToForeign));
        }
    }
}
