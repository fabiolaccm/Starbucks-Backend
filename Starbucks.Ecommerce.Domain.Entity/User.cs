
namespace Starbucks.Ecommerce.Domain.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ProvinceId { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Province Province { get; set; }


    }
}
