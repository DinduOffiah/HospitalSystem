using ConsultService;
using Grpc.Net.Client;

namespace VitalService.Services
{
    public class PatientDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly PatientService.PatientServiceClient _client;

        public PatientDataClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var channel = GrpcChannel.ForAddress(_configuration["Grpc:ConsultServiceUrl"]);
            _client = new PatientService.PatientServiceClient(channel);
        }

        public async Task<PatientResponse> AddPatientAsync(PatientRequest patientRequest)
        {
            return await _client.AddPatientAsync(patientRequest);
        }
    }
}
