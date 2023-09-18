
namespace Starbucks.Ecommerce.Application.DTO
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ProvinceDto Province { get; set; }
        public RoleDto Role { get; set; }
    }

}
