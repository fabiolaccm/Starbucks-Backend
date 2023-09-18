using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Application.DTO
{
    public class UpdateIngredientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal QuantityAvailable { get; set; }
        public decimal StockAlert { get; set; }
    }
}
