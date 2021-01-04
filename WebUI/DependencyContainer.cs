using DatabaseModule;
using DatabaseModuleInterface;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI
{
    public class DependencyContainer
    {
        public static void MapDependencies(IServiceCollection services)
        {
            services.AddScoped<ILoadAllUserGroups, LoadAllUserGroups>();
            services.AddScoped<IDeleteGroup, DeleteGroup>();
        }
    }
}
