using Starbucks.Ecommerce.Domain.Entity;

namespace Starbucks.Ecommerce.Infraestructure.Repository
{
    public interface IIngredientRepository
    {
        Task<Ingredient> FindById(Guid id);

        Task<IEnumerable<Ingredient>> FindAll();

        Task<bool> Update(Ingredient ingredient);

    }
}
