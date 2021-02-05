using DatabaseModule;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequentail")]
    public class CountNewFlashcardsWhereUserIdTests
    {
        [Fact]
        public void CountNewFlashcardsWhereUserIdTestA()
        {
            ResetTestDatabasev6.Reset();

            CountNewFlashcardsWhereUserId _process = new CountNewFlashcardsWhereUserId();

            Assert.True(
                _process.Count("00782523-7206-403a-b953-75cfa7ccb4e1") == 4);
        }

        [Fact]
        public void CountNewFlashcardsWhereUserIdTestB()
        {
            ResetTestDatabasev6.Reset();

            CountNewFlashcardsWhereUserId _process = new CountNewFlashcardsWhereUserId();

            Assert.True(
                _process.Count("a2c76aeb-94ff-4020-bc19-059877fe8705") == 1);
        }
    }
}