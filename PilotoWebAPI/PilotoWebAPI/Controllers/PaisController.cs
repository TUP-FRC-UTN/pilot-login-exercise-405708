using PilotoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using PilotoWebAPI.Services.IServices;

namespace PilotoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _paisService;

        public PaisController(IPaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet("/GetPaises")]
        public async Task<ActionResult<List<Paise>>> Get()
        {
            return Ok(await _paisService.ObtenerPaises());
        }
    }
}
