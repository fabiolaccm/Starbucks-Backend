
using System.ComponentModel.DataAnnotations;

namespace Starbucks.Ecommerce.Infraestructure.Data.DataModels
{
    public class IngredientDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal QuantityAvailable { get; set; }
        public decimal StockAlert { get; set; }
    }
}
