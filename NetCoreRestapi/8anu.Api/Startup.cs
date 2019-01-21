
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag.AspNetCore;
using System.Reflection;
using System.Threading.Tasks;
using NJsonSchema;
using NJsonSchema.Infrastructure;
using _8anu.Api.Common.Runtime.Caching;
using _8anu.Api.Managers.Services;
// using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Hangfire;
using Hangfire.MemoryStorage;

namespace _8anu.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           var sqlConnectionString = Configuration.GetConnectionString("8aConnection");
            var keycloakEndpoint = Configuration.GetSection("AppSettings")["keycloakEndpoint"];
            services.AddMemoryCache();
            services.AddTransient<IObjectCache, ObjectCache>();
            services.AddSingleton<ICacheHandler,CacheHandler>();
            services.AddMvc();
            services.AddApiVersioning();
            
            services.AddHangfire(x => x.UseMemoryStorage());
            
            //services.AddHangfire(config => 
            //    config.uses(Configuration.GetConnectionString("HangfireConnection")));
            
            // tutorial
            // https://medium.com/@michaelmaier_32241/openid-connect-with-net-core-2-jboss-keycloak-3fd83c30564c
            // https://developer.okta.com/blog/2018/03/23/token-authentication-aspnetcore-complete-guide
            
            // endpoints for keycloak
            // https://vlatka.vertical-life.info/auth/realms/Vertical-Life/.well-known/openid-configuration
            services.AddAuthentication(o => {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    // only for testing
                    cfg.RequireHttpsMetadata = true;
                    cfg.Authority = keycloakEndpoint;
                    cfg.IncludeErrorDetails = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidIssuer = keycloakEndpoint,
                        ValidateLifetime = true
                    };

                    cfg.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = c =>
                        {
                            Console.WriteLine("token authentication failed");
                            Console.Write(c.Exception.ToString());
                            c.NoResult();
                            c.Response.StatusCode = 401;
                            c.Response.ContentType = "text/plain";
                            return c.Response.WriteAsync(c.Exception.ToString());
                        },
                        OnTokenValidated = c =>
                        {
                            // access token
                            // https://www.jerriepelser.com/blog/aspnetcore-jwt-saving-bearer-token-as-claim/
                            
                            
                            Console.WriteLine("validated");
                            Console.WriteLine("valid to:" + c.SecurityToken.ValidTo.ToLongTimeString());
                            return Task.CompletedTask;
                        }
                    };
                });
       
                 
            var businessStartup = new Managers.Startup();
            businessStartup.ConfigureServices(services, sqlConnectionString);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });//TODO:CHANGE THIS! https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.1
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAllHeaders"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Test"))
            {
                app.UseDeveloperExceptionPage();

                #region init swagger

                app.UseStaticFiles();
                // Enable the Swagger UI middleware and the Swagger generator

                app.UseAuthentication();
                
                app.UseSwaggerUi3(typeof(Startup).GetTypeInfo().Assembly, settings =>
                {
                    settings.SwaggerRoute = "/api/swagger/v1/swagger.json2";
                    settings.SwaggerUiRoute = "/api/swagger";
                    settings.GeneratorSettings.Title = "8a.nu API";
                    settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;

                    // let's add correct scheme so swagger points to right locations
                    settings.PostProcess = document =>
                    {
                        document.Schemes.Clear();
                        if (!env.IsDevelopment()) 
                        {
                            document.Schemes.Add(NSwag.SwaggerSchema.Https);    
                        }
                        else
                        {
                            document.Schemes.Add(NSwag.SwaggerSchema.Http);  
                        }

                    };
                });

                Debug.WriteLine("see swagger at: /api/swagger");
                
                #endregion init swagger
            }

            // Shows UseCors with CorsPolicyBuilder.
            // TODO: change this!
            // https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.1
            app.UseCors("AllowAllHeaders");
            
            app.UseAuthentication();
            app.UseMvc();

            app.UseHangfireDashboard();
            app.UseHangfireServer();            
            
            Console.WriteLine("start loading cache...");
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                try
                {
                    // todo: change this to hosted service
                    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.1
                    var statisticsService = serviceScope.ServiceProvider.GetService<IStatisticsService>();
                    var elasticService = serviceScope.ServiceProvider.GetService<IElasticService>();

                    // start only if needed
                    if (!elasticService.AreIndexesCreated)
                    {
                        BackgroundJob.Enqueue(() => statisticsService.CreateStatistics());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error loading cache...");
                    Console.Write(ex);
                }
            }
        }
    }
}
