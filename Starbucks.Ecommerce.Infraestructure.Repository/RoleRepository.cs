using AutoMapper;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Infraestructure.Data;
using Starbucks.Ecommerce.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Infraestructure.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly StarbucksDatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public RoleRepository(StarbucksDatabaseContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Role>> FindAll()
        {
            var response = _dbContext.Roles.AsEnumerable();
            return _mapper.Map<IEnumerable<Role>>(response);
        }
    }
}
