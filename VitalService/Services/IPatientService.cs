using VitalService.Models;

namespace RegisterService.Interface
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientAsync(Guid id);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task<Patient> CreatePatientAsync(Patient patient);
    }

}
