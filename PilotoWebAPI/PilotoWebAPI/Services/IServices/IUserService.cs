using LoginPilotoApp.Dtos.ResponseApiDto;
using PilotoWebAPI.Dtos;

namespace PilotoWebAPI.Services.IServices
{
    public interface IUserService
    {
        Task<ApiResponseDto<UserDto>> GetUserByEmailAndPassword(string email, string password);
    }
}
