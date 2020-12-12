using Processor;
using System;
using Xunit;

namespace XUnitTests
{
    [Collection("Sequential")]
    public class CheckIfGroupIdIsUniqueTests
    {
        [Theory]
        [InlineData("00000000-65e3-4f37-8d1b-4ab096f64046", true)]
        [InlineData("f34b0017-65e3-4f37-8d1b-4ab096f64046", false)]
        public void CheckIfIdIsUniqueTestA(string stringId, bool expected)
        {
            ResetTestDatabasev2.Reset();

            Guid id = Guid.Parse(stringId);

            ICheckIfGroupIdIsUnique _processor = new CheckIfGroupIdIsUnique();

            Assert.Equal(expected, _processor.Check(id));
        }
    }
}
