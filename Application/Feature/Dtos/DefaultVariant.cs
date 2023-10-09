using Newtonsoft.Json;

namespace Application.Dtos
{
    public class DefaultVariant
    {

        [JsonProperty(propertyName: "price")] 
        public PriceDto Price { get; set; } = new PriceDto();
        
    }
}