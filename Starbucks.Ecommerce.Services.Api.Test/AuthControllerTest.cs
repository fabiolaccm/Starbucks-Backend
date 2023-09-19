using Microsoft.AspNetCore.Mvc;
using Moq;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Services.Api.Common;
using Starbucks.Ecommerce.Services.Api.Controllers;
using Starbucks.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Services.Api.Test
{
    public class AuthControllerTests
    {
        [Fact]
        public async Task Login_ValidCredentials_ReturnsToken()
        {
            var email = "test@example.com";
            var password = "password123";
            var request = new LoginRequestDto { Email = email, Password = password };

            var mockUserApplication = new Mock<IUserApplication>();
            var mockLogger = new Mock<IAppLogger<AuthController>>();

            var successResponse = new Response<UserResponseDto> { 
                IsSuccess = true,
                Data = new UserResponseDto {
                    Id = Guid.NewGuid(),
                    Email = "any-email",
                    Role = new RoleDto { 
                        Name = "any-role"
                    }
                }
            };
            var controller = new AuthController(mockUserApplication.Object, mockLogger.Object);

            mockUserApplication.Setup(app => app.Authenticate(email, password))
                .ReturnsAsync(successResponse);

            var result = await controller.Login(request);

            var loginResponse = Assert.IsType<LoginResponseDto>(result.Value);
            Assert.NotNull(loginResponse);
            Assert.NotNull(loginResponse.Token);
        }

        [Fact]
        public async Task Login_InvalidCredentials_ReturnsError()
        { 
            var email = "invalid@example.com";
            var password = "invalidpassword";
            var request = new LoginRequestDto { Email = email, Password = password };

            var mockUserApplication = new Mock<IUserApplication>();
            var mockLogger = new Mock<IAppLogger<AuthController>>();

            var errorMessage = "Invalid credentials.";
            var errorResponse = new Response<UserResponseDto> { IsSuccess = false, Message = errorMessage };
            var controller = new AuthController(mockUserApplication.Object, mockLogger.Object);

            mockUserApplication.Setup(app => app.Authenticate(email, password))
                .ReturnsAsync(errorResponse);

            
            var result = await controller.Login(request);

            var resultError = Assert.IsType<ObjectResult>(result.Result);
            var error = Assert.IsType<ApiException>(resultError.Value);
            Assert.Equal(412, resultError.StatusCode);
            Assert.Equal(errorMessage, error.Message);
        }

        [Fact]
        public async Task Login_Exception_ReturnsInternalServerError()
        {
            
            var email = "test@example.com";
            var password = "password123";
            var request = new LoginRequestDto { Email = email, Password = password };

            var mockUserApplication = new Mock<IUserApplication>();
            var mockLogger = new Mock<IAppLogger<AuthController>>();

            var exceptionMessage = "An unexpected error occurred.";
            var exception = new Exception(exceptionMessage);
            var controller = new AuthController(mockUserApplication.Object, mockLogger.Object);

            mockUserApplication.Setup(app => app.Authenticate(email, password))
                .ThrowsAsync(exception);

            var result = await controller.Login(request);
            
            var resultError = Assert.IsType<ObjectResult>(result.Result);
            var error = Assert.IsType<ApiException>(resultError.Value);
            Assert.Equal(500, resultError.StatusCode);
            Assert.Equal(exceptionMessage, error.Message);
        }
    }
}
