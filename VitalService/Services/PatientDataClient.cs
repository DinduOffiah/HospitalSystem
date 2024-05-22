using ConsultService;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace VitalService.Services
{
    public class PatientDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly PatientService.PatientServiceClient _client;
        private readonly ILogger<PatientDataClient> _logger;

        public PatientDataClient(IConfiguration configuration, ILogger<PatientDataClient> logger)
        {
            _configuration = configuration;
            _logger = logger;
            var channel = GrpcChannel.ForAddress(_configuration["Grpc:ConsultServiceUrl"]);
            _client = new PatientService.PatientServiceClient(channel);
        }

        public async Task<PatientResponse> AddPatientAsync(PatientRequest patientRequest)
        {
            try
            {
                _logger.LogInformation("Sending patient {PatientId} to ConsultService", patientRequest.Id);
                var response = await _client.AddPatientAsync(patientRequest);
                _logger.LogInformation("Received response from ConsultService for patient {PatientId}: {Status}", patientRequest.Id, response.Status);
                return response;
            }
            catch (RpcException ex)
            {
                _logger.LogError(ex, "Error while sending patient {PatientId} to ConsultService. Status: {StatusCode}, Detail: {Detail}", patientRequest.Id, ex.StatusCode, ex.Status.Detail);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while sending patient {PatientId} to ConsultService.", patientRequest.Id);
                throw;
            }
        }
    }
}
