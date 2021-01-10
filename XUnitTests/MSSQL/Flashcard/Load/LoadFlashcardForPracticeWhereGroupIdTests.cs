using DatabaseModule;
using Models;
using System;
using System.Linq;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class LoadFlashcardForPracticeWhereGroupIdTests
    {
        [Fact]
        public void LoadFlashcardForPracticeWhereGroupIdTestA()
        {
            ResetTestDatabasev6.Reset();

            var _processor = new LoadFlashcardForPracticeWhereGroupId();

            var output = _processor.Load(Guid.Parse("189D32D1-22B8-4617-8FBA-0267880F303E"), 1);

            Assert.Empty(output);
        }

        [Fact]
        public void LoadFlashcardForPracticeWhereGroupIdTestB()
        {
            ResetTestDatabasev6.Reset();

            var _processor = new LoadFlashcardForPracticeWhereGroupId();

            var output = _processor.Load(Guid.Parse("1D917073-68EA-4E11-B4AE-816F30E33E72"), 2);

            Assert.Single(output);

            Assert.NotNull(output.FirstOrDefault(e => e.Id == Guid.Parse("0B6799B7-9734-49C2-B701-770AD9601284") && e.PracticeDirection == PracticeDirection.FromNativeToForeign));
        }
    }
}
