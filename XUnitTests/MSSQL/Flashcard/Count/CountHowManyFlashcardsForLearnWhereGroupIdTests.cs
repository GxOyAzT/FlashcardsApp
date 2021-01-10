using DatabaseModule;
using System;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class CountHowManyFlashcardsForLearnWhereGroupIdTests
    {
        [Theory]
        [InlineData("9098D9D1-48F6-4BAF-B669-602E7F7EFB4B", 1)]
        [InlineData("189D32D1-22B8-4617-8FBA-0267880F303E", 5)]
        [InlineData("F34B0017-65E3-4F37-8D1B-4AB096F64046", 4)]
        public void CountHowManyFlashcardsForLearnWhereGroupIdTestA(string groupId, int expected)
        {
            ResetTestDatabasev6.Reset();

            var _processor = new CountHowManyFlashcardsForLearnWhereGroupId();

            Assert.Equal(expected, _processor.Count(Guid.Parse(groupId)));
        }
    }
}
