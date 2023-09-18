using Starbucks.Ecommerce.Domain.Entity;

namespace Starbucks.Ecommerce.Infraestructure.Interface
{
    public interface IUserRepository
    {
        Task<User> FindByUsername(string username);

        Task<User> FindById(Guid id);

        Task<IEnumerable<User>> FindAll();

        Task<bool> Create(User user);

        Task<bool> Update(User user);

        Task<bool> Delete(User user);



    }
}
