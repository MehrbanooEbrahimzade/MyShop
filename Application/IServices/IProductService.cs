using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.IServices
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<IEnumerable<Product>> GetProductsByName(string name);
    }
}
