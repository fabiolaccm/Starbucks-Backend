using AutoMapper;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Infraestructure.Data;
using Starbucks.Ecommerce.Infraestructure.Interface;

namespace Starbucks.Ecommerce.Infraestructure.Repository
{
    public class ProvinceRepository: IProvinceRepository
    {
        private readonly StarbucksDatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public ProvinceRepository(StarbucksDatabaseContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Province>> FindAll()
        {
            var response =  _dbContext.Provinces.AsEnumerable();
            return _mapper.Map<IEnumerable<Province>>(response);
        }
    }
}
