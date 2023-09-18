using Microsoft.AspNetCore.Mvc;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Services.Api.Common;

namespace Starbucks.Ecommerce.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UsersController(IUserApplication userApplication)
        {
            this._userApplication = userApplication;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            try
            {
                var response = await _userApplication.FindById(userId);
                if (response.IsSuccess)
                {
                    return Ok(response.Data);
                }
                return ApiException.Build412(response.Message);
            }
            catch (Exception ex) {
                return ApiException.Build500(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                var response = await _userApplication.GetAll();
                if (response.IsSuccess)
                {
                    return Ok(response.Data);
                }
                return ApiException.Build412(response.Message);
            }
            catch (Exception ex)
            {
                return ApiException.Build500(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserDto user)
        {
            try
            {
                var response = await _userApplication.Create(user);
                if (response.IsSuccess)
                {
                    return Ok(response.Data);
                }
                return ApiException.Build412(response.Message);
            }
            catch (Exception ex)
            {
                return ApiException.Build500(ex);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto user)
        {
            try
            {
                var response = await _userApplication.Update(user);
                if (response.IsSuccess)
                {
                    return NoContent();
                }
                return ApiException.Build412(response.Message);
            }
            catch (Exception ex)
            {
                return ApiException.Build500(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var response = await _userApplication.Delete(id);
                if (response.IsSuccess)
                {
                    return StatusCode(204);
                }
                return ApiException.Build412(response.Message);
            }
            catch (Exception ex)
            {
                return ApiException.Build500(ex);
            }
        }


    }
}
