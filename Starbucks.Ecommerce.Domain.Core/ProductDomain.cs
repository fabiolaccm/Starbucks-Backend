using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Domain.Interface;
using Starbucks.Ecommerce.Infraestructure.Interface;

namespace Starbucks.Ecommerce.Domain.Core
{
    public class ProductDomain : IProductDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductDomain(IUnitOfWork unitOfWork) {
            this._unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Product>> FindAll()
        {
            return this._unitOfWork.Products.FindAll();
        }

        public Task<Product> FindById(Guid id)
        {
            return this._unitOfWork.Products.FindById(id);
        }
    }
}
