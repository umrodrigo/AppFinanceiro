//using Financ.Data;

//namespace Financ.API.Helpers
//{
//    public static class Injector
//    {
//        private static IServiceProvider ServiceProvider { get; set; }
//        private static IServiceCollection Services { get; set; }
//        public static T GetService<T>()
//        {
//            Services = Services ?? RegisterServices();
//            ServiceProvider = ServiceProvider ?? Services.BuildServiceProvider();
//            return ServiceProvider.GetService<T>();
//        }

//        public static FinancContext GetDbContext()
//        {
//            return GetService<FinancContext>();
//        }

//        //private static IServiceCollection RegisterServices()
//        //{
//        //    return RegisterServices(new ServiceCollection());
//        //}

//        //private static IServiceCollection RegisterServices(IServiceCollection service)
//        //{
//        //    IParameters
//        //}
//    }
//}
