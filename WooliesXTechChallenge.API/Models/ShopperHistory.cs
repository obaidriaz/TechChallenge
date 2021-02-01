using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WooliesXTechChallenge.API.Models
{
    public class ShopperHistory
    {
        [JsonPropertyName("customerId")]
        public long CustomerId { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}
