using Grpc.Core;

namespace ConsultService.Protos
{
    public class PatientService : Patient.PatientBase
    {
        public override Task<PatientResponse> UpdatePatient(PatientRequest request, ServerCallContext context)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Task.FromResult(new PatientResponse
            {
                Message = "Patient updated successfully"
            });
        }
    }

}
