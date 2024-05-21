using ConsultService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsultService.Data
{
    public class ConsultDBContext : DbContext
    {
        public ConsultDBContext(DbContextOptions<ConsultDBContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
