using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class Container
    {
        public static void ConfigueServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IGroceryListApi), typeof(GroceryListApi));
            services.AddSingleton(typeof(IItemApi), typeof(ItemApi));
        }

    }
}
