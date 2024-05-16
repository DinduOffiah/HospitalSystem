using RegisterService.Models;
using System.Text.Json;
using System.Text;

namespace RegisterService.Services
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;

        public NotificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task NotifyNewPatientAsync(Patient patient)
        {
            var json = JsonSerializer.Serialize(patient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send HTTP POST request to VitalService
            var response = await _httpClient.PostAsync("http://vitalservice/api/patients", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
