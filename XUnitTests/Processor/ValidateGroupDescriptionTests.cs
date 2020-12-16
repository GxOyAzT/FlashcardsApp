using Processor;
using Xunit;

namespace XUnitTests.Processor
{
    [Collection("Sequential")]
    public class ValidateGroupDescriptionTests
    {
        [Fact]
        public void ValidateGroupDescriptionTestA()
        {
            string input = "";

            IValidateGroupDescription _processor = new ValidateGroupDescription();

            Assert.True(_processor.Validate(input));
        }

        [Fact]
        public void ValidateGroupDescriptionTestB()
        {
            string input = "Aascfwgh ergrgwgwr geht";

            IValidateGroupDescription _processor = new ValidateGroupDescription();

            Assert.True(_processor.Validate(input));
        }

        [Fact]
        public void ValidateGroupDescriptionTestC()
        {
            string input = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Voluptas, aliquid corrupti et eum reiciendis natus animi voluptate consectetur error dolorem accusantium officia qui. Lorem, ipsum dolor sit amet consectetur adipisicing elit. Voluptas, aliquid corrupti et eum reiciendis natus animi voluptate consectetur error dolorem accusantium officia qui.";

            IValidateGroupDescription _processor = new ValidateGroupDescription();

            Assert.False(_processor.Validate(input));
        }
    }
}
