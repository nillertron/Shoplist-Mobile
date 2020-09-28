using Domain;
using System.Threading.Tasks;

namespace Service
{
    public interface IGroceryListApi
    {
        Task<GroceryList> GetListFromId(int id);
    }
}