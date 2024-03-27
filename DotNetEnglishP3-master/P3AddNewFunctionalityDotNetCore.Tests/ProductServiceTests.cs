using Microsoft.Extensions.Localization;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models;
using Xunit;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using Moq;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceTests
    {
               
            [Fact]
            public void GetAllProductsViewModel_ShouldReturnListOfProductViewModel()
            {
                // Arrange
                var mockCart = new Mock<ICart>();
                var mockProductRepository = new Mock<IProductRepository>();
                var mockOrderRepository = new Mock<IOrderRepository>();
                var mockLocalizer = new Mock<IStringLocalizer<ProductService>>();

                var productService = new ProductService(mockCart.Object, mockProductRepository.Object, mockOrderRepository.Object, mockLocalizer.Object);

                var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.99, Quantity = 50 },
                new Product { Id = 2, Name = "Product 2", Price = 24.99, Quantity = 30 },
                new Product { Id = 3, Name = "Product 3", Price = 54.99, Quantity = 20 }
            };

                mockProductRepository.Setup(repo => repo.GetAllProducts()).Returns(products);

                // Act
                var result = productService.GetAllProductsViewModel();

                // Assert
                Assert.NotNull(result);
                Assert.IsType<List<ProductViewModel>>(result);
                Assert.Equal(products.Count, result.Count);
            }

            [Fact]
            public void GetProductByIdViewModel_ShouldReturnCorrectProductViewModel()
            {
                // Arrange
                var mockCart = new Mock<ICart>();
                var mockProductRepository = new Mock<IProductRepository>();
                var mockOrderRepository = new Mock<IOrderRepository>();
                var mockLocalizer = new Mock<IStringLocalizer<ProductService>>();
          

                var productService = new ProductService(mockCart.Object, mockProductRepository.Object, mockOrderRepository.Object, mockLocalizer.Object);

                var products = new List<Product>
                       {
                new Product { Id = 1, Name = "Product 1", Price = 10.99, Quantity = 50 },
                new Product { Id = 2, Name = "Product 2", Price = 24.99, Quantity = 30 },
                new Product { Id = 3, Name = "Product 3", Price = 54.99, Quantity = 20 }
            };

            List<Product> productsEntities = products;
           
                mockProductRepository.Setup(repo => repo.GetAllProducts()).Returns(products);

                // Act
                var result = productService.GetProductByIdViewModel(2);

                // Assert
                Assert.NotNull(result);
                Assert.IsType<ProductViewModel>(result);
                Assert.Equal("Product 2", result.Name);
                Assert.Equal("24.99",result.Price);
            }

           
            // Add more tests as needed for other methods in ProductService
        }

        // TODO write test methods to ensure a correct coverage of all possibilities
    }
