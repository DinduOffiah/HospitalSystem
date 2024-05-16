using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterService.Interface;
using RegisterService.Models;

namespace VitalService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
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
            if (id != patient.Id)
            {
                return BadRequest();
            }

            var updatedPatient = await _patientService.UpdatePatientAsync(patient);

            return Ok(updatedPatient);
        }
    }

}
