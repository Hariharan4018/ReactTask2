using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Interfaces
{
    public interface IAuthDAL
    {
        Task<Customer> UserRegister(Customer customer);
        Task<T?> Login<T>(string Email, string password) where T : class;
    }
}
