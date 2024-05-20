using ConsultService.Models;

namespace ConsultService.Services
{
    public class DoctorService
    {
        public async Task<Doctor> RegisterPatientAsync(Doctor doctor)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient;
        }
    }
}
