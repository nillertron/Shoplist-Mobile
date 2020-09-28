using Microsoft.Extensions.DependencyInjection;
using Service;
using ShoplistMobile.AppServices;
using ShoplistMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoplistMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get => new Command(async () => await OnLoginClicked()); }
        private string _id = string.Empty;
        public string Id { get => _id; set { _id = value; OnPropertyChanged("Id"); } }
        private readonly IGroceryListApi groceryListApi;
        private readonly IStoredPropertiesService storedPropertiesService;
        public LoginViewModel(IGroceryListApi groceryListApi, IStoredPropertiesService storedPropertiesService)
        {
            this.groceryListApi = groceryListApi;
            this.storedPropertiesService = storedPropertiesService;
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                if (await CheckForLoginProperty())
                    await NavigateToApp();
            });
        }
        private async Task NavigateToApp()
        {

            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(async() =>
            {
                App.Current.MainPage = new AppShell();
               
                await Shell.Current.GoToAsync($"GroceryList");
                await Shell.Current.Navigation.PopToRootAsync();
            });

        }
        private async Task OnLoginClicked()
        {
            try
            {
                var list = await groceryListApi.GetListFromId(Convert.ToInt32(Id));
                await storedPropertiesService.SaveProperty("ListId",list.Id.ToString());
                await NavigateToApp();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        private async Task<bool> CheckForLoginProperty()
        {
            try
            {
                var obj = await storedPropertiesService.GetProperty("ListId");
                return true;

            }
            catch(Exception ex)
            {
                
                return false;
            }
        }
    }
}
