using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Infraestructure.Data;
using Starbucks.Ecommerce.Infraestructure.Interface;

namespace Starbucks.Ecommerce.Infraestructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StarbucksDatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(StarbucksDatabaseContext dbContext, IMapper mapper) { 
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<Product>> FindAll()
        {
            var response = _dbContext.Products
                .Include(mi => mi.ProductItems)
                .ThenInclude(detail => detail.Ingredient)
                .AsEnumerable();
            return _mapper.Map<IEnumerable<Product>>(response);
        }

        public async Task<Product> FindById(Guid id)
        {
            var response = _dbContext.Products
                .Include(mi => mi.ProductItems)
                .ThenInclude(detail => detail.Ingredient)
                .FirstOrDefault(mi => mi.Id == id);
            return _mapper.Map<Product>(response);
        }
    }
}
