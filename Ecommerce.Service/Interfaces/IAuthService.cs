using Ecommerce.DAL.Entities;
using Ecommerce.Service.DTOs.RequestDTOs;
using Ecommerce.Service.DTOs.ResponceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interfaces
{
    public interface IAuthService
    {
        Task<GenericApiResponceDTO<ResponseDTO>> UserRegister(CustomerRegisterDTO customerData);
        Task<GenericApiResponceDTO<LoginResponceDTO?>> Login(LoginCredentialsDTO loginCredentials);
        string GenerateAccessToken(Customer customer);
        string GenerateJwtToken(string UserName, string Role, int ExpirationTime);

    }
}
