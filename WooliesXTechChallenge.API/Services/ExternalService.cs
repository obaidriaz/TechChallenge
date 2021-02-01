using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WooliesXTechChallenge.API.Models;

namespace WooliesXTechChallenge.API.Services
{
    public class ExternalService: IExternalService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        private const string productsApiUrl = "api/resource/products";
        private const string shopperHistoryApiUrl = "api/resource/shopperHistory";
        private const string trolleyCalculatorApiUrl = "api/resource/trolleyCalculator";
        private const string baseURLConfigKey = "AppSettings:WooliesXAPIBaseUrl";

        public ExternalService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Product>> GetProducts()
        {
            var uri = GetUri(productsApiUrl);
            var response = await _httpClient.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<Product>>(responseString);

            return products;
        }

        public async Task<List<ShopperHistory>> GetShopperHistory()
        {
            var uri = GetUri(shopperHistoryApiUrl);
            var response = await _httpClient.GetAsync(uri);
            
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var shopperHistory = JsonSerializer.Deserialize<List<ShopperHistory>>(responseString);

            return shopperHistory;
        }        

        public async Task<decimal> GetTrolleyTotal(TrolleyDataDTO trolleyData)
        {
            var uri = GetUri(trolleyCalculatorApiUrl);
            var trolleyDataContent = new StringContent(JsonSerializer.Serialize(trolleyData), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, trolleyDataContent);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var trolleyTotal = JsonSerializer.Deserialize<decimal>(responseString);

            return trolleyTotal;
        }

        private string GetUri(string path)
        {
            return QueryHelpers.AddQueryString($"{_configuration.GetValue<string>(baseURLConfigKey)}{path}", "token", Constants.Token);
        }
    }
}

