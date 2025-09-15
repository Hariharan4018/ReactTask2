using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.DTOs.ResponceDTOs
{
    public class ResponseDTO
    {
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

    }
}
