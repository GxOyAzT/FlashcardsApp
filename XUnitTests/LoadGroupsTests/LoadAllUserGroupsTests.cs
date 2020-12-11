using DatabaseModule;
using DatabaseModuleInterface;
using XDatabaseForXUnitTests;
using Xunit;

namespace XUnitTests
{
    public class LoadAllUserGroupsTests
    {
        [Fact]
        public void LoadAllUserGroupsTestsA()
        {
            ResetTestDatabasev2.Reset();

            ILoadAllUserGroups _loadAllUserGroups = new LoadAllUserGroups();

            var output = _loadAllUserGroups.Load("00782523-7206-403a-b953-75cfa7ccb4e1");

            Assert.NotNull(output);
            Assert.Equal(1, (int)output.Count);
        }

        [Fact]
        public void LoadAllUserGroupsTestsB()
        {
            ResetTestDatabase.Reset();

            ILoadAllUserGroups _loadAllUserGroups = new LoadAllUserGroups();

            var output = _loadAllUserGroups.Load("c4a82913-7936-4448-a9e9-d33e5796a414");

            Assert.NotNull(output);
            Assert.Equal(0, (int)output.Count);
        }
    }
}
