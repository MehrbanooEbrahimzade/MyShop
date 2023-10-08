using Application.Dtos;
using Application.Feture.Command;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            //if (!command.Validate())//fluentvalidation
            //{
            //    return BadRequest("WrongCartInformation");
            //}
            var cartId = await _cartService.AddCartAsync(command);

            return Ok(cartId);
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItemToCartAsync(AddItemToCartCommand command)
        {
            //if (!command.Validate())//fluentvalidation
            //{
            //    return BadRequest("WrongCartInformation");
            //}

             await _cartService.AddItemToCartAsync(command);
            return Ok();
        }


        [HttpPost("Pay")]
        public async Task<IActionResult> PayAsync( )
        {
            return Ok();
        }

        [HttpPost("Confirm")]
        public async Task<IActionResult> ConfirmCartAsync( )
        {
            //pay if ok
            //send post request to dgkala
            //change cart status
            //add log to database
            return Ok();
        }

    }
}
