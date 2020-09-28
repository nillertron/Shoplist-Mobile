using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoplistMobile.Views;

namespace ShoplistMobile
{
    public partial class App : Application
    {
        public App(LoginPage page)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = page;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
