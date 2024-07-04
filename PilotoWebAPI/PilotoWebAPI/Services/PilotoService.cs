using AutoMapper;
using Azure;
using LoginPilotoApp.Dtos.ResponseApiDto;
using PilotoWebAPI.Dtos;
using PilotoWebAPI.Models;
using PilotoWebAPI.Repositories.IRepositories;
using PilotoWebAPI.Services.IServices;
using System.Net;

namespace PilotoWebAPI.Services
{
    public class PilotoService : IPilotoService
    {
        private readonly IPilotoRepository _pilotoRepository;
        private readonly IMapper _mapper;

        public PilotoService(IPilotoRepository pilotoRepository, IMapper mapper)
        {
            _pilotoRepository = pilotoRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponseDto<PilotoDto>> AddPiloto(PilotoDto piloto)
        {
            var response = new ApiResponseDto<PilotoDto>();

            //Mapeo a piloto
            var pilotoToMap = _mapper.Map<Piloto>(piloto);
            //Agrego a la bd
            var pilotoAdd = await _pilotoRepository.AddPiloto(pilotoToMap);
            if (pilotoAdd != null) { 
                //Mapeo a dto
                var pilotoDtoAdd = _mapper.Map<PilotoDto>(pilotoAdd);
                response.Data = pilotoDtoAdd;
                response.Success = true;
                response.StatusCode = System.Net.HttpStatusCode.Created;
            }
            else
            {
                response.SetError("No se pudo agregar", System.Net.HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<List<PilotosDto>>> getAllPilotos(string email)
        {
            var response = new ApiResponseDto<List<PilotosDto>>();
            var pilotos = await _pilotoRepository.GetPilotosByEmail(email);
            if (pilotos != null || pilotos.Count > 0) 
            {
                //Mapeo la lista de pilotos traida. La paso a dto
                var pilotosDto = _mapper.Map<List<PilotosDto>>(pilotos);
                response.Data = pilotosDto;
                response.Success = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontraron pilotos con ese email", System.Net.HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<PilotoDto>> getPiloto(int id)
        {
            var response = new ApiResponseDto<PilotoDto>();
            var piloto = await _pilotoRepository.GetPilotoById(id);
            if(piloto != null)
            {
                //Mapeo piloto a su respectivo Dto
                var pilotoDto = _mapper.Map<PilotoDto>(piloto);
                response.Data = pilotoDto;
                response.Success = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontro piloto con el id", System.Net.HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<PilotoDtoUpdate>> UpdatePiloto(PilotoDtoUpdate pilotoDtoUpdate)
        {
            var response = new ApiResponseDto<PilotoDtoUpdate>();

            var pilotoUpdate = await _pilotoRepository.UpdatePiloto(pilotoDtoUpdate);

            if (pilotoUpdate != null)
            {
                //mapeo el piloto actualizado
                var pilotoUpdatedDto = _mapper.Map<PilotoDtoUpdate>(pilotoUpdate);
                //Campos a mostrar
                pilotoUpdatedDto.Id = pilotoUpdate.IdPiloto;
                pilotoUpdatedDto.idPais = (int)pilotoUpdate.Pais;
                pilotoDtoUpdate.cant_hrs_vuelo = (int)pilotoUpdate.CantHrVuelo;
                pilotoDtoUpdate.Email = pilotoUpdate.Email;
                response.Data = pilotoUpdatedDto;
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se pudo modificar el piloto", HttpStatusCode.InternalServerError);
            }
            return response;
        }
    }
}
