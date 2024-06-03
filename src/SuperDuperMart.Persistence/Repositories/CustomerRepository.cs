using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Persistence.Data;

namespace SuperDuperMart.Persistence.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly SuperDuperMartDbContext _context;

        public CustomerRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
            return customer;
        }
    }
}
