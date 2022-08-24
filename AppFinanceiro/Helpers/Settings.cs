using Financ.Api.Models;
using Financ.Api.Security;
using Financ.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Financ.Api.Helpers
{
    public static class Settings
    {
        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BearerTokenConf>(configuration.GetSection(nameof(BearerTokenConf)));

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

        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var bearerConf = configuration.GetSection(nameof(BearerTokenConf)).Get<BearerTokenConf>();
            var sigBearer = new BearerSigning(bearerConf.Key, bearerConf.Issuer, bearerConf.Audiences);
            services.AddSingleton(sigBearer);

            var passportConf = configuration.GetSection(nameof(PassportTokenConf)).Get<PassportTokenConf>();
            var sigPassport = new PassportSigning(passportConf.Key, passportConf.Issuer, passportConf.Audiences.Split(','));
            services.AddSingleton(sigPassport);

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = AuthSchemas.Bearer;
                o.DefaultChallengeScheme = AuthSchemas.Bearer;
            })
            .AddJwtBearer(AuthSchemas.Bearer, jwtBearer =>
            {
                jwtBearer.RequireHttpsMetadata = true;
                jwtBearer.SaveToken = true;
                jwtBearer.TokenValidationParameters = sigBearer.TokenValidation;
            })
            .AddJwtBearer(AuthSchemas.Passport, jwtBearer =>
            {
                jwtBearer.RequireHttpsMetadata = true;
                jwtBearer.SaveToken = true;
                jwtBearer.TokenValidationParameters = sigPassport.TokenValidation;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy(AuthSchemas.Bearer, new AuthorizationPolicyBuilder(AuthSchemas.Bearer)
                    .RequireAuthenticatedUser()
                    .Build());

                auth.AddPolicy(AuthSchemas.Passport, new AuthorizationPolicyBuilder(AuthSchemas.Passport)
                    .RequireAuthenticatedUser()
                    .Build());
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
