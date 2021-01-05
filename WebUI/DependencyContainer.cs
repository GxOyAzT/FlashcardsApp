using DatabaseModule;
using DatabaseModuleInterface;
using Microsoft.Extensions.DependencyInjection;
using Processor;

namespace WebUI
{
    public class DependencyContainer
    {
        public static void MapDependencies(IServiceCollection services)
        {
            services.AddScoped<ILoadAllUserGroups, LoadAllUserGroups>();
            services.AddScoped<IDeleteGroup, DeleteGroup>();
            services.AddScoped<IInsertNewGroup, InsertNewGroup>();
            services.AddScoped<IValidateGroupModel, ValidateGroupModel>();
            services.AddScoped<IValidateGroupName, ValidateGroupName>();
            services.AddScoped<IValidateGroupDescription, ValidateGroupDescription>();
            services.AddScoped<ICreateNewGroup, CreateNewGroup>();
            services.AddScoped<ICheckIfGroupIdIsUnique, CheckIfGroupIdIsUnique>();
            services.AddScoped<ICheckIfUserOwnGroup, CheckIfUserOwnGroup>();
            services.AddScoped<ILoadFlashcardsWhereGroupId, LoadFlashcardsWhereGroupId>();
        }
    }
}
