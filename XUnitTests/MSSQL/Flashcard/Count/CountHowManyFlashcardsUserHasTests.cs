using DatabaseModule;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class CountHowManyFlashcardsUserHasTests
    {
        [Theory]
        [InlineData("466c7fca-ad58-4e9d-b88a-e3926386735f", 14)]
        [InlineData("a2c76aeb-94ff-4020-bc19-059877fe8705", 4)]
        [InlineData("00782523-7206-403a-b953-75cfa7ccb4e1", 10)]
        public void CountHowManyFlashcardsUserHasTestA(string userId, int expected)
        {
            ResetTestDatabasev6.Reset();

            CountHowManyFlashcardsUserHas _process = new CountHowManyFlashcardsUserHas();

            Assert.Equal(_process.Count(userId), expected);
        }
    }
}
