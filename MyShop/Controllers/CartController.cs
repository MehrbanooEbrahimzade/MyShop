using Application.Dtos;
using Application.Feture.Command;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController: ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCartAsync(AddCartCommand command)
        {
            var cartId = await _cartService.AddCartAsync(command);

            return Ok(cartId);
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItemToCartAsync(AddProductToCartCommand command)
        {
            await _cartService.AddProductToCartAsync(command);
            return Ok();
        }

        [HttpPost("RemoveItem")]
        public async Task<IActionResult> RemoveItemFromCartAsync(RemoveProductFromCartCommand command)
        {
            await _cartService.RemoveProductFromCartAsync(command);
            return Ok();
        }


        [HttpPost("Pay")]
        public async Task<IActionResult> PayAsync(PayCartCommand command)
        {
           var success = await _cartService.PayCart(command.UserId);
            return Ok(success);
        }

        [HttpGet("Confirm/{cartId}")]
        public async Task<IActionResult> ConfirmCartAsync(int cartId)
        {
            var success = await _cartService.ConfirmCart(cartId);
            return Ok(success);
        }

    }
}
