using AutoMapper;
using Moq;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Application.Main;
using Starbucks.Ecommerce.Domain.Core;
using Starbucks.Ecommerce.Domain.Interface;
using Starbucks.Ecommerce.Services.Api.Controllers;
using Starbucks.Ecommerce.Transversal.Common;
using Microsoft.AspNetCore.Mvc;
using Starbucks.Ecommerce.Services.Api.Common;

namespace Starbucks.Ecommerce.Services.Api.Test
{
    public class ProductsControllerTest
    {

        [Fact]
        public async Task GetAll_ReturnsOkResultWithData()
        {
            var mockProductApplication = new Mock<IProductApplication>();
            var productResponse = new Response<IEnumerable<ProductResponseDto>>
            {
                IsSuccess = true,
                Data = new List<ProductResponseDto> { new ProductResponseDto() }
            };
            mockProductApplication.Setup(app => app.GetAllProducts())
                .ReturnsAsync(productResponse);
            var controller = new ProductsController(mockProductApplication.Object);

            var result = await controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var products = Assert.IsAssignableFrom<IEnumerable<ProductResponseDto>>(okResult.Value);
            Assert.Single(products);
        }

        [Fact]
        public async Task GetById_ValidId_ReturnsOkResultWithData()
        {
            var productId = Guid.NewGuid();
            var mockProductApplication = new Mock<IProductApplication>();
            var productResponse = new Response<ProductResponseDto>
            {
                IsSuccess = true,
                Data = new ProductResponseDto { Id = productId }
            };
            mockProductApplication.Setup(app => app.GetProductById(productId))
                .ReturnsAsync(productResponse);
            var controller = new ProductsController(mockProductApplication.Object);

            var result = await controller.GetById(productId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var product = Assert.IsType<ProductResponseDto>(okResult.Value);
            Assert.Equal(productId, product.Id);
        }

        [Fact]
        public async Task GetById_InvalidId_ReturnsBadRequest()
        {
            var invalidProductId = Guid.Empty;
            var mockProductApplication = new Mock<IProductApplication>();
            var errorResponse = new Response<ProductResponseDto>
            {
                IsSuccess = false,
                Message = "Product not found."
            };
            mockProductApplication.Setup(app => app.GetProductById(invalidProductId))
                .ReturnsAsync(errorResponse);
            var controller = new ProductsController(mockProductApplication.Object);

            var result = await controller.GetById(invalidProductId);

            var badRequestResult = Assert.IsType<ObjectResult>(result.Result);
            var error = Assert.IsType<ApiException>(badRequestResult.Value);
            Assert.Equal("Product not found.", error.Message);
        }

    }
}
