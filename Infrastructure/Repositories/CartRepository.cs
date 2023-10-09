using System;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CartRepository: ICartRepository
    {
        private readonly DatabaseContext _context;

        public CartRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
             await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCartById(int cartId)
        {
           return await _context.Carts.Include(x => x.Products).SingleOrDefaultAsync(x=>x.Id ==cartId);
        }

        public async Task<Cart> GetCartByUserId(int userId)
        {
            return await _context.Carts.Include(x=>x.Products).SingleOrDefaultAsync(x => x.UserId == userId);
        }

        public int CreateCart(Cart cart)
        { 
            _context.Carts.Add(cart);
             _context.SaveChanges();
            return cart.Id;
        }

        public async Task AddProductToCart(int cartId, Product product)
        {
            var cart = await _context.Carts.SingleOrDefaultAsync(x => x.Id == cartId);
            if (cart is null)
                throw new NullReferenceException($"Cart with id {cartId} not found!");

            if (cart.Status != CartStatusType.Pending)
                throw new Exception("You can't edit confirmed cart!");
            cart.AddProduct(product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductFromCart(int cartId, int productId)
        {
            var cart = await _context.Carts.SingleOrDefaultAsync(x => x.Id == cartId);
            if (cart is null)
                throw new NullReferenceException($"Cart with id {cartId} not found!");

            cart.RemoveProduct(productId);
            await _context.SaveChangesAsync();
        }
    }
}
