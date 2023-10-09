using Application.Dtos;
using Application.IServices;
using Domain.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var url = "https://api.digikala.com/v1/search/?q=keyword&page=1";
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = await client.GetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Get data from the external client {url} doesn't work!");

            var data = JsonSerializer.Deserialize<GetDataDto>(response.Content);
            var products = data.Data.GetProductsDto.Select(x => _mapper.Map<Product>(x)).ToList();
            return products;
        }

    }
}
