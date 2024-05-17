using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterService.DTOs;
using RegisterService.Interface;
using RegisterService.Models;
using Serilog;
using System.Text;
using System.Text.Json;

namespace RegisterService.Controllers
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

       [HttpPost("register")]
        public async Task<IActionResult> RegisterPatient([FromBody] PatientDTO patientDto)
        {
            var patient = new Patient
            {
                Name = patientDto.Name,
                DateOfBirth = patientDto.DateOfBirth
            };

            try
            {
                await _patientService.RegisterPatientAsync(patient);
                return Ok(patient);
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "An error occurred during patient registration");
                return StatusCode(500, "Internal server error");
            }
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
