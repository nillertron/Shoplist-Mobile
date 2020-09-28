using Domain;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GroceryListApi : IGroceryListApi
    {
        public async Task<GroceryList> GetListFromId(int id)
        {
            var client = new RestClient("http://shopapi.nillertron.com");
            var request = new RestRequest("grocerylist/getsingle", Method.GET);
            request.AddParameter("id", id);
            var response = await client.ExecuteAsync(request);
            var obj = JsonConvert.DeserializeObject<GroceryList>(response.Content);
            return obj;
        }
    }
}
