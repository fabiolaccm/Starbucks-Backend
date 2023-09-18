using System.ComponentModel.DataAnnotations;

namespace Starbucks.Ecommerce.Infraestructure.Data.DataModels
{
    public class OrderDetailDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductDataModel Product { get; set; }
    }
}
