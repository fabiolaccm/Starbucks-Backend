using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Application.DTO
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PreparationTime { get; set; }
        public ICollection<ProductItemResponseDto> ProductItems { get; set; }
    }

    public class ProductItemResponseDto
    {
        public Guid ProductItemId { get; set; }
        public int Quantity { get; set; }
        public IngredientResponseDto Ingredient { get; set; }
    }

}