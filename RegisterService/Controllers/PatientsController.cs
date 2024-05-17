using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterService.Interface;
using RegisterService.Models;
using System.Text;
using System.Text.Json;

namespace RegisterService.Controllers
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

        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();

            if(patients != null)
            {
                return Ok(patients);
            }
            else
            {
                return NotFound("No patient found.");
            }

           
        }

        [HttpPost("RegisterPatient")]
        public async Task<IActionResult> RegisterPatient([FromBody] Patient patient)
        {
            var registeredPatient = await _patientService.RegisterPatientAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = registeredPatient.Id }, registeredPatient);
        }


        [HttpGet("GetPatient/{id}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var patient = await _patientService.GetPatientAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
    }

}
