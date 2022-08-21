using Financ.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Financ.API.Helpers
{
    public static class Settings
    {
        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<BearerTokenConf>(configuration.GetSection(nameof(BearerTokenConf)));

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration, bool isDev = true)
        {
            services.AddDbContextPool<FinancContext>(options =>
            {
                options
                    .UseSqlServer(configuration.GetConnectionString(nameof(FinancContext)), x => x.EnableRetryOnFailure())
                    .ConfigureWarnings(x => x.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning))
                    .EnableSensitiveDataLogging(isDev)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }

        public static void AddServices(this IServiceCollection services)
        {
            Injector.RegisterServices(services);
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    builder =>
                    {
                        //if(env.IsProduction())
                        builder
                            .WithOrigins(configuration.GetValue<string>("cors").Split(','))
                            .SetPreflightMaxAge(System.TimeSpan.FromDays(1))
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .AllowAnyHeader();
                        //else
                        //builder
                        //    .SetIsOriginAllowed((host) => true)
                        //    .SetPreflightMaxAge(System.TimeSpan.FromDays(1))
                        //    .AllowAnyMethod()
                        //    .AllowCredentials()
                        //    .AllowAnyHeader();
                    });
            });
            return services;
        }
    }
}
