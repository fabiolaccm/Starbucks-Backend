
using Starbucks.Ecommerce.Domain.Entity;

namespace Starbucks.Ecommerce.Infraestructure.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindAll();

        Task<Product> FindById(Guid id);
    }
}
