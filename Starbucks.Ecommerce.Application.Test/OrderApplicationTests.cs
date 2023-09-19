using AutoMapper;
using Moq;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Main;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Domain.Interface;
using Starbucks.Ecommerce.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Application.Test
{
    public class OrderApplicationTests
    {

        [Fact]
        public async Task CreateOrder_ValidOrder_ReturnsSuccessResponse()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var uuid = Guid.Parse("fc77b82b-548d-4547-80c1-d234242dac77");
            var orderRequest = new CreateOrderRequestDto
            {
                UserId = userId,
                OrderDetails = new List<OrderDetailRequest>
                {
                    new OrderDetailRequest { ProductId = uuid, Quantity = 2 }
                }
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var orderDomainMock = new Mock<IOrderDomain>();
            var mapperMock = new Mock<IMapper>();


            var orderApplication = new OrderApplication(orderDomainMock.Object, unitOfWorkMock.Object, mapperMock.Object);

            unitOfWorkMock.Setup(uow => uow.Users.FindById(userId))
                .ReturnsAsync(new User 
                { 
                    Id = userId,
                    Province = new Province { 
                        Id = 1,
                        Igv = 19,
                        Name = "Incremento"
                    }
                }
                );

            

            unitOfWorkMock.Setup(uow => uow.Products.FindById(It.IsAny<Guid>()))
                .ReturnsAsync(new Product
                { 
                    Id = uuid, 
                    Price = 10,
                    ProductItems = new[] { 
                        new ProductItem { 
                            ProductItemId = uuid,
                            Ingredient = new Ingredient {
                                Id = uuid
                            }
                        }
                    }
                }
                );
            
            unitOfWorkMock.Setup(uow => uow.Ingredients.FindById(It.IsAny<Guid>()))
                .ReturnsAsync(new Ingredient { Id = uuid, QuantityAvailable = 10 });

            unitOfWorkMock.Setup(uow => uow.Ingredients.Update(It.IsAny<Ingredient>()))
                .ReturnsAsync(true);

            orderDomainMock.Setup(od => od.Create(It.IsAny<Order>()))
                .ReturnsAsync(true);

            orderDomainMock.Setup(od => od.FindById(It.IsAny<Guid>()))
                .ReturnsAsync(new Order { 
                    Id = uuid,
                    CreationDate = DateTime.Now
                });

            mapperMock.Setup(mapper => mapper.Map<Order>(It.IsAny<CreateOrderRequestDto>()))
                .Returns(new Order { Id = uuid });

            mapperMock.Setup(mapper => mapper.Map<OrderResponseDto>(It.IsAny<Order>()))
                .Returns(new OrderResponseDto { Id = uuid });

            // Act
            var result = await orderApplication.CreateOrder(orderRequest);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task CreateOrder_InvalidUser_ReturnsFailureResponse()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var orderRequest = new CreateOrderRequestDto
            {
                UserId = userId,
                OrderDetails = new List<OrderDetailRequest>
                {
                    new OrderDetailRequest { ProductId = Guid.NewGuid(), Quantity = 2 }
                }
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var orderDomainMock = new Mock<IOrderDomain>();
            var mapperMock = new Mock<IMapper>();

            var orderApplication = new OrderApplication(orderDomainMock.Object, unitOfWorkMock.Object, mapperMock.Object);

            unitOfWorkMock.Setup(uow => uow.Users.FindById(userId))
                .ReturnsAsync((User)null);

            // Act
            var result = await orderApplication.CreateOrder(orderRequest);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Equal("Usuario no válido", result.Message);
        }


       
        [Fact]
        public async Task CreateOrder_NullOrderDetails_ReturnsFailureResponse()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var orderRequest = new CreateOrderRequestDto
            {
                UserId = userId,
                OrderDetails = null
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var orderDomainMock = new Mock<IOrderDomain>();
            var mapperMock = new Mock<IMapper>();

            var orderApplication = new OrderApplication(orderDomainMock.Object, unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await orderApplication.CreateOrder(orderRequest);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Equal("La orden debe tener al menos un detalle de pedido", result.Message);
        }
    }
}
