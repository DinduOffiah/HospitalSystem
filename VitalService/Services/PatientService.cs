using AppDbContext.Data;
using ConsultService;
using Microsoft.EntityFrameworkCore;
using RegisterService.Interface;
using VitalService.Models;
using VitalService.Services;

namespace RegisterService.Services
{
    public class PatientService : IPatientService
    {
        private readonly VitalDbContext _context;
        private readonly PatientDataClient _patientDataClient;

        public PatientService(VitalDbContext context, PatientDataClient patientDataClient)
        {
            _context = context;
            _patientDataClient = patientDataClient;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientAsync(Guid id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var patientRequest = new PatientRequest
            {
                Id = patient.Id.ToString(),
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth.ToString("o") // Using round-trip date/time pattern for string representation
            };

            await _patientDataClient.AddPatientAsync(patientRequest);

            return patient;
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var patientRequest = new PatientRequest
            {
                Id = patient.Id.ToString(),
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth.ToString("o")
            };

            await _patientDataClient.AddPatientAsync(patientRequest);

            return patient;
        }

    }
}
