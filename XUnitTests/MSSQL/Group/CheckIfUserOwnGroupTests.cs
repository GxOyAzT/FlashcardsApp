using DatabaseModule;
using DatabaseModuleInterface;
using System;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class CheckIfUserOwnGroupTests
    {

        [Fact]
        public void CheckIfUserOwnGroupTestA()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfUserOwnGroup _checkIfUserOwnGroup = new CheckIfUserOwnGroup();

            Assert.True(_checkIfUserOwnGroup.Check("00782523-7206-403a-b953-75cfa7ccb4e1", Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")));
        }

        [Fact]
        public void CheckIfUserOwnGroupTestB()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfUserOwnGroup _checkIfUserOwnGroup = new CheckIfUserOwnGroup();

            Assert.True(_checkIfUserOwnGroup.Check("c4a82913-7936-4448-a9e9-d33e5796a414", Guid.Parse("1d917073-68ea-4e11-b4ae-816f30e33e72")));
        }

        [Fact]
        public void CheckIfUserOwnGroupTestC()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfUserOwnGroup _checkIfUserOwnGroup = new CheckIfUserOwnGroup();

            Assert.False(_checkIfUserOwnGroup.Check("00782523-7206-403a-b953-75cfa7ccb4e1", Guid.Parse("1d917073-68ea-4e11-b4ae-816f30e33e72")));
        }

        [Fact]
        public void CheckIfUserOwnGroupTestD()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfUserOwnGroup _checkIfUserOwnGroup = new CheckIfUserOwnGroup();

            Assert.False(_checkIfUserOwnGroup.Check("", Guid.Parse("1d917073-68ea-4e11-b4ae-816f30e33e72")));
        }

        [Fact]
        public void CheckIfUserOwnGroupTestE()
        {
            ResetTestDatabasev2.Reset();

            ICheckIfUserOwnGroup _checkIfUserOwnGroup = new CheckIfUserOwnGroup();

            Assert.False(_checkIfUserOwnGroup.Check("", Guid.Parse("00000000-0000-0000-0000-816f30e33e72")));
        }
    }
}
