using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Services.Api.Common;

namespace Starbucks.Ecommerce.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderApplication _orderApplication;
        public OrdersController(IOrderApplication orderApplication)
        {
            this._orderApplication = orderApplication;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(Guid id)
        {
            try
            {
                var response = await _orderApplication.GetOrderById(id);
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

        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            try
            {
                var response = await _orderApplication.GetAllOrders();
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
        public async Task<IActionResult> CreateOrder(CreateOrderRequestDto order)
        {
            try
            {
                var response = await _orderApplication.CreateOrder(order);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var response = await _orderApplication.DeleteOrder(id);
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

        [HttpPut("{id}/execute")]
        public async Task<IActionResult> ExecuteOrder(Guid id)
        {
            try
            {
                var response = await _orderApplication.ExecuteOrder(id);
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

        [HttpPut("{id}/invoice")]
        public async Task<IActionResult> InvoiceOrder(Guid id)
        {
            try
            {
                var response = await _orderApplication.InvoiceOrder(id);
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
