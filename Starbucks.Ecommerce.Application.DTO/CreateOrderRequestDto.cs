
namespace Starbucks.Ecommerce.Application.DTO
{
    public class CreateOrderRequestDto
    {
        public Guid UserId { get; set; }
        public string PaymentMethod { get; set; }
        public int OrderNro { get; set; }
        public ICollection<OrderDetailRequest> OrderDetails { get; set; }
    }

    public class OrderDetailRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
