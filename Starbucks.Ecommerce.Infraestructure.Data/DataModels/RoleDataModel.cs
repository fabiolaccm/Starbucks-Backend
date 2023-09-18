using System.ComponentModel.DataAnnotations;

namespace Starbucks.Ecommerce.Infraestructure.Data.DataModels
{
    public class RoleDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
