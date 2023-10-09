using System.Collections.Generic;
using Application.Convertor;
using Newtonsoft.Json;

namespace Application.Dtos
{
    public class GetProductsDto
    {
        [JsonProperty(propertyName: "id")] 
        public int Id { get; set; }

        [JsonProperty(propertyName: "title_fa")]
        public string FaName { get; set; }

        [JsonProperty(propertyName: "title_en")]
        public string EnName { get; set; }

        [JsonProperty(propertyName: "status")]
        public string Status { get; set; }

        [JsonProperty(propertyName: "url")]
        public UrlInfo UrlInfo { get; set; }

        [JsonProperty(propertyName: "default_variant")]
        [JsonConverter(typeof(SingleOrArrayConverter<DefaultVariant>))]
        public List<DefaultVariant> DefaultVariant { get; set; } = new List<DefaultVariant>();

    }

    public class SellerDto
    {
        [JsonProperty(propertyName: "id")]
        public int Id { get; set; }

        [JsonProperty(propertyName: "title")]
        public string Title { get; set; }
    }

    public class PriceDto
    {
        [JsonProperty(propertyName: "selling_price")]
        public decimal SellingPrice { get; set; } = 0;
    }
}
