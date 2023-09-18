using Starbucks.Ecommerce.Domain.Entity;

namespace Starbucks.Ecommerce.Infraestructure.Interface
{
    public interface IOrderRepository
    {
        Task<Order> FindById(Guid id);

        Task<IEnumerable<Order>> FindAll();

        Task<bool> Create(Order user);

        Task<bool> Update(Order user);

        Task<bool> Delete(Order user);
    }
}
