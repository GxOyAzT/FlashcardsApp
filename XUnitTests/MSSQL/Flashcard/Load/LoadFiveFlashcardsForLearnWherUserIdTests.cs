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
            ILoadFiveFlashcardsForLearnWherUserId _processor =
                new LoadFiveFlashcardsForLearnWherUserId();

            var output = _processor.Load("c4a82913-7936-4448-a9e9-d33e5796a414");

            Assert.NotNull(output.FirstOrDefault(e => e.Id == Guid.Parse("E53CDB26-CC6A-47AB-8E46-0451AC4DCFD1") && e.PracticeDirection == Models.PracticeDirection.FromNativeToForeign));

            Assert.NotNull(output.FirstOrDefault(e => e.Id == Guid.Parse("46ACF237-9D3C-4FAC-8464-0A03CA5D89AE") && e.PracticeDirection == Models.PracticeDirection.FromNativeToForeign));

            Assert.Null(output.FirstOrDefault(e => e.Id == Guid.Parse("0c2c07a0-d258-45b3-817e-d6fe926dee69")));

            Assert.Null(output.FirstOrDefault(e => e.Id == Guid.Parse("58d47aaf-ddcd-47d0-b8a1-4febd4e24c7f")));

            Assert.Null(output.FirstOrDefault(e => e.Id == Guid.Parse("073e83a0-57ff-43b8-a2c7-56a54b5ab22c")));
        }
    }
}
