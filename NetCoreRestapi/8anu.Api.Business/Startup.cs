using Microsoft.Extensions.DependencyInjection;
using _8anu.Api.Managers.Interfaces;
using _8anu.Api.Managers.Services;

namespace _8anu.Api.Managers
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, string connectionString)
        {
            var dataStart = new _8anu.Api.Data.Startup();
            dataStart.ConfigureServices(services, connectionString);

            services.AddTransient<ITestModelsManager, TestModelsManager>();
            services.AddTransient<INewsManager, NewsManager>();
            services.AddTransient<ICountriesManager, CountriesManager>();
            services.AddTransient<ICragsManager, CragsManager>();
            services.AddTransient<IUsersManager, UsersManager>();
            services.AddTransient<IForumCategoriesManager, ForumCategoriesManager>();
            services.AddTransient<IForumThreadsManager, ForumThreadsManager>();
            services.AddTransient<IForumCommentsManager, ForumCommentsManager>();
            services.AddTransient<IGradingSystemsManager, GradingSystemsManager>();
            services.AddTransient<IAreasManager, AreasManager>();
            services.AddTransient<ISectorsManager, SectorsManager>();
            services.AddTransient<IRoutesManager, RoutesManager>();
            services.AddTransient<IBouldersManager, BouldersManager>();
            services.AddTransient<IAscentsManager, AscentsManager>();
            services.AddTransient<ICacheManager, CacheManager>();
            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddTransient<IElasticService, ElasticService>();
        }
    }
}
