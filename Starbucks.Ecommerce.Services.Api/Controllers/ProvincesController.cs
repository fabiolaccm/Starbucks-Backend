using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Services.Api.Common;

namespace Starbucks.Ecommerce.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {

        private readonly IProvinceApplication _provinceApplication;

        public ProvincesController(IProvinceApplication provinceApplication)
        {
            this._provinceApplication = provinceApplication;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var response = await _provinceApplication.GetAll();
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
