using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Transversal.Common;

namespace Starbucks.Ecommerce.Application.Interface
{
    public interface IRoleApplication
    {
        public Task<Response<IEnumerable<RoleDto>>> GetAll();

    }
}
