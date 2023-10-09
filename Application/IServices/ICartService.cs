using Application.Dtos;
using Application.Feture.Command;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICartService
    {
        public Task<int> AddCartAsync(AddCartCommand command);
        public Task AddProductToCartAsync(AddProductToCartCommand command);
        public Task RemoveProductFromCartAsync(RemoveProductFromCartCommand command);
        public Task<bool> ConfirmCart(int cartId);
        public Task<bool> PayCart(int userId);
    }
}
