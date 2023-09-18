using Microsoft.AspNetCore.Mvc;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Services.Api.Common;

namespace Starbucks.Ecommerce.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleApplication _roleApplication;

        public RolesController(IRoleApplication roleApplication)
        {
            this._roleApplication = roleApplication;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var response = await _roleApplication.GetAll();
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


    }
}
