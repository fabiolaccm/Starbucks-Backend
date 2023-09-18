using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Services.Api.Common;
using Starbucks.Ecommerce.Transversal.Common;

namespace Starbucks.Ecommerce.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserApplication _userApplication;
        private readonly IAppLogger<AuthController> _logger;

        public AuthController(IUserApplication userApplication, IAppLogger<AuthController> logger) {
            this._userApplication = userApplication;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                var response = await _userApplication.Authenticate(request.Email, request.Password);
                if (response.IsSuccess)
                {
                    return new LoginResponseDto
                    {
                        Token = JwtHelper.BuildJwt(response.Data)
                    };
                }
                _logger.LogError(response.Message);
                return ApiException.Build412(response.Message);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return ApiException.Build500(ex);
            }
        }
    }
}
