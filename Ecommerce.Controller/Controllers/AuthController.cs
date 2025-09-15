using Ecommerce.Service.DTOs.RequestDTOs;
using Ecommerce.Service.DTOs.ResponceDTOs;
using Ecommerce.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<GenericApiResponceDTO<ResponseDTO>>> UserRegister([FromBody] CustomerRegisterDTO customerData)
        {
            var data = await _authService.UserRegister(customerData);
            return Ok(data);
        }

        [HttpPost("login")]
        public async Task<ActionResult<GenericApiResponceDTO<ResponseDTO?>>> Login([FromBody] LoginCredentialsDTO loginCredentialsDTO)
        {
            var data = await _authService.Login(loginCredentialsDTO);

            if (data.Success)
            {
                return Ok(data);
            }
            if (data.Data == null)
            {
                return NotFound(data);
            }
            return BadRequest(data);

        }

    }
}
