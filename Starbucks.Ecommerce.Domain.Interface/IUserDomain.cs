
using Starbucks.Ecommerce.Domain.Entity;

namespace Starbucks.Ecommerce.Domain.Interface
{
    public interface IUserDomain
    {
        Task<User> FindById(Guid id);
        Task<User> FindByEmail(string email);
        Task<IEnumerable<User>> GetAll();
        Task<bool> Create(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(User user);
    }
}
