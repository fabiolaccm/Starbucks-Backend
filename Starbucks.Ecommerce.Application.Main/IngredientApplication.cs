using AutoMapper;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Infraestructure.Interface;
using Starbucks.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Application.Main
{
    public class IngredientApplication : IIngredientApplication
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public IngredientApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<Response<IEnumerable<IngredientResponseDto>>> GetAllIngredients()
        {
            var ingredients = await _unitOfWork.Ingredients.FindAll();
            var data = _mapper.Map<IEnumerable<IngredientResponseDto>>(ingredients);
            return Response<IEnumerable<IngredientResponseDto>>.Ok(data);
        }

        public async Task<Response<IngredientResponseDto>> GetIngredientById(Guid id)
        {
            var ingredient = await _unitOfWork.Ingredients.FindById(id);
            if (ingredient == null) {
                return Response<IngredientResponseDto>.Fail("Ingredient not found");
            }
            var data = _mapper.Map<IngredientResponseDto>(ingredient);
            return Response<IngredientResponseDto>.Ok(data);
        }

        public async Task<Response<bool>> UpdateIngredient(UpdateIngredientDto updateIngredientDto)
        {
            var ingredient = await _unitOfWork.Ingredients.FindById(updateIngredientDto.Id);
            if (ingredient == null)
            {
                return Response<bool>.Fail("Ingredient not found");
            }

            if (updateIngredientDto.QuantityAvailable <= 0 || updateIngredientDto.StockAlert < 0) {
                return Response<bool>.Fail("QuantityAvailable | StockAlert not minor 0 ");
            }

            var data = _mapper.Map<Ingredient>(updateIngredientDto);

            var updated = await _unitOfWork.Ingredients.Update(data);

            if (updated)
            {
                return Response<bool>.Ok(true);
            }
            return Response<bool>.Fail("Error updating ingredient");

        }
    }
}
