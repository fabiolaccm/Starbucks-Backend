
namespace Starbucks.Ecommerce.Application.DTO
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public int ProvinceId { get; set; }
    }
}

