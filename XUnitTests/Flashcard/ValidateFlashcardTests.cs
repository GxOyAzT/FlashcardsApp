using Processor;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTests
{
    public class ValidateFlashcardTests
    {
        [Fact]
        public void ValidateFlashcardTestA()
        {
            string native = "Asdf cfds aaa12./*-";
            string foreign = "addf Sdvcf";

            IValidateFlashcard _processor = new ValidateFlashcard();

            Assert.True(_processor.Validate(foreign, native));
            Assert.Empty(_processor.GetErrorMessages());
        }

        [Fact]
        public void ValidateFlashcardTestB()
        {
            string native = "Asdf cfds aaa ";
            string foreign = "addf Sdvcf";

            IValidateFlashcard _processor = new ValidateFlashcard();

            Assert.False(_processor.Validate(foreign, native));
            Assert.NotEmpty(_processor.GetErrorMessages());
            Assert.Contains("Native contain spaces on the beginning or end.", _processor.GetErrorMessages());
        }

        [Fact]
        public void ValidateFlashcardTestC()
        {
            string native = "Asdf cfds aa";
            string foreign = "  addf Sdvcf";

            IValidateFlashcard _processor = new ValidateFlashcard();

            Assert.False(_processor.Validate(foreign, native));
            Assert.NotEmpty(_processor.GetErrorMessages());
            Assert.Contains("Foreign contain spaces on the beginning or end.", _processor.GetErrorMessages());
        }

        [Fact]
        public void ValidateFlashcardTestD()
        {
            string native = "Asdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aa";
            string foreign = "addf Sdvcf";

            IValidateFlashcard _processor = new ValidateFlashcard();

            Assert.False(_processor.Validate(foreign, native));
            Assert.NotEmpty(_processor.GetErrorMessages());
            Assert.Contains("Native cannot be longer then 100 characters.", _processor.GetErrorMessages());
        }

        [Fact]
        public void ValidateFlashcardTestE()
        {
            string native = "Asdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aaAsdf cfds aa ";
            string foreign = "addf Sdvcf";

            IValidateFlashcard _processor = new ValidateFlashcard();

            Assert.False(_processor.Validate(foreign, native));
            Assert.NotEmpty(_processor.GetErrorMessages());
            Assert.Contains("Native cannot be longer then 100 characters.", _processor.GetErrorMessages());
            Assert.Contains("Native contain spaces on the beginning or end.", _processor.GetErrorMessages());
        }

        [Fact]
        public void ValidateFlashcardTestF()
        {
            string native = "";
            string foreign = null;

            IValidateFlashcard _processor = new ValidateFlashcard();

            Assert.Throws<ArgumentNullException>(() => _processor.Validate(foreign, native));
        }

        [Fact]
        public void ValidateFlashcardTestG()
        {
            IValidateFlashcard _processor = new ValidateFlashcard();

            _processor.Validate("", "");

            Assert.True(_processor.Validate("ASD", "ASD"));
        }
    }
}
