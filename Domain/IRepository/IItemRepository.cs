using System.Threading.Tasks;
using Domain.Models;

namespace Domain.IRepository
{
    public interface IItemRepository
    {
        public Task<CartItem> GetItemById(int ItemId);

    }
}
