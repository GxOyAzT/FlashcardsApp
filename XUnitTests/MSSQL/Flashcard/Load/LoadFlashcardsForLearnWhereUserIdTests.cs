using DatabaseModule;
using System;
using System.Linq;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class LoadFlashcardsForLearnWhereUserIdTests
    {
        [Fact]
        public void LoadFlashcardsForLearnWhereUserIdTestA()
        {
            ResetTestDatabasev6.Reset();

            var _processor = new LoadFlashcardsForLearnWhereUserId();

            var output = _processor.Load("466c7fca-ad58-4e9d-b88a-e3926386735f", 3);

            Assert.Equal(3, output.Count);

            Assert.NotNull(output
                .FirstOrDefault(e => e.Id == Guid.Parse("E53CDB26-CC6A-47AB-8E46-0451AC4DCFD1") &&
                    e.PracticeDirection == Models.PracticeDirection.FromForeignToNative));

            Assert.NotNull(output
                .FirstOrDefault(e => e.Id == Guid.Parse("E53CDB26-CC6A-47AB-8E46-0451AC4DCFD1") &&
                    e.PracticeDirection == Models.PracticeDirection.FromNativeToForeign));

            Assert.NotNull(output
                .FirstOrDefault(e => e.Id == Guid.Parse("FB014F21-452E-44C2-8538-9503933A1E4E") &&
                    e.PracticeDirection == Models.PracticeDirection.FromNativeToForeign));
        }

        [Fact]
        public void LoadFlashcardsForLearnWhereUserIdTestB()
        {
            ResetTestDatabasev6.Reset();

            var _processor = new LoadFlashcardsForLearnWhereUserId();

            var output = _processor.Load("a2c76aeb-94ff-4020-bc19-059877fe8705", 1);

            Assert.Single(output);

            Assert.NotNull(output
                .FirstOrDefault(e => e.Id == Guid.Parse("2B134D1A-965D-4E97-888E-BDD64A044EB9") &&
                    e.PracticeDirection == Models.PracticeDirection.FromNativeToForeign));
        }
    }
}
