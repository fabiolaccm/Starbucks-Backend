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
    public class ProvinceApplication: IProvinceApplication
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ProvinceApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<Response<IEnumerable<ProvinceDto>>> GetAll()
        {
            var roles = await _unitOfWork.Provinces.FindAll();
            var data = _mapper.Map<IEnumerable<ProvinceDto>>(roles);
            return Response<IEnumerable<ProvinceDto>>.Ok(data);
        }
    }
}
