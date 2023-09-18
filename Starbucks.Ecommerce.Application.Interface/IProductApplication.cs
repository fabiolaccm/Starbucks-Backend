

using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Transversal.Common;

namespace Starbucks.Ecommerce.Application.Interface
{
    public interface IProductApplication
    {
        public Task<Response<IEnumerable<ProductResponseDto>>> GetAllProducts();

        public Task<Response<ProductResponseDto>> GetProductById(Guid id);
    }
}
