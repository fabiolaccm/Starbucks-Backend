using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Services.Api.Common;

namespace Starbucks.Ecommerce.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientApplication _ingredientApplication;

        public IngredientsController(IIngredientApplication ingredientApplication)
        {
            this._ingredientApplication = ingredientApplication;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var response = await _ingredientApplication.GetAllIngredients();
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _ingredientApplication.GetIngredientById(id);
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
        public async Task<IActionResult> UpdateIngredient(Guid id, UpdateIngredientDto ingredient)
        {
            if (id != ingredient.Id)
            {
                return ApiException.Build412("Ids not match!");
            }
            try
            {
                var response = await _ingredientApplication.UpdateIngredient(ingredient);
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
    }
}
