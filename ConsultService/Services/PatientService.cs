using ConsultService.Data;
using Microsoft.EntityFrameworkCore;
using RegisterService.Models;

namespace ConsultService.Services
{
    public class PatientService
    {
        private readonly ConsultDBContext _context;

        public PatientService(ConsultDBContext context)
        {
            _context = context;
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return patient;
        }
    }
}
