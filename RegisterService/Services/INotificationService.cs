using RegisterService.Models;

namespace RegisterService.Services
{
    public interface INotificationService
    {
        Task NotifyNewPatientAsync(Patient patient);
    }
}
