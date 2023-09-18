using Starbucks.Ecommerce.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IProvinceRepository Provinces { get; }
        public IProductRepository Products { get; }
        public IIngredientRepository Ingredients { get; }
        public IOrderRepository Orders { get; }
        public UnitOfWork(IUserRepository users, 
            IRoleRepository roles, 
            IProvinceRepository provinces,
            IProductRepository products,
            IIngredientRepository ingredients,
            IOrderRepository orders
            )
        {
            this.Users = users;
            this.Roles = roles;
            this.Provinces = provinces;
            this.Products = products;
            this.Ingredients = ingredients;
            this.Orders = orders;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
