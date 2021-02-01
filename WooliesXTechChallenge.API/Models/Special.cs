using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WooliesXTechChallenge.API.Models
{
    public class Special
    {
        [JsonPropertyName("quantities")]
        public List<Product> Quantities { get; set; }

        [JsonPropertyName("total")]
        public decimal Total { get; set; }
    }
}
