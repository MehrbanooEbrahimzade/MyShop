using Domain.IRepository;
using Domain.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using RestSharp;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Product> GetProductById(int productId)
        {
            var url = "https://api.digikala.com/v1/search/?q=keyword&page=1";
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = await client.GetAsync(request);
            //متوجه نشدم چطور باید از کوئری خود url استفاده کنم
            //توی پروداکت هم ادرس داره ولی 404 میداد
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Get data from the external client {url} doesn't work!");

            var data = JsonConvert.DeserializeObject<GetDataDto>(response.Content);
            var productDto = data.Data.GetProductsDto.SingleOrDefault(x => x.Id == productId);
           return _mapper.Map<Product>(productDto);
        }
    }
}
