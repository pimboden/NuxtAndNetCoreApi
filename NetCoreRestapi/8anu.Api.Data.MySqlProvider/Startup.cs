using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace _8anu.Api.Data.MySqlProvider
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
            )

        }
    }
}
