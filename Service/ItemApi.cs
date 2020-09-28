using Domain;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ItemApi : IItemApi
    {
        public async Task DeleteItem(Item item)
        {
            var client = new RestClient("http://shopapi.nillertron.com");
            var request = new RestRequest("item/delete", Method.DELETE);
            request.AddParameter("id", item.Id);
            var response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<string>(response.Content);
            if (result != "Deleted")
                throw new Exception(result);
        }
        public async Task CreateItem(Item item)
        {
            var client = new RestClient("http://shopapi.nillertron.com");
            var request = new RestRequest("item/create", Method.POST);
            var serialiseret = JsonConvert.SerializeObject(item);
            request.AddParameter("application/json; charset=utf-8", serialiseret, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
           var returnitem = JsonConvert.DeserializeObject<Item>(response.Content);
            item.Id = returnitem.Id;
        }
    }
}
