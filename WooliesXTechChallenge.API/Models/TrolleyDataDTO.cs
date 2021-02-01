using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WooliesXTechChallenge.API.Models
{
    public class TrolleyDataDTO
    {
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }

        [JsonPropertyName("specials")]
        public List<Special> Specials { get; set; }

        [JsonPropertyName("quantities")]
        public List<Product> Quantities { get; set; }
    }
}
