using API.DTOs.Request.Auth;
using API.DTOs.Response.Auth;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<AuthResponseDTO>> Login(AuthRequestDTO request) 
        {
            return Ok(new AuthResponseDTO { 
                Token = "Bearer JWT"
            });
        }

    }
}
