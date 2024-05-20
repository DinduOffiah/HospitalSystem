using ConsultService.Models;

namespace ConsultService.Services
{
    public interface IDoctorService
    {
        Task<Doctor> AddDoctorAsync(Doctor doctor);
    }
}
