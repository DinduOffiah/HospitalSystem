using ConsultService.Data;
using ConsultService.Models;

namespace ConsultService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ConsultDBContext _context;

        public DoctorService(ConsultDBContext context)
        {
            _context = context;
        }
        public async Task<Doctor> RegisterPatientAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }
    }
}
