using System.Text.Json.Serialization;

namespace WooliesXTechChallenge.API.Models
{
    public class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
