
namespace Starbucks.Ecommerce.Domain.Entity
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal QuantityAvailable { get; set; }
        public decimal StockAlert { get; set; }
    }
}
