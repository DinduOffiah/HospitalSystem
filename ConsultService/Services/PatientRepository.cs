using ConsultService.Models;
using System.Collections.Concurrent;

namespace ConsultService.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ConcurrentDictionary<Guid, Patient> _patients = new();

        public Task AddPatientAsync(Patient patient)
        {
            _patients[patient.Id] = patient;
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            // In-memory storage, so no actual save is needed.
            // For a real database, this method would contain save logic.
            return Task.CompletedTask;
        }
    }
}
