using System.ComponentModel.DataAnnotations;

namespace Starbucks.Ecommerce.Infraestructure.Data.DataModels
{
    public class ProductDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PreparationTime { get; set; }
        public ICollection<ProductItemDataModel> ProductItems { get; set; }
    }
}
