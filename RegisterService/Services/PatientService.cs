using AppDbContext.Data;
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
            // Add the patient to the database
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient;
        }
    }
}
