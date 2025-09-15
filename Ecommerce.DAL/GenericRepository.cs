using Ecommerce.DAL.ECommerceContext;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL
{
    public class GenericRepository<T>:IRepository<T> where T : class
    {
        private readonly EcommerceDbContext _context;
       public GenericRepository(EcommerceDbContext context) { 
        _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T?> Login(string Email, string password) 
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => EF.Property<string>(x,nameof(Email)) == Email && EF.Property<string>(x,nameof(password)) == password);
        }
    }

}
