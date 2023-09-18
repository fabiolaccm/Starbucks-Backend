
namespace Starbucks.Ecommerce.Domain.Entity
{
    public class ProductItem
    {
        public Guid ProductItemId { get; set; }
        public int Quantity { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
