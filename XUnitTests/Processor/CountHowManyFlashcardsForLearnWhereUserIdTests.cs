using DatabaseModule;
using Xunit;

namespace XUnitTests.Processor
{
    [Collection("Sequential")]
    public class CountHowManyFlashcardsForLearnWhereUserIdTests
    {
        [Theory]
        [InlineData("466c7fca-ad58-4e9d-b88a-e3926386735f", 7)]
        [InlineData("00782523-7206-403a-b953-75cfa7ccb4e1", 4)]
        [InlineData("a2c76aeb-94ff-4020-bc19-059877fe8705", 1)]
        public void CountHowManyFlashcardsForLearnWhereUserIdTestA(string userId, int expectedOutput)
        {
            ResetTestDatabasev6.Reset();

            var _processor = new CountHowManyFlashcardsForLearnWhereUserId();

            Assert.Equal(expectedOutput, _processor.Count(userId));
        }
    }
}
