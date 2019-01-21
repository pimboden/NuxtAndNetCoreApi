using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _8anu.Api.Managers.Services;
using _8anu.Api.Seed;

namespace _8anu.Api
{
    public class Program
    {   
        public static void Main(string[] args)
        {
            Console.WriteLine("start Main");
            
            var host = BuildWebHost(args);

            host.Seed();
            
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }






}
