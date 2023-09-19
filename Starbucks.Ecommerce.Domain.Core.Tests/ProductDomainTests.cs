using Moq;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Infraestructure.Interface;

namespace Starbucks.Ecommerce.Domain.Core.Tests
{
    public class ProductDomainTests
    {
        [Fact]
        public async Task FindAll_ReturnsAllProducts()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Product1" },
                new Product { Id = Guid.NewGuid(), Name = "Product2" }
            };
            unitOfWorkMock.Setup(uow => uow.Products.FindAll()).ReturnsAsync(products);
            var productDomain = new ProductDomain(unitOfWorkMock.Object);

            // Act
            var result = await productDomain.FindAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(products, result);
        }

        [Fact]
        public async Task FindById_ReturnsProductById()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var productId = Guid.NewGuid();
            var product = new Product { Id = productId, Name = "Product1" };
            unitOfWorkMock.Setup(uow => uow.Products.FindById(productId)).ReturnsAsync(product);
            var productDomain = new ProductDomain(unitOfWorkMock.Object);

            // Act
            var result = await productDomain.FindById(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
        }
    }
}
