using System.Collections.Generic;
using WooliesXTechChallenge.API.Models;

namespace WooliesXTechChallenge.Test
{
    public static class TestDataProvider
    {
        public static List<Product> GetFakeProducts()
        {
            var productsList = new List<Product>() {
                new Product{ Name = "Product 1", Price = 10.2M, Quantity = 2},
                new Product{ Name = "Product 4", Price = 105.5M, Quantity = 5},
                new Product{ Name = "Product 2", Price = 6.5M, Quantity = 1},
                new Product{ Name = "Product 3", Price = 30.6M, Quantity = 4},
            };

            return productsList;
        }

        public static List<Product> GetSortedProductsLowToHigh()
        {
            var productsList = new List<Product>() {
                new Product{ Name = "Product 2", Price = 6.5M, Quantity = 1},
                new Product{ Name = "Product 1", Price = 10.2M, Quantity = 2},
                new Product{ Name = "Product 3", Price = 30.6M, Quantity = 4},
                new Product{ Name = "Product 4", Price = 105.5M, Quantity = 5}
            };

            return productsList;
        }

        public static List<Product> GetSortedProductsHighToLow()
        {
            var productsList = new List<Product>() {
                new Product{ Name = "Product 4", Price = 105.5M, Quantity = 5},
                new Product{ Name = "Product 3", Price = 30.6M, Quantity = 4},
                new Product{ Name = "Product 1", Price = 10.2M, Quantity = 2},                
                new Product{ Name = "Product 2", Price = 6.5M, Quantity = 1}                
            };

            return productsList;
        }

        public static List<Product> GetSortedProductsAscending()
        {
            var productsList = new List<Product>() {
                new Product{ Name = "Product 1", Price = 10.2M, Quantity = 2},
                new Product{ Name = "Product 2", Price = 6.5M, Quantity = 1},
                new Product{ Name = "Product 3", Price = 30.6M, Quantity = 4},
                new Product{ Name = "Product 4", Price = 105.5M, Quantity = 5}
            };

            return productsList;
        }

        public static List<Product> GetSortedProductsDescending()
        {
            var productsList = new List<Product>() {
                new Product{ Name = "Product 4", Price = 105.5M, Quantity = 5},
                new Product{ Name = "Product 3", Price = 30.6M, Quantity = 4},
                new Product{ Name = "Product 2", Price = 6.5M, Quantity = 1},
                new Product{ Name = "Product 1", Price = 10.2M, Quantity = 2}
            };

            return productsList;
        }

        public static List<Product> GetSortedProductsByPopularity()
        {
            var productsList = new List<Product>() {
                new Product{ Name = "Product 1", Price = 15.5M, Quantity = 10},
                new Product{ Name = "Product 5", Price = 30.5M, Quantity = 8},
                new Product{ Name = "Product 4", Price = 7.5M, Quantity = 5},
                new Product{ Name = "Product 2", Price = 25M, Quantity = 4},
                new Product{ Name = "Product 3", Price = 4.5M, Quantity = 3}
            };

            return productsList;
        }

        public static List<Product> GetSortedProductsByPopularity2()
        {
            var productsList = new List<Product>() {
                new Product{ Name = "Product 1", Price = 15.5M, Quantity = 7},
                new Product{ Name = "Product 3", Price = 4.5M, Quantity = 6},
                new Product{ Name = "Product 2", Price = 25M, Quantity = 5},
                new Product{ Name = "Product 4", Price = 105.5M, Quantity = 5}
            };

            return productsList;
        }

        public static List<ShopperHistory> GetFakeShopperHistory()
        {
            var shopperHistory = new List<ShopperHistory>() {
                new ShopperHistory ()
                {
                    CustomerId = 1,
                    Products = new List<Product> ()
                    {
                        new Product { Name = "Product 1", Price = 15.5M, Quantity = 1 },
                        new Product { Name = "Product 2", Price = 25M, Quantity = 1 },
                        new Product { Name = "Product 3", Price = 4.5M, Quantity = 2 }
                    }
                },
                new ShopperHistory()
                {
                    CustomerId = 2,
                    Products = new List<Product> ()
                    {
                        new Product { Name = "Product 4", Price = 7.5M, Quantity = 3 },
                        new Product { Name = "Product 5", Price = 30.5M, Quantity = 1 },
                        new Product { Name = "Product 1", Price = 15.5M, Quantity = 2 }
                    }
                },
                new ShopperHistory()
                {
                    CustomerId = 3,
                    Products = new List<Product> ()
                    {
                        new Product { Name = "Product 1", Price = 15.5M, Quantity = 3 },
                        new Product { Name = "Product 2", Price = 25M, Quantity = 1 },
                        new Product { Name = "Product 5", Price = 30.5M, Quantity = 2 },
                    }
                },
                new ShopperHistory()
                {
                    CustomerId = 4,
                    Products = new List<Product> ()
                    {
                        new Product { Name = "Product 5", Price = 30.5M, Quantity = 2 },
                        new Product { Name = "Product 3", Price = 4.5M, Quantity = 1 }
                    }
                },
                new ShopperHistory()
                {
                    CustomerId = 5,
                    Products = new List<Product> ()
                    {
                        new Product { Name = "Product 5", Price = 30.5M, Quantity = 3 },
                        new Product { Name = "Product 2", Price = 25M, Quantity = 2 },
                        new Product { Name = "Product 4", Price = 7.5M, Quantity = 2 },
                        new Product { Name = "Product 1", Price = 15.5M, Quantity = 4 }
                    }
                }
            };
            return shopperHistory;
        }

