using Grpc.Core;
using ConsultService.Models;
using Microsoft.Extensions.Logging;
using System;
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
            try
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

                _logger.LogInformation("Patient {PatientId} added successfully", patient.Id);

                return new PatientResponse { Status = "Patient added successfully" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding patient {PatientId}", request.Id);
                throw new RpcException(new Status(StatusCode.Internal, "Internal server error"));
            }
        }
    }
}
