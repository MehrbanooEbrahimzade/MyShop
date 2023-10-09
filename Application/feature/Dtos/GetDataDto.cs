using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Application.Dtos
{
    public class GetDataDto
    {
        [JsonProperty(propertyName: "status")]
        public int Status { get; set; }

        [JsonProperty(propertyName: "data")]
        public Info Data { get; set; }
    }
    public class Info
    {
        [JsonProperty(propertyName: "products")]
        public List<GetProductsDto> GetProductsDto { get; set; }
    }
}
