using Domain;
using Service;
using ShoplistMobile.AppServices;
using ShoplistMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoplistMobile.ViewModels
{
    public class GroceryListViewModel:BaseViewModel
    {
        private ObservableCollection<Item> _itemList;
        public ObservableCollection<Item> ItemList { get =>_itemList; set { _itemList = value; OnPropertyChanged("ItemList"); } }
        private readonly IStoredPropertiesService storedPropertiesService;
        private readonly IGroceryListApi groceryListApi;
        public System.Windows.Input.ICommand DeleteItemCommand { get => new Command(async(o)=> await DeleteItem(o)); }
        private readonly IItemApi itemApi;
        public GroceryListViewModel()
        {
            Title = "List";
            this.storedPropertiesService = new StoredPropertiesService();
            this.groceryListApi = new GroceryListApi();
            this.itemApi = new ItemApi();
            Task.Run(async () => { await SetItemCollection(); });
            MessagingCenter.Subscribe<CreateItemViewModel, Item>(this, "New", async (s,e) =>
            {
                ItemList.Add(e);
            });
        }
        private async Task DeleteItem(object item)
        {
            try
            {
                var itemToDelete = item as Item;
                await itemApi.DeleteItem(itemToDelete);
                ItemList.Remove(itemToDelete);
            }
            catch (Exception ex)
            {
               await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                
            }

        }
        private async Task SetItemCollection()
        {
            try
            {
                var listId = Convert.ToInt32(await storedPropertiesService.GetProperty("ListId"));
                var list = await groceryListApi.GetListFromId(listId);
                ItemList = new ObservableCollection<Item>(list.Items);
            }
            catch (Exception ex)
            {

               
            }

        }
    }
}
