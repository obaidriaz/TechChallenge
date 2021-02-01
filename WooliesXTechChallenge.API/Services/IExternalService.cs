using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesXTechChallenge.API.Models;

namespace WooliesXTechChallenge.API.Services
{
    public interface IExternalService
    {
        Task<List<Product>> GetProducts();
        Task<List<ShopperHistory>> GetShopperHistory();
        Task<decimal> GetTrolleyTotal(TrolleyDataDTO trolleyData);
    }
}
