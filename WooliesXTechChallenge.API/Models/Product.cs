using System;
using System.Text.Json.Serialization;

namespace WooliesXTechChallenge.API.Models
{
    public class Product: IEquatable<Product>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Product);
        }

        public bool Equals(Product obj) {
            return obj != null && obj.Name == Name
                && obj.Price == Price
                && obj.Quantity == Quantity;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
