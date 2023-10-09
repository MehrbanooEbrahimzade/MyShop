using Domain.Models;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ICartRepository
    {
        public Task<Cart> GetCartById(int cartId);
        public Task<Cart> GetCartByUserId(int userId);
        public int CreateCart(Cart cart);
        public Task AddProductToCart(int cartId, Product product);
        public Task RemoveProductFromCart(int cartId, int productId);
        public Task SaveAsync();
    }
}
