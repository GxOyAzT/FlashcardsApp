using DatabaseModule;
using System;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class CountHowManyFlashcardsForPracticeWhereGroupIdTests
    {
        [Theory]
        [InlineData("9098D9D1-48F6-4BAF-B669-602E7F7EFB4B", 2)]
        [InlineData("189D32D1-22B8-4617-8FBA-0267880F303E", 0)]
        [InlineData("F34B0017-65E3-4F37-8D1B-4AB096F64046", 6)]
        public void CountHowManyFlashcardsForPracticeWhereGroupIdTestA(string groupId, int expected)
        {
            ResetTestDatabasev6.Reset();

            var _processor = new CountHowManyFlashcardsForPracticeWhereGroupId();

            Assert.Equal(expected, _processor.Count(Guid.Parse(groupId)));
        }
    }
}
