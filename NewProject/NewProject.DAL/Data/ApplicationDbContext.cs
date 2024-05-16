using Microsoft.EntityFrameworkCore;
using NewProject.DAL.Models;

namespace NewProject.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
    }
}