using LoginPilotoApp.Dtos.ResponseApiDto;
using PilotoWebAPI.Dtos;

namespace PilotoWebAPI.Services.IServices
{
    public interface IPilotoService
    {
        Task<ApiResponseDto<PilotoDto>> AddPiloto(PilotoDto piloto);
        Task<ApiResponseDto<PilotoDtoUpdate>> UpdatePiloto(PilotoDtoUpdate pilotoDtoUpdate);
        Task<ApiResponseDto<List<PilotosDto>>> getAllPilotos(string email);
        Task<ApiResponseDto<PilotoDto>> getPiloto(int id);
    }
}
