using Starbucks.Ecommerce.Domain.Entity;

namespace Starbucks.Ecommerce.Domain.Interface
{
    public interface IOrderDomain
    {
        Task<Order> FindById(Guid id);
        Task<IEnumerable<Order>> GetAll();
        Task<bool> Create(Order user);
        Task<bool> Update(Order user);
        Task<bool> Delete(Order user);

    }
}
