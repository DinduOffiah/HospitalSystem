using Grpc.Core;

namespace ConsultService.Protos
{
    public class PatientService : Patient.PatientBase
    {
        public override Task<PatientResponse> UpdatePatient(PatientRequest request, ServerCallContext context)
        {
            // Update the patient in the database here

            return Task.FromResult(new PatientResponse
            {
                Message = "Patient updated successfully"
            });
        }
    }

}
