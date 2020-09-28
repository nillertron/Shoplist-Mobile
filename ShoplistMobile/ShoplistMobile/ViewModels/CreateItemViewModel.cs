using Domain;
using Service;
using ShoplistMobile.AppServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoplistMobile.ViewModels
{
    class CreateItemViewModel:BaseViewModel
    {
        private string _item = string.Empty;
        public string Item { get => _item; set { _item = value; OnPropertyChanged("Item"); } }
        public ICommand CreateCommand { get => new Command(async () => await CreateItem()); }
        private readonly IItemApi itemApi;
        private readonly IStoredPropertiesService storedPropertiesService;
        private int? listId;
        public CreateItemViewModel()
        {
            Title = "Create";
            itemApi = new ItemApi();
            storedPropertiesService = new StoredPropertiesService();
        }
        private async Task CreateItem()
        {

            try
            {
                await GetListId();
                var item = new Item { GroceryListId = (int)listId, Name = Item };
                await itemApi.CreateItem(item);
                MessagingCenter.Send<CreateItemViewModel, Item>(this, "New",item);
                Item = string.Empty;

            }
            catch (Exception ex)
            {

              await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        private async Task GetListId()
        {
            if(listId == null)
            {
                listId = Convert.ToInt32(await storedPropertiesService.GetProperty("ListId"));
            }
        }
    }
}
