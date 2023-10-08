using Application.Dtos;
using Application.Feture.Command;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICartService
    {
        public Task<int> AddCartAsync(AddCartCommand command);
        public Task AddItemToCartAsync(AddItemToCartCommand command);
    }
}
