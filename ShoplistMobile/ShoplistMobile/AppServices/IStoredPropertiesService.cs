using System.Threading.Tasks;

namespace ShoplistMobile.AppServices
{
    public interface IStoredPropertiesService
    {
        Task DeleteProperty(string key);
        Task<object> GetProperty(string key);
        Task SaveProperty(string key, string value);
    }
}