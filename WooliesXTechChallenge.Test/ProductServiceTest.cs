using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesXTechChallenge.API.Models;
using WooliesXTechChallenge.API.Services;

namespace WooliesXTechChallenge.Test
{
    [TestClass]
    public class ProductServiceTest
    {
        /// <summary>
        /// This method will test the SortProducts method and will run multiple times against data provided by GetSortProductsData method. 
        /// The data will be provided dynamically which will contain sorting options Low, High, Ascending, Descending, Invalid value and Empty value
        /// </summary>        
        [DataTestMethod]
        [DynamicData(nameof(GetSortProductsData), DynamicDataSourceType.Method)]
        public async Task TestSortProducts(List<Product> fakeProducts, string sortOption, List<Product> expectedResult)
        {
            //Arrange
            var externalServiceMock = new Mock<IExternalService>();
            externalServiceMock.Setup(x => x.GetProducts()).ReturnsAsync(fakeProducts);

            //Act
            var productService = new ProductService(externalServiceMock.Object);
            var sortedProducts = await productService.GetSortedProducts(sortOption);

            //Assert
            CollectionAssert.AreEqual(sortedProducts, expectedResult);
        }

        /// This method will test the sort product recommended method and will run multiple times against data provided by GetSortProductsRecommendedData method. 
        /// The data will be provided dynamically which will contain scenarios where 1) all products will be in the shopping history and 2) some additional products 
        /// that will not be in the shopping history.
        /// </summary>        
        [DataTestMethod]
        [DynamicData(nameof(GetSortProductsRecommendedData), DynamicDataSourceType.Method)]
        public async Task TestSortProducts_Recommended(List<Product> fakeProducts, List<ShopperHistory> fakeShopperHistory, List<Product> expectedResult)
        {
            //Arrange
            var externalServiceMock = new Mock<IExternalService>();
            externalServiceMock.Setup(x => x.GetProducts()).ReturnsAsync(fakeProducts);
            externalServiceMock.Setup(x => x.GetShopperHistory()).ReturnsAsync(fakeShopperHistory);

            //Act
            var productService = new ProductService(externalServiceMock.Object);
            var sortedProducts = await productService.GetSortedProducts("Recommended");
            
            //Assert
            CollectionAssert.AreEqual(sortedProducts, expectedResult);
        }

        /// <summary>
        /// This method will test the GetLowestTrolleyTotal method and will run multiple times against data provided by GetTrolleyTotalData method. 
        /// The data will be provided dynamically.
        /// </summary>        
        //[DataTestMethod]
        //[DynamicData(nameof(GetTrolleyTotalData), DynamicDataSourceType.Method)]
        //public async Task TestGetTrolleyTotal(TrolleyDataDTO fakeTrolleyData, decimal expectedResult)
        //{
        //    //Arrange
        //    var externalServiceMock = new Mock<IExternalService>();            

        //    //Act
        //    var productService = new ProductService(externalServiceMock.Object);
        //    var trolleyTotal = await productService.GetLowestTrolleyTotal(fakeTrolleyData);

        //    //Assert
        //    Assert.AreEqual(trolleyTotal, expectedResult);
        //}

        #region Test Data Methods

        /// <summary>
        /// This method provides the test data for TestSortProducts method of this class
        /// </summary>        
        public static IEnumerable<object[]> GetSortProductsData()
        {
            //Low to high
            yield return new object[] { TestDataProvider.GetFakeProducts(), "Low", TestDataProvider.GetSortedProductsLowToHigh() };

            //High to low
            yield return new object[] { TestDataProvider.GetFakeProducts(), "High", TestDataProvider.GetSortedProductsHighToLow() };

            //Ascending
            yield return new object[] { TestDataProvider.GetFakeProducts(), "Ascending", TestDataProvider.GetSortedProductsAscending() };

            //Descending
            yield return new object[] { TestDataProvider.GetFakeProducts(), "Descending", TestDataProvider.GetSortedProductsDescending() };

            //Invalid sort Option that will return the products as it is.
            yield return new object[] { TestDataProvider.GetFakeProducts(), "Descending6767", TestDataProvider.GetFakeProducts() };

            //Empty sort Option that will return the products as it is.
            yield return new object[] { TestDataProvider.GetFakeProducts(), "", TestDataProvider.GetFakeProducts() };
        }

        /// <summary>
        /// This method provides the test data for TestSortProducts_Recommended method of this class
        /// </summary>
        public static IEnumerable<object[]> GetSortProductsRecommendedData()
        {
            //Sorting based on popularity when all products are in shopping history
            yield return new object[] { TestDataProvider.GetFakeProducts(), TestDataProvider.GetFakeShopperHistory(), TestDataProvider.GetSortedProductsByPopularity() };

            //Sorting based on popularity when all products are NOT in shopping history
            yield return new object[] { TestDataProvider.GetFakeProducts(), TestDataProvider.GetFakeShopperHistory2(), TestDataProvider.GetSortedProductsByPopularity2() };
        }

        /// <summary>
        /// This method provides the test data for TestGetTrolleyTotal method of this class
        /// </summary>
        public static IEnumerable<object[]> GetTrolleyTotalData()
        {
            yield return new object[] { TestDataProvider.GetFakeTrolleyData1(), 22.5M };
            yield return new object[] { TestDataProvider.GetFakeTrolleyData2(), 21M };
        }

        #endregion
    }
}
