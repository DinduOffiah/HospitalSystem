using ConsultService.Models;

namespace ConsultService.Services
{
    public interface IDoctorService
    {
        Task<Doctor> RegisterPatientAsync(Doctor doctor);
    }
}
