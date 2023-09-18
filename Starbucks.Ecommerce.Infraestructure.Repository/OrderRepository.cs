using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Infraestructure.Data;
using Starbucks.Ecommerce.Infraestructure.Data.DataModels;
using Starbucks.Ecommerce.Infraestructure.Interface;

namespace Starbucks.Ecommerce.Infraestructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StarbucksDatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public OrderRepository(StarbucksDatabaseContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<bool> Create(Order order)
        {
            try
            {
                var orderDataModel = _mapper.Map<OrderDataModel>(order);
                orderDataModel.UserId = order.User.Id;
                _dbContext.Orders.Add(orderDataModel);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Order order)
        {
            try
            {
                var orderDataModel = _mapper.Map<OrderDataModel>(order);
                this.untrack();
                _dbContext.Orders.Remove(orderDataModel);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Order>> FindAll()
        {
            var orders = await _dbContext.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(detail => detail.Product)
                .ToListAsync();
            return _mapper.Map<IEnumerable<Order>>(orders);
        }

        public async Task<Order> FindById(Guid id)
        {
            var response = await _dbContext.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (response == null)
            {
                return await Task.FromResult<Order>(null);
            }
            return _mapper.Map<Order>(response);
        }

        public async Task<bool> Update(Order user)
        {
            try
            {
                var userDataModel = _mapper.Map<OrderDataModel>(user);
                _dbContext.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Detached);
                _dbContext.Entry(userDataModel).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void untrack()
        {
            _dbContext.ChangeTracker.Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Detached);
        }
    }
}
