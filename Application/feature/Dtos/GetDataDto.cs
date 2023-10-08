using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class GetDataDto
    {
        [JsonPropertyName(name: "status")]
        public int Status { get; set; }

        [JsonPropertyName(name: "data")]
        public Info Data { get; set; }
    }
    public class Info
    {
        [JsonPropertyName(name: "products")]
        public List<GetProductsDto> GetProductsDto { get; set; }
    }
}
