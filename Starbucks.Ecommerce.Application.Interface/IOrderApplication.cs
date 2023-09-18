using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Transversal.Common;


namespace Starbucks.Ecommerce.Application.Interface
{
    public interface IOrderApplication
    {
        public Task<Response<IEnumerable<OrderResponseDto>>> GetAllOrders();

        public Task<Response<OrderResponseDto>> GetOrderById(Guid id);

        public Task<Response<OrderResponseDto>> CreateOrder(CreateOrderRequestDto createOrder);

        public Task<Response<bool>> DeleteOrder(Guid orderId);

        public Task<Response<bool>> ExecuteOrder(Guid orderId);

        public Task<Response<bool>> InvoiceOrder(Guid orderId);

    }
}
