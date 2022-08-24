using AutoMapper;

namespace Financ.Api.Services.Log
{
    public static class LogDependencyInjectionExtensions
    {
        public static IServiceCollection AddLogService(this IServiceCollection services, LogSettings conf, Profile mapperProfile = null)
        {
            services.AddSingleton(conf);
            services.AddSingleton<ILogRepository, LogRepository>();

            services.AddScoped<ILog, LogService>();

            MapperConfiguration mapperConfig;

            if (mapperProfile != null)
                mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(mapperProfile);
                });
            else
                mapperConfig = new MapperConfiguration(cfg => { });

            services.AddSingleton(new LogMapper(mapperConfig.CreateMapper()));

            return services;
        }

        public class LogSettings
        {
            public string URIconnection { get; set; }
            public string Database { get; set; }
            public string CollectionActionLog { get; set; }
        }
    }
}
