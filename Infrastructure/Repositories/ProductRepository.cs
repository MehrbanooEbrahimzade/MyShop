using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Database _database;
        public ProductRepository(Database database)
        {
            _database = database;
        }

        Task IProductRepository.UpdateAll(List<Product> products)
        {
            throw new System.NotImplementedException();
        }
    }
}
