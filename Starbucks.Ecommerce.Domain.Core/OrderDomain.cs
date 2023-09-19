using Starbucks.Ecommerce.Domain.Interface;
using Starbucks.Ecommerce.Infraestructure.Interface;

namespace Starbucks.Ecommerce.Domain.Entity
{
    public class OrderDomain : IOrderDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDomain(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<bool> Create(Order order)
        {
            return _unitOfWork.Orders.Create(order);
        }

        public Task<bool> Delete(Order order)
        {
            return _unitOfWork.Orders.Delete(order);
        }

        public Task<Order> FindById(Guid id)
        {
            return _unitOfWork.Orders.FindById(id);
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            return _unitOfWork.Orders.FindAll();
        }

        public Task<bool> Update(Order order)
        {
            return _unitOfWork.Orders.Update(order);
        }
    }
}
