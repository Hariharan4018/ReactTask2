using Ecommerce.Service.DTOs.ResponceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interfaces
{
    public interface IAdminServices
    {
        Task<GenericApiResponceDTO<List<CustomerListDTO?>>> GetAllCustomers();  
    }
}
