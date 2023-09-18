using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Infraestructure.Data;
using Starbucks.Ecommerce.Infraestructure.Data.DataModels;
using Starbucks.Ecommerce.Infraestructure.Interface;

namespace Starbucks.Ecommerce.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StarbucksDatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(StarbucksDatabaseContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<bool> Create(User user)
        {
            try
            {
                var userDataModel = _mapper.Map<UserDataModel>(user);
                _dbContext.Users.Add(userDataModel);
                _dbContext.SaveChanges();
                return true;    
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                var userDataModel = _mapper.Map<UserDataModel>(user);
                _dbContext.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Detached);
                _dbContext.Entry(userDataModel).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(User user)
        {
            try
            {
                var userDataModel = _mapper.Map<UserDataModel>(user);
                this.untrack();
                _dbContext.Users.Remove(userDataModel);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            var response = _dbContext.Users
                .Include(u => u.Role)
                .Include(user => user.Province)
                .AsEnumerable();
            return _mapper.Map<IEnumerable<User>>(response);
        }

        public async Task<User> FindById(Guid id)
        {
            var response = _dbContext.Users
                .Include(u => u.Role)
                .Include(user => user.Province)
                .FirstOrDefault(u => u.Id == id);
            if (response == null)
            {
                return await Task.FromResult<User>(null);
            }
            return _mapper.Map<User>(response);
        }

        public async Task<User> FindByUsername(string username)
        {
            var response = _dbContext.Users
                .Include(u => u.Role)
                .Include(user => user.Province)
                .FirstOrDefault(user => user.Email == username);
            if (response == null)
            {
                return await Task.FromResult<User>(null);
            }
            return _mapper.Map<User>(response);
        }

        private void untrack() 
        {
            _dbContext.ChangeTracker.Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Detached);
        }

    }
}
