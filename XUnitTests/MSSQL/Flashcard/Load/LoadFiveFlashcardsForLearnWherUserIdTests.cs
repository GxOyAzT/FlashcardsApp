using DatabaseModule;
using DatabaseModuleInterface;
using System;
using System.Linq;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class LoadFiveFlashcardsForLearnWherUserIdTests
    {
        [Fact]
        public void LoadFiveFlashcardsForLearnWherUserIdTestA()
        {
            ResetTestDatabasev6.Reset();

            ILoadFiveFlashcardsForLearnWherUserId _processor =
                new LoadFiveFlashcardsForLearnWherUserId();

            var output = _processor.Load("a2c76aeb-94ff-4020-bc19-059877fe8705");

            Assert.NotNull(output.FirstOrDefault(e => e.Id == Guid.Parse("2b134d1a-965d-4e97-888e-bdd64a044eb9") && e.PracticeDirection == Models.PracticeDirection.FromNativeToForeign));

            Assert.Single(output);
        }
    }
}
