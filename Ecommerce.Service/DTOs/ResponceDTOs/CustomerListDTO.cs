using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.DTOs.ResponceDTOs
{
    public class CustomerListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public string PasswordHash { get; set; } = null!;

        public string? Address { get; set; }
    }
}
