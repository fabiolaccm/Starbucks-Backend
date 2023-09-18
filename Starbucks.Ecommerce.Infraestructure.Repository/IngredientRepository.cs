using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Infraestructure.Data;
using Starbucks.Ecommerce.Infraestructure.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Infraestructure.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly StarbucksDatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public IngredientRepository(StarbucksDatabaseContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Ingredient>> FindAll()
        {
            var response = _dbContext.Ingredients.AsEnumerable();
            return _mapper.Map<IEnumerable<Ingredient>>(response);
        }

        public async Task<Ingredient> FindById(Guid id)
        {
            var response = _dbContext.Ingredients.FirstOrDefault(u => u.Id == id);
            if (response == null)
            {
                return await Task.FromResult<Ingredient>(null);
            }
            return _mapper.Map<Ingredient>(response);
        }

        public async Task<bool> Update(Ingredient ingredient)
        {
            try
            {
                var ingredientDataModel = _mapper.Map<IngredientDataModel>(ingredient);
                this.untrack();
                _dbContext.Entry(ingredientDataModel).State = EntityState.Modified;
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
