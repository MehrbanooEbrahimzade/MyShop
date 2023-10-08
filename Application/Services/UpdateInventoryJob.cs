using Application.Dtos;
using Quartz;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services
{
    //public class UpdateInventoryJob : IJob
    //{
    //    public async Task Execute(IJobExecutionContext context)
    //    {
    //        //getallcarts data
    //        //check exist our product 
    //        var url = "https://api.digikala.com/v1/search/?q=keyword&page=1";
    //        var client = new RestClient(url);
    //        var request = new RestRequest();
    //        var response = await client.GetAsync(request);

    //        if (response.StatusCode != HttpStatusCode.OK)
    //            throw new Exception($"Get data from the external client {url} dosent work!");

    //        var data = JsonSerializer.Deserialize<GetDataDto>(response.Content);
            
    //        //check cart inventories


    //    }
    //}
}
