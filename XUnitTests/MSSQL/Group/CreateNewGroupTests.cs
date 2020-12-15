using DatabaseModule;
using Processor;
using Xunit;

namespace XUnitTests.MSSQL
{
    [Collection("Sequential")]
    public class CreateNewGroupTests
    {
        [Fact]
        public void CreateNewGroupTestA()
        {
            ResetTestDatabasev2.Reset();
             
            ICreateNewGroup _processor = new CreateNewGroup(
                new ValidateGroupModel(
                    new ValidateGroupName(), new ValidateGroupDescription()), 
                new InsertNewGroup(), 
                new CheckIfGroupIdIsUnique());

            string userId = "9dc52762-daca-44ef-a827-893986645529";
            string groupName = "Asdf1225 144";
            string description = "Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_";

            Assert.True(_processor.Create(groupName, description, userId));
            Assert.Empty(_processor.GetUserMessages());
        }

        [Fact]
        public void CreateNewGroupTestB()
        {
            ResetTestDatabasev2.Reset();

            ICreateNewGroup _processor = new CreateNewGroup(
                new ValidateGroupModel(
                    new ValidateGroupName(), new ValidateGroupDescription()),
                new InsertNewGroup(),
                new CheckIfGroupIdIsUnique());

            string userId = "9dc52762-daca-44ef-a827-893986645529";
            string groupName = "Asdf1225 144";
            string description = "Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_";

            Assert.False(_processor.Create(groupName, description, userId));
            Assert.Contains("Description cannot be longer then 200 characters.", _processor.GetUserMessages());
            Assert.Single(_processor.GetUserMessages());
        }

        [Fact]
        public void CreateNewGroupTestC()
        {
            ResetTestDatabasev2.Reset();

            ICreateNewGroup _processor = new CreateNewGroup(
                new ValidateGroupModel(
                    new ValidateGroupName(), new ValidateGroupDescription()),
                new InsertNewGroup(),
                new CheckIfGroupIdIsUnique());

            string userId = "9dc52762-daca-44ef-a827-893986645529";
            string groupName = "Asdf1225 144.";
            string description = "Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_Sanfwpefjw qafdjpeiwqkf.,-=+/*-+,@#$%^&*()_";

            Assert.False(_processor.Create(groupName, description, userId));
            Assert.Contains("Description cannot be longer then 200 characters.", _processor.GetUserMessages());
            Assert.Contains("Group name can contain only letters, numbers or spaces.", _processor.GetUserMessages());
        }
    }
}
