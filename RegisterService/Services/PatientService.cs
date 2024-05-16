using AppDbContext.Data;
using Microsoft.EntityFrameworkCore;
using RegisterService.Interface;
using RegisterService.Models;

namespace RegisterService.Services
{
    public class PatientService : IPatientService
    {
        private readonly RegisterDbContext _context;

        public PatientService(RegisterDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> RegisterPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task<Patient> GetPatientAsync(Guid id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }
    }

}
