using System;
using System.Collections.Generic;
using ShoplistMobile.ViewModels;
using ShoplistMobile.Views;
using Xamarin.Forms;

namespace ShoplistMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("GroceryList", typeof(GroceryList));
            Routing.RegisterRoute("CreateItem", typeof(CreateItem));

        }

    }
}
