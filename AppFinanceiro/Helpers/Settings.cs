using Financ.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

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
                    .EnableDetailedErrors(isDev)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }

        public static void AddServices(this IServiceCollection services)
        {
            Injector.RegisterServices(services);
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    builder =>
                    {
                        if(env.IsProduction())
                        builder
                            .WithOrigins(configuration.GetValue<string>("cors").Split(','))
                            .SetPreflightMaxAge(System.TimeSpan.FromDays(1))
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .AllowAnyHeader();
                        else
                            builder
                                .SetIsOriginAllowed((host) => true)
                                .SetPreflightMaxAge(System.TimeSpan.FromDays(1))
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .AllowAnyHeader();
                    });
            });
            return services;
        }

    }
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString(), styles: System.Globalization.DateTimeStyles.AdjustToUniversal);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"));
        }
    }
}
