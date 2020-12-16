using DatabaseModulePostgreSQL;
using System;
using Xunit;

namespace XUnitTests.PostgreSQL
{
    [Collection("Sequential")]
    public class CheckIfFlashcardIdIsUniquePostgreSQLTests
    {
        [Theory]
        [InlineData("073e83a0-57ff-43b8-a2c7-56a54b5ab22c", false)]
        [InlineData("00000000-57ff-43b8-a2c7-56a54b5ab22c", true)]
        public void CheckIfFlashcardIdIsUniquePostgreSQLTestA(string stringId, bool expected)
        {
            ResetTestDatabasePostgreSQLv2.Reset();

            CheckIfFlashcardIdIsUniquePostgreSQL _processor = new CheckIfFlashcardIdIsUniquePostgreSQL();

            Assert.Equal(expected, _processor.Check(Guid.Parse(stringId)));
        }
    }
}