
using Starbucks.Ecommerce.Domain.Entity;

namespace Starbucks.Ecommerce.Application.DTO
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public int OrderNro { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public string CreationDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public ICollection<OrderDetailResponseDto> OrderDetails { get; set; }
    }

    public class OrderDetailResponseDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductResponseDto Product { get; set; }
    }
}
