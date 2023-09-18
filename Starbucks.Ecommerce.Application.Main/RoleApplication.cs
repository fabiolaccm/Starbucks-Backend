using AutoMapper;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Infraestructure.Interface;
using Starbucks.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Application.Main
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public RoleApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<Response<IEnumerable<RoleDto>>> GetAll()
        {
            var roles = await _unitOfWork.Roles.FindAll();
            var data = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return Response<IEnumerable<RoleDto>>.Ok(data);
        }
    }
}
