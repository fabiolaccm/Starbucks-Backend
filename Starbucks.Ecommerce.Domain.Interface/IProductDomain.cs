
using Starbucks.Ecommerce.Domain.Entity;

namespace Starbucks.Ecommerce.Domain.Interface
{
    public interface IProductDomain
    {
        Task<Product> FindById(Guid id);
        Task<IEnumerable<Product>> FindAll();
    }
}
