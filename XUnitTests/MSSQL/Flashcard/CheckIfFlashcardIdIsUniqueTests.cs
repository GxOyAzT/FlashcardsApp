using System;
using Xunit;
using DatabaseModule;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class CheckIfFlashcardIdIsUniqueTests
    {
        [Theory]
        [InlineData("073e83a0-57ff-43b8-a2c7-56a54b5ab22c", false)]
        [InlineData("00000000-57ff-43b8-a2c7-56a54b5ab22c", true)]
        public void CheckIfFlashcardIfIsUniqueTestA(string stringId, bool expected)
        {
            ResetTestDatabasev2.Reset();

            CheckIfFlashcardIdIsUnique _processor = new CheckIfFlashcardIdIsUnique();

            Assert.Equal(expected, _processor.Check(Guid.Parse(stringId)));
        }
    }
}
