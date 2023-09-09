using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NCwDDD.Application.Interfaces;
using NCwDDD.Application.ViewModels;
using NCwDDD.Services.API.Controllers;
using Xunit;

//TODO: Projeto de testes ainda em desenvolvimento criado, a principio, para demonstrar como alguns testes unitários podem ser realizados na controller de produtos

namespace NCwDDD.Services.API.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public async Task Get_ReturnsListOfProducts()
        {
            // Arrange
            var productAppServiceMock = new Mock<IProductAppService>();
            productAppServiceMock.Setup(service => service.GetAll()).ReturnsAsync(new List<ProductViewModel>());

            var controller = new ProductController(productAppServiceMock.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var products = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(okResult.Value);
            Assert.Empty(products);
        }

        [Fact]
        public async Task Get_WithValidId_ReturnsProduct()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var productViewModel = new ProductViewModel { Id = productId, Name = "Test Product" };
            var productAppServiceMock = new Mock<IProductAppService>();
            productAppServiceMock.Setup(service => service.GetById(productId)).ReturnsAsync(productViewModel);

            var controller = new ProductController(productAppServiceMock.Object);

            // Act
            var result = await controller.Get(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var product = Assert.IsType<ProductViewModel>(okResult.Value);
            Assert.Equal(productId, product.Id);
            Assert.Equal("Test Product", product.Name);
        }

        [Fact]
        public async Task Post_WithInvalidModel_ReturnsBadRequest()
        {
            // Arrange
            var productViewModel = new ProductViewModel { Name = null }; // Invalid model
            var controller = new ProductController(Mock.Of<IProductAppService>());

            // Act
            var result = await controller.Post(productViewModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}