using RegisterService.Models;

namespace RegisterService.Interface
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientAsync(Guid id);
        Task<Patient> UpdatePatientAsync(Patient patient);
    }

}
