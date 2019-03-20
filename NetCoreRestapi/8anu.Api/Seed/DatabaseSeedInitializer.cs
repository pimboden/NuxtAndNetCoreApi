﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace _8anu.Api.Seed
{
    public static class DatabaseSeedInitializer
    {
        public static IWebHost Seed(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                try
                {
                    var dataseed = new DataSeeder();
                    dataseed.Seed(serviceProvider);
                }
                catch (Exception ex)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            return host;
        }
    }
}
