using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesXTechChallenge.API.Models;

namespace WooliesXTechChallenge.API.Services
{
    public class ProductService: IProductService
    {
        private readonly IExternalService _externalService;

        public ProductService(IExternalService externalService) {
            _externalService = externalService;
        }

        /// <summary>
        /// Sorts product list based on the sorting option provided
        /// </summary>
        /// <param name="sortOption">
        /// "Low" - Low to High Price
        /// "High" - High to Low Price
        /// "Ascending" - A - Z sort on the Name
        /// "Descending" - Z - A sort on the Name
        /// "Recommended" - this will call the "shopperHistory" resource to get a list of customers orders and needs to return based on popularity
        /// </param>
        /// <returns>Sorted list of products</returns>
        public async Task<List<Product>> GetSortedProducts(string sortOption) {

            var products = await _externalService.GetProducts();
            
            if (products == null || products.Count == 0)
                return products;

            switch (sortOption)
            {
                case SortOptions.Low:
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case SortOptions.High:
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                case SortOptions.Ascending:
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
                case SortOptions.Descending:
                    products = products.OrderByDescending(p => p.Name).ToList();
                    break;
                case SortOptions.Recommended:
                    products = await this.GetRecommendedSortedProducts(products);
                    break;
                default:
                    break;
            }

            return products;
        }

        /// <summary>
        /// This method will call the "shopperHistory" resource to get a list of customers orders and will return products based on popularity
        /// </summary>
        /// <returns>Sorted product list based on popularity</returns>
        public async Task<List<Product>> GetRecommendedSortedProducts(List<Product> productList)
        {
            var shopperHistoryList = await _externalService.GetShopperHistory();
            var productDictionary = new Dictionary<string, Product>();

            //Sum quantities per product
            foreach (var history in shopperHistoryList) {
                foreach (var product in history.Products) {
                    if (productDictionary.ContainsKey(product.Name))
                        productDictionary[product.Name].Quantity += product.Quantity;
                    else
                        productDictionary.Add(product.Name, product);
                }
            }
            //Order products by quantity descending.
            var updatedProductList = productDictionary.Values.ToList();
            var orderedProductList = updatedProductList.OrderByDescending(p => p.Quantity).ToList();

            //Add remaining products that were not part of the shopping history
            foreach (var product in productList)
            {
                if (!productDictionary.ContainsKey(product.Name))                
                    orderedProductList.Add(product);                
            }

            return orderedProductList;
        }

        /// <summary>
        /// This method will return the lowest possible total based on provided lists of prices, specials and quantities.
        /// </summary>
        /// <param name="trolleyData">Trolley data for calculation</param>
        /// <returns>Lowest trolley total</returns>
        public async Task<decimal> GetLowestTrolleyTotal(TrolleyDataDTO trolleyData) {
            return await _externalService.GetTrolleyTotal(trolleyData);
        }
    }
}
