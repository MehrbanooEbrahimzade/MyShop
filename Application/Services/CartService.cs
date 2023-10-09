using Application.Dtos;
using Application.Feture.Command;
using Application.IServices;
using Domain.IRepository;
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISellLogRepository _sellLogRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository, ISellLogRepository sellLogRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _sellLogRepository = sellLogRepository;
        }

        public async Task<int> AddCartAsync(AddCartCommand command)
        {
            //one cart pre user flow
            var cart = await _cartRepository.GetCartByUserId(command.UserId);

            if (cart is not null) return cart.Id;
            var newCart = new Cart(command.UserId);
            return _cartRepository.CreateCart(newCart);
        }

        public async Task AddProductToCartAsync(AddProductToCartCommand command)
        {
            var product= await _productRepository.GetProductById(command.ProductId);
            if (product is null)
                throw new NullReferenceException($"The product with id {command.ProductId} not found!");

            if (product.Status == ProductStatusType.OutOfStock)
                throw new Exception("The product is out of stock!");

            await _cartRepository.AddProductToCart(command.CartId, product);
        }

        public async Task RemoveProductFromCartAsync(RemoveProductFromCartCommand command)
        {
            var cart = await _cartRepository.GetCartById(command.CartId);

            if (cart.Status != CartStatusType.Pending)
                throw new Exception("You can't edit confirmed cart!");

            var exist = cart.Products.Any(x => x.Id == command.ProductId);
            if (!exist)
                throw new NullReferenceException("The product not found in your cart!");
            await _cartRepository.RemoveProductFromCart(command.CartId, command.ProductId);
        }

        public async Task<bool> PayCart(int userId)
        {
            var cart = await _cartRepository.GetCartByUserId(userId);
            if (cart is null)
                throw new NullReferenceException($"Cart with id {cart.Id} doesn't exist!");
            if (cart.Products.Count == 0)
                throw new ArgumentException("no product to buy!");
            Console.WriteLine("Success");
            cart.ChangeStatus(CartStatusType.Paid);
            
            await _cartRepository.SaveAsync();
            var log = new SellLog(cart.Id, userId);
            _sellLogRepository.CreateLog(log);
            await _cartRepository.SaveAsync();//It's better to use with rollback!
            return true;

        }

        public async Task<bool> ConfirmCart(int cartId)//after pay result
        {
            var cart = await _cartRepository.GetCartById(cartId);
            if (cart is null)
                throw new NullReferenceException($"Cart with id {cartId} doesn't exist!");
            if (cart.Status != CartStatusType.Paid)
                throw new Exception("invalid operation");

            var url = "https://60a0d16ad2855b00173b1351.mockapi.io/orders";
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = await client.PostAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                cart.ChangeStatus(CartStatusType.Fulfilled);
                return true;
            }
            return false;
        }


    }
}
