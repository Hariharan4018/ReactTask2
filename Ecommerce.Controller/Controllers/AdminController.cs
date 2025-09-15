using Ecommerce.Service.DTOs.ResponceDTOs;
using Ecommerce.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminServices _adminServices;
        public AdminController(IAdminServices adminServices) { 
        _adminServices = adminServices;
        }
        [HttpGet("GetAllCustomers")]
        [Authorize(Roles = "Admin,SuperAdmin")]

        public async Task<ActionResult<GenericApiResponceDTO<List<CustomerListDTO?>>>> GetAllCustomers()
        {
            var data = await _adminServices.GetAllCustomers();
            if (!data.Success)
            {
                return NoContent();
            }
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }

    }
}
