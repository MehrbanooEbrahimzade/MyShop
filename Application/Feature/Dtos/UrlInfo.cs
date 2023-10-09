using Newtonsoft.Json;

namespace Application.Dtos
{
    public class UrlInfo
    {
        [JsonProperty(propertyName: "uri")]
        public string Uri { get; set; }
        
    }
}