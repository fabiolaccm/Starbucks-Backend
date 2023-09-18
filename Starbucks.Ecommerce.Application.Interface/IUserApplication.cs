
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Transversal.Common;

namespace Starbucks.Ecommerce.Application.Interface
{
    public interface IUserApplication
    {
        public Task<Response<UserResponseDto>> FindById(Guid id);
        public Task<Response<UserResponseDto>> FindByEmail(string email);
        public Task<Response<IEnumerable<UserResponseDto>>> GetAll();
        public Task<Response<UserResponseDto>> Create(CreateUserDto createUserDto);
        public Task<Response<bool>> Update(UpdateUserDto updateUserDto);
        public Task<Response<bool>> Delete(Guid id);
        public Task<Response<UserResponseDto>> Authenticate(string email, string password);
    }
}
