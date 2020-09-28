using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShoplistMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<Item> ItemList { get; set; }
        public AboutViewModel()
        {
            Title = "About";
        }
        public async Task SetItemCollection(List<Item> list)
        {
            ItemList = new ObservableCollection<Item>(list);
        }
    }
}