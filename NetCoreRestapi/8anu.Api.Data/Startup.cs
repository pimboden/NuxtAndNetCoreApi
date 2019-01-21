using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories;
using _8anu.Api.Data.Repositories.Interfaces;

namespace _8anu.Api.Data
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, string sqlConnectionString)
        {
            services.AddDbContext<DomainModelMySqlContext>(options =>
                options.UseMySql(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("8anu.Api")
                )
            );
            services.AddTransient<ICountriesRepository, CountriesRepository>();
            services.AddTransient<ICragsRepository, CragsRepository>();
            services.AddTransient<ITestModelsRepository, TestModelsRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IForumCategoriesRepository, ForumCategoriesRepository>();
            services.AddTransient<IForumThreadsRepository, ForumThreadsRepository>();
            services.AddTransient<IForumCommentsRepository, ForumCommentsRepository>();
            services.AddTransient<IGradingSystemsRepository, GradingSystemsRepository>();
            services.AddTransient<IAreasRepository, AreasRepository>();
            services.AddTransient<ISectorsRepository, SectorsRepository>();
            services.AddTransient<IRoutesRepository, RoutesRepository>();
            services.AddTransient<IBouldersRepository, BouldersRepository>();
            services.AddTransient<IAscentsRepository, AscentsRepository>();
        }
    }
}
