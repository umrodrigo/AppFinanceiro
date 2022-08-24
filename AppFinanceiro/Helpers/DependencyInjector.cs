using Financ.Api.ViewModel;
using Financ.Api.ViewModel.Interface;
using Financ.Api.Security;
using Financ.Api.Services.Cryptography;
using Financ.Data;

namespace Financ.Api.Helpers
{
    public static class Injector
    {
        private static IServiceProvider ServiceProvider { get; set; }
        private static IServiceCollection Services { get; set; }
        public static T GetService<T>()
        {
            Services = Services ?? RegisterServices();
            ServiceProvider = ServiceProvider ?? Services.BuildServiceProvider();
            return ServiceProvider.GetService<T>();
        }

        public static FinancContext GetDbContext()
        {
            return GetService<FinancContext>();
        }

        public static IServiceCollection RegisterServices()
        {
            return RegisterServices(new ServiceCollection());
        }

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ICryptoManager, CryptoManager>();
            services.AddSingleton<IJsonWebToken, JsonWebToken>();

            services.AddScoped<IAuthentication, Authentication>();

            services.AddScoped<IUserViewModel, UserViewModel>();

            Services = services;
            return services;
        }
    }
}
