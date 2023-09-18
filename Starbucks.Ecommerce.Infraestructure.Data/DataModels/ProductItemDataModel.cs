
using System.ComponentModel.DataAnnotations;

namespace Starbucks.Ecommerce.Infraestructure.Data.DataModels
{
    public class ProductItemDataModel
    {
        [Key]
        public Guid ProductItemId { get; set; }
        public Guid IngredientId { get; set; }
        public int Quantity { get; set; }
        public IngredientDataModel Ingredient { get; set; }
    }
}
