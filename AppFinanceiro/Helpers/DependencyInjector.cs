using Financ.API.ViewModel;
using Financ.API.ViewModel.Interface;
using Financ.Data;

namespace Financ.API.Helpers
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
            services.AddScoped<IUserViewModel, UserViewModel>();

            Services = services;
            return services;
        }
    }
}
