using AppDbContext.Data;
using Microsoft.EntityFrameworkCore;
using RegisterService.Interface;
using RegisterService.Models;

namespace RegisterService.Services
{
    public class PatientService : IPatientService
    {
        private readonly VitalDbContext _context;

        public PatientService(VitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientAsync(Guid id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return patient;
        }
    }


}
