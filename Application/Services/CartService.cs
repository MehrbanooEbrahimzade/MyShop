using Application.Dtos;
using Application.Feture.Command;
using Application.IServices;
using Domain.IRepository;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository, IItemRepository itemRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<int> AddCartAsync(AddCartCommand command)
        {
            //one cart pre user flow
            var cart = await _cartRepository.GetCartByUserId(command.UserId);
            if(cart is null)
                return await _cartRepository.CreateCartByUserId(command.UserId);
            else
            {
                //return await _cartRepository.CheckInventoryOfProducts(command.UserId);
            }
            return cart.Id;
        }

        public async Task AddItemToCartAsync(AddItemToCartCommand command)
        {
            var item = await _itemRepository.GetItemById(command.ItemId);
            if (item is null)
                throw new NullReferenceException("good error text:D");
            //CheckAvalible;

            var cart = await _cartRepository.GetCartById(command.CartId);
            if (cart is null)
                throw new NullReferenceException("good error text:D");

            await _cartRepository.AddItemToCart(cart,item);
            //cart check
            //additemtocart
            //check again if source doesn't have it?
        }

        public async Task ConfirmCart(int cartId)//after pay result
        {
            var cart = await _cartRepository.GetCartByUserId(cartId);
            if (cart is null)
                throw new NullReferenceException($"Cart with id {cartId} doesn't exist!");
            //ChangeStatusToFulfilled
            //add log

        }


    }
}
