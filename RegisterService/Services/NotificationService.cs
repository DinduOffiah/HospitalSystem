using RegisterService.Models;
using System.Text.Json;
using System.Text;
using Serilog;
using Newtonsoft.Json;

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
            //using (var client = new HttpClient())
            //{
            //    var url = "http://localhost:5196/api/Patients"; // Ensure this is the correct URL
            //    var content = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");

            //    try
            //    {
            //        var response = await client.PostAsync(url, content);
            //        if (!response.IsSuccessStatusCode)
            //        {
            //            var responseBody = await response.Content.ReadAsStringAsync();
            //            Log.Error("Failed to notify new patient. Status Code: {StatusCode}, Response: {Response}", response.StatusCode, responseBody);
            //            response.EnsureSuccessStatusCode(); // This will throw an exception if the status code is not successful
            //        }
            //    }
            //    catch (HttpRequestException ex)
            //    {
            //        Log.Error(ex, "An error occurred while sending the notification request.");
            //        throw; // Optionally, handle or rethrow the exception
            //    }
            //}

            // Notify VitalService about the new patient
            var json = JsonConvert.SerializeObject(patient);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("http://localhost:5196/api/Patients", data);
        }

    }
}
