﻿using Processor;
using Xunit;

namespace XUnitTests
{
    [Collection("Sequential")]
    public class ValidateGroupNameTests
    {
        [Fact]
        public void ValidateGroupNameTestA()
        {
            string input = "Abbd Asdfa";

            IValidateGroupName _processor = new ValidateGroupName();

            Assert.True(_processor.Validate(input));
        }

        [Fact]
        public void ValidateGroupNameTestB()
        {
            string input = " Abbd Asdfa";

            IValidateGroupName _processor = new ValidateGroupName();

            Assert.False(_processor.Validate(input));
        }

        [Fact]
        public void ValidateGroupNameTestC()
        {
            string input = "Abbd Asdfa ";

            IValidateGroupName _processor = new ValidateGroupName();

            Assert.False(_processor.Validate(input));
        }

        [Fact]
        public void ValidateGroupNameTestD()
        {
            string input = "";

            IValidateGroupName _processor = new ValidateGroupName();

            Assert.False(_processor.Validate(input));
        }

        [Fact]
        public void ValidateGroupNameTestE()
        {
            string input = "   ";

            IValidateGroupName _processor = new ValidateGroupName();

            Assert.False(_processor.Validate(input));
        }

        [Fact]
        public void ValidateGroupNameTestF()
        {
            string input = "Asdf/";

            IValidateGroupName _processor = new ValidateGroupName();

            Assert.False(_processor.Validate(input));
        }
    }
}
