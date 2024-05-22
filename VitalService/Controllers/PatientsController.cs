using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterService.Interface;
using VitalService.Models;

namespace VitalService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(IPatientService patientService, ILogger<PatientsController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var patient = await _patientService.GetPatientAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] Patient patient)
        {
            try
            {
                _logger.LogInformation("Updating patient {PatientId}", id);
                var result = await _patientService.UpdatePatientAsync(patient);
                _logger.LogInformation("Patient {PatientId} updated successfully", id);
                return Ok(result);
            }
            catch (RpcException ex)
            {
                _logger.LogError(ex, "RpcException occurred while updating patient {PatientId}. Status: {StatusCode}, Detail: {Detail}", id, ex.StatusCode, ex.Status.Detail);
                return StatusCode(500, "Internal server error while communicating with ConsultService.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating patient {PatientId}", id);
                return StatusCode(500, "An unexpected error occurred.");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            await _patientService.CreatePatientAsync(patient);
            return Ok("Patient added successfully");
        }

    }

}
