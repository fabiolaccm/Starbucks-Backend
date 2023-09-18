
using Starbucks.Ecommerce.Domain.Entity;

namespace Starbucks.Ecommerce.Infraestructure.Interface
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> FindAll();
    }
}
