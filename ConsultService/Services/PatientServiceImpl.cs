using Grpc.Core;
using ConsultService.Data;
using ConsultService.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ConsultService.Services
{

    public class PatientServiceImpl : PatientService.PatientServiceBase
    {
        private readonly IPatientRepository _repository;
        private readonly ILogger<PatientServiceImpl> _logger;

        public PatientServiceImpl(IPatientRepository repository, ILogger<PatientServiceImpl> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public override async Task<PatientResponse> AddPatient(PatientRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received a new patient: {Name}", request.Name);

            var patient = new Patient
            {
                Id = new Guid(request.Id),
                Name = request.Name,
                DateOfBirth = DateTime.Parse(request.DateOfBirth)
            };

            await _repository.AddPatientAsync(patient);
            await _repository.SaveChangesAsync();

            return new PatientResponse { Status = "Patient added successfully" };
        }
    }

}
