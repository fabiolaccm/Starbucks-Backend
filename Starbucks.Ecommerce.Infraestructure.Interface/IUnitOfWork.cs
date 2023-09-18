using Starbucks.Ecommerce.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Infraestructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
        public IProvinceRepository Provinces { get; }
        public IRoleRepository Roles { get; }
        public IProductRepository Products { get; }
        public IIngredientRepository Ingredients { get; }
        public IOrderRepository Orders { get; }

    }
}
