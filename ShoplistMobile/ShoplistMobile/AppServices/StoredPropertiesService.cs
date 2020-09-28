using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoplistMobile.AppServices
{
    public class StoredPropertiesService : IStoredPropertiesService
    {
        public async Task SaveProperty(string key, string value)
        {
            Application.Current.Properties.Add(key, value);
            await Application.Current.SavePropertiesAsync();
        }
        public async Task<object> GetProperty(string key)
        {
           var prop = App.Current.Properties[key];
            return prop;
        }
        public async Task DeleteProperty(string key)
        {
            App.Current.Properties.Remove(key);
        }
    }
}
