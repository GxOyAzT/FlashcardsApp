using Processor;
using System;
using Xunit;

namespace XUnitTests.MSSQL
{
    public class ValidateGroupModelTests
    {
        [Fact]
        public void ValidateGroupModelTestA()
        {
            string groupName = "Abbd Asdfa";
            string description = "Aascfwgh ergrgwgwr geht";

            IValidateGroupModel _processor = new ValidateGroupModel(
                new ValidateGroupName(), 
                new ValidateGroupDescription());

            Assert.Empty(_processor.GetErrorMessages());
            Assert.True(_processor.Validate(groupName, description));
        }

        [Fact]
        public void ValidateGroupModelTestB()
        {
            string groupName = " Abbd Asdfa";
            string description = "Aascfwgh ergrgwgwr geht";

            IValidateGroupModel _processor = new ValidateGroupModel(
                new ValidateGroupName(),
                new ValidateGroupDescription());

            Assert.False(_processor.Validate(groupName, description));
            Assert.NotEmpty(_processor.GetErrorMessages());
            Assert.Contains("Group name cannot contain space on the end or begin.", _processor.GetErrorMessages());
        }

        [Fact]
        public void ValidateGroupModelTestC()
        {
            string groupName = " Abbd Asdfa";
            string description = "Aascfwgh ergrgwgwr geht Aascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr geht";

            IValidateGroupModel _processor = new ValidateGroupModel(
                new ValidateGroupName(),
                new ValidateGroupDescription());

            Assert.False(_processor.Validate(groupName, description));
            Assert.NotEmpty(_processor.GetErrorMessages());
            Assert.Contains("Description cannot be longer then 200 characters.", _processor.GetErrorMessages());
        }

        [Fact]
        public void ValidateGroupModelTestD()
        {
            string groupName = " Abbd Asdfa";
            string description = "Aascfwgh ergrgwgwr geht Aascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr gehtAascfwgh ergrgwgwr geht";

            IValidateGroupModel _processor = new ValidateGroupModel(
                new ValidateGroupName(),
                new ValidateGroupDescription());

            Assert.False(_processor.Validate(groupName, description));
            Assert.True(_processor.Validate("Abdf", "Ahdeofhw akfwef."));
        }
    }
}
