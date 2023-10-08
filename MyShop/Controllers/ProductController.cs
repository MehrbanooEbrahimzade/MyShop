using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

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

        [HttpPost("Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            _productService.GetProducts();
            //convert to model
            return Ok();//(models);
        }

        [HttpPost("GetProduct/{id}")]
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
