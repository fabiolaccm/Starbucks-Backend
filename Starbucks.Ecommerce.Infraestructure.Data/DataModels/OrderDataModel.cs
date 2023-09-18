using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Infraestructure.Data.DataModels
{
    public class OrderDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderNro { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public ICollection<OrderDetailDataModel> OrderDetails { get; set; }
    }
}
