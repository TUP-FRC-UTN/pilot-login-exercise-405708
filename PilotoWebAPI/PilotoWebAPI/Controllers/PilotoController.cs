
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PilotoWebAPI.Dtos;
using PilotoWebAPI.Services.IServices;


namespace PilotoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotoController : ControllerBase
    {
        private readonly IPilotoService _pilotoService;

        public PilotoController(IPilotoService pilotoService)
        {
            _pilotoService = pilotoService;
        }

     
        [HttpPost("/Piloto/PostPiloto")]
        public async Task<IActionResult> AddPiloto([FromBody] PilotoDto pilotoDto)
        {
            try
            {
                var response = await _pilotoService.AddPiloto(pilotoDto);

                if (response.Success)
                {
                    return Ok(response.Data); 
                }
                else
                {
                    return BadRequest(response.ErrorMessage); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }


        [HttpPut("/Piloto/UpdatePiloto")]
        public async Task<IActionResult> UpdatePiloto([FromBody] PilotoDtoUpdate pilotoDtoUpdate)
        {
            try
            {
                var response = await _pilotoService.UpdatePiloto(pilotoDtoUpdate);
                if (response.Success)
                {
                    return Ok(response.Data); 
                }
                else
                {
                    return BadRequest(response.ErrorMessage); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }
        [HttpGet("/Piloto/GetPilotosByEmail")]
        public async Task<IActionResult> GetPilotosByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email requerido");
            }

            var result = await _pilotoService.getAllPilotos(email);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Data);
            }
            return Ok(result.Data);
        }

        [HttpGet("/Piloto/GetPilotoById")]
        public async Task<IActionResult> GetPilotoById(int id)
        {
            var result = await _pilotoService.getPiloto(id);

            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Data);
            }
            return Ok(result.Data);
        }
    }
}
