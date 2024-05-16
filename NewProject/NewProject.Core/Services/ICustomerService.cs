using NewProject.DAL.Models;

namespace NewProject.Core.Services
{
    // Defining methods(contracts) using interface.
    public interface ICustomerService
    {
        //Task<IEnumerable<Customer>> GetAllAsync(string query);
        Task AddAsync(Customer customer);
        Task<Customer> GetByIdAsync(int id);  // Gets details.
        //Task<Customer> UpdateAsync(int id, Customer customer);
        //Task DeleteAsync(int id);
    }
}
