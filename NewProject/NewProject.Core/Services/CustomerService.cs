using Microsoft.EntityFrameworkCore;
using NewProject.DAL.Data;
using NewProject.DAL.Migrations;
using NewProject.DAL.Models;

namespace NewProject.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        //public async Task DeleteAsync(int id)
        //{
        //    //Using the IsDeleted Feature.
        //    var customer = _context.Customers.FirstOrDefault(c => c.Id == id) ?? throw new NotFoundException("Student not found");
        //    //customer.IsDeleted = true;
        //    await _context.Customers.Remove(customer);
        //}

        // Gets details
        public async Task<Customer> GetByIdAsync(int id)
        {
            var details = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id) ?? throw new NotFoundException("No record found");
            return details;
        }

    }
}
