using System.ComponentModel.DataAnnotations;

namespace Starbucks.Ecommerce.Infraestructure.Data.DataModels
{
    public class UserDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ProvinceId { get; set; }
        public Guid RoleId { get; set; }
        public RoleDataModel Role { get; set; }
        public ProvinceDataModel Province { get; set; }
    }
}
