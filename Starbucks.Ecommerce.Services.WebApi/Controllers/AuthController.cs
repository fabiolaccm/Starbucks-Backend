using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starbucks.Ecommerce.Application.DTO;

namespace Starbucks.Ecommerce.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto request)
        {
            return Ok(new LoginResponseDto
            {
                Token = "Bearer JWT"
            });
        }
    }
}
