using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace ShoplistMobile.Droid
{
    public static class Container
    {
        public static void ConfigureAndroid(this IServiceCollection services)
        {
            services.ConfigureSharedClassLibrary();
            services.ConfigueServices();
        }
    }
}