        public static List<ShopperHistory> GetFakeShopperHistory2()
        {
            var shopperHistory = new List<ShopperHistory>() {
                new ShopperHistory ()
                {
                    CustomerId = 1,
                    Products = new List<Product> ()
                    {
                        new Product { Name = "Product 1", Price = 15.5M, Quantity = 1 },
                        new Product { Name = "Product 2", Price = 25M, Quantity = 1 },
                        new Product { Name = "Product 3", Price = 4.5M, Quantity = 2 }
                    }
                },
                new ShopperHistory()
                {
                    CustomerId = 2,
                    Products = new List<Product> ()
                    {
                        new Product { Name = "Product 1", Price = 15.5M, Quantity = 3 },
                        new Product { Name = "Product 2", Price = 25M, Quantity = 2 },
                        new Product { Name = "Product 3", Price = 4.5M, Quantity = 1 }
                    }
                },
                new ShopperHistory()
                {
                    CustomerId = 2,
                    Products = new List<Product> ()
                    {
                        new Product { Name = "Product 1", Price = 15.5M, Quantity = 2 },
                        new Product { Name = "Product 2", Price = 25M, Quantity = 1 },
                        new Product { Name = "Product 3", Price = 4.5M, Quantity = 3 }
                    }
                },
                new ShopperHistory()
                {
                    CustomerId = 2,
                    Products = new List<Product> ()
                    {
                        new Product { Name = "Product 1", Price = 15.5M, Quantity = 1 },
                        new Product { Name = "Product 2", Price = 25M, Quantity = 1 }
                    }
                }
            };
            return shopperHistory;
        }

        public static TrolleyDataDTO GetFakeTrolleyData1()
        {
            var trolleyData = new TrolleyDataDTO()
            {
                Products = new List<Product>()
                {
                    new Product { Name = "Product 1", Price = 5 },
                    new Product { Name = "Product 2", Price = 10 }
                },
                Specials = new List<Special>()
                {
                    new Special
                    {

                        Quantities = new List<Product>()
                        {
                            new Product { Name = "Product 1", Quantity = 3 },
                            new Product { Name = "Product 2", Quantity = 1 }
                        },
                        Total = 30
                    },
                    new Special
                    {
                        Quantities = new List<Product>()
                        {
                            new Product { Name = "Product 1", Quantity = 1 },
                            new Product { Name = "Product 2", Quantity = 2 }
                        },
                        Total = 12.5M
                    }
                },
                Quantities = new List<Product>()
                {
                    new Product { Name = "Product 1", Quantity = 3 },
                    new Product { Name = "Product 2", Quantity = 2 }
                }
            };
            return trolleyData;
        }

        public static TrolleyDataDTO GetFakeTrolleyData2()
        {
            var trolleyData = new TrolleyDataDTO()
            {
                Products = new List<Product>()
                {
                    new Product { Name = "Product 1", Price = 5 },
                    new Product { Name = "Product 2", Price = 10 }
                },
                Specials = new List<Special>()
                {
                    new Special
                    {

                        Quantities = new List<Product>()
                        {
                            new Product { Name = "Product 1", Quantity = 3 },
                            new Product { Name = "Product 2", Quantity = 1 }
                        },
                        Total = 11
                    },
                    new Special
                    {
                        Quantities = new List<Product>()
                        {
                            new Product { Name = "Product 1", Quantity = 1 },
                            new Product { Name = "Product 2", Quantity = 2 }
                        },
                        Total = 12.5M
                    },
                    new Special
                    {
                        Quantities = new List<Product>()
                        {
                            new Product { Name = "Product 1", Quantity = 1 },
                            new Product { Name = "Product 2", Quantity = 4 }
                        },
                        Total = 40
                    }
                },
                Quantities = new List<Product>()
                {
                    new Product { Name = "Product 1", Quantity = 3 },
                    new Product { Name = "Product 2", Quantity = 2 }
                }
            };
            return trolleyData;
        }
    }
}
