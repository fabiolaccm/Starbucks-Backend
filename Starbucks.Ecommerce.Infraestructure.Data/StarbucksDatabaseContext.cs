using Microsoft.EntityFrameworkCore;
using Starbucks.Ecommerce.Infraestructure.Data.DataModels;

namespace Starbucks.Ecommerce.Infraestructure.Data
{
    public class StarbucksDatabaseContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "StarbucksDb");
        }

        public DbSet<RoleDataModel> Roles { get; set; }
        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<OrderDataModel> Orders { get; set; }
        public DbSet<ProvinceDataModel> Provinces { get; set; }
        public DbSet<ProductDataModel> Products { get; set; }
        public DbSet<IngredientDataModel> Ingredients { get; set; }

    }
}
