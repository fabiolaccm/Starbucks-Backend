
namespace Starbucks.Ecommerce.Domain.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PreparationTime { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; }
    }
}
