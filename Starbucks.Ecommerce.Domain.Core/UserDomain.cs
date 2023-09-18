using AutoMapper;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Domain.Interface;
using Starbucks.Ecommerce.Infraestructure.Interface;

namespace Starbucks.Ecommerce.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UserDomain(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public Task<User> FindByEmail(string email)
        {
            return _unitOfWork.Users.FindByUsername(email);
        }

        public Task<User> FindById(Guid id)
        {
            return _unitOfWork.Users.FindById(id);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return _unitOfWork.Users.FindAll();
        }

        public async Task<bool> Create(User user)
        {
            var created = await _unitOfWork.Users.Create(user);
            return created;
        }

        public async Task<bool> Update(User user)
        {
            var updated = await _unitOfWork.Users.Update(user);
            return updated;
        }
        public async Task<bool> Delete(User user)
        {
            var deleted = await _unitOfWork.Users.Delete(user);
            return deleted;
        }

    }
}
