
namespace Starbucks.Ecommerce.Domain.Entity
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int OrderNro { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderState Status { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
