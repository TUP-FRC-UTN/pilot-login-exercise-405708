using AutoMapper;
using LoginPilotoApp.Dtos.ResponseApiDto;
using PilotoWebAPI.Dtos;
using PilotoWebAPI.Repositories.IRepositories;
using PilotoWebAPI.Services.IServices;

namespace PilotoWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponseDto<UserDto>> GetUserByEmailAndPassword(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAndPassword(email, password);
            if (user != null) 
            {
                var userTaked = new UserDto
                {
                    Email = user.UserEmail
                };
                return new ApiResponseDto<UserDto>
                {
                    Data = userTaked,
                    Success = true
                };
            }
            else
            {
                var response = new ApiResponseDto<UserDto>();
                response.ErrorMessage = "User no encontrado";
                response.Success = false;
                return response;
            }
        }
    }
}
