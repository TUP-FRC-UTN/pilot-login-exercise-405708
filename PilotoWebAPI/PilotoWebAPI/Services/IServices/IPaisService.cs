using LoginPilotoApp.Dtos.ResponseApiDto;
using PilotoWebAPI.Dtos;

namespace PilotoWebAPI.Services.IServices
{
    public interface IPaisService
    {
        Task<ApiResponseDto<List<PaisDto>>> ObtenerPaises();
    }
}
