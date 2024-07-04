using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PilotoWebAPI.Dtos;
using PilotoWebAPI.Services.IServices;

namespace PilotoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
      
        public UserController( IUserService userService)
        {
            _userService = userService;            
        }

        [HttpPost("/User/Login")] 
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                var usuario = await _userService.GetUserByEmailAndPassword(userLoginDto.Email, userLoginDto.Password);
                if (usuario == null)
                {
                    return NotFound("Usuario o contraseña incorrecto");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
     }
    }
