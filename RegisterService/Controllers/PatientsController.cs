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

            // Create a new HttpClient
            using (var client  = new HttpClient())
            {
                // Set the URL of the VitalService
                client.BaseAddress = new Uri("http://localhost:5196");

                // Serialize the registered patient to JSON
                var json = JsonSerializer.Serialize(registeredPatient);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                // Make a POST request to the VitalService
                var response = await client.PostAsync("/Patients", data);

                // Check if the request was successful
                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode);
                }
            }


            // Return a 201 Created status code and the registered patient
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
