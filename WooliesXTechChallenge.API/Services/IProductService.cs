using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesXTechChallenge.API.Models;

namespace WooliesXTechChallenge.API.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetSortedProducts(string sortOption);
        Task<List<Product>> GetRecommendedSortedProducts(List<Product> productList);
        Task<decimal> GetLowestTrolleyTotal(TrolleyDataDTO trolleyData);
    }
}
