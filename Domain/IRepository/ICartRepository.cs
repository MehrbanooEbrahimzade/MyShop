using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ICartRepository
    {
        public Task<Cart> GetCartById(int cartId);
        public Task<Cart> GetCartByUserId(int userId);
        public Task<int> CreateCartByUserId(int userId);
        public Task<int> AddItemToCart(Cart cart,CartItem Item);
    }
}
