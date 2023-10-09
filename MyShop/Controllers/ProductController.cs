using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.IServices;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok( await _productService.GetProducts());
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            //if (!command.Validate())//fluentvalidation
            //{
            //    return BadRequest("WrongCartInformation");
            //}

            //request to get
            return Ok();
        }
        //and get by Url


    }
}
