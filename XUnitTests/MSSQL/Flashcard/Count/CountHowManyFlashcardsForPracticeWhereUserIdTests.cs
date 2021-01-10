using DatabaseModule;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class CountHowManyFlashcardsForPracticeWhereUserIdTests
    {
        [Theory]
        [InlineData("466c7fca-ad58-4e9d-b88a-e3926386735f", 4)]
        [InlineData("00782523-7206-403a-b953-75cfa7ccb4e1", 6)]
        [InlineData("a2c76aeb-94ff-4020-bc19-059877fe8705", 2)]
        public void CountHowManyFlashcardsForPracticeWhereUserIdTestA(string userId, int expectedOutput)
        {
            ResetTestDatabasev6.Reset();

            var _processor = new CountHowManyFlashcardsForPracticeWhereUserId();

            Assert.Equal(expectedOutput, _processor.Count(userId));
        }
    }
}
