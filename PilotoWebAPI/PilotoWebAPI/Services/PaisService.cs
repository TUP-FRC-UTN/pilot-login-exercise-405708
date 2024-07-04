using AutoMapper;
using LoginPilotoApp.Dtos.ResponseApiDto;
using PilotoWebAPI.Dtos;
using PilotoWebAPI.Models;
using PilotoWebAPI.Repositories;
using PilotoWebAPI.Repositories.IRepositories;
using PilotoWebAPI.Services.IServices;

namespace PilotoWebAPI.Services
{
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _paisRepository;
        private readonly IMapper _mapper;

        public PaisService(IPaisRepository paisRepository, IMapper mapper)
        {
            _paisRepository = paisRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponseDto<List<PaisDto>>> ObtenerPaises()
        {
            ApiResponseDto<List<PaisDto>> response = new ApiResponseDto<List<PaisDto>>();

            List<Paise> lstPaises = await _paisRepository.GetAllPais();
            if(lstPaises == null || lstPaises.Count == 0)
            {
                response.SetError("No se encontraron Paises", System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                //Uso del mapper
                var paisesDto = _mapper.Map<List<PaisDto>>(lstPaises);
                for (int i = 0; i < lstPaises.Count; i++)
                {
                    paisesDto[i].nombrePais = lstPaises[i].Pais;
                }
                response.Success = true;
                response.ErrorMessage = "Lista de paises obtenida";
                response.Data = paisesDto;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            return response;
        }
    }
}
