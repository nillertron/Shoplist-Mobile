using Domain;
using System.Threading.Tasks;

namespace Service
{
    public interface IItemApi
    {
        Task CreateItem(Item item);
        Task DeleteItem(Item item);
    }
}