using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ShoplistMobile
{
    public static class Container
    {
        public static void ConfigureSharedClassLibrary(this IServiceCollection services)
        {
            ConfigureViews(services);
            ConfigureViewModels(services);
            ConfigureAppServices(services);
            services.AddTransient(typeof(App));
        }
        private static void ConfigureViews(IServiceCollection services)
        {
            var list = Assembly.Load(nameof(ShoplistMobile)).GetTypes().Where(x => !x.IsNested && x.FullName.Contains("Views")).ToList();
            list.ForEach(x => services.AddTransient(x));
        }
        private static void ConfigureViewModels(IServiceCollection services)
        {
            var list = Assembly.Load(nameof(ShoplistMobile)).GetTypes().Where(x => !x.IsNested && x.FullName.Contains("ViewModel")).ToList();
            list.ForEach(x => services.AddTransient(x));
        }
        private static void ConfigureAppServices(IServiceCollection services)
        {
            var list = Assembly.Load(nameof(ShoplistMobile)).GetTypes().Where(x => !x.IsNested && !x.IsInterface && x.FullName.Contains("AppServices")).ToList();
            list.ForEach(x => services.AddTransient(x.GetInterfaces().First(), x));
        }
    }
}
