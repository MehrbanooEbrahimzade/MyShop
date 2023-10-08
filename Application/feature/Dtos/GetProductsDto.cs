using Domain.Models;
using System.Text.Json.Serialization;

namespace Application.Dtos
{
    public class GetProductsDto
    {
        [JsonPropertyName(name: "id")]
        public int Id { get;  set; }

        [JsonPropertyName(name: "title_fa")]
        public string FaName { get;  set; }

        [JsonPropertyName(name: "title_en")]
        public string EnName { get;  set; }

        [JsonPropertyName(name: "default_variant")]
        public DefaultVariant DefaultVariant { get; set; } = new DefaultVariant();
    }
    public class DefaultVariant
    {
        [JsonPropertyName(name: "price")]
        public PriceDto Price { get; set; }

        [JsonPropertyName(name: "seller")]
        public SellerDto Seller { get; set; }
    }

    public class SellerDto
    {
        [JsonPropertyName(name: "id")]
        public int Id { get; set; }

        [JsonPropertyName(name: "title")]
        public string Title { get; set; }
    }

    public class PriceDto
    {
        [JsonPropertyName(name: "selling_price")]
        public decimal SellingPrice { get; set; }
    }
}
