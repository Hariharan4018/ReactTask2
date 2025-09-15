using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.DTOs.ResponceDTOs
{
    public class LoginResponceDTO
    {
        public string AccessToken { get; set;}
        public string RefreshToken {  get; set;}
    }
}
