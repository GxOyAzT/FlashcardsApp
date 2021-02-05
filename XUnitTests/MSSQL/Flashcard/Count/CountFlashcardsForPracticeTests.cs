using DatabaseModule;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class CountFlashcardsForPracticeTests
    {
        [Fact]
        public void CountFlashcardsForPracticeTestA()
        {
            ResetTestDatabasev6.Reset();

            var _process = new CountFlashcardsForPractice();

            Assert.True(_process.Count("00782523-7206-403a-b953-75cfa7ccb4e1") == 6);
        }
    }
}
