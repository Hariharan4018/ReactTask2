using Ecommerce.DAL.ECommerceContext;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class AuthDAL : IAuthDAL
    {
        private readonly EcommerceDbContext _context;
        public AuthDAL(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> UserRegister(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            _context.SaveChangesAsync();
            return customer;
        }
        public async Task<T?> Login<T>(string Email, string password) where T : class
        {
            return await _context.Set<T>()
             .FirstOrDefaultAsync(u => EF.Property<string>(u, "Email") == Email &&
                                       EF.Property<string>(u, "PasswordHash") == password);
        }
        //public async Task<Admin?> AdminLogin(string Email, string password)
        //{
        //    return await _context.Admins.FirstOrDefaultAsync(x => x.Email == Email && x.PasswordHash == password);
        //}

    }
}
