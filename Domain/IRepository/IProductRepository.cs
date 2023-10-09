using Domain.Models;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IProductRepository
    {
        public Task<Product> GetProductById(int productId);
    }
}
