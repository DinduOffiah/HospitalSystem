using ConsultService.Models;

namespace ConsultService.Services
{
    public interface IPatientRepository
    {
        Task AddPatientAsync(Patient patient);
        Task SaveChangesAsync();
    }
}
