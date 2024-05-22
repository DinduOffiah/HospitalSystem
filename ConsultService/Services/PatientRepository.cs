using ConsultService.Data;
using ConsultService.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ConsultService.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ConsultDBContext _context;
        private readonly ILogger<PatientRepository> _logger;

        public PatientRepository(ConsultDBContext context, ILogger<PatientRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            _logger.LogInformation("Adding patient {PatientId} to the database", patient.Id);
            try
            {
                await _context.Patients.AddAsync(patient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding patient {PatientId} to the database.", patient.Id);
                throw;
            }
        }

        public async Task SaveChangesAsync()
        {
            _logger.LogInformation("Saving changes to the database");
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving changes to the database.");
                throw;
            }
        }
    }
}
