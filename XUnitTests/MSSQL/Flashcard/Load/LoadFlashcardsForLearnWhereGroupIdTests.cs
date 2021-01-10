using DatabaseModule;
using Models;
using System;
using System.Linq;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class LoadFlashcardsForLearnWhereGroupIdTests
    {
        [Fact]
        public void LoadFlashcardsForLearnWhereGroupIdTestA()
        {
            ResetTestDatabasev6.Reset();

            var _processor = new LoadFlashcardsForLearnWhereGroupId();

            var output = _processor.Load(Guid.Parse("189D32D1-22B8-4617-8FBA-0267880F303E"), 3);

            Assert.Equal(3, output.Count);

            Assert.NotNull(output.FirstOrDefault(e => e.Id == Guid.Parse("E53CDB26-CC6A-47AB-8E46-0451AC4DCFD1") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));

            Assert.NotNull(output.FirstOrDefault(e => e.Id == Guid.Parse("E53CDB26-CC6A-47AB-8E46-0451AC4DCFD1") && e.PracticeDirection == PracticeDirection.FromForeignToNative));

            Assert.NotNull(output.FirstOrDefault(e => e.Id == Guid.Parse("FB014F21-452E-44C2-8538-9503933A1E4E") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));
        }

        [Fact]
        public void LoadFlashcardsForLearnWhereGroupIdTestB()
        {
            ResetTestDatabasev6.Reset();

            var _processor = new LoadFlashcardsForLearnWhereGroupId();

            var output = _processor.Load(Guid.Parse("9098d9d1-48f6-4baf-b669-602e7f7efb4b"), 3);

            Assert.Single(output);

            Assert.NotNull(output.FirstOrDefault(e => e.Id == Guid.Parse("2B134D1A-965D-4E97-888E-BDD64A044EB9") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));
        }
    }
}
