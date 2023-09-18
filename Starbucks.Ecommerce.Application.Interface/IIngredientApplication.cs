using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Application.Interface
{
    public interface IIngredientApplication
    {
        public Task<Response<IEnumerable<IngredientResponseDto>>> GetAllIngredients();

        public Task<Response<IngredientResponseDto>> GetIngredientById(Guid id);

        public Task<Response<bool>> UpdateIngredient(UpdateIngredientDto updateIngredientDto);
    }
}
