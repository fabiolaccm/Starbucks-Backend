using AutoMapper;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Domain.Interface;
using Starbucks.Ecommerce.Transversal.Common;

namespace Starbucks.Ecommerce.Application.Main
{
    public class UserApplication: IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        public UserApplication(IUserDomain userDomain, IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }

        public async Task<Response<UserResponseDto>> Authenticate(string email, string password)
        {
            var user = await _userDomain.FindByEmail(email);

            if (user == null) { 
                return Response<UserResponseDto>.Fail("Usuario no existe");
            }

            if (user.Password != password) {
                return Response<UserResponseDto>.Fail("Credenciales invalidas");
            }
            var data = _mapper.Map<UserResponseDto>(user);
            return Response<UserResponseDto>.Ok(data);
        }

        public async Task<Response<UserResponseDto>> Create(CreateUserDto createUserDto)
        {
            var user = await _userDomain.FindByEmail(createUserDto.Email);
            if (user != null)
            {
                return Response<UserResponseDto>.Fail("Email already use");
            }
            var data = _mapper.Map<User>(createUserDto);
            data.Id = Guid.NewGuid();
            var created = await _userDomain.Create(data);

            if (created) {
                return await this.FindByEmail(createUserDto.Email);
            }

            return Response<UserResponseDto>.Fail("Problems create user");
        }

        public async Task<Response<bool>> Delete(Guid id)
        {
            var user = await _userDomain.FindById(id);
            if (user == null)
            {
                return Response<bool>.Fail("User not exists");
            }
            var deleted = await _userDomain.Delete(user);
            if (deleted) {
                return Response<bool>.Ok(true);
            }
            return Response<bool>.Fail("Problems create user");
        }

        public async Task<Response<UserResponseDto>> FindByEmail(string email)
        {
            var user = await _userDomain.FindByEmail(email);
            if (user == null)
            {
                return Response<UserResponseDto>.Fail("No data");
            }
            var data = _mapper.Map<UserResponseDto>(user);
            return Response<UserResponseDto>.Ok(data);
        }

        public async Task<Response<UserResponseDto>> FindById(Guid id)
        {
            var user = await _userDomain.FindById(id);
            if (user == null)
            {
                return Response<UserResponseDto>.Fail("No data");
            }
            var data = _mapper.Map<UserResponseDto>(user);
            return Response<UserResponseDto>.Ok(data);
        }

        public async Task<Response<IEnumerable<UserResponseDto>>> GetAll()
        {
            try
            {
                var users = await _userDomain.GetAll();
                if (users == null)
                {
                    return Response<IEnumerable<UserResponseDto>>.Fail("No data");
                }
                var data = _mapper.Map<IEnumerable<UserResponseDto>>(users);
                return Response<IEnumerable<UserResponseDto>>.Ok(data);

            }
            catch (Exception ex)
            {
                return Response<IEnumerable<UserResponseDto>>.Fail(ex.Message);
            }
        }

        public async Task<Response<bool>> Update(UpdateUserDto updateUserDto)
        {
            var userById = await _userDomain.FindById(updateUserDto.Id);
            if (userById == null)
            {
                return Response<bool>.Fail("User not exists");
            }

            var userByEmail = await _userDomain.FindByEmail(updateUserDto.Email);
            if (userByEmail != null && userByEmail.Id != userById.Id)
            {
                return Response<bool>.Fail("Email already exists");
            }

            var data = _mapper.Map<User>(updateUserDto);
            data.Password = userById.Password;

            var updated = await _userDomain.Update(data);
            if (updated) {
                return Response<bool>.Ok(await _userDomain.Update(data));
            }
            return Response<bool>.Fail("Problems update user");
        }



        /*
        public async Task<Response<CustomersDto>> GetAsync(string customerId)
        {
            var response = new Response<CustomersDto>();
            try
            {
                var customer = await _customersDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDto>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
         */
    }
}